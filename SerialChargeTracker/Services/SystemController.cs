using System;
using System.Collections.Generic;

namespace SerialChargeTracker
{
    public class SystemController
    {
        private readonly VirtualBatteryMonitor _virtualMonitor;
        private readonly BatterySerialMonitor _realMonitor;
        private readonly FileRepository _fileRepo;

        public event Action<BatteryData> NewDataReady;

        public SystemController(string logPath)
        {
            _fileRepo = new FileRepository(logPath);

            // Инициализируем оба, но использовать будем один
            _virtualMonitor = new VirtualBatteryMonitor();
            _realMonitor = new BatterySerialMonitor();

            // Подписываем обоих на один и тот же общий обработчик
            _virtualMonitor.RawLineReceived += HandleIncomingRawLine;
            _realMonitor.RawLineReceived += HandleIncomingRawLine;
        }

        // ОБЩИЙ ОБРАБОТЧИК (для файла, парсинга и UI)
        private void HandleIncomingRawLine(string rawLine)
        {
            // 1. Сохраняем в файл (с датой внутри AppendRaw)
            _fileRepo.AppendRaw(rawLine);

            // 2. Парсим для UI
            var data = BatteryParser.Parse(rawLine);
            if (data != null)
            {
                NewDataReady?.Invoke(data);
            }
        }

        // Запуск эмулятора (для тестов)
        public void Start() => _virtualMonitor.Start();

        // Запуск реального порта (для работы)
        public void Start(string portName) => _realMonitor.Start(portName);

        // Останавливаем обоих на всякий случай
        public void Stop()
        {
            _virtualMonitor.Stop();
            _realMonitor.Stop();
        }

        public void ProcessManualInput(string rawLine) => HandleIncomingRawLine(rawLine);

        public List<BatteryData> GetHistory() => _fileRepo.ReadAll();
    }
}
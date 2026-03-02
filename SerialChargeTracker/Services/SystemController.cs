using SerialChargeTracker.DataRepositories;
using SerialChargeTracker.Hardware;
using SerialChargeTracker.Models;
using System;
using System.Collections.Generic;

namespace SerialChargeTracker.Services
{
    public class SystemController
    {
        private readonly IBatteryMonitor _monitor; // Работаем только через интерфейс
        private readonly FileRepository _fileRepo;

        public event Action<BatteryData> NewDataReady;
        public event Action<string> ErrorMessage;

        // Теперь мы передаем монитор ИЗВНЕ (внедрение зависимости)
        public SystemController(IBatteryMonitor monitor, string logPath)
        {
            _fileRepo = new FileRepository(logPath);
            _monitor = monitor ?? throw new ArgumentNullException(nameof(monitor));

            // Подписываемся на события монитора (неважно, реальный он или нет)
            _monitor.RawLineReceived += HandleIncomingRawLine;
            _monitor.ErrorOccurred += (msg) => ErrorMessage?.Invoke(msg);
        }

        private void HandleIncomingRawLine(string rawLine)
        {
            var dateTime = DateTime.Now;
            // 1. Сохраняем "сырец" в файл
            _fileRepo.AppendRaw(rawLine, dateTime);

            // 2. Парсим для работы
            var data = BatteryParser.Parse(rawLine, dateTime);
            if (data != null)
            {
                NewDataReady?.Invoke(data);
            }
        }

        // Универсальные методы управления
        public void Start() => _monitor.Start();
        public void Stop() => _monitor.Stop();

        public void ProcessManualInput(string rawLine) => HandleIncomingRawLine(rawLine);
        public List<BatteryData> GetHistory() => _fileRepo.ReadAll();
    }
}
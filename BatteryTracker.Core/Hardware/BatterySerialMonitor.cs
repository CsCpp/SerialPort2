using System;
using System.IO.Ports;

namespace BatteryTracker.Core.Hardware
{
    public class BatterySerialMonitor : IBatteryMonitor
    {
        private SerialPort _serialPort;
        private readonly string _portName;
        private readonly int _baudRate;

        public event Action<string> RawLineReceived;
        public event Action<string> ErrorOccurred;

        // Передаем настройки порта при создании объекта
        public BatterySerialMonitor(string portName, int baudRate = 9600)
        {
            _portName = portName;
            _baudRate = baudRate;
        }

        // Теперь свойство IsRunning реализовано
        public bool IsRunning => _serialPort?.IsOpen ?? false;

        // Реализация метода Start БЕЗ параметров (согласно интерфейсу)
        public void Start()
        {
            if (IsRunning) return;

            _serialPort = new SerialPort(_portName, _baudRate);
            _serialPort.ReadTimeout = 2000;

            _serialPort.DataReceived += (s, e) =>
            {
                try
                {
                    string line = _serialPort.ReadLine();
                    RawLineReceived?.Invoke(line);
                }
                catch (TimeoutException)
                {
                    ErrorOccurred?.Invoke("Таймаут: данные не полные или МК молчит.");
                }
                catch (Exception ex)
                {
                    ErrorOccurred?.Invoke($"Ошибка порта: {ex.Message}");
                }
            };

            try
            {
                _serialPort.Open();
            }
            catch (Exception ex)
            {
                ErrorOccurred?.Invoke($"Не удалось открыть {_portName}: {ex.Message}");
            }
        }

        public void Stop()
        {
            if (_serialPort != null)
            {
                if (_serialPort.IsOpen) _serialPort.Close();
                _serialPort.Dispose();
                _serialPort = null;
            }
        }

        public void Dispose() => Stop();
    }
}
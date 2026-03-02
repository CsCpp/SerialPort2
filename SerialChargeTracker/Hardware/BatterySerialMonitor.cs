using System;
using System.IO.Ports;

namespace SerialChargeTracker
{
    public class BatterySerialMonitor : IDisposable
    {
        private SerialPort _serialPort;
        public event Action<string> RawLineReceived;
        public event Action<string> ErrorOccurred;

        public void Start(string portName, int baudRate = 9600)
        {
            if (_serialPort?.IsOpen == true) return;

            _serialPort = new SerialPort(portName, baudRate);

            // ЗАЩИТА: Если в течение 2 секунд (2000 мс) символ \n не получен,
            // метод ReadLine() прервется и выдаст ошибку, вместо бесконечного ожидания.
            _serialPort.ReadTimeout = 2000;

            _serialPort.DataReceived += (s, e) =>
            {
                try
                {
                    // Пытаемся прочитать строку до \n
                    string line = _serialPort.ReadLine();
                    RawLineReceived?.Invoke(line);
                }
                catch (TimeoutException)
                {
                    // МК не прислал конец строки вовремя
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
                ErrorOccurred?.Invoke($"Не удалось открыть {portName}: {ex.Message}");
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


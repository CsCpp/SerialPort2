using System;
using System.Threading;
using System.Threading.Tasks;

namespace SerialChargeTracker.Hardware
{
    public class VirtualBatteryMonitor : IBatteryMonitor
    {
        private CancellationTokenSource _cts;
        private readonly Random _rnd = new Random();

        public event Action<string> RawLineReceived;
        // Добавлено событие из интерфейса (даже если оно не используется активно в эмуляторе)
        public event Action<string> ErrorOccurred;

        // Реализация свойства из интерфейса
        public bool IsRunning => _cts != null && !_cts.IsCancellationRequested;

        // ВАЖНО: Убираем параметры, чтобы соответствовать IBatteryMonitor.Start()
        public void Start()
        {
            if (IsRunning) return;

            _cts = new CancellationTokenSource();
            Task.Run(() => SimulationLoop(_cts.Token));
            Console.WriteLine("Виртуальный порт запущен...");
        }

        private async Task SimulationLoop(CancellationToken token)
        {
            try
            {
                while (!token.IsCancellationRequested)
                {
                    // Генерируем строку
                    string rawLine = "$12.5,1.0,25.0";

                    if (RawLineReceived != null)
                    {
                        RawLineReceived.Invoke(rawLine);
                    }
                    else
                    {
                        Console.WriteLine("[VM] Ошибка: На RawLineReceived никто не подписан!");
                    }

                    await Task.Delay(1000, token);
                }
            }
            catch (OperationCanceledException) { /* Нормальное завершение */ }
            catch (Exception ex)
            {
                ErrorOccurred?.Invoke($"[VM] КРИТИЧЕСКАЯ ОШИБКА: {ex.Message}");
            }
        }

        public void Stop()
        {
            _cts?.Cancel();
            _cts?.Dispose();
            _cts = null;
        }

        public void Dispose() => Stop();
    }
}
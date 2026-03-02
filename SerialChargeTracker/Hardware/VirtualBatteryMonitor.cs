using System;
using System.Threading;
using System.Threading.Tasks;

namespace SerialChargeTracker
{
    // Реализуем тот же интерфейс/события, что и у реального порта
    public class VirtualBatteryMonitor : IDisposable
    {
        private CancellationTokenSource _cts;
        private readonly Random _rnd = new Random();

        // Событие, которое ожидает наш SystemController
        public event Action<string> RawLineReceived;

        public void Start(string portName = "VIRTUAL", int baudRate = 9600)
        {
            Stop(); // На всякий случай останавливаем старый поток
            _cts = new CancellationTokenSource();

            // Запускаем бесконечный цикл в фоновом потоке
            Task.Run(() => SimulationLoop(_cts.Token));
            Console.WriteLine("Виртуальный порт запущен...");
        }

        private async Task SimulationLoop(CancellationToken token)
        {
            try
            {
                while (!token.IsCancellationRequested)
                {
                    // Генерируем строку (используем точки для InvariantCulture)
                    string rawLine = "$12.5,1.0,25.0";

                    // ВАЖНО: Проверяем, есть ли подписчики
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
            catch (Exception ex)
            {
                // Это сообщение вы увидите в Output теста, если всё упадет
                Console.WriteLine($"[VM] КРИТИЧЕСКАЯ ОШИБКА В ПОТОКЕ: {ex.Message}");
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
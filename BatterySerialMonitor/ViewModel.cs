using BatteryTracker.Core.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO.Ports;
using System.Runtime.CompilerServices;
using System.Windows.Threading; // Для таймера эмуляции

namespace BatterySerialMonitor
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly DispatcherTimer _simulationTimer;
        private readonly Random _rnd = new();

        public ObservableCollection<string> AvailablePorts { get; } = new(SerialPort.GetPortNames());
        public int[] AvailableBaudRates { get; } = { 9600, 19200, 38400, 57600, 115200 };

        // Свойства для привязки
        private bool _isSimulationEnabled;
        public bool IsSimulationEnabled
        {
            get => _isSimulationEnabled;
            set
            {
                _isSimulationEnabled = value;
                if (value) _simulationTimer.Start(); else _simulationTimer.Stop();
                OnPropertyChanged();
            }
        }

        private string _logText = "";
        public string LogText { get => _logText; set { _logText = value; OnPropertyChanged(); } }

        public MainViewModel()
        {
            _simulationTimer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            _simulationTimer.Tick += OnSimulationTick;
        }

        private void OnSimulationTick(object? sender, EventArgs e)
        {
            // 1. Генерируем "сырую" строку как от порта
            double u = 12.0 + _rnd.NextDouble() * 2;
            double i = 0.5 + _rnd.NextDouble();
            double t = 25.0 + _rnd.NextDouble() * 5;
            string rawData = $"${u:F2},{i:F2},{t:F2}";

            // 2. Используем ВАШ BatteryParser
            var batteryData = BatteryParser.Parse(rawData);

            if (batteryData != null)
            {
                // 3. Выводим результат в лог
                LogText += $"[Эмуляция] Вход: {rawData} -> Парсинг: U={batteryData.U}V, I={batteryData.I}A\n";
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
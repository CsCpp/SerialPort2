using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO.Ports;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows.Media;

namespace BatterySerialMonitor
{
    public class MainViewModel : INotifyPropertyChanged
    {
        // Списки для выбора
        public ObservableCollection<string> AvailablePorts { get; } = new(SerialPort.GetPortNames());
        public int[] AvailableBaudRates { get; } = { 9600, 19200, 38400, 57600, 115200 };

        // Выбранные значения
        private string? _selectedPort;
        public string? SelectedPort { get => _selectedPort; set { _selectedPort = value; OnPropertyChanged(); } }

        private int _selectedBaud = 9600;
        public int SelectedBaud { get => _selectedBaud; set { _selectedBaud = value; OnPropertyChanged(); } }

        // Состояние интерфейса
        private string _logText = "Система готова к запуску...\n";
        public string LogText { get => _logText; set { _logText = value; OnPropertyChanged(); } }

        private Brush _statusColor = Brushes.Gray;
        public Brush StatusColor { get => _statusColor; set { _statusColor = value; OnPropertyChanged(); } }

        private string _statusMessage = "Ожидание...";
        public string StatusMessage { get => _statusMessage; set { _statusMessage = value; OnPropertyChanged(); } }

        // Команда для кнопки
        public ICommand ConnectCommand { get; }

        public MainViewModel()
        {
            ConnectCommand = new RelayCommand(Connect);
        }

        private void Connect()
        {
            if (string.IsNullOrEmpty(SelectedPort)) return;

            LogText += $"[{DateTime.Now:HH:mm:ss}] Подключение к {SelectedPort}...\n";
            StatusMessage = $"Активен: {SelectedPort}";
            StatusColor = Brushes.LimeGreen;

            // Здесь будет вызов вашего BatteryParser.Parse() при получении данных
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    // Простая реализация команды
    public class RelayCommand(Action execute) : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        public bool CanExecute(object? parameter) => true;
        public void Execute(object? parameter) => execute();
    }
}
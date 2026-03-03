using System.Collections.ObjectModel;
using System.IO.Ports;
using BatteryTracker.Core.Models;

namespace BatterySerialMonitor.ViewModels
{
    public class ConnectionViewModel : ViewModelBase
    {
        // Сущность из твоей библиотеки Core
        public SerialSettings Settings { get; } = new SerialSettings();

        public ObservableCollection<string> AvailablePorts { get; } = new();
        public ObservableCollection<int> BaudRates { get; } = new() { 9600, 19200, 38400, 57600, 115200 };

        public ConnectionViewModel()
        {
            RefreshPorts();
        }

        public string SelectedPort
        {
            get => Settings.PortName;
            set { Settings.PortName = value; OnPropertyChanged(); }
        }

        public int SelectedBaudRate
        {
            get => Settings.BaudRate;
            set { Settings.BaudRate = value; OnPropertyChanged(); }
        }

        public void RefreshPorts()
        {
            AvailablePorts.Clear();
            foreach (var port in SerialPort.GetPortNames()) AvailablePorts.Add(port);
        }
    }
}

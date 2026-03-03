using System.Windows;
using BatteryTracker.Core.Hardware;
using BatteryTracker.Core.Models;
using BatteryTracker.Core.Services;
using BatteryTracker.App.ViewModels;

namespace BatteryTracker.App.Views
{
    public partial class MainWindow : Window
    {
        private SystemController _controller;

        public MainWindow()
        {
            InitializeComponent();
            OpenSettingsAndStart();
        }

        // Не забываем остановить монитор при закрытии окна
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            _controller?.Stop();
            base.OnClosing(e);
        }
        private void OpenSettingsAndStart()
        {
            var connVm = new ConnectionViewModel();
            var connWin = new ConnectionWindow { DataContext = connVm };

            if (connWin.ShowDialog() == true)
            {
                var settings = connVm.GetSettings();
                IBatteryMonitor monitor;

                if (settings.PortName == "VIRTUAL")
                {
                    monitor = new VirtualBatteryMonitor();
                }
                else
                {
                    monitor = new BatteryTracker.Core.Hardware.BatterySerialMonitor(settings);
                }

                // Инициализируем контроллер с выбранным монитором
                _controller = new SystemController(monitor, "logs");
                this.DataContext = new MainViewModel(_controller);
                _controller.Start();
            }
        }
    }
}
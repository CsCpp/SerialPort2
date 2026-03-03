using System.Windows;
using BatteryTracker.Core.Hardware;
using BatteryTracker.Core.Models;
using BatteryTracker.Core.Services;
using BatterySerialMonitor.ViewModels;

namespace BatterySerialMonitor.Views
{
    public partial class MainWindow : Window
    {
        private SystemController _controller;

        public MainWindow()
        {
            System.Diagnostics.Debug.WriteLine("=== ОКНО ЗАПУСКАЕТСЯ ===");
            InitializeComponent();

            // 1. Настройка монитора (пока используем виртуалку для теста интерфейса)
            
            IBatteryMonitor monitor = new VirtualBatteryMonitor();

            // 2. Создаем контроллер (путь к логу можно вынести в настройки)
            _controller = new SystemController(monitor, "battery_data_log.txt");

            // 3. Создаем ViewModel
            var viewModel = new MainViewModel(_controller);

            // 4. Привязываем ViewModel к разметке XAML
            this.DataContext = viewModel;

            // 5. Запуск потока данных
            _controller.Start();

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
                _controller = new SystemController(monitor, "log.txt");
                this.DataContext = new MainViewModel(_controller);
                _controller.Start();
            }
        }
    }
}
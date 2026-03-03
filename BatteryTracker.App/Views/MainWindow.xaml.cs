using System;
using System.Windows;
using System.ComponentModel;
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

        /// <summary>
        /// Вызываем Dispose при закрытии окна. 
        /// Это принудительно сбросит остатки данных из буфера на диск.
        /// </summary>
        protected override void OnClosing(CancelEventArgs e)
        {
            // Метод Dispose внутри себя вызывает Stop() и делает финальный Flush
            _controller?.Dispose();
            base.OnClosing(e);
        }

        private void OpenSettingsAndStart()
        {
            var connVm = new ConnectionViewModel();
            var connWin = new ConnectionWindow { DataContext = connVm };

            // Если пользователь нажал "Connect" в окне настроек
            if (connWin.ShowDialog() == true)
            {
                var settings = connVm.GetSettings();
                IBatteryMonitor monitor;

                // Выбор типа монитора
                if (settings.PortName == "VIRTUAL")
                {
                    monitor = new VirtualBatteryMonitor();
                }
                else
                {
                    // Проверка на случай, если порт не выбран или пуст
                    if (string.IsNullOrEmpty(settings.PortName))
                    {
                        MessageBox.Show("Порт не выбран. Работа будет остановлена.");
                        return;
                    }
                    monitor = new BatteryTracker.Core.Hardware.BatterySerialMonitor(settings);
                }

                // Инициализируем контроллер. 
                // Папка будет иметь имя порта (например, COM3_LogData)
                _controller = new SystemController(monitor, settings.PortName + "_LogData");

                // Устанавливаем DataContext для связи с UI через MVVM
                this.DataContext = new MainViewModel(_controller);

                // Запуск процесса мониторинга
                _controller.Start();
            }
            else
            {
                // Если пользователь закрыл окно настроек без подключения - закрываем и приложение
                this.Close();
            }
        }
    }
}
using System;
using BatteryTracker.Core.Models;   // Данные (U, I, T)
using BatteryTracker.Core.Services; // Контроллер

namespace BatteryTracker.App.ViewModels
{
       public class MainViewModel : ViewModelBase
    {
        private readonly SystemController _controller;
        private BatteryData _currentData;
        private string _statusMessage = "Ожидание данных...";

        public MainViewModel(SystemController controller)
        {
            _controller = controller ?? throw new ArgumentNullException(nameof(controller));

            // Подписываемся на "живые" данные из контроллера
            _controller.NewDataReady += (data) =>
            {
                CurrentData = data;
                StatusMessage = $"Обновлено: {DateTime.Now:HH:mm:ss}";
            };

            // Подписываемся на ошибки (проброс из монитора)
            _controller.ErrorMessage += (err) => StatusMessage = $"Ошибка: {err}";
        }

        // Свойство для отображения данных в WPF
        public BatteryData CurrentData
        {
            get => _currentData;
            set
            {
                _currentData = value;
                OnPropertyChanged(); // Уведомляем UI
            }
        }

        // Свойство для статус-бара
        public string StatusMessage
        {
            get => _statusMessage;
            set { _statusMessage = value; OnPropertyChanged(); }
        }
    }
}
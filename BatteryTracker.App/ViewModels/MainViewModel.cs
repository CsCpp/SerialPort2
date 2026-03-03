using BatteryTracker.Core.Models;
using BatteryTracker.Core.Services;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using Microsoft.Win32;

namespace BatteryTracker.App.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly SystemController _controller;
        private BatteryData _currentData;
        private string _statusMessage = "Ожидание данных...";

        public ObservableCollection<ObservablePoint> VoltageValues { get; } = new();
        public ObservableCollection<ObservablePoint> CurrentValues { get; } = new();

        public ISeries[] VoltageSeries { get; set; }
        public ISeries[] CurrentSeries { get; set; }

        public Func<double, string> XFormatter => v =>
            v > 0 ? DateTime.FromOADate(v).ToString("HH:mm:ss") : "";

        public MainViewModel(SystemController controller)
        {
            _controller = controller ?? throw new ArgumentNullException(nameof(controller));

            // 1. Инициализация серий
            VoltageSeries = new ISeries[] {
                new LineSeries<ObservablePoint> {
                    Values = VoltageValues,
                    Name = "Напряжение (V)",
                    Stroke = new SolidColorPaint(SKColors.DodgerBlue, 2),
                    GeometrySize = 0,
                    Fill = null,
                    ScalesYAt = 0 // Левая ось
                }
            };

            CurrentSeries = new ISeries[] {
                new LineSeries<ObservablePoint> {
                    Values = CurrentValues,
                    Name = "Ток (A)",
                    Stroke = new SolidColorPaint(SKColors.OrangeRed, 2),
                    GeometrySize = 0,
                    Fill = null,
                    ScalesYAt = 1 // Правая ось
                }
            };

            // 2. Подписка на данные
            _controller.NewDataReady += (data) =>
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    CurrentData = data;
                    StatusMessage = $"Обновлено: {DateTime.Now:HH:mm:ss}";

                    var x = data.Timestamp.ToOADate();
                    VoltageValues.Add(new ObservablePoint(x, data.Voltage));
                    CurrentValues.Add(new ObservablePoint(x, data.Current));

                    if (VoltageValues.Count > 300)
                    {
                        VoltageValues.RemoveAt(0);
                        CurrentValues.RemoveAt(0);
                    }
                });
            };

            _controller.ErrorMessage += (err) => StatusMessage = $"Ошибка: {err}";
        }

        public void LoadLogFile()
        {
            var dialog = new OpenFileDialog
            {
                Filter = "Log files (*.txt)|*.txt|All files (*.*)|*.*",
                Title = "Открыть данные BatteryTracker"
            };

            if (dialog.ShowDialog() == true)
            {
                try
                {
                    var lines = File.ReadAllLines(dialog.FileName);

                    VoltageValues.Clear();
                    CurrentValues.Clear();

                    foreach (var line in lines)
                    {
                        var data = BatteryParser.Parse(line);
                        if (data != null)
                        {
                            var x = data.Timestamp.ToOADate();
                            VoltageValues.Add(new ObservablePoint(x, data.Voltage));
                            CurrentValues.Add(new ObservablePoint(x, data.Current));
                        }
                    }
                    StatusMessage = $"Файл загружен: {Path.GetFileName(dialog.FileName)} ({VoltageValues.Count} точек)";

                    // Важно: уведомляем график, что данные в сериях полностью обновились
                    OnPropertyChanged(nameof(CombinedSeries));
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при парсинге файла: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        // Конструктор для Дизайнера (предотвращает NullReference)
        public MainViewModel()
        {
            VoltageSeries = new ISeries[] { new LineSeries<ObservablePoint> { Values = new ObservableCollection<ObservablePoint>() } };
            CurrentSeries = new ISeries[] { new LineSeries<ObservablePoint> { Values = new ObservableCollection<ObservablePoint>() } };
        }

        public BatteryData CurrentData
        {
            get => _currentData;
            set { _currentData = value; OnPropertyChanged(); }
        }

        // Безопасное свойство для XAML
        public ISeries[] CombinedSeries
        {
            get
            {
                if (VoltageSeries == null || CurrentSeries == null) return Array.Empty<ISeries>();
                return new ISeries[] { VoltageSeries[0], CurrentSeries[0] };
            }
        }

        public string StatusMessage
        {
            get => _statusMessage;
            set { _statusMessage = value; OnPropertyChanged(); }
        }
    }
}
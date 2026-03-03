using System.Windows;
using System.Windows.Controls;

namespace BatterySerialMonitor
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // DataContext уже задан в XAML, здесь ничего добавлять не нужно
        }

        // Этот метод ОБЯЗАТЕЛЬНО должен быть здесь, чтобы XAML его видел
        private void LogControl_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Автоматическая прокрутка вниз при поступлении новых данных
            if (sender is TextBox textBox)
            {
                textBox.ScrollToEnd();
            }
        }
    }
}
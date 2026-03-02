using System;

namespace SerialChargeTracker.Models
{
    public class BatteryData
    {
        public DateTime Timestamp { get; private set; }
        public double Voltage { get; private set; }
        public double Current { get; private set; }
        public double Temperature { get; private set; }

        // для создания из БД\Файла время при ходит из вне
        public BatteryData(double voltage, double current, double temperature, DateTime timestamp)
        {
            Timestamp = timestamp;
            Voltage = voltage;
            Current = current;
            Temperature = temperature;
        }
        // Для создания в реальном времени из МК
        public BatteryData(double voltage, double current, double temperature) 
            : this(voltage, current, temperature, DateTime.Now) { }
        
    }
}

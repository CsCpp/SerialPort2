namespace BatteryTracker.Core.Models
{
    internal class SerialSettings
    {
        public string PortName { get; set; }
        public int BaudRate { get; set; } = 9600;
    }
}

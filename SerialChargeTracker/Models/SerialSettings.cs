using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialChargeTracker.Models
{
    internal class SerialSettings
    {
        public string PortName { get; set; }
        public int BaudRate { get; set; } = 9600;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialPortC
{
    public class DataForm5
    {
        private double buffDataI;
        private double buffDataU;
        private DateTime buffDataTime;

        public void AddDataBuff(double varI, double varU, DateTime varTime)
        {
            buffDataI = varI;
            buffDataU = varU;
            buffDataTime = varTime;
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialPortC
{
    public class BuffDataForm5
    {
       private List <DataForm5> buffData;
       private DataForm5 dataForm5;

        public void AddDataBuff(double varI, double varU, DateTime dateTime)
        {
            dataForm5 = new DataForm5();

            dataForm5.buffDataI = varI;
            dataForm5.buffDataU = varU;
            
            dataForm5.buffDateTime = dateTime;
          
            buffData.Add(dataForm5);
        }

        public void InDataForm5(Form5Grafika form5Grafika)
        {
           
            foreach (var item in buffData)
            {
                form5Grafika.dataIU(item.buffDataI, item.buffDataU, item.buffDateTime);
            }
         
        }


    }
}

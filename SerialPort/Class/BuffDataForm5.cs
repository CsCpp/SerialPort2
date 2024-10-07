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

        public void AddDataBuff(DataForm5 dataForm5)
        { 
        buffData.Add(dataForm5);
        }

        public DataForm5 InDataForm5()
        { 
        return buffData[0];
        }


    }
}

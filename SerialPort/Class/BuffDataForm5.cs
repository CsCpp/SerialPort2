using System;
using System.Collections.Generic;


namespace SerialPortC
{
    public class BuffDataForm5
    {
        private struct DataForm5
        {
            public double buffDataI { set; get; }
            public double buffDataU { set; get; }
            public DateTime buffDateTime { set; get; }
        }

        private Queue <DataForm5> buffData;
        private DataForm5 dataForm;

        public BuffDataForm5()
        {
         buffData = new Queue <DataForm5>();
        }

        public void Push(double varI, double varU, DateTime dateTime)
        {
            dataForm.buffDataI = varI;
            dataForm.buffDataU = varU;
            dataForm.buffDateTime = dateTime;

            buffData.Enqueue(dataForm);
        }

        public void CopyTo(Form5Grafika form5Grafika)
        {
            foreach (var item in buffData)
            {
             form5Grafika.Push(item.buffDataI, item.buffDataU, item.buffDateTime);
            }
        }

        public void Clear()
        {
            buffData.Clear();
        }

    }
}

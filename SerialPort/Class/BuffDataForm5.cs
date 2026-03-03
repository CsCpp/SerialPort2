using System;
using System.Collections.Generic;


namespace SerialPortC
{
    public class BuffDataForm5
    {
        private struct DataForm5
        {
            public double BuffDataI { set; get; }
            public double BuffDataU { set; get; }
            public DateTime BuffDateTime { set; get; }
        }

        private Queue <DataForm5> BuffDatas;
        private DataForm5 DataForm;

        public BuffDataForm5()
        {
         BuffDatas = new Queue <DataForm5>();
        }

        public void Push(double varI, double varU, DateTime dateTime)
        {
            DataForm.BuffDataI = varI;
            DataForm.BuffDataU = varU;
            DataForm.BuffDateTime = dateTime;

            BuffDatas.Enqueue(DataForm);
        }

        public void CopyTo(Form5Grafika form5Grafika)
        {
            foreach (var item in BuffDatas)
            {
             form5Grafika.Push(item.BuffDataI, item.BuffDataU, item.BuffDateTime);
            }
        }

        public void Clear()
        {
            BuffDatas.Clear();
        }

    }
}

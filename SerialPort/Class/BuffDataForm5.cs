using System;
using System.Collections.Generic;


namespace SerialPortC
{
    public class BuffDataForm5
    {
        private Stack <DataForm5> buffData;
        private DataForm5 dataForm;
     
        public BuffDataForm5()
        {
         buffData = new Stack <DataForm5>();
        }

        public void Push(double varI, double varU, DateTime dateTime)
        {
         dataForm = new DataForm5(varI, varU, dateTime);
         buffData.Push(dataForm);
        }

        public void Pop(Form5Grafika form5Grafika)
        {
            foreach (var item in buffData)
            {
            form5Grafika.dataIU(item.getDataI(), item.getDataI(), item.getDateTim());
            }
        }

        public struct DataForm5
        {
            private double buffDataI;
            private double buffDataU;
            private DateTime buffDateTime;
            //public double buffDataI
            //{
            //    get
            //    { return buffDataI; }
            //    set
            //    { buffDataI = value; }
            //}
            //public double buffDataU { get { return buffDataU; } set { buffDataU = value; } }
            //public DateTime buffDateTime { get { return buffDateTime; } set { buffDateTime = value; } }

            public DataForm5(double varI, double varU, DateTime dateTime)
            {
                buffDataI = varI;
                buffDataU = varU;
                buffDateTime = dateTime;
            }

            public double getDataI()
            {
                return buffDataI;
            }
            public double getDataU()
            {
                return buffDataU;
            }
            public DateTime getDateTim()
            {
                return buffDateTime;
            }
        }





    }
}

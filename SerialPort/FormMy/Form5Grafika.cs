using System;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SerialPortC
{
    public partial class Form5Grafika : Form
    {
        private readonly string _name;
        private DateTime dateTimeStart;

        private enum DiapTime
        {
            t1c,
            t10c,
            t30c,
            t1m,
            t5m,
            t10m,
            t30m,
            t1h,
            t2h,
            t5h,
            t12h
        }
        DiapTime diapTime = new DiapTime();

        public Form5Grafika(string str)
        {
            InitializeComponent();
          
            _name = "VoltAmpetr is " + str;
            {
                //chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Seconds;
                //chart1.ChartAreas[0].AxisX.Interval = 5;
            }
        }

        public void Push(double varI, double varU, DateTime dateTime)
        {
            label2I.Text = $@"I={varI.ToString("0.##")}A";
            label4U.Text = $@"U={varU.ToString("0.##")}V";
            var now = DateTime.Now;
            chart1.Series[0].Points.AddXY(dateTime, varI);
            chart1.Series[1].Points.AddXY(dateTime, varU);
            var axisX = chart1.ChartAreas[0].AxisX;
            var aoNowDate = now.ToOADate();
            if (aoNowDate >= axisX.Maximum)
            {
                SetInterval(aoNowDate);
            }
        }

        private void Form5Grafika_Load(object sender, EventArgs e)
        {
            Text = _name;
            chart1.ChartAreas[0].AxisY.Maximum = 20;
            chart1.ChartAreas[0].AxisY.Minimum = 0;

            chart1.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm:ss";
            chart1.Series[0].XValueType = ChartValueType.DateTime;
            chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Seconds;
            SetInterval(DateTime.Now.ToOADate());

            dateTimeStart = DateTime.Now;
            diapTime = DiapTime.t1c;
            label2.Text = diapTime.ToString();
        }

      

        private void Form5Grafika_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void SetInterval(double startDate)
        {
            var axisX = chart1.ChartAreas[0].AxisX;
            var timeOffset = GetInterval();
            var valMinTime = startDate - (double)timeOffset.Ticks / TimeSpan.TicksPerDay;
            // axisX.IntervalType = DateTimeIntervalType.Auto;
           // Math.Min(timeOffset.Minutes * 10, 1);
           // chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Seconds;
            //chart1.ChartAreas[0].AxisX.Interval = 5;
            axisX.Minimum = valMinTime;
            axisX.Maximum = startDate;
            DateTime date =DateTime.FromOADate(valMinTime);

            label3.Text = date.Year.ToString();
            label4.Text = date.Month + "/" + date.Day;
            return;

            TimeSpan GetInterval()
            {
                switch (diapTime)
                {
                    case DiapTime.t1c:
                        axisX.IntervalType = DateTimeIntervalType.Seconds;
                        axisX.Interval = 1;
                        return TimeSpan.FromSeconds(10);

                    case DiapTime.t10c:
                        axisX.IntervalType = DateTimeIntervalType.Seconds;
                        axisX.Interval = 10;
                        return TimeSpan.FromSeconds(100);
                     
                    case DiapTime.t30c:
                        axisX.IntervalType = DateTimeIntervalType.Seconds;
                        axisX.Interval = 30;
                        return TimeSpan.FromSeconds(300);
                     
                    case DiapTime.t1m:
                        axisX.IntervalType = DateTimeIntervalType.Minutes;
                        axisX.Interval = 1;
                        return TimeSpan.FromMinutes(10);

                    case DiapTime.t5m:
                       axisX.IntervalType = DateTimeIntervalType.Minutes;
                        axisX.Interval = 5;
                        return TimeSpan.FromMinutes(50);

                    case DiapTime.t10m:
                        axisX.IntervalType = DateTimeIntervalType.Minutes;
                        axisX.Interval = 10;
                        return TimeSpan.FromMinutes(100);

                    case DiapTime.t30m:
                        axisX.IntervalType = DateTimeIntervalType.Minutes;
                        axisX.Interval = 30;
                        return TimeSpan.FromMinutes(300);

                    case DiapTime.t1h:
                        axisX.IntervalType = DateTimeIntervalType.Hours;
                        axisX.Interval = 1;
                        return TimeSpan.FromMinutes(600);

                    case DiapTime.t2h:
                        axisX.IntervalType = DateTimeIntervalType.Hours;
                        axisX.Interval = 2;
                        return TimeSpan.FromMinutes(1200);

                    case DiapTime.t5h:
                        axisX.IntervalType = DateTimeIntervalType.Hours;
                        axisX.Interval = 5;
                        return TimeSpan.FromMinutes(3000);

                    case DiapTime.t12h:
                        axisX.IntervalType = DateTimeIntervalType.Hours;
                        axisX.Interval = 12;
                        return TimeSpan.FromMinutes(7200);

                    default:
                        throw new InvalidOperationException();
                }
            }
        }

       

        private void button_DownTime(object sender, EventArgs e)
        {
            dateButtonRegul(false);
        }
        private void button_UpTime(object sender, EventArgs e)
        {
            dateButtonRegul(true);
        }
        private void dateButtonRegul(bool znak)
        {
            var timeOffset = GetInterval();
            
           if (!znak)
            {
                dateTimeStart = dateTimeStart.AddSeconds(-(double)timeOffset.TotalSeconds);
            }
            else
            {
                dateTimeStart = dateTimeStart.AddSeconds((double)timeOffset.TotalSeconds);
            }

            SetInterval(dateTimeStart.ToOADate());

            TimeSpan GetInterval()
            {
                switch (diapTime)
                {
                    case DiapTime.t1c:
                        return TimeSpan.FromSeconds(1);

                    case DiapTime.t10c:
                        return TimeSpan.FromSeconds(10);

                    case DiapTime.t30c:
                        return TimeSpan.FromSeconds(30);

                    case DiapTime.t1m:
                        return TimeSpan.FromMinutes(1);

                    case DiapTime.t5m:
                        return TimeSpan.FromMinutes(5);

                    case DiapTime.t10m:
                        return TimeSpan.FromMinutes(10);

                    case DiapTime.t30m:
                        return TimeSpan.FromMinutes(30);

                    case DiapTime.t1h:
                        return TimeSpan.FromMinutes(60);

                    case DiapTime.t2h:
                        return TimeSpan.FromMinutes(120);

                    case DiapTime.t5h:
                        return TimeSpan.FromMinutes(300);

                    case DiapTime.t12h:
                        return TimeSpan.FromMinutes(720);

                    default:
                        throw new InvalidOperationException();
                }
            }
        }

        private void button_DiapTimeDown(object sender, EventArgs e)
        {
            if(diapTime>DiapTime.t1c)
            diapTime--;
            label2.Text= diapTime.ToString();
            SetInterval(DateTime.Now.ToOADate());
        }
        private void button_DiapTimeUp(object sender, EventArgs e)
        {
            if(diapTime<DiapTime.t12h)
            diapTime++;
            label2.Text = diapTime.ToString();
            SetInterval(DateTime.Now.ToOADate());
        }
    }
}

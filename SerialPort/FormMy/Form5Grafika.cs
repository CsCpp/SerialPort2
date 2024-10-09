using Mysqlx.Expr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SerialPortC
{
    public partial class Form5Grafika : Form
    {
        private readonly string _name;
         
        public Form5Grafika(string str)
        {
            InitializeComponent();
            label1.Text = @"Данные получены " + DateTime.Now.ToShortDateString() + " источник " + str;
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
                SetInterval(aoNowDate, comboBox1.SelectedIndex);
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
            comboBox1.SelectedIndex = 0;
            SetInterval(DateTime.Now.ToOADate(), comboBox1.SelectedIndex);


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            SetInterval(DateTime.Now.ToOADate(), comboBox1.SelectedIndex);
            //if (comboBox1.SelectedIndex == 0)
            //{
            //    valInterval = 10;
            //    valMinTime = DateTime.Now.AddSeconds(-10);

            //    chart1.ChartAreas[0].AxisX.Interval = 1;

            //}
            //else
            //if (comboBox1.SelectedIndex == 1)
            //{
            //    valInterval = 1;
            //    valMinTime = DateTime.Now.AddMinutes(-1);

            //    chart1.ChartAreas[0].AxisX.Interval = 10;

            //}
            //else
            //if (comboBox1.SelectedIndex == 2)
            //{
            //    valInterval = 10;
            //    valMinTime = DateTime.Now.AddMinutes(-10);

            //    chart1.ChartAreas[0].AxisX.Interval = 30;

            //}
            //else
            //if (comboBox1.SelectedIndex == 3)
            //{
            //    valInterval = 30;
            //    valMinTime = DateTime.Now.AddMinutes(-30);

            //    chart1.ChartAreas[0].AxisX.Interval = 10 * valInterval;

            //}
            //else
            //if (comboBox1.SelectedIndex == 4)
            //{
            //    valInterval = 60;
            //    valMinTime = DateTime.Now.AddMinutes(-60);

            //    chart1.ChartAreas[0].AxisX.Interval = 10 * valInterval;

            //}
            //else
            //if (comboBox1.SelectedIndex == 5)
            //{
            //    valInterval = 1440;
            //    valMinTime = DateTime.Now.AddMinutes(-1440);

            //    chart1.ChartAreas[0].AxisX.Interval = 10 * valInterval;

            //}
            //else { return; }

            //chart1.ChartAreas[0].AxisX.Minimum = valMinTime.ToOADate();
            //valMaxTime = DateTime.Now;
            //chart1.ChartAreas[0].AxisX.Maximum = valMaxTime.ToOADate();
        }

        private void Form5Grafika_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void SetInterval(double startDate, int index)
        {
            var timeOffset = GetInterval();
            var valMinTime = startDate - (double)timeOffset.Ticks / TimeSpan.TicksPerDay;
            var axisX = chart1.ChartAreas[0].AxisX;
            axisX.Interval = Math.Min(timeOffset.Minutes * 10, 1);
            axisX.Minimum = valMinTime;
            axisX.Maximum = startDate;
            return;

            TimeSpan GetInterval()
            {
                switch (index)
                {
                    case 0:
                        return TimeSpan.FromSeconds(10);

                    case 1:
                        return TimeSpan.FromMinutes(1);

                    case 2:
                        return TimeSpan.FromMinutes(10);

                    case 3:
                        return TimeSpan.FromMinutes(30);

                    case 4:
                        return TimeSpan.FromMinutes(60);

                    case 5:
                        return TimeSpan.FromMinutes(1440);
                    default:
                        throw new InvalidOperationException();
                }
            }
        }
    }
   
}

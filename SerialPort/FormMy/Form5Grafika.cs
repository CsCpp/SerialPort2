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
        private DateTime valMaxTime;
        private DateTime valMinTime;
        private DateTime startTime;
        private int valInterval;
        
        public Form5Grafika(string str)
        {
            InitializeComponent();
            label1.Text = "Данные получены "+DateTime.Now.ToShortDateString()+ " источник "  +str;
            this.Text = "VoltAmpetr is " + str;

            this.chart1.Series[0].Points.Clear();
            this.chart1.Series[1].Points.Clear();
            valInterval = 1;

            chart1.ChartAreas[0].AxisY.Maximum = 20;
            chart1.ChartAreas[0].AxisY.Minimum = 0;

            chart1.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm:ss";
            chart1.Series[0].XValueType = ChartValueType.DateTime;
            startTime = valMinTime = DateTime.Now;
            chart1.ChartAreas[0].AxisX.Minimum = valMinTime.ToOADate();
            valMaxTime = DateTime.Now.AddMinutes(valInterval);
            chart1.ChartAreas[0].AxisX.Maximum = valMaxTime.ToOADate();

            chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Seconds;
            chart1.ChartAreas[0].AxisX.Interval = 5;

        }

        public Form5Grafika(string str, Form5Grafika form1) 
        {
            InitializeComponent();
            label1.Text = "Данные получены " + DateTime.Now.ToShortDateString() + " источник " + str;
            this.Text = "VoltAmpetr is " + str;
            this.valInterval = form1.valInterval;

            this.chart1.ChartAreas[0].AxisY.Maximum = 20;
            this.chart1.ChartAreas[0].AxisY.Minimum = 0;

            this.chart1.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm:ss";
            this.chart1.Series[0].XValueType = ChartValueType.DateTime;
            startTime = valMinTime = form1.startTime;
            this.chart1.ChartAreas[0].AxisX.Minimum = valMinTime.ToOADate();
            valMaxTime = form1.valMaxTime;
            this.chart1.ChartAreas[0].AxisX.Maximum = valMaxTime.ToOADate();

            this.chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Seconds;
            this.chart1.ChartAreas[0].AxisX.Interval = 5;

            this.chart1.Series[0] = form1.chart1.Series[0];
            this.chart1.Series[1] = form1.chart1.Series[1];
        }

        public void dataIU(float varI, float varU)
        {
            label2I.Text ="I=" + varI.ToString("0.##") +"A";
            label4U.Text ="U=" + varU.ToString("0.##") +"V";
            chart1.Series[0].Points.AddXY(DateTime.Now, varI);
            chart1.Series[1].Points.AddXY(DateTime.Now, varU);
            if (DateTime.Now >= valMaxTime)
            {
                valMaxTime=valMaxTime.AddSeconds(1);
                valMinTime= valMinTime.AddSeconds(1);
                chart1.ChartAreas[0].AxisX.Minimum = valMinTime.ToOADate();
                chart1.ChartAreas[0].AxisX.Maximum = valMaxTime.ToOADate();
            }
        }

        private void Form5Grafika_Load(object sender, EventArgs e)
        {


          
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            valMinTime = startTime;
            chart1.ChartAreas[0].AxisX.Minimum = valMinTime.ToOADate();
          
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                valInterval = 10;
                valMinTime = DateTime.Now.AddSeconds(-10);

                chart1.ChartAreas[0].AxisX.Interval = 1;

            }
            else
            if (comboBox1.SelectedIndex == 1)
            {
                valInterval = 1;
                valMinTime = DateTime.Now.AddMinutes(-1);

                chart1.ChartAreas[0].AxisX.Interval = 10;

            }
            else
            if (comboBox1.SelectedIndex == 2)
            {
                valInterval = 10;
                valMinTime = DateTime.Now.AddMinutes(-10);

                chart1.ChartAreas[0].AxisX.Interval = 30;

            }
            else
            if (comboBox1.SelectedIndex == 3)
            {
                valInterval = 30;
                valMinTime = DateTime.Now.AddMinutes(-30);

                chart1.ChartAreas[0].AxisX.Interval = 10 * valInterval;

            }
            else
            if (comboBox1.SelectedIndex == 4)
            {
                valInterval = 60;
                valMinTime = DateTime.Now.AddMinutes(-60);

                chart1.ChartAreas[0].AxisX.Interval = 10 * valInterval;

            }
            else
            if (comboBox1.SelectedIndex == 5)
            {
                valInterval = 1440;
                valMinTime = DateTime.Now.AddMinutes(-1440);

                chart1.ChartAreas[0].AxisX.Interval = 10 * valInterval;

            }
            else { return; }

            chart1.ChartAreas[0].AxisX.Minimum = valMinTime.ToOADate();
            valMaxTime = DateTime.Now;
            chart1.ChartAreas[0].AxisX.Maximum = valMaxTime.ToOADate();
        }

        private void Form5Grafika_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
   
}

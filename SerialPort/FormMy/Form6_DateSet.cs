using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SerialPortC
{
    public partial class Form6_DateSet : Form
    {
        public Form2ComSendIn form2 = new Form2ComSendIn();

        DateTime dateStart;
        DateTime dateStop;

        public Form6_DateSet()
        {
            InitializeComponent();
        }
        public Form6_DateSet(Form2ComSendIn form)
        {
            form2 = form;
            InitializeComponent();
        }

        private void Form6_DateSet_Load(object sender, EventArgs e)
        {
            dateStart = DateTime.MinValue;
            dateStop = DateTime.MaxValue;
        }

        
        private async Task OpenVA()
        {
            dateStart = Convert.ToDateTime( dateTimePicker1.ToString());
            dateStop =  Convert.ToDateTime( dateTimePicker2.ToString());
            await  form2.openVAinDate(dateStart, dateStop);
        }

   

        private async void Form6_DateSet_FormClosed(object sender, FormClosedEventArgs e)
        {
           await OpenVA();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using static Mysqlx.Expect.Open.Types.Condition.Types;
using System.Runtime.InteropServices;



namespace SerialPortC
{
    public partial class Form2ComSendIn : Form
    {
        StreamWriter streamWriter;
        string pathFile = @"C:\1.txt";

        public Form5Grafika form5Grafika;
        public BuffDataForm5 buffDataForm5;
        public DataForm5 dataForm5;


        public Form1ComSet form1;
        public Form3MySqlDATA objForm3;

        public Form2ComSendIn()
        {
            InitializeComponent();
        }
        
        public Form2ComSendIn(Form1ComSet f)
        {
            InitializeComponent();
            form1 = f;
           
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            form1.Visible = false;
            saveMySQLToolStripMenuItem.Checked = false;
            this.Text = "Терминал "+ form1.ComPortName();

            buffDataForm5=new BuffDataForm5();
            DataForm5 dataForm5 = new DataForm5();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            form1.Visible = true;
            form1.ComPortClose();
        }
        
        public void FormUpdate(string str)
        {
            inDataForm5(str);
           
            tBoxDataIN.Text += str;
            onForm3();
            try
            {
                streamWriter = new StreamWriter(pathFile, true);
                streamWriter.WriteLine(str);
                streamWriter.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void comPortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (form1.Visible == true) { form1.Visible = false; }
            else { form1.Visible = true; }
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //----------------------ТЕКСТ БОКС------------------------

        private void btnClearData_Click(object sender, EventArgs e)
        {
            tBoxDataIN.Text = "";
            tBoxDataOut.Text = "";
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
           await sendData();
        }

        private async void tBoxDataOut_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
              await  sendData();
            }
        }

        private async Task sendData()
        {
           await form1.sendDataEnter(tBoxDataOut.Text);
            onForm3();
            tBoxDataOut.Text = "";
        }

        //----------------------Показать БАЗУ ДАННЫХ------------------------

        private void showDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            onForm3();
            objForm3.Show();
        }

       

       

       
        private void inDataForm5(string str)
        {
            float varI = sortData(str, "I=", 'A');
            float varU = sortData(str, "U=", 'V');


            //form5Grafika ??= new Form5Grafika(form1.ComPortName()); для 8 С#
            if (form5Grafika == null)
            {
                form5Grafika = new Form5Grafika(form1.ComPortName());
                form5Grafika.FormClosing += onForm5Closed;
            }
            form5Grafika.dataIU(varI, varU);
            
            dataForm5.AddDataBuff(varI, varU, DateTime.Now);
            buffDataForm5.AddDataBuff(dataForm5);
           


        }
        //-----------------------Сортировка----------------------------------
        private float sortData(string str, string inStr, char outStr)
        {
            int indexOfData = str.LastIndexOf(inStr) + 2;
            string strData = "";
            float floatData = 0;
            

            for (int i = indexOfData; i < str.Length; i++)
            {
                if (str[i] == outStr || str[i] < '0' || str[i] > '9')
                {
                    if (str[i] != ',' ) break;
                }
                strData += str[i];
            }
           
            try
            {
                floatData = Convert.ToSingle(strData);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return floatData;
         
        }
        
        private void onForm5Closed(object sender, FormClosingEventArgs e)
        {
                form5Grafika.FormClosing -= onForm5Closed;
                form5Grafika = null;
        }

        private void onForm3()
        {
            if (objForm3 == null)
            {
                objForm3 = new Form3MySqlDATA(form1.ComPortName());
                objForm3.FormClosing += onForm3Closed;
            }
           objForm3.RefreshAndShowDataOnDataGidView();
             
        }
        private void onForm3Closed(object sender, FormClosingEventArgs e)
        {
            objForm3.FormClosing -= onForm3Closed;
            objForm3 = null;
        }

        private void voltAmpetrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (form5Grafika == null)
            {
                form5Grafika = new Form5Grafika(form1.ComPortName());
                form5Grafika.FormClosing += onForm5Closed;
            }
            form5Grafika.Show();
        }

        //----------------------Вкл. обманку данных -------------------------
        private async void timer1_Tick(object sender, EventArgs e)
        {
            Random random = new Random();
              
                    try
                    {
                       await  form1.sendDataEnter(Convert.ToString($"I={(random.NextDouble()) * 20}A U={(random.NextDouble()) * 20}V \n"));
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
            

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //if (checkBox1.Checked)
            //    timer1.Enabled = true;
            //else
            //    timer1.Enabled = false;
            timer1.Enabled = checkBox1.Checked;
        }
    }
}

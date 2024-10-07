using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Data.Common;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SerialPortC
{
    public partial class Form1ComSet : Form
    {
       
        string dataIN;

        public  BDmySQL bdmySQL = new BDmySQL();

        public Form2ComSendIn newForm;
        public Form4MySQLSet mySqlSetting;

        public Form1ComSet()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            this.Location = new Point(this.Location.X - 318, this.Location.Y);

            string[] ports = SerialPort.GetPortNames();
            cBoxCOMPORT.Items.AddRange(ports);
            chBoxDtrEnable.Checked=false;
            serialPort.DtrEnable = false;
            chBoxRtsEnable.Checked=false;
            serialPort.RtsEnable = false;
         

            chBoxWriteLine.Checked = false;
           
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            ComPortOpen();
        }
        
        public void ComPortClose()
        {
            if (serialPort.IsOpen)
            {
                serialPort.Close();
             

                cBoxCOMPORT.Enabled = true;
                cBoxBAUDRATE.Enabled = true;
                cBoxDATABITS.Enabled = true;
                cBoxPARITYBITS.Enabled = true;
                cBoxSTOPBITS.Enabled = true;
           
                btnOpen.Enabled = true;
              


            }

        }
        //  ---------------------------------------------------
        //  ---------------------------------------------------
        //  ---------------------------------------------------
        //  ----------------------   Отправка данных -----------------------------
        public async Task sendDataEnter(string str)
        {
            if (serialPort.IsOpen)
            {
                if (newForm.saveMySQLToolStripMenuItem.Checked == true)
                {
                   bdmySQL.SaveDataToMySqlDataBase(str, true);
                }

                string str2 = "";
                if (chBoxWriteLine.Checked)
                {
                    str2 = serialPort.NewLine;
                }
                var buf = serialPort.Encoding.GetBytes(DateTime.Now + " : " + cBoxCOMPORT.Text + " -> " + str + str2);
                await serialPort.BaseStream.WriteAsync(buf, 0, buf.Length);
                await serialPort.BaseStream.FlushAsync();
            }
           
        }
        //  ---------------------------------------------------
        //  ---------------------------------------------------
        //  ---------------------------------------------------
        //  ----------------------   Получение данных -----------------------------

        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            dataIN = serialPort.ReadExisting();

            if (newForm.saveMySQLToolStripMenuItem.Checked == true)
            {
                bdmySQL.SaveDataToMySqlDataBase(dataIN, false);
            }

              this.Invoke(new EventHandler(ShowData));
        
        }

        //  ---------------------------------------------------
        private  void ShowData(object sender, EventArgs e)
         {
            int dataINLength = dataIN.Length;
            newForm.FormUpdate(dataIN.ToString());
         }

        private void cOMОткрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ComPortOpen();
        }
        
        private void ComPortOpen()
        {
            try
            {
                serialPort.PortName = cBoxCOMPORT.Text;
                serialPort.BaudRate = Convert.ToInt32(cBoxBAUDRATE.Text);
                serialPort.DataBits = Convert.ToInt32(cBoxDATABITS.Text);
                serialPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), cBoxSTOPBITS.Text);
                serialPort.Parity = (Parity)Enum.Parse(typeof(Parity), cBoxPARITYBITS.Text);

                serialPort.Open();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            {
                cBoxCOMPORT.Enabled = false;
                cBoxBAUDRATE.Enabled = false;
                cBoxDATABITS.Enabled = false;
                cBoxPARITYBITS.Enabled = false;
                cBoxSTOPBITS.Enabled = false;
                btnOpen.Enabled = false;
                chBoxWriteLine.Checked = true;
            }
             newForm = new Form2ComSendIn(this);
             newForm.Show();
           
        }

        private void cOMЗакрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ComPortClose();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void chBoxDtrEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (chBoxDtrEnable.Checked)
            {
                serialPort.DtrEnable = true;
                MessageBox.Show("DRT Enable", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                serialPort.DtrEnable = false;
            }
        }

        private void chBoxRtsEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (chBoxRtsEnable.Checked)
            {
                serialPort.RtsEnable = true;
                MessageBox.Show("RST Enable", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                serialPort.RtsEnable = false;
            }
        }

        private void mySQLSETToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(cBoxCOMPORT.Text!="")
            {
                if (mySqlSetting == null)
                {
                    mySqlSetting = new Form4MySQLSet();
                    mySqlSetting.FormClosing += onMySqlSettingClosed;
                }
                mySqlSetting.Show();
            }
            else
            {
                MessageBox.Show("Comport не выбран", "Ex", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void onMySqlSettingClosed(object sender, FormClosingEventArgs e)
        {
            mySqlSetting.FormClosing -= onMySqlSettingClosed;
            mySqlSetting = null;
        }


        //_________________________________ № Com PORTA ______________________________
        public string ComPortName()
        {
            return cBoxCOMPORT.Text;
        }

        private void cBoxCOMPORT_SelectedIndexChanged(object sender, EventArgs e)
        {
            BDmySQL.TableLH = cBoxCOMPORT.Text;
        }
    }
}

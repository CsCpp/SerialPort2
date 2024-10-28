using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Data;




namespace SerialPortC
{
    public partial class Form2ComSendIn : Form
    {
        private StreamWriter streamWriter;
        private readonly string pathFile = @"C:\1.txt";

        private readonly BDmySQL _bdmySql;
        DataSet myDataSet;

        public Form5Grafika form5Grafika;
        public BuffDataForm5 buffDataForm5;

        public Form6_DateSet form6_DateSet;
       
        public Form1ComSet form1;
        public Form3MySqlDATA objForm3;

        public Form2ComSendIn()
        {
            InitializeComponent();
        }

        public Form2ComSendIn(Form1ComSet f, BDmySQL bdmySql)
        {
            InitializeComponent();
            form1 = f;
            _bdmySql = bdmySql;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            form1.Visible = false;
            saveMySQLToolStripMenuItem.Checked = false;
            this.Text = "Терминал "+ form1.ComPortName();

            buffDataForm5=new BuffDataForm5();
          
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            form1.Visible = true;
            form1.ComPortClose();
        }
        
        public Task FormUpdate(string str)
        {
            inDataForm5(str, DateTime.Now, DateTime.MinValue, DateTime.MaxValue);
           
            tBoxDataIN.Text += str;
          //  onForm3();
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
             return  onForm3();
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
            await onForm3();
            tBoxDataOut.Text = "";
        }

        //----------------------Показать БАЗУ ДАННЫХ------------------------

        private async void showDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
          await onForm3();
          objForm3.Show();
        }

        private void inDataForm5(string str, DateTime _dateTime, DateTime dateStart,DateTime dateStop )
        {
            double varI = 0;
            double varU = 0;
            DateTime dateTime;

            dateTime = parserDate(str, _dateTime);

            varI = parserData(str, "I=", 'A');
            varU = parserData(str, "U=", 'V');

            //   parserDataRegex(str, ref varI, ref varU);

            if (dateTime >= dateStart && dateTime <= dateStop)
            {
                buffDataForm5.Push(varI, varU, dateTime);

                if (form5Grafika != null) form5Grafika.Push(varI, varU, dateTime);
            }

            
        }

        //----------------------- Парсинг 2 ----------------------------------
        private const string I = "I";
        private const string U = "V";

        //private readonly Regex Regex = new Regex($"I=(?<{I}>\\d+?)A U=(?<{U}>\\d+?)V*$");
        private static readonly Regex Regex = new Regex($"I=(?<{I}>\\d+(?:[\\.,]\\d+)?)A\\s*U=(?<{U}>\\d+(?:[\\.,]\\d+)?)V.*$", RegexOptions.Multiline);

        private void parserDataRegex(string str, ref double varI, ref double varU)
        {
            var match = Regex.Match(str);
            if (!match.Success)
            {
                MessageBox.Show($@"'{str}' isn't valid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                 varI = Convert.ToDouble(match.Groups[I].Value.Replace(',', '.'));
                 varU = Convert.ToDouble(match.Groups[U].Value.Replace(',', '.'));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //-----------------------Парсинг----------------------------------
        private double parserData(string str, string inStr, char outStr)
        {
            int indexOfData = str.LastIndexOf(inStr) + 2;
            string strData = "";
            double doubleData = 0;

            for (int i = indexOfData; i < str.Length; i++)
            {
                if (str[i] == outStr || str[i] < '0' || str[i] > '9')
                {
                    if (str[i] != ',' ) break;
                }
                strData += str[i];
            }
            if (strData != "")
            {
                try
                {
                    doubleData = Convert.ToDouble(strData);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return doubleData;
        }

        private DateTime parserDate(string str, DateTime _dateTime)
        {
            int indexOfData = str.LastIndexOf("DT*") + 3;
            string strData = "";
            DateTime dateTime= _dateTime;
           
            for (int i = indexOfData; i < str.Length; i++)
            {
                if (str[i] < '0' || str[i] > '9')
                {
                    if (str[i] != '.' && str[i] != ':' && str[i] != ' ') break;
                }
                strData += str[i];
            }
            if (strData != "")
            {
                try
                {
                    dateTime = Convert.ToDateTime(strData);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return dateTime;
        }

        private void onForm5Closed(object sender, FormClosingEventArgs e)
        {
                form5Grafika.FormClosing -= onForm5Closed;
                form5Grafika = null;
        }

        private async Task onForm3()
        {
            if (objForm3 == null)
            {
                objForm3 = new Form3MySqlDATA(form1.ComPortName(), _bdmySql);
                objForm3.FormClosing += onForm3Closed;
            }
           await objForm3.RefreshAndShowDataOnDataGidView();
        }

        private void onForm3Closed(object sender, FormClosingEventArgs e)
        {
            objForm3.FormClosing -= onForm3Closed;
            objForm3 = null;
        }
        // ------------------------ Показать ГРАФИК ---------------------------
        private void voltAmpetrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //form5Grafika ??= new Form5Grafika(form1.ComPortName()); для 8 С#
            if (form5Grafika == null)
            {
                form5Grafika = new Form5Grafika(form1.ComPortName());
                form5Grafika.FormClosing += onForm5Closed;
                buffDataForm5.CopyTo(form5Grafika);
            }
            form5Grafika.Show();
        }

        //----------------------Вкл. эмулятор данных -------------------------
        private async void timer1_Tick(object sender, EventArgs e)
        {
            Random random = new Random();
              
                    try
                    {
                       await  form1.sendDataEnter(Convert.ToString($"I={((random.NextDouble()) * 20).ToString("0.##") }A  U={((random.NextDouble()) * 20).ToString("0.##")}V \n"));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

        }

        private void checkBox_ZU_Run(object sender, EventArgs e)
        {
            timer1.Enabled = checkBox1.Checked;
        }

        private  void openInMySQLBDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form6_DateSet = new Form6_DateSet(this);
            form6_DateSet.Show();
            buffDataForm5.Clear();
        }

        public async Task openVAinDate(DateTime dateStart, DateTime dateStop)
        {

            myDataSet = new DataSet();
            myDataSet = await _bdmySql.ReadInDataSql();

            //  MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
            //  dataAdapter.Fill(myDataSet);
            foreach (DataTable dt in myDataSet.Tables)
            {
                foreach (DataRow row in dt.Rows)
                {
                    var cells = row.ItemArray;
                    foreach (var cell in cells)
                    {
                        inDataForm5(cell.ToString(), DateTime.Now, dateStart, dateStop);
                    }
                }
            }
            if (form5Grafika == null)
            {
                form5Grafika = new Form5Grafika(form1.ComPortName());
                form5Grafika.FormClosing += onForm5Closed;
                buffDataForm5.CopyTo(form5Grafika);
            }
            form5Grafika.Show();
        }
    }
}

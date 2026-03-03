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
        private StreamWriter StreamWriter;
        private readonly string PathFile = @"C:\1.txt";


        DataSet MyDataSet;
        private readonly BDmySQL MyBDmySQL;
        public Form5Grafika Form5MyGrafika;
        public BuffDataForm5 BuffMyDataForm5;
        public Form6_DateSet Form6MyDateSet;

        public Form1ComSet Form1MyComSet;
        public Form3MySqlDATA Form3MySqlDATA;

        public Form2ComSendIn()
        {
            InitializeComponent();
        }

        public Form2ComSendIn(Form1ComSet form1ComSet, BDmySQL bdmySql)
        {
            InitializeComponent();
            Form1MyComSet = form1ComSet;
            MyBDmySQL = bdmySql;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Form1MyComSet.Visible = false;
            saveMySQLToolStripMenuItem.Checked = false;
            this.Text = "Терминал " + Form1MyComSet.ComPortName();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1MyComSet.Visible = true;
            Form1MyComSet.ComPortClose();
        }

        public Task FormUpdate(string str)
        {
            inDataForm5(str, DateTime.Now, DateTime.MinValue, DateTime.MaxValue);

            tBoxDataIN.Text += str;
            //  onForm3();
            try
            {
                StreamWriter = new StreamWriter(PathFile, true);
                StreamWriter.WriteLine(str);
                StreamWriter.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return onForm3();
        }

        private void comPortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Form1MyComSet.Visible == true) { Form1MyComSet.Visible = false; }
            else { Form1MyComSet.Visible = true; }
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
                await sendData();
            }
        }

        private async Task sendData()
        {
            await Form1MyComSet.sendDataEnter(tBoxDataOut.Text);
            await onForm3();
            tBoxDataOut.Text = "";
        }

        //----------------------Показать БАЗУ ДАННЫХ------------------------

        private async void showDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await onForm3();
            Form3MySqlDATA.Show();
        }

        private void inDataForm5(string str, DateTime _dateTime, DateTime dateStart, DateTime dateStop)
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
                BuffMyDataForm5.Push(varI, varU, dateTime);

                if (Form5MyGrafika != null) Form5MyGrafika.Push(varI, varU, dateTime);
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
                    if (str[i] != ',') break;
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
            DateTime dateTime = _dateTime;

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
            Form5MyGrafika.FormClosing -= onForm5Closed;
            Form5MyGrafika = null;
        }

        private async Task onForm3()
        {
            if (Form3MySqlDATA == null)
            {
                Form3MySqlDATA = new Form3MySqlDATA(Form1MyComSet.ComPortName(), MyBDmySQL);
                Form3MySqlDATA.FormClosing += onForm3Closed;
            }
            await Form3MySqlDATA.RefreshAndShowDataOnDataGidView();
        }

        private void onForm3Closed(object sender, FormClosingEventArgs e)
        {
            Form3MySqlDATA.FormClosing -= onForm3Closed;
            Form3MySqlDATA = null;
        }
        // ------------------------ Показать ГРАФИК ---------------------------
        private void voltAmpetrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //form5Grafika ??= new Form5Grafika(form1.ComPortName()); для 8 С#
            if (Form5MyGrafika == null)
            {
                Form5MyGrafika = new Form5Grafika(Form1MyComSet.ComPortName());
                Form5MyGrafika.FormClosing += onForm5Closed;
                BuffMyDataForm5.CopyTo(Form5MyGrafika);
            }
            Form5MyGrafika.Show();
        }

        /// <summary>
        /// Вкл. эмулятор данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void timer1_Tick(object sender, EventArgs e)
        {
            Random random = new Random();

            try
            {
                await Form1MyComSet.sendDataEnter(Convert.ToString($"I={((random.NextDouble()) * 20).ToString("0.##")}A  U={((random.NextDouble()) * 20).ToString("0.##")}V \n"));
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

        private void openInMySQLBDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6MyDateSet = new Form6_DateSet(this);
            Form6MyDateSet.Show();
            BuffMyDataForm5.Clear();
        }

        public async Task openVAinDate(DateTime dateStart, DateTime dateStop)
        {

            MyDataSet = new DataSet();
            MyDataSet = await MyBDmySQL.ReadInDataSql();

            //  MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
            //  dataAdapter.Fill(myDataSet);
            foreach (DataTable dt in MyDataSet.Tables)
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
            if (Form5MyGrafika == null)
            {
                Form5MyGrafika = new Form5Grafika(Form1MyComSet.ComPortName());
                Form5MyGrafika.FormClosing += onForm5Closed;
                BuffMyDataForm5.CopyTo(Form5MyGrafika);
            }
            Form5MyGrafika.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace SerialPortC
{
    public partial class Form3MySqlDATA : Form
    {
        private readonly BDmySQL _bdmySql;
        DataSet myDataSet;


        public async Task RefreshAndShowDataOnDataGidView()
        {
            myDataSet = new DataSet();
            myDataSet = await _bdmySql.ReadDataToMySqlDataBase();
            
            dataGridView1.DataSource = myDataSet;
            dataGridView1.DataMember = "Serial Data";
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
           dataGridView1.Refresh();
        }

        public Form3MySqlDATA(string  str, BDmySQL bdmySQL)
        {
            InitializeComponent();
            this.Text += " " + str;
            _bdmySql = bdmySQL;
        }

        private async void Form3_Load(object sender, EventArgs e)
        {
            this.Location = new Point(this.Location.X + 362, this.Location.Y);

           await RefreshAndShowDataOnDataGidView();
        }
  
    }
}

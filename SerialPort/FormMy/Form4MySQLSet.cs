using System;
using System.Windows.Forms;



namespace SerialPortC
{
    public partial class Form4MySQLSet : Form
    {
        public Form4MySQLSet()
        {
            InitializeComponent();
        }

        private void MySQLSet_Load(object sender, EventArgs e)
        {

            textBox1.Text = BDmySQL.ServerLH;
            textBox2.Text = BDmySQL.UsernameLH;
            textBox3.Text = BDmySQL.PasswordLH;
            textBox4.Text = Convert.ToString(BDmySQL.PortLH);
            textBox5.Text = BDmySQL.DatabaseLH;
            textBox6.Text = BDmySQL.TableLH;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BDmySQL.ServerLH = textBox1.Text;
            BDmySQL.UsernameLH = textBox2.Text;
            BDmySQL.PasswordLH = textBox3.Text;
            BDmySQL.PortLH = Convert.ToInt16(textBox4.Text);
            BDmySQL.DatabaseLH = textBox5.Text;
            BDmySQL.TableLH = textBox6.Text;

            BDmySQL bDmySQL = new BDmySQL();
            bDmySQL.TestDataToMySqlDataBase();

          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BDmySQL bDmySQL = new BDmySQL();
            bDmySQL.CreateTableMysql();
        }
    }
      
}

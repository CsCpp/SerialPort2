using System;
using System.Windows.Forms;

namespace SerialPortC
{
    public partial class Form4MySQLSet : Form
    {

        public BDmySQL UserBDmySQL;
        public Form4MySQLSet(BDmySQL bDmySQL)
        {
            InitializeComponent();
            UserBDmySQL = bDmySQL;
        }

        private void MySQLSet_Load(object sender, EventArgs e)
        {
            textBox1.Text = UserBDmySQL.ServerLH;
            textBox2.Text = UserBDmySQL.UsernameLH;
            textBox3.Text = UserBDmySQL.PasswordLH;
            textBox4.Text = UserBDmySQL.PortLH.ToString();
            textBox5.Text = UserBDmySQL.DatabaseLH;
            textBox6.Text = UserBDmySQL.TableLH;
        }

        private async void Create_Click(object sender, EventArgs e)
        {
            UserBDmySQL.ServerLH = textBox1.Text;
            UserBDmySQL.UsernameLH = textBox2.Text;
            UserBDmySQL.PasswordLH = textBox3.Text;
            UserBDmySQL.PortLH = Convert.ToInt32(textBox4.Text);
            UserBDmySQL.DatabaseLH = textBox5.Text;
            UserBDmySQL.TableLH = textBox6.Text;

            await UserBDmySQL.CreateTableMysql();
        }
    }

}

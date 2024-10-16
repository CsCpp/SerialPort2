using System;
using System.Windows.Forms;

namespace SerialPortC
{
    public partial class Form4MySQLSet : Form
    {
        private UserRegData _userRegData;
        private BDmySQL _bDmySQL;
        public Form4MySQLSet(UserRegData usRegData, BDmySQL bDmySQL)
        {
            InitializeComponent();
            _userRegData = usRegData;
            _bDmySQL = bDmySQL;
        }

        private void MySQLSet_Load(object sender, EventArgs e)
        {
            textBox1.Text = _userRegData.ServerLH;
            textBox2.Text = _userRegData.UsernameLH;
            textBox3.Text = _userRegData.PasswordLH;
            textBox4.Text = _userRegData.PortLH.ToString();
            textBox5.Text = _userRegData.DatabaseLH;
            textBox6.Text = _userRegData.TableLH;
        }
 
        private async void Create_Click(object sender, EventArgs e)
        {
            _userRegData.ServerLH = textBox1.Text;
            _userRegData.UsernameLH = textBox2.Text;
            _userRegData.PasswordLH = textBox3.Text;
            _userRegData.PortLH = Convert.ToInt32(textBox4.Text);
            _userRegData.DatabaseLH = textBox5.Text;
            _userRegData.TableLH = textBox6.Text;

           _bDmySQL.UpdateUserData(_userRegData);
           await _bDmySQL.CreateTableMysql();
        }
    }
      
}

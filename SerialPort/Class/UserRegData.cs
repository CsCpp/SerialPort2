
namespace SerialPortC
{
    public class UserRegData
    {
        public string ServerLH;
        public string UsernameLH;
        public string PasswordLH;
        public int PortLH;
        public string DatabaseLH;
        public string TableLH;
        
        public UserRegData()
        {
            ServerLH = "localhost";
            UsernameLH = "root";
            PortLH = 3306;
            DatabaseLH = "database01";
            TableLH = "table1";
            PasswordLH = "";
        }
    }
}

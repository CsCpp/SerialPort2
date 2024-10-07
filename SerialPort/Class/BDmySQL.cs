using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using MySqlX.XDevAPI.Relational;

namespace SerialPortC
{
    public class BDmySQL
    {

        static string serverLH;
        static public string ServerLH
        {

            get { return serverLH; }
            set { serverLH = value; }
        }

        static string usernameLH;
        static public string UsernameLH { get { return usernameLH; } set { usernameLH = value; } }

        static string passwordLH;
        static public string PasswordLH { get { return passwordLH; } set { passwordLH = value; } }

        static int portLH;
        static public int PortLH { get { return portLH; } set { portLH = value; } }

        static string databaseLH;
        static public string DatabaseLH { get { return databaseLH; } set { databaseLH = value; } }

        static string tableLH;
        static public string TableLH { get { return tableLH; } set { tableLH = value; } }

        private MySqlConnection myConnection;
        private MySqlCommand myCommand;

        private MySqlDataAdapter myDataAdapter;
        private DataSet myDataSet;

        public BDmySQL(){}
        static BDmySQL()
        {
            serverLH = "localhost";
            usernameLH = "root";
            passwordLH = "";
            portLH = 3306;
            databaseLH = "database01";
            tableLH = "table1";

        }


        public void SaveDataToMySqlDataBase(string str,bool valueInOrOut)
        {

            try
            {
                myConnection = new MySqlConnection($"server={ServerLH}; username={UsernameLH}; password={passwordLH}; port={Convert.ToString(portLH)}; database={databaseLH}");
                myConnection.Open();
                if (valueInOrOut)
                { 
                myCommand = new MySqlCommand(string.Format($"INSERT INTO {tableLH}" +
                                                    $" (`DataIN`, `DataOut`)  VALUES('', '" +
                                                     $"{str}" + "')"), myConnection);
                 
                }
                else
                {
                myCommand = new MySqlCommand(string.Format($"INSERT INTO {tableLH}" +
                                                   $" (`DataIN`, `DataOut`)  VALUES('" +
                                                   $"{str}" + "', '')"), myConnection);
                }
                myCommand.ExecuteNonQuery();
                myConnection.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
          
        }

        public DataSet ReadDataToMySqlDataBase()
        {

            try
            {
                myConnection = new MySqlConnection($"server={ServerLH}; username={UsernameLH}; password={passwordLH}; port={Convert.ToString(portLH)}; database={databaseLH}");
                myConnection.Open();

                myCommand = new MySqlCommand($"SELECT * FROM {tableLH} ORDER BY Id DESC", myConnection);
                myDataAdapter = new MySqlDataAdapter(myCommand);
                myDataSet = new DataSet();

                myDataAdapter.Fill(myDataSet, "Serial Data");


                myConnection.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return myDataSet;

        }

        public void TestDataToMySqlDataBase()
        {
            try
            {
                myConnection = new MySqlConnection($"server={ServerLH}; username={UsernameLH}; password={passwordLH}; port={Convert.ToString(portLH)}; database={databaseLH}");
                myConnection.Open();

                myCommand = new MySqlCommand($"SELECT * FROM {tableLH}", myConnection);
                
                myConnection.Close();
                MessageBox.Show("MySQL data base is OK", "Good", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex){MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);}
        }

        public void CreateTableMysql()
        {
            bool i=false;

            //-------------------------------- есть ли базза данных -----------------------------
            try
            {
                myConnection = new MySqlConnection($"server={ServerLH}; username={UsernameLH}; password={passwordLH}; port={Convert.ToString(portLH)}; database={databaseLH}");
                myConnection.Open();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message + " Ошибка на стадии открытия базы данных", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            
            //--------------------------проверяем есть ли такая таблица-----------------------------
            try
            {
                myCommand = new MySqlCommand($"SELECT * FROM {tableLH}", myConnection);
                myDataAdapter = new MySqlDataAdapter(myCommand);
                myDataSet = new DataSet();

                myDataAdapter.Fill(myDataSet, "Serial Data");
            

                MessageBox.Show("Такая таблица уже существует", "Ex", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            catch (Exception)
            {
                i= true;
                
            }
            if (i)
            {
                try
                {
                    //----------------------------- создание таблицы --------------------------------------
                    myCommand = new MySqlCommand(
                            string.Format($"CREATE TABLE {databaseLH}" + "." + $"{tableLH} (`Id` INT(11) UNSIGNED NOT NULL AUTO_INCREMENT , `Date` DATE NOT NULL DEFAULT CURRENT_TIMESTAMP , `Time` TIME(6) NOT NULL DEFAULT CURRENT_TIMESTAMP , `DataIN` VARCHAR(250) NOT NULL , `DataOut` VARCHAR(250) NOT NULL , PRIMARY KEY (`Id`)) ENGINE = MyISAM CHARSET=armscii8 COLLATE armscii8_general_ci;")
                            // - old- - (`Id` INT NOT NULL ,`DataIN` VARCHAR(100) NOT NULL, `DataOut` VARCHAR(100) NOT NULL) ENGINE = InnoDB;")
                            //CREATE TABLE `database01`.`com8` (`Id` INT(11) UNSIGNED NOT NULL AUTO_INCREMENT , `Date` DATE NOT NULL DEFAULT CURRENT_TIMESTAMP , `Time` TIME(6) NOT NULL DEFAULT CURRENT_TIMESTAMP , `DataIN` VARCHAR(250) NOT NULL , `DataOut` VARCHAR(250) NOT NULL , PRIMARY KEY (`Id`)) ENGINE = MyISAM CHARSET=armscii8 COLLATE armscii8_general_ci;

                            , myConnection);

                    myCommand.ExecuteNonQuery();

                    myCommand = new MySqlCommand(
                        $" INSERT INTO {tableLH} (`DataIN`, `DataOut`) VALUES('Base is', 'create')"
                        , myConnection);

                    myCommand.ExecuteNonQuery();

                    myConnection.Close();

                    MessageBox.Show("MySQL data base CREATE", "Good", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message + " Ошибка на стадии создании таблицы", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            }




        }
    }
}

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

        //private MySqlConnection myConnection;
        //private MySqlCommand myCommand;

        //private MySqlDataAdapter myDataAdapter;
        //private DataSet myDataSet;

       
        public BDmySQL()
        {
        
        }
        static BDmySQL()
        {
            serverLH = "localhost";
            usernameLH = "root";
            passwordLH = "";
            portLH = 3306;
            databaseLH = "database01";
            tableLH = "table1";

        }


        public async Task SaveDataToMySqlDataBase(string str,bool valueInOrOut)
        {
            MySqlConnection connection = null;
            try
            {
               connection = CreateConnection();
               await connection.OpenAsync();
               var valuesArgs = valueInOrOut ? $"'', '{str}'" : $"'{str}', ''";
               var command = new MySqlCommand(
                    $"INSERT INTO {TableLH}(`DataIN`, `DataOut`)  VALUES({valuesArgs})",
                    connection
                );

                command.ExecuteNonQuery();
                await connection.CloseAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                await CloseConnection(connection);
            }
          
        }

        public async Task <DataSet> ReadDataToMySqlDataBase()
        {
            var dataSet = new DataSet();
            MySqlConnection connection = null;
            try
            {
                connection=CreateConnection();
                await connection.OpenAsync();
                var command = new MySqlCommand($"SELECT * FROM {TableLH} ORDER BY Id DESC", connection);
                var dataAdapter = new MySqlDataAdapter(command);
                dataAdapter.Fill(dataSet, "Serial Data");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                await CloseConnection(connection);
            }
            return dataSet;
        }

        public async Task AssertDataBaseValid()
        {
            MySqlConnection connection = null;
            try
            {
                connection = CreateConnection();
                await connection.OpenAsync();
                var isValid = await IsDataBaseValid(connection);
                if (isValid)
                {
                    MessageBox.Show(
                        $"{TableLH} таблица уже существует",
                        "Ex",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            finally
            {
                await CloseConnection(connection);
            }

            {  //try
               //{
               //    myConnection = new MySqlConnection($"server={ServerLH}; username={UsernameLH}; password={passwordLH}; port={Convert.ToString(portLH)}; database={databaseLH}");
               //    myConnection.Open();

                //    myCommand = new MySqlCommand($"SELECT * FROM {tableLH}", myConnection);

                //    myConnection.Close();
                //    MessageBox.Show("MySQL data base is OK", "Good", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
            } //catch (Exception ex){MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);}
        }

        private async Task<bool> IsDataBaseValid(MySqlConnection connection)
        {
            var command = new MySqlCommand($"SHOW TABLES LIKE '{TableLH}'", connection);
            var result = await command.ExecuteScalarAsync();
            return result != null;
        }

        public async Task CreateTableMysql()
        {
            MySqlConnection connection = null;
            try
            {
                connection = CreateConnection();
                await connection.OpenAsync();
                var isTableExist = await IsDataBaseValid(connection);
                if (isTableExist)
                {
                    MessageBox.Show(
                        $"{TableLH} таблица уже существует",
                        "Ex",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message + " Ошибка на стадии открытия базы данных", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            try
            {
                
                var command = new MySqlCommand(
                        $"CREATE TABLE {databaseLH}.{tableLH} " +
                        $"(`Id` INT(11) UNSIGNED NOT NULL AUTO_INCREMENT , `Date` " +
                        $"DATE NOT NULL DEFAULT CURRENT_TIMESTAMP , `Time` TIME(6) NOT NULL DEFAULT CURRENT_TIMESTAMP , " +
                        $"`DataIN` VARCHAR(250) NOT NULL , `DataOut` VARCHAR(250) NOT NULL , PRIMARY KEY (`Id`)) " +
                        $"ENGINE = MyISAM CHARSET=armscii8 COLLATE armscii8_general_ci;"
                        ,connection);

             //   var s = command.CommandText;
                command.ExecuteNonQuery();

                command = new MySqlCommand(
                    $" INSERT INTO {tableLH} (`DataIN`, `DataOut`) VALUES('Base is', 'create')"
                    ,connection);

             
              command.ExecuteNonQuery();

                MessageBox.Show("MySQL data base CREATE", "Good", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            catch (Exception ex)
            {
                var ошибкаБазыДанных = ex.Message + " Ошибка базы данных" + ex.StackTrace;
                MessageBox.Show(
                                ошибкаБазыДанных,
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            finally
            {
                await CloseConnection(connection);
            }
        }
        private MySqlConnection CreateConnection()
        {
            return new MySqlConnection(
                $"server={ServerLH}; username={UsernameLH}; password={PasswordLH}; port={Convert.ToString(PortLH)}; database={DatabaseLH}"
            );
        }

        private static Task CloseConnection(MySqlConnection connection)
        {
            return connection?.CloseAsync() ?? Task.CompletedTask;
        }
    }
}

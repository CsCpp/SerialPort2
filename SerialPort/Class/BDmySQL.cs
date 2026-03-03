using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SerialPortC
{
    public class BDmySQL
    {
        public string ServerLH { get; set; } = "NoServer";
        public string UsernameLH { get; set; } = "NoUser";
        public string PasswordLH { get; set; } = "PASSWORD";
        public int PortLH { get; set; } = 3306;
        public string DatabaseLH { get; set; } = "NoDataBase";
        public string TableLH { get; set; } = "NoTable";

        public BDmySQL() { }

        public async Task SaveDataToMySqlDataBase(string str, bool valueInOrOut)
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

        public async Task<DataSet> ReadDataToMySqlDataBase()
        {
            var dataSet = new DataSet();
            MySqlConnection connection = null;
            try
            {
                connection = CreateConnection();
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
        public async Task<DataSet> ReadInDataSql()
        {
            var dataSet = new DataSet();
            MySqlConnection connection = null;
            try
            {
                connection = CreateConnection();
                await connection.OpenAsync();
                //SELECT `DataIN` FROM `com8` WHERE `DataIN`!="";
                var command = new MySqlCommand($"SELECT `DataIN` FROM {TableLH}  WHERE `DataIN`!=\"\"", connection);
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
                        $"CREATE TABLE {DatabaseLH}.{TableLH} " +
                        $"(`Id` INT(11) UNSIGNED NOT NULL AUTO_INCREMENT , `Date` " +
                        $"DATE NOT NULL DEFAULT CURRENT_TIMESTAMP , `Time` TIME(6) NOT NULL DEFAULT CURRENT_TIMESTAMP , " +
                        $"`DataIN` VARCHAR(250) NOT NULL , `DataOut` VARCHAR(250) NOT NULL , PRIMARY KEY (`Id`)) " +
                        $"ENGINE = MyISAM CHARSET=armscii8 COLLATE armscii8_general_ci;"
                        , connection);

                //   var s = command.CommandText;
                command.ExecuteNonQuery();

                command = new MySqlCommand(
                    $" INSERT INTO {TableLH} (`DataIN`, `DataOut`) VALUES('Base is', 'create')"
                    , connection);


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
                $"server={ServerLH}; username={UsernameLH}; " +
                $"password={PasswordLH}; port={Convert.ToString(PortLH)};" +
                $" database={DatabaseLH}"
            );
        }

        private static Task CloseConnection(MySqlConnection connection)
        {
            return connection?.CloseAsync() ?? Task.CompletedTask;
        }
    }
}

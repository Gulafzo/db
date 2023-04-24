using MySql.Data.MySqlClient;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Console_Data_Base
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string SelectSQLcommand = @"SELECT c.Name AS ""Person Name"", cc.ClassName AS ""Class Name"" FROM Characters AS c, CharactersClass AS cc WHERE c.CharacterClassID = cc.ID;";

            MySqlConnection connection = null;
            MySqlDataReader reader = null;
            MySqlConnectionStringBuilder mySqlConnectionStringBuilder = new MySqlConnectionStringBuilder()
            {
                Server = "db4free.net",
                Database = "isoevagulafzo",
                UserID = "gulafzo",
                Password = "_TZWsQ836d@_wAf",
                OldGuids = true
            };

            //connection = new SqlConnection();
            //connection.ConnectionString = @"Data Source=db4free.net:3306 ; Initial Catalog=first_test_bd; User ID=anonim; Password=anonim228";

            try
            {


                connection = new MySqlConnection(mySqlConnectionStringBuilder.ToString());
                await connection.OpenAsync();

                //SqlCommand cmd = new SqlCommand();
                //cmd.Connection = connection;
                //cmd.CommandText = SelectSQLcommand;

                MySqlCommand cmd = new MySqlCommand(SelectSQLcommand, connection);

                //cmd.ExecuteNonQuery();

                reader = (MySqlDataReader)await cmd.ExecuteReaderAsync();

                while (reader.Read())
                {
                    Console.WriteLine(reader[0] + " " + reader[1]);
                }

                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadKey();
            }
            finally
            {
                if (connection != null)
                {
                    await connection.CloseAsync();
                }
                if (reader != null)
                {
                    await reader.CloseAsync();
                }
            }
        }
    }
}
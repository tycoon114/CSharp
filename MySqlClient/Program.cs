using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace MySqlClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "server=localhost; user=test; database = membership; password=1q2w3e4r5t";

            MySqlConnection mySqlConnection = new MySqlConnection(connectionString);
            try
            {
                mySqlConnection.Open();
                MySqlCommand mySqlCommand = new MySqlCommand();
                mySqlCommand.Connection = mySqlConnection;

                mySqlCommand.Prepare();
                mySqlCommand.Parameters.AddWithValue("@user_id", "htk008");
                mySqlCommand.Parameters.AddWithValue("@user_password", "1234");

                MySqlDataReader dataReader = mySqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    Console.WriteLine(dataReader["name"] + " " + dataReader["email"]);
                }
                dataReader.Close();

                //회원 가입
                MySqlCommand mySqlCommand2 = new MySqlCommand();
                mySqlCommand2.Connection = mySqlConnection;

                mySqlCommand2.CommandText = "insert into users (user_id, user_password, name, email) values ( @user_id, @user_password, @name, @email)";
                mySqlCommand2.Prepare();
                mySqlCommand2.Parameters.AddWithValue("@user_id", "abc001");
                mySqlCommand2.Parameters.AddWithValue("@user_password", "2222");
                mySqlCommand2.Parameters.AddWithValue("@name", "신지용");
                mySqlCommand2.Parameters.AddWithValue("@email", "abc001@abc001.com");
                mySqlCommand2.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                mySqlConnection.Close();
            }
        }
    }
}

using System;
using LSport_HomeTask.Models.Giphy;
using MySql.Data.MySqlClient;


namespace LSport_HomeTask.Managers.MySQL.GiphyManager
{

    public class GiphyMySQLManager : MySQLManagerInterface
    {
        private MySqlConnection connection;


        public GiphyMySQLManager(string connectionString)
        {

            try
            {
                connection = new MySqlConnection(connectionString);
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        Console.WriteLine("Invalid username/password, please try again");
                        break;
                }
                throw;
            }
        }

        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        Console.WriteLine("Invalid username/password, please try again");
                        break;

                    default:
                        Console.WriteLine("ERROR Message:" + ex.Message);
                        break;
                }
                return false;
            }
        }

        public bool SaveToDatabase(Giphy gifToSave)
        {
            try
            {
                if (OpenConnection() == true)
                {
                    Console.WriteLine("MySQL connection is now Open ");
                    string sqlQuery = "INSERT INTO giphy.gifs(ID,URL,rating,title,type) VALUES('" + gifToSave.id + "','" + gifToSave.URL + "','" + gifToSave.rating + "','" + gifToSave.title + "','" + gifToSave.type + "');";
                    MySqlCommand newCommand = new MySqlCommand(sqlQuery, connection);
                    int connectionResult = newCommand.ExecuteNonQuery();
                    CloseConnection();
                    Console.WriteLine("MySQL connection is now Closed ");
                    if (connectionResult == 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    Console.WriteLine("No MySQL connection !");
                    return false;
                }


            }
            catch (MySqlException ex)
            {
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        Console.WriteLine("Invalid username/password, please try again");
                        break;
                    default:
                        Console.WriteLine(ex.Message);
                        break;
                }
                return false;
            }

        }
    }
}

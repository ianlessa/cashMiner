using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace DB
{
    public class DBConnection
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        //Constructor
        public DBConnection(string server, string database, string uid, string password)
        {
            this.server = server;
            this.database = database;
            this.uid = uid;
            this.password = password;
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        //open connection to database
        private bool OpenConnection()
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
                        throw new Exception("Cannot connect to server.  Contact administrator");
                    //break;

                    case 1045:
                        throw new Exception("Invalid username/password, please try again");
                        //break;
                }
                return false;
            }
        }

        public void testConnection()
        {
            this.OpenConnection();
            this.CloseConnection();
        }

        //Close connection
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


        public void Query(string query)
        {
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }



        //Select statement
        public List<string>[] Select(string query)
        {
            //string query = "SELECT * FROM tableinfo";

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                List<string>[] list = new List<string>[dataReader.FieldCount];
                for (int col = 0; col < dataReader.FieldCount; col++)
                {
                    list[col] = new List<string>();
                }



                //Read the data and store them in the list
                while (dataReader.Read())
                {

                    for (int col = 0; col < dataReader.FieldCount; col++)
                    {
                        list[col].Add(dataReader[col] + "");
                        // Console.WriteLine("{0}", list[col]);
                    }


                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return list;
            }
            else
            {
                return new List<string>[1];
            }
        }

    }
}

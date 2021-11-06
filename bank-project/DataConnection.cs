using System;
using System.IO;
using System.Data.SQLite;

namespace bank_project
{
    public class DataConnection
    {
        public SQLiteConnection bankConnection;

        public DataConnection()
        {
            bankConnection = new SQLiteConnection("Data Source=bankdatabase.sqlite3");

            if (!File.Exists("./bankdatabase.sqlite3"))
            {
                Console.WriteLine("Database successfully created");
                SQLiteConnection.CreateFile("bankdatabase.sqlite3");

                bankConnection.Open();
                string sql = "create table clients (guid VARCHAR(50) NOT NULL, lastName VARCHAR(30), firstName VARCHAR(30), pin VARCHAR(4), blocked INT, mainCurrency VARCHAR(3), balance INT, USD INT, EUR INT, JPY INT, GBP INT, AUD INT, CAD INT, CHF INT, CNH INT, SEK INT, NZD INT, CONSTRAINT PK PRIMARY KEY (guid))";

                SQLiteCommand command = new SQLiteCommand(sql, bankConnection);
                command.ExecuteNonQuery();

                bankConnection.Close();
            }
        }

        public static bool CheckConnection()
        {
            try
            {
                DataConnection databaseObject = new DataConnection();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex + "Cannot establish connection with database");
                return false;
            }
        }

        public void OpenConnection()
        {
            if (bankConnection.State != System.Data.ConnectionState.Open)
            {
                bankConnection.Open();
            }
        }

        public void CloseConnection()
        {
            if (bankConnection.State != System.Data.ConnectionState.Closed)
            {
                bankConnection.Close();
            }
        }
    }
}

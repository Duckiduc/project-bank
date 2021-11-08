using System;
using System.Data.SQLite;

namespace bank_project
{
    public class ClientDBAccess : IClientDataAccess
    {
        DataConnection databaseObject = new DataConnection();

        public Client ParseClient(string id)
        {
            Guid guid = new Guid(id);
            string lastName = string.Empty;
            string firstName = string.Empty;
            string pin = string.Empty;
            string mainCurrency = string.Empty;
            decimal balance = 0;
            bool blocked = false;
            decimal USD = 0;
            decimal EUR = 0;
            decimal JPY = 0;
            decimal GBP = 0;
            decimal AUD = 0;
            decimal CAD = 0;
            decimal CHF = 0;
            decimal CNH = 0;
            decimal SEK = 0;
            decimal NZD = 0;

            string query = "SELECT * FROM clients WHERE guid = @guid";
            SQLiteCommand command = new SQLiteCommand(query, databaseObject.bankConnection);
            databaseObject.OpenConnection();
            command.Parameters.AddWithValue("@guid", id);
            SQLiteDataReader clients = command.ExecuteReader();

            if (clients.HasRows)
            {
                while (clients.Read())
                {
                    guid = new Guid((string)clients["guid"]);
                    lastName = (string)clients["lastName"];
                    firstName = (string)clients["firstName"];
                    pin = (string)clients["pin"];
                    mainCurrency = "USD";
                    blocked = false;

                    try
                    {
                        mainCurrency = (string)clients["mainCurrency"];
                    }
                    catch (Exception ex)
                    { }

                    try
                    {
                        balance = Convert.ToDecimal(clients["balance"]);
                    }
                    catch (Exception ex)
                    { }

                    try
                    {
                        blocked = (bool)clients["blocked"];
                    }
                    catch (Exception ex)
                    { }

                    try
                    {
                        USD = Convert.ToDecimal(clients["USD"]);
                    }
                    catch (Exception ex)
                    { }

                    try
                    {
                        EUR = Convert.ToDecimal(clients["EUR"]);
                    }
                    catch (Exception ex)
                    { }

                    try
                    {
                        JPY = Convert.ToDecimal(clients["JPY"]);
                    }
                    catch (Exception ex)
                    { }

                    try
                    {
                        GBP = Convert.ToDecimal(clients["GBP"]);
                    }
                    catch (Exception ex)
                    { }

                    try
                    {
                        AUD = Convert.ToDecimal(clients["AUD"]);
                    }
                    catch (Exception ex)
                    { }

                    try
                    {
                        CAD = Convert.ToDecimal(clients["CAD"]);
                    }
                    catch (Exception ex)
                    { }

                    try
                    {
                        CHF = Convert.ToDecimal(clients["CHF"]);
                    }
                    catch (Exception ex)
                    { }

                    try
                    {
                        CNH = Convert.ToDecimal(clients["CNH"]);
                    }
                    catch (Exception ex)
                    { }

                    try
                    {
                        SEK = Convert.ToDecimal(clients["SEK"]);
                    }
                    catch (Exception ex)
                    { }

                    try
                    {
                        NZD = Convert.ToDecimal(clients["NZD"]);
                    }
                    catch (Exception ex)
                    { }
                }
            }

            databaseObject.CloseConnection();
            Client client = new Client(guid, lastName, firstName, pin, balance, mainCurrency, blocked, USD, EUR, JPY, GBP, AUD, CAD, CHF, CNH, SEK, NZD);
            return client;
        }

        public void BackDatabase(Client client)
        {
            string query = "UPDATE clients SET `lastName` = @lastName, `firstName` = @firstName, `blocked` = @blocked, `balance` = @balance, `pin` = @pin, `USD` = @USD, `EUR` = @EUR, `JPY` = @JPY, `GBP` = @GBP, `AUD` = @AUD, `CAD` = @CAD, `CHF` = @CHF, `CNH` = @CNH, `SEK` = @SEK, `NZD` = @NZD WHERE `guid` = @guid";
            SQLiteCommand command = new SQLiteCommand(query, databaseObject.bankConnection);
            databaseObject.OpenConnection();
            command.Parameters.AddWithValue("@guid", client.id.ToString());
            command.Parameters.AddWithValue("@lastName", client.lastName);
            command.Parameters.AddWithValue("@firstName", client.firstName);
            command.Parameters.AddWithValue("@blocked", client.blocked);
            command.Parameters.AddWithValue("@balance", client.balance);
            command.Parameters.AddWithValue("@pin", client.pin);
            command.Parameters.AddWithValue("@USD", client.USD);
            command.Parameters.AddWithValue("@EUR", client.EUR);
            command.Parameters.AddWithValue("@JPY", client.JPY);
            command.Parameters.AddWithValue("@GBP", client.GBP);
            command.Parameters.AddWithValue("@AUD", client.AUD);
            command.Parameters.AddWithValue("@CAD", client.CAD);
            command.Parameters.AddWithValue("@CHF", client.CHF);
            command.Parameters.AddWithValue("@CNH", client.CNH);
            command.Parameters.AddWithValue("@SEK", client.SEK);
            command.Parameters.AddWithValue("@NZD", client.NZD);
            var result = command.ExecuteNonQuery();
            databaseObject.CloseConnection();
            Console.WriteLine("Rows updated: {0}", result);
        }

        public void GetAll()
        {
            string query = "SELECT * FROM clients";
            SQLiteCommand command = new SQLiteCommand(query, databaseObject.bankConnection);
            databaseObject.OpenConnection();
            SQLiteDataReader clients = command.ExecuteReader();
            if (clients.HasRows)
            {
                while (clients.Read())
                {
                    Console.WriteLine((string)clients["guid"] + " " + (string)clients["lastName"] + " " + (string)clients["firstName"]);
                }
            }
            databaseObject.CloseConnection();
        }

        public void CreateUser()
        {
            Client client = new Client();

            string query = "INSERT INTO clients (`guid`, `lastName`, `firstName`, `pin`) VALUES (@guid, @lastName, @firstName, @pin)";
            SQLiteCommand command = new SQLiteCommand(query, databaseObject.bankConnection);
            databaseObject.OpenConnection();
            command.Parameters.AddWithValue("@guid", client.id.ToString());
            command.Parameters.AddWithValue("@lastName", client.lastName);
            command.Parameters.AddWithValue("@firstName", client.firstName);
            command.Parameters.AddWithValue("@pin", client.pin);
            var result = command.ExecuteNonQuery();
            databaseObject.CloseConnection();
            Console.WriteLine("Rows added: {0}", result);
        }

        public void GetClient(string id)
        {
            string query = "SELECT * FROM clients WHERE guid = @guid";
            SQLiteCommand command = new SQLiteCommand(query, databaseObject.bankConnection);
            databaseObject.OpenConnection();
            command.Parameters.AddWithValue("@guid", id);
            SQLiteDataReader clients = command.ExecuteReader();
            if (clients.HasRows)
            {
                while (clients.Read())
                {
                    Console.WriteLine((string)clients["guid"] + " " + (string)clients["lastName"] + " " + (string)clients["firstName"]);
                }
            }
            databaseObject.CloseConnection();
        }

        public void UpdateClient(string id)
        {
            int choice = 0;

            Client client = ParseClient(id);

            while (choice != 7)
            {
                Console.WriteLine(
                "Welcome to your managing interface. Please enter the corresponding number of what you want to do." + Environment.NewLine +
                "1: Update last name" + Environment.NewLine +
                "2: Update first name" + Environment.NewLine +
                "3: Update pin" + Environment.NewLine +
                "4: Update balance" + Environment.NewLine +
                "5: Update main currency" + Environment.NewLine +
                "6: Update blocked status" + Environment.NewLine +
                "7: Quit"
                );
                do
                {
                    Console.WriteLine("Please choose a valid option :");
                    int.TryParse(Console.ReadLine(), out var result);
                    choice = result;
                } while (choice < 1 || choice > 7);

                ClientDBAccess DBAccess = new ClientDBAccess();
                if (choice == 1)
                {
                    Console.WriteLine("Update last name");
                    client.updateLastName();
                }
                else if (choice == 2)
                {
                    Console.WriteLine("Update first name");
                    client.updateFirstName();
                }
                else if (choice == 3)
                {
                    Console.WriteLine("Update pin");
                    client.updatePin();
                }
                else if (choice == 4)
                {
                    Console.WriteLine("Update balance");
                    client.updateBalance();
                }
                else if (choice == 5)
                {
                    Console.WriteLine("Update main currency");
                    client.updateMainCurrency();
                }
                else if (choice == 6)
                {
                    Console.WriteLine("Update blocked status");
                    client.updateBlocked();
                }
            }

            BackDatabase(client);
        }

        public void DeleteClient(string id)
        {
            string query = "DELETE FROM clients WHERE guid = @guid";
            SQLiteCommand command = new SQLiteCommand(query, databaseObject.bankConnection);
            databaseObject.OpenConnection();
            command.Parameters.AddWithValue("@guid", id);
            var result = command.ExecuteNonQuery();
            databaseObject.CloseConnection();
            Console.WriteLine("Rows deleted: {0}", result);
        }

        public bool AuthenticateClient(string id, string pin)
        {
            string pinDB = string.Empty;
            string query = "SELECT * FROM clients WHERE guid = @guid";
            SQLiteCommand command = new SQLiteCommand(query, databaseObject.bankConnection);
            databaseObject.OpenConnection();
            command.Parameters.AddWithValue("@guid", id);
            SQLiteDataReader clients = command.ExecuteReader();
            if (clients.HasRows)
            {
                while (clients.Read())
                {
                    pinDB = (string)clients["pin"];
                }
            }
            databaseObject.CloseConnection();

            if (pin == pinDB)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

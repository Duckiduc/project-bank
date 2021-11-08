using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;

namespace bank_project
{
    public class Client
    {
        public Guid id;

        public string lastName;

        public string firstName;

        public string pin;

        public bool blocked;

        public string mainCurrency;

        public decimal balance;

        public decimal USD;
        public decimal EUR;
        public decimal JPY;
        public decimal GBP;
        public decimal AUD;
        public decimal CAD;
        public decimal CHF;
        public decimal CNH;
        public decimal SEK;
        public decimal NZD;

        public Client(Guid id, string lastName, string firstName, string pin, decimal balance, string mainCurrency, bool blocked, decimal USD, decimal EUR, decimal JPY, decimal GBP, decimal AUD, decimal CAD, decimal CHF, decimal CNH, decimal SEK, decimal NZD)
        {
            this.id = id;
            this.lastName = lastName;
            this.firstName = firstName;
            this.pin = pin;
            this.balance = balance;
            this.mainCurrency = mainCurrency;
            this.blocked = blocked;
            this.USD = USD;
            this.EUR = EUR;
            this.JPY = JPY;
            this.GBP = GBP;
            this.AUD = AUD;
            this.CAD = CAD;
            this.CHF = CHF;
            this.CNH = CNH;
            this.SEK = SEK;
            this.NZD = NZD;
        }

        public Client(bool authenticate)
        {
            
        }

        public Client()
        {
            this.id = generateGuid();
            this.lastName = setLastName();
            this.firstName = setFirstName();
            this.pin = setPin();
        }

        public string setLastName()
        {
            Console.WriteLine("Enter last name");
            string lastName = Console.ReadLine();
            return lastName;
        }

        public void updateLastName()
        {
            Console.WriteLine("Enter last name");
            string lastName = Console.ReadLine();
            this.lastName = lastName;
        }

        public string setFirstName()
        {
            Console.WriteLine("Enter first name");
            string firstName = Console.ReadLine();
            return firstName;
        }

        public void updateFirstName()
        {
            Console.WriteLine("Enter first name");
            string firstName = Console.ReadLine();
            this.firstName = firstName;
        }

        public string setPin()
        {
            Console.WriteLine("Enter new pin");
            string pin = Console.ReadLine();
            Console.WriteLine(pin);
            return pin;
        }

        public void updatePin()
        {
            Console.WriteLine("Enter new pin");
            string pin = Console.ReadLine();
            this.pin = pin;
        }

        public void updateBalance()
        {
            Console.WriteLine("Enter balance");
            decimal balance = Convert.ToDecimal(Console.ReadLine());
            this.balance = balance;
        }

        public void updateBlocked()
        {
            Console.WriteLine("Enter balance");
            string block = Console.ReadLine();
            bool blocked = bool.Parse(block);
            this.blocked = blocked;
        }

        public void updateMainCurrency()
        {
            Console.WriteLine("Enter main currency");
            string mainCurrency = Console.ReadLine();
            this.mainCurrency = mainCurrency;
        }

        public Guid generateGuid()
        {
            return Guid.NewGuid();
        }

        public void ClientMenu(string guid)
        {
            int choice = 0;
            ClientDBAccess clientAccess = new ClientDBAccess();
            Client client = clientAccess.ParseClient(guid);

            while (choice != 7)
            {
                Console.WriteLine(
                "Welcome to your managing interface. Please enter the corresponding number of what you want to do." + Environment.NewLine +
                "1: Get credentials" + Environment.NewLine +
                "2: View balance" + Environment.NewLine +
                "3: Retrieve money from currency" + Environment.NewLine +
                "4: Add money to currency" + Environment.NewLine +
                "5: Change pin" + Environment.NewLine +
                "6: Exchance between currencies" + Environment.NewLine +
                "7: Quit"
                );
                do
                {
                    Console.WriteLine("Please choose a valid option :");
                    int.TryParse(Console.ReadLine(), out var result);
                    choice = result;
                } while (choice < 1 || choice > 7);

                if (DataConnection.CheckConnection())
                {
                    if (choice == 1)
                    {
                        Console.WriteLine("Get credentials");
                        //clientAccess.GetClient(guid);
                        Console.WriteLine("Guid: " + client.id);
                        Console.WriteLine("Last name: " + client.lastName);
                        Console.WriteLine("First name: " + client.firstName);
                    }
                    else if (choice == 2)
                    {
                        Console.WriteLine("View balance");
                        Console.WriteLine("Balance: $" + client.balance);
                    }
                    else if (choice == 3)
                    {
                        string[] currencies = { "USD", "EUR", "JPY", "GBP", "AUD", "CAD", "CHF", "CNH", "SEK", "NZD" };
                        Console.WriteLine("Retrieve money from currency");
                        Console.WriteLine("Enter currency symbol from the following list: USD, EUR, JPY, GBP, AUD, CAD, CHF, CNH, SEK, NZD");
                        string currency = Console.ReadLine();
                        if (currencies.Contains(currency))
                        {
                            if (currency == "USD")
                            {
                                Console.WriteLine(client.USD);
                            }
                            else if (currency == "EUR")
                            {
                                Console.WriteLine(client.EUR);
                            }
                            else if (currency == "JPY")
                            {
                                Console.WriteLine(client.JPY);
                            }
                            else if (currency == "GBP")
                            {
                                Console.WriteLine(client.GBP);
                            }
                            else if (currency == "AUD")
                            {
                                Console.WriteLine(client.AUD);
                            }
                            else if (currency == "CAD")
                            {
                                Console.WriteLine(client.CAD);
                            }
                            else if (currency == "CHF")
                            {
                                Console.WriteLine(client.CHF);
                            }
                            else if (currency == "CNH")
                            {
                                Console.WriteLine(client.CNH);
                            }
                            else if (currency == "SEK")
                            {
                                Console.WriteLine(client.SEK);
                            }
                            else if (currency == "NZD")
                            {
                                Console.WriteLine(client.NZD);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Wrong currency");
                        }
                    }
                    else if (choice == 4)
                    {
                        Console.WriteLine("Update client");
                        Console.WriteLine("Enter client's guid");
                        string clientGuid = Console.ReadLine();
                        //DBAccess.UpdateClient(clientGuid);
                    }
                    else if (choice == 5)
                    {
                        client.updatePin();
                    }
                    else if (choice == 6)
                    {
                        Console.WriteLine("Delete client");
                        Console.WriteLine("Enter client's guid");
                        string clientGuid = Console.ReadLine();
                        //DBAccess.DeleteClient(clientGuid);
                    }
                }
                else
                {
                    Console.WriteLine("JSON");
                }
                clientAccess.BackDatabase(client);
            }
            Console.WriteLine("Terminating...");
        }

        public void Authenticate()
        {
            ClientDBAccess clientAccess = new ClientDBAccess();

            Console.WriteLine("Please enter your guid");
            string guidInput = Console.ReadLine();

            Console.WriteLine("Please enter your pin");
            string pinInput = Console.ReadLine();



            if (clientAccess.AuthenticateClient(guidInput, pinInput))
            {
                Console.WriteLine("Authentication successful");
                Console.WriteLine("Redirecting to your interface...");
                ClientMenu(guidInput);
            }
            else
            {
                Console.WriteLine("Fail to authenticate. Exiting...");
                Environment.Exit(1);
            }
        }
    }
}

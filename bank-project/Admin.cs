using System;
namespace bank_project
{
    public class Admin
    {
        private string username = "admin";
        private string password = "Admin4";

        private void AdminMenu()
        {
            int choice = 0;

            while (choice != 6)
            {
                Console.WriteLine(
                "Welcome to your managing interface. Please enter the corresponding number of what you want to do." + Environment.NewLine +
                "1: Get all users" + Environment.NewLine +
                "2: Create user" + Environment.NewLine +
                "3: Get client" + Environment.NewLine +
                "4: Update client" + Environment.NewLine +
                "5: Delete client" + Environment.NewLine +
                "6: Quit"
                );
                do
                {
                    Console.WriteLine("Please choose a valid option :");
                    int.TryParse(Console.ReadLine(), out var result);
                    choice = result;
                } while (choice < 1 || choice > 6);

                if (DataConnection.CheckConnection())
                {
                    ClientDBAccess DBAccess = new ClientDBAccess();
                    if (choice == 1)
                    {
                        Console.WriteLine("Get all users");
                        DBAccess.GetAll();
                    }
                    else if (choice == 2)
                    {
                        Console.WriteLine("Create user");
                        DBAccess.CreateUser();
                    }
                    else if (choice == 3)
                    {
                        Console.WriteLine("Get client");
                        Console.WriteLine("Enter client's guid");
                        string clientGuid = Console.ReadLine();
                        DBAccess.GetClient(clientGuid);
                    }
                    else if (choice == 4)
                    {
                        Console.WriteLine("Update client");
                        Console.WriteLine("Enter client's guid");
                        string clientGuid = Console.ReadLine();
                        DBAccess.UpdateClient(clientGuid);
                    }
                    else if (choice == 5)
                    {
                        Console.WriteLine("Delete client");
                        Console.WriteLine("Enter client's guid");
                        string clientGuid = Console.ReadLine();
                        DBAccess.DeleteClient(clientGuid);
                    }
                }
                else
                {
                    ClientJsonAccess DBAccess = new ClientJsonAccess();
                    if (choice == 1)
                    {
                        Console.WriteLine("Get all users");
                        DBAccess.GetAll();
                    }
                    else if (choice == 2)
                    {
                        Console.WriteLine("Create user");
                        DBAccess.CreateUser();
                    }
                    else if (choice == 3)
                    {
                        Console.WriteLine("Get client");
                        Console.WriteLine("Enter client's guid");
                        string clientGuid = Console.ReadLine();
                        DBAccess.GetClient(clientGuid);
                    }
                    else if (choice == 4)
                    {
                        Console.WriteLine("Update client");
                        Console.WriteLine("Enter client's guid");
                        string clientGuid = Console.ReadLine();
                        DBAccess.UpdateClient(clientGuid);
                    }
                    else if (choice == 5)
                    {
                        Console.WriteLine("Delete client");
                        Console.WriteLine("Enter client's guid");
                        string clientGuid = Console.ReadLine();
                        DBAccess.DeleteClient(clientGuid);
                    }
                }
            }
            Console.WriteLine("Terminating...");
        }

        public void Authenticate()
        {
            Console.WriteLine("Please enter your username");
            string usernameInput = Console.ReadLine();

            Console.WriteLine("Please enter your password");
            string passwordInput = Console.ReadLine();

            if (username == usernameInput && password == passwordInput)
            {
                Console.WriteLine("Authentication successful");
                Console.WriteLine("Redirecting to your interface...");
                AdminMenu();
            }
            else
            {
                Console.WriteLine("Fail to authenticate. Exiting...");
                Environment.Exit(1);
            }
        } 
    }
}

using System;

namespace bank_project
{
    class Program
    {
        public static int Menu()
        {
            int choice;
            Console.WriteLine(
                "Welcome to your managing interface. Please enter the corresponding number of what you want to do." + Environment.NewLine +
                "1: Admin" + Environment.NewLine +
                "2: Client" + Environment.NewLine +
                "3: Quit"
                );
            do
            {
                Console.WriteLine("Please choose a valid option :");
                int.TryParse(Console.ReadLine(), out var result);
                choice = result;
            } while (choice < 1 || choice > 3);
            return choice;
        }

        static void Main(string[] args)
        {
            int choice = 0;

            while (choice != 3)
            {
                choice = Menu();
                DataConnection.CheckConnection();

                if (choice == 1)
                {
                    Console.WriteLine("Entering admin interface...");
                    Admin admin = new Admin();
                    admin.Authenticate();
                }
                else if (choice == 2)
                {
                    Console.WriteLine("Entering client interface...");
                    Client client = new Client(true);
                    client.Authenticate();
                }
            }
            Console.WriteLine("Terminating...");
        }
    }
}

using System;
using System.Collections.Generic;

namespace bank_project
{
    public class Client
    {
        public Guid id;

        public string lastName;

        public string firstName;

        public string pin;

        string mainCurrency;

        decimal balance;

        decimal USD;
        decimal EUR;
        decimal JPY;
        decimal GBP;
        decimal AUD;
        decimal CAD;
        decimal CHF;
        decimal CNH;
        decimal SEK;
        decimal NZD;

        public Client(Guid id, string lastName, string firstName, string pin, decimal balance, string mainCurrency, bool blocked)
        {
            this.id = id;
            this.lastName = lastName;
            this.firstName = firstName;
            this.pin = pin;
            this.balance = balance;
            this.mainCurrency = mainCurrency;
            this.blocked = blocked;
        }

        public Client()
        {
            this.id = generateGuid();
            this.lastName = setLastName();
            this.firstName = setFirstName();
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

<<<<<<< HEAD
        public void updateFirstName()
        {
            Console.WriteLine("Enter first name");
            string firstName = Console.ReadLine();
            this.firstName = firstName;
        }

        //Secure input: check length and type int
        public string setPin()
=======
        public int setPin()
>>>>>>> ee821be72b8901454a5f1f79e5858407dc102d7d
        {
            Console.WriteLine("Enter new pin");
            string pin = Console.ReadLine();
            Console.WriteLine(pin);
            return pin;
        }

<<<<<<< HEAD
        public void updatePin()
        {
            Console.WriteLine("Enter new pin");
            string pin = Console.ReadLine();
            this.pin = pin;
        }

        public void updateBalance()
        {
            Console.WriteLine("Enter balance");
            decimal balance = Console.Read();
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

=======
>>>>>>> ee821be72b8901454a5f1f79e5858407dc102d7d
        public Guid generateGuid()
        {
            return Guid.NewGuid();
        }
    }
}

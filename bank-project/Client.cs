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

        public bool blocked;

        string mainCurrency;

        public decimal balance;

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
    }
}

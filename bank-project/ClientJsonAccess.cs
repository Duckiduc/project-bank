using System;
using Newtonsoft.Json.Linq;
using System.IO;

namespace bank_project
{
    public class ClientJsonAccess : IClientDataAccess
    {
        private string jsonFile =
            @"/Users/leabuende/Library/Mobile Documents/com~apple~CloudDocs/GitHub/bank-project/bank-project/clients.json";
        public void GetAll()
        {
            var json = File.ReadAllText(jsonFile);
            var jsonObj = JObject.Parse(json);
            foreach (var user in jsonObj["users"])
            {
                Console.WriteLine("Name :" + user["firstname"].ToString() + " " + user["lastname"].ToString());
                Console.WriteLine("Id :" + user["id"].ToString());
                Console.WriteLine(" ");
            }
        }

        public void CreateUser()
        {
            Console.WriteLine("Enter first name : ");
            string first_name = Console.ReadLine();
            Console.WriteLine("\nEnter last name : ");
            string last_name = Console.ReadLine();
            Console.WriteLine("\nEnter Id : ");
            var id = Console.ReadLine();
            Console.WriteLine("\nEnter pin : ");
            var pin = Console.ReadLine();
            var user = "{ 'firstname': '" + first_name + "' , 'lastname': '" + last_name + "', 'id': '" + id + "', 'pin': '" + pin + "', 'balance' : 0, 'fav-currency' : null }";
            try
            {
                var json = File.ReadAllText(jsonFile);
                var jsonObj = JObject.Parse(json);
                Console.WriteLine("ok");
                var users = jsonObj.GetValue("users") as JArray;
                Console.WriteLine("ok there");
                var new_user = JObject.Parse(user);
                Console.WriteLine("ok here");

                users.Add(new_user);

                jsonObj["users"] = users;
                string newJsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj,
                    Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(jsonFile, newJsonResult);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Add Error : " + ex.Message.ToString());
            }
        }

        public void GetClient(string id)
        {
            var json = File.ReadAllText(jsonFile);
            var jsonObj = JObject.Parse(json);
            bool exists = false;
            foreach (var user in jsonObj["users"])
            {
                if (user["id"].ToString() == id)
                {
                    exists = true;
                    Console.WriteLine("Name :" + user["firstname"].ToString() + " " + user["lastname"].ToString());
                    Console.WriteLine("Id :" + user["id"].ToString());
                    Console.WriteLine(" ");
                }
            }
            if (exists == false)
            {
                Console.WriteLine("Client doesn't exist in the database");
            }
        }

        public void UpdateClient(string id)
        {
            string json = File.ReadAllText(jsonFile);
            int choice = 0;
            Console.WriteLine(
                "Welcome to your managing interface. Please enter the corresponding number of what you want to do." + Environment.NewLine +
                "1: Update last name" + Environment.NewLine +
                "2: Update first name" + Environment.NewLine +
                "3: Update pin" + Environment.NewLine +
                "4: Update balance" + Environment.NewLine +
                "5: Update main currency" + Environment.NewLine +
                "6: Quit"
            );
            do
            {
                Console.WriteLine("Please choose a valid option :");
                int.TryParse(Console.ReadLine(), out var result);
                choice = result;
            } while (choice < 1 || choice > 6);
            var jObject = JObject.Parse(json);
            JArray users = (JArray)jObject["users"];
            var exists = false;
            foreach (var user in users)
            {
                if (user["id"].ToString() == id)
                {
                    exists = true;
                    if (choice == 1)
                    {
                        Console.Write("Enter new First name : ");
                        var firstname = Convert.ToString(Console.ReadLine());
                        user["firstname"] = firstname;
                    }

                    if (choice == 2)
                    {
                        Console.Write("Enter new Last name : ");
                        var lastname = Convert.ToString(Console.ReadLine());
                        user["lastname"] = lastname;
                    }
                    if (choice == 3)
                    {
                        Console.Write("Enter new PIN : ");
                        var pin = Convert.ToString(Console.ReadLine());
                        user["pin"] = pin;
                    }
                    if (choice == 4)
                    {
                        Console.Write("Enter new balance : ");
                        int balance = Convert.ToInt32(Console.ReadLine());
                        user["balance"] = balance;
                    }
                    if (choice == 5)
                    {
                        Console.Write("Enter new favorite currency : ");
                        var fav = Convert.ToString(Console.ReadLine());
                        user["fav-currency"] = fav;
                    }
                }
            }
            jObject["users"] = users;
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(jObject, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(jsonFile, output);

            if (exists == false)
            {
                Console.WriteLine("This Client doesn't exist in the database");
            }
        }

        public void DeleteClient(string id)
        {
            var json = File.ReadAllText(jsonFile);
            try
            {
                var jObject = JObject.Parse(json);
                JArray users = (JArray)jObject["users"];
                var exists = false;
                foreach (var user in users)
                {
                    if (user["id"].ToString() == id)
                    {
                        exists = true;
                        var usertoDelete = user;
                        users.Remove(usertoDelete);
                        string output =
                            Newtonsoft.Json.JsonConvert.SerializeObject(jObject, Newtonsoft.Json.Formatting.Indented);
                        File.WriteAllText(jsonFile, output);
                        Console.WriteLine("Client successfully deleted");
                        break;
                    }
                }

                if (exists == false)
                {
                    Console.WriteLine("This Client doesn't exist in the database");
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        Client IClientDataAccess.ParseClient(string id)
        {
            throw new NotImplementedException();
        }
    }
}

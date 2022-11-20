using System;
using System.Collections.Generic;
using System.ComponentModel.Design;

namespace Bank
{
    class Program
    {

        static void Deposit(Client client, List<string> history)
        {
            Console.WriteLine("Write value to deposit");
            decimal value = Convert.ToDecimal(Console.ReadLine());
            client.Deposit(value);
            Console.WriteLine($"Your balance is now {client.Balance}");
            history.Add($"{value} deposited, balance: {client.Balance} on {DateTime.Now}");
        }

        static void Withdrawal(Client client, List<string> history)
        {
            Console.WriteLine("Write value to withdraw");
            decimal value = Convert.ToDecimal(Console.ReadLine());
            client.Withdrawal(value);
            Console.WriteLine($"{value} withdrawed succesfully, your balance is now {client.Balance}");
            history.Add($"{value} withdrawed, balance: {client.Balance} on {DateTime.Now}");
        }
        static void Main(string[] args)
        {
            List<string> history = new List<string>();

            Console.WriteLine("Welcome on the site of our bank, create an account");
            Console.WriteLine("Choose your account number, must be 11 digits long");
            var accNumber = Console.ReadLine();
            Console.WriteLine("Choose your account password, must be 6-12 characters without symbols");
            var password = Console.ReadLine();
            Client client = new Client(accNumber, password);

            Console.WriteLine($"Account added succesfully! Your starting balance is {client.Balance}");

            menu:
            Console.WriteLine();
            Console.WriteLine("Now, what you want to do:" +
                "\n 1. Deposit money" +
                "\n 2. Withdraw money" +
                "\n 3. See account balance" +
                "\n 4. See history");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine();
                    Deposit(client, history);
                    goto menu;
                case "2":
                    Console.WriteLine();
                    Withdrawal(client, history);
                    goto menu;
                case "3":
                    Console.WriteLine();
                    Console.WriteLine($"Your current balance: {client.Balance}");
                    goto menu;
                case "4":
                    Console.WriteLine();
                    foreach (var item in history)
                    {
                        Console.WriteLine(item);
                    }
                    goto menu;
                default:
                    Console.WriteLine();
                    Console.WriteLine("Invalid instruction");
                    break;
            }
        }
    }
}

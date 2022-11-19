using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bank
{
    class Client
    {
        private string _accountNumber;
        public string AccountNumber
        {
            get => _accountNumber;
            set => _accountNumber = CheckNumber(value);
        }

        private string _password;
        public string Password
        {
            get => _password;
            set => _password = CheckPassword(value);
        }

        private decimal _balance;
        public decimal Balance = 0;

        public Client(string AccountNumber, string Password)
        {
            _accountNumber = AccountNumber;
            _password = Password;
        }

        private string CheckNumber(string accNumber)
        {
            accNumber = accNumber.Replace(" ", "");
            if (accNumber.Length != 11)
            {
                throw new ArgumentException("Choose a number that is 11 characters long");
            }
            foreach (char c in accNumber)
            {
                if (!Char.IsDigit(c))
                {
                    throw new ArgumentException("Account number cant contain values different than numbers");
                }
            }

            return accNumber;
        }

        private string CheckPassword(string password)
        {
            password = password.Replace(" ", "");
            if (password.Length < 6 || password.Length > 12)
            {
                throw new ArgumentException("Password must be 6-12 characters");
            }
            foreach (char c in password)
            {
                if (Char.IsSymbol(c))
                {
                    throw new ArgumentException("Password can't contain symbols");
                }
            }

            return password;
        }

        public decimal Deposit(decimal value) => value > 0 ? Balance += value : throw new ArgumentException("Deposit must be larger than 0");
        public decimal Withdrawal(decimal value)
        {
            if (value > Balance)
            {
                throw new ArgumentException("Not enough money");
            }
            if (value <= 0)
            {
                throw new ArgumentException("Withdrawal must be larger than 0");
            }
            Balance -= value;

            return Balance;
        }
    }
}


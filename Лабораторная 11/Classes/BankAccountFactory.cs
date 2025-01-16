using System;
using System.Collections;

namespace Лабораторная_11.Classes
{
    internal class BankAccountFactory
    {
        private Dictionary<string, BankAccount> accounts = new Dictionary<string, BankAccount>();
        private int accountCounter = 0;
        public string CreateAccount()
        {
            string newAccountNumber = GenerateAccountNumber();
            BankAccount newAccount = new BankAccount(newAccountNumber);
            accounts[newAccountNumber] = newAccount;
            return newAccountNumber;
        }
        public bool CloseAccount(string accountNumber)
        {
            return accounts.Remove(accountNumber);
        }
        private string GenerateAccountNumber()
        {
            accountCounter++;
            return "ACC" + accountCounter.ToString("D6");
        }
    }
}

using System;
using System.Security.AccessControl;
using System.Transactions;
using static Лабораторная_11.Classes.EnumBankAccount;

namespace Лабораторная_11.Classes
{
    class BankAccount
    {
        public string AccountNumber { get; private set; }
        public decimal Balance { get; private set;}
        private AccType accountType;
        private Random random = new Random();
        private int accountNumberCounter = 0;
        private string accountNumber;
        internal BankAccount(string accountNumber)
        {
            AccountNumber = accountNumber;
            Balance = 0;
        }

        public void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                Balance += amount;
            }
            else
            {
                Console.WriteLine("Сумма должна быть положительной.");
            }
        }

        public void Withdraw(decimal amount)
        {
            if (amount > 0 && amount <= Balance)
            {
                Balance -= amount;
            }
            else
            {
                Console.WriteLine("Недостаточно средств на счете.");
            }
        }
        public void Transfer(BankAccount destinationAccount, decimal amount)
        {
            Withdraw(amount);
            destinationAccount.Deposit(amount);
            Console.WriteLine($"Переведено {amount} на счет {destinationAccount.AccountNumber}.");
        }
        private string GenerateAccountNumber()
        {
            int randomPart = random.Next(1000, 1000000);
            accountNumberCounter++;
            return $"AC{randomPart}-{accountNumberCounter:0000}";
        }
        public void PrintAccountInfo()
        {
            Console.WriteLine($"Номер счета: {AccountNumber}");
            Console.WriteLine($"Баланс: {Balance}");
            Console.WriteLine($"Тип счета: {accountType}");
        }
    }
}

using System;
using System.Transactions;
using static Лабораторная_12.Classes.EnumBankAccount;

namespace Лабораторная_12.Classes
{
    class BankAccount3
    {
        private static Random random = new Random();
        private static int accountNumberCounter = 0;
        private string accountNumber;
        private decimal balance;
        private AccType accountType;
        private Queue<Transaction> transactions;
        private bool disposed = false;

        public BankAccount3() : this(0, AccType.Current) { }
        public BankAccount3(decimal balance) : this(balance, AccType.Current) { }
        public BankAccount3(AccType accountType) : this(0, accountType) { }
        public BankAccount3(decimal balance, AccType accountType)
        {
            this.balance = balance;
            this.accountType = accountType;
            this.accountNumber = UnicAccountNumber();
            this.transactions = new Queue<Transaction>();
        }
        private string UnicAccountNumber()
        {
            int randomPart = random.Next(1000, 1000000);
            accountNumberCounter++;
            return $"AC{randomPart}-{accountNumberCounter:0000}";
        }
        public void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                balance += amount;
            }
            else
            {
                Console.WriteLine("Сумма должна быть положительной.");
            }
            transactions.Enqueue(new Transaction(amount));
        }
        public void Withdraw(decimal amount)
        {
            if (amount > 0 && amount <= balance)
            {
                balance -= amount;
            }
            else
            {
                Console.WriteLine("Недостаточно средств на счете.");
            }
            transactions.Enqueue(new Transaction(amount));
        }
        public void Transfer(BankAccount3 fromAccount, BankAccount3 toAccount, decimal amount)
        {
            fromAccount.Withdraw(amount);
            toAccount.Deposit(amount);
        }
        public Queue<Transaction> GetTransactions()
        {
            return transactions;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    WriteTransactionsToFile();
                }
                disposed = true;
            }
        }

        private void WriteTransactionsToFile()
        {
            string filePath = "transactions.txt";

            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                while (transactions.Count > 0)
                {
                    Transaction transaction = transactions.Dequeue();
                    writer.WriteLine($"{DateTime.Now}: Transaction amount: {transaction.Amount}, Type: {(transaction.Amount > 0 ? "Deposit" : "Withdraw")}");
                }
            }
        }

        public void PrintAccountInfo()
        {
            Console.WriteLine($"Номер счета: {accountNumber}");
            Console.WriteLine($"Баланс: {balance}");
            Console.WriteLine($"Тип счета: {accountType}");
        }
        public static bool operator ==(BankAccount3 a, BankAccount3 b)
        {
            if (ReferenceEquals(a, b)) return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null)) return false;
            return a.accountNumber == b.accountNumber && a.accountType == b.accountType;
        }

        public static bool operator !=(BankAccount3 a, BankAccount3 b)
        {
            return !(a == b);
        }
        public override bool Equals(object obj)// Переопределение метода Equals
        {
            if (obj == null || GetType() != obj.GetType()) return false;
            BankAccount3 other = (BankAccount3)obj;
            return this == other;
        }
        public override int GetHashCode()//метод GetHashCode
        {
            return HashCode.Combine(accountNumber, accountType);
        }
        public override string ToString()// Переопределение метода ToString
        {
            return $"Номер счета: {accountNumber}, Баланс: {balance}, Тип счета: {accountType}";
        }

    }
}

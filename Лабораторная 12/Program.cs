using System;
using Лабораторная_12.Classes;
using static Лабораторная_12.Classes.EnumBankAccount;

namespace HomeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            Task1();
            Task2();
            Task3();
            Task4();
        }

        static void Task1()
        {
            /*Упражнение 12.1 Для класса банковский счет переопределить операторы == и != для
сравнения информации в двух счетах. Переопределить метод Equals аналогично оператору
==, не забыть переопределить метод GetHashCode(). Переопределить метод ToString() для
печати информации о счете. Протестировать функционирование переопределенных методов
и операторов на простом примере.*/
            Console.WriteLine("Упражнение 12.1");
            BankAccount3 account1 = new BankAccount3(3500, AccType.Current);
            BankAccount3 account2 = new BankAccount3(2400, AccType.Current);
            BankAccount3 account3 = new BankAccount3(500, AccType.Savings);

            account1.PrintAccountInfo();
            account2.PrintAccountInfo();
            account3.PrintAccountInfo();

            Console.WriteLine($"Сравнение account1 и account2: {account1 == account2}");
            Console.WriteLine($"Сравнение account1 и account3: {account1 == account3}");

            Console.WriteLine(account1);
            Console.WriteLine(account2);
            Console.WriteLine(account3);
            account1.Dispose();
            account2.Dispose();
            account3.Dispose();
        }
        static void Task2()
        {
            /*Упражнение 12.2 Создать класс рациональных чисел. В классе два поля – числитель и
знаменатель. Предусмотреть конструктор. Определить операторы ==, != (метод Equals()), <,
>, <=, >=, +, – , ++, --. Переопределить метод ToString() для вывода дроби. Определить
операторы преобразования типов между типом дробь, float, int. Определить операторы *, /,
%.*/
            Console.WriteLine("Упражнение 12.2");
            Rational r1 = new Rational(1, 2);
            Rational r2 = new Rational(3, 4);

            Console.WriteLine($"Дробь 1: {r1}");
            Console.WriteLine($"Дробь 2: {r2}");

            Rational sum = r1 + r2;
            Console.WriteLine($"Сумма: {sum}");

            Rational difference = r1 - r2;
            Console.WriteLine($"Разность: {difference}");

            Rational product = r1 * r2;
            Console.WriteLine($"Произведение: {product}");

            Rational quotient = r1 / r2;
            Console.WriteLine($"Частное: {quotient}");

            Console.WriteLine($"Дробь 1 как тип float: {(float)r1}");
            Console.WriteLine($"Дробь 2 как тип int: {(int)r2}"); 
        }
        static void Task3()
        {
            /*Домашнее задание 12.1 На перегрузку операторов. Описать класс комплексных чисел.
Реализовать операцию сложения, умножения, вычитания, проверку на равенство двух
комплексных чисел. Переопределить метод ToString() для комплексного числа.
Протестировать на простом примере.*/
            Console.WriteLine("Домашнее задание 12.1");
            Complex c1 = new Complex(2, 3);
            Complex c2 = new Complex(4, -5);

            Console.WriteLine($"C1: {c1}");
            Console.WriteLine($"C2: {c2}");

            Complex sum = c1 + c2;
            Console.WriteLine($"Сумма: {sum}");

            Complex difference = c1 - c2;
            Console.WriteLine($"Разность: {difference}");

            Complex product = c1 * c2;
            Console.WriteLine($"Произведение: {product}");

            bool areEqual = c1 == c2;
            Console.WriteLine($"C1 равно C2: {areEqual}");

            Complex c3 = new Complex(2, 3);
            bool areEqual2 = c1 == c3;
            Console.WriteLine($"C1 равно C3: {areEqual2}");
        }
        static void Task4()
        {
            /*Домашнее задание 12.2 Написать делегат, с помощью которого реализуется сортировка
книг. Книга представляет собой класс с полями Название, Автор, Издательство и
конструктором. Создать класс, являющийся контейнером для множества книг (массив книг).
В этом классе предусмотреть метод сортировки книг. Критерий сортировки определяется
экземпляром делегата, который передается методу в качестве параметра. Каждый экземпляр
делегата должен сравнивать книги по какому-то одному полю: названию, автору,
издательству.*/
            Console.WriteLine("Домашнее задание 12.2");
            Book[] books = new Book[]
        {
            new Book("Война и Мир", "Л.Н. Толстой","АСТ" ),
            new Book("Отцы и Дети", "Тургенев", "АСТ"),
            new Book("Голодные игры", "С. Коллинз", "Эксмо"),
            new Book("Магическая битва", "Акутами", "Азбука")
        };

            BookCollection bookCollection = new BookCollection(books);

            Console.WriteLine("Книги, отсортированные по названию:");
            bookCollection.Sort(BookComparer.CompareByTitle);
            bookCollection.Display();

            Console.WriteLine("Книги, отсортированные по автору:");
            bookCollection.Sort(BookComparer.CompareByAuthor);
            bookCollection.Display();

            Console.WriteLine("Книги, отсортированные по издательству:");
            bookCollection.Sort(BookComparer.CompareByPublisher);
            bookCollection.Display();
        }
    }
}
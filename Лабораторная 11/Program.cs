using System;
using Лабораторная_11.Classes;
using libr;
using libr2;

namespace HomeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            Task1();
            Task2();
        }

        static void Task1()
        {
            /*Упражнение 11.1.Создать новый класс, который будет являться фабрикой объектов класса
      банковский счет. Изменить модификатор доступа у конструкторов класса банковский счет на
      internal. Добавить в фабричный класс перегруженные методы создания счета CreateAccount,
      которые бы вызывали конструктор класса банковский счет и возвращали номер созданного
      счета. Использовать хеш-таблицу для хранения всех объектов банковских счетов в
      фабричном классе. В фабричном классе предусмотреть метод закрытия счета, который
      удаляет счет из хеш-таблицы (методу в качестве параметра передается номер банковского
      счета). Использовать утилиту ILDASM для просмотра структуры классов.*/
            Console.WriteLine("Упражнение 11.1");
            BankAccountFactory factory = new BankAccountFactory();
            string account1 = factory.CreateAccount();
            string account2 = factory.CreateAccount();
            Console.WriteLine($"Создан счет: {account1}");
            Console.WriteLine($"Создан счет: {account2}");
            if (factory.CloseAccount(account1))
            {
                Console.WriteLine($"Счет {account1} закрыт.");
            }
            else
            {
                Console.WriteLine($"Не удалось закрыть счет {account1}.");
            }
        }
        static void Task2()
        {
            /*Домашнее задание 11.1 Для реализованного класса из домашнего задания 7.1 создать
новый класс Creator, который будет являться фабрикой объектов класса здания. Для этого
изменить модификатор доступа к конструкторам класса, в новый созданный класс добавить
перегруженные фабричные методы CreateBuild для создания объектов класса здания. В
классе Creator все методы сделать статическими, конструктор класса сделать закрытым. Для
хранения объектов класса здания в классе Creator использовать хеш-таблицу. Предусмотреть
возможность удаления объекта здания по его уникальному номеру из хеш-таблицы. Создать
тестовый пример, работающий с созданными классами.*/
            Console.WriteLine("Домашнее задание 11.1");
            Creator.CreateBuild(45, 17, 54, 2);
            Creator.CreateBuild(35, 11, 150, 3);
            Creator.CreateBuild(25, 5, 50, 1);
            Console.WriteLine("Список зданий:");
            Creator.PrintBuildings();

            int buildingIdToRemove = 1;
            if (Creator.RemoveBuilding(buildingIdToRemove))
            {
                Console.WriteLine($"Здание с уникальным номером {buildingIdToRemove} успешно удалено.");
            }
            else
            {
                Console.WriteLine($"Не удалось удалить здание с уникальным номером {buildingIdToRemove}.");
            }
            Console.WriteLine("Список зданий после удаления:");
            Creator.PrintBuildings();
        }
    }
}
using System;
using Домашнее_задание_10.Classes;

namespace HomeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            Task1();
            Task2();
        }
        private static List<Student> students = new List<Student>();

        static void Task1()
        {
            /*Задача 1. Студентам периодически необходимо участвовать в различных мероприятиях (студенты
могут быть в разных группах). Участвовать каждый студент во всех мероприятиях не должен. Однако существуют
студенты-халявщики, которые не хотят делать вообще ничего. Поэтому было решено, что
человек, не участвовавший ни в одном из последних трех мероприятий с большей
вероятностью будет выбран в качестве участника.
Необходимо создать программу, которая будет из текстового файла считывать всех студентов
и их принадлежность к группе. Далее пользователь создает мероприятие с необходимым
количеством участников, оно записывается в специально созданный файл. Далее дозаписать
в файл с мероприятием всех участников мероприятия.*/
            Console.WriteLine("Задача 1");
            LoadStudents("C:\\Users\\User\\source\\repos\\Домашнее задание 10\\Домашнее задание 10\\Classes\\students..txt");
            string eventName = GetInput("Введите название мероприятия:");
            string eventDate = GetInput("Введите дату мероприятия (дд.мм.гггг):");
            int participantsPerGroup = GetParticipantsCount("Введите количество участников от каждой группы:");

            ConductRaffle(eventName, eventDate, participantsPerGroup);
        }

        private static string GetInput(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        private static int GetParticipantsCount(string message)
        {
            Console.WriteLine(message);
            int count;
            while (!int.TryParse(Console.ReadLine(), out count) || count <= 0)
            {
                Console.WriteLine("Пожалуйста, введите корректное положительное число.");
            }
            return count;
        }

        private static void LoadStudents(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Файл со студентами не найден.");
                return;
            }

            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 2)
                {
                    string name = parts[0].Trim();
                    string group = parts[1].Trim();
                    students.Add(new Student(name, group));
                }
            }
        }

        private static void ConductRaffle(string eventName, string eventDate, int participantsPerGroup)
        {
            List<IGrouping<string, Student>> groups = students.GroupBy(s => s.Group).ToList();

            if (groups.Count < 2)
            {
                Console.WriteLine("Необходимо как минимум две группы для проведения розыгрыша.");
                return;
            }

            List<Student> selectedStudents = new List<Student>();

            foreach (IGrouping<string, Student> group in groups)
            {
                int currentCount = selectedStudents.Count(sg => sg.Group == group.Key);
                int remainingSpots = participantsPerGroup - currentCount;

                if (remainingSpots > 0)
                {
                    List<Student> studentsInGroup = group.ToList();

                    List<Student> eligibleStudents = new List<Student>();

                    foreach (Student student in studentsInGroup)// Проверяем, свободен ли студент
                    {
                        if (student.IsFree() && eligibleStudents.Count < remainingSpots)
                        {
                            eligibleStudents.Add(student);
                        }
                    }
                    foreach (Student student in studentsInGroup)
                    {
                        if (!eligibleStudents.Contains(student) && eligibleStudents.Count < remainingSpots)
                        {
                            eligibleStudents.Add(student);
                        }
                    }
                    foreach (Student student in eligibleStudents)
                    {
                        student.UpdateParticipation(true);
                        selectedStudents.Add(student);
                    }
                }
            }

            RecordEvent(eventName, eventDate, selectedStudents);
        }

        private static void RecordEvent(string eventName, string eventDate, List<Student> selectedStudents)
        {
            string eventRecord = $"{eventDate}; {eventName}; {string.Join(", ", selectedStudents.Select(s => $"{s.Name} ({s.Group})"))}";

            using (StreamWriter writer = new StreamWriter("events.txt", true))
            {
                writer.WriteLine(eventRecord);
            }

            Console.WriteLine("Розыгрыш завершен. Результаты записаны в файл events.txt.");
        }
        static void Task2()
        {
            /*Задача 2. У каждого есть хобби. Написать программу для слежения за интересующим вас событием (выход сериала, концерт и т.д.)
    Создать не менее трех человек с разными увлечениями. Пользователь вводит (можно из
    заранее определенного списка) событие. Если событие совпало с увлечением кого-либо,
    вывести его реакцию на событие.*/
            Console.WriteLine("Задача 2");
            Person alice = new Person("Маша");
            alice.AddHobby(new HobbyEvent("сериал", "выход сериала", "Наконец то смогу посмотреть этот сериал!"));

            Person bob = new Person("Катя");
            bob.AddHobby(new HobbyEvent("рисование", "Арт-выстовка", "Классно! Смогу сходить с друзьями!"));

            Person charlie = new Person("Азалия");
            charlie.AddHobby(new HobbyEvent("книги", "выход книги", "Не могу дождаться, когда прочитаю это!"));

            List<Person> people = new List<Person> { alice, bob, charlie };
            Console.WriteLine("Введите событие (выход сериала, Арт-выстовка, выход книг):");
            string eventInput = Console.ReadLine();

            bool eventMatched = false;

            foreach (Person person in people)
            {
                foreach (HobbyEvent hobbyEvent in person.Hobbies)
                {
                    if (eventInput.Contains(hobbyEvent.Hobby) || eventInput.Contains(hobbyEvent.EventDescription))
                    {
                        Console.WriteLine($"{person.Name}: {hobbyEvent.Reaction}");
                        eventMatched = true;
                    }
                }
            }
            if (!eventMatched)
            {
                Console.WriteLine("Никто не заинтересован в этом событии.");
            }
        }
    }
}

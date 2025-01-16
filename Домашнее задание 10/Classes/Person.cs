using System;

namespace Домашнее_задание_10.Classes
{
    internal class Person
    {
        public string Name { get; set; }
        public List<HobbyEvent> Hobbies { get; set; }

        public Person(string name)
        {
            Name = name;
            Hobbies = new List<HobbyEvent>();
        }
        public void AddHobby(HobbyEvent hobbyEvent)
        {
            Hobbies.Add(hobbyEvent);
        }
    }
}

using System;

namespace Домашнее_задание_10.Classes
{
    class Student
    {
        public string Name { get; set; }
        public string Group { get; set; }
        public List<bool> ParticipationHistory { get; set; }
        public Student(string name, string group)
        {
            Name = name;
            Group = group;
            ParticipationHistory = new List<bool> { false, false, false }; 
        }

        public void UpdateParticipation(bool participated)
        {
            ParticipationHistory.Add(participated);
            if (ParticipationHistory.Count > 3)
                ParticipationHistory.RemoveAt(0);
        }
        public bool IsFree()
        {
            return !ParticipationHistory.TakeLast(3).Any(p => p);
        }
    }
}

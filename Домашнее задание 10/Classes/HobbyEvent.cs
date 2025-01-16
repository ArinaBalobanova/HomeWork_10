using System;


namespace Домашнее_задание_10.Classes
{
    internal class HobbyEvent
    {
        public string Hobby { get; set; }
        public string EventDescription { get; set; }
        public string Reaction { get; set; }

        public HobbyEvent(string hobby, string eventDescription, string reaction)
        {
            Hobby = hobby;
            EventDescription = eventDescription;
            Reaction = reaction;
        }
    }
}

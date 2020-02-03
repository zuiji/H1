using System.Collections.Generic;

namespace FirstInFirstOut
{
    class Guest
    {
        public string Name { get; set; }
        public byte Age { get; set; }

        public Guest(string name, byte age, Queue<Guest> guests)
        {
            Name = name;
            Age = age;
        }
    }
}
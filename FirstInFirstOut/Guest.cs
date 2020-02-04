using System.Collections.Generic;

namespace FirstInFirstOut
{
    public class Guest
    {
        public string Name { get; set; }
        public byte Age { get; set; }
 

        public Guest(string name, byte age)
        {
            Name = name;
            Age = age;
        }
    }
}
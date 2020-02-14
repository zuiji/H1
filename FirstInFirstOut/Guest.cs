using System.Collections.Generic;

namespace FirstInFirstOut
{
    public class Guest
    {
        //properties that are able to get the data from and set data in.
        public string Name { get; set; }
        public byte Age { get; set; }
 
        //my constructor that needs augments name and age.
        public Guest(string name, byte age)
        {
            Name = name;
            Age = age;
        }
    }
}
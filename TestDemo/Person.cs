using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeiCui.Unity
{
    namespace SortDemo
    {
        public class Person
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
            public int Weight { get; set; }
            public Person() : this(-1, "Defalut", -1, -1) { }
            public Person(int id, string name, int age, int weight)
            {
                Id = id;
                Name = name;
                Age = age;
                Weight = weight;
            }

        }
    }
}


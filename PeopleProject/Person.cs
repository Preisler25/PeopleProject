using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleProject
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public bool IsStudent { get; set; }
        public int Score { get; set; }

        public Person(string name, int age, bool isStudent, int score)
        {
            Name = name;
            Age = age;
            IsStudent = isStudent;
            Score = score;
        }
    }
}
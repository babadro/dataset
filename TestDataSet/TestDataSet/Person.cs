using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDataSet
{
    public class Person
    {
        public Person(string country, int age, string gender, double grossSalary)
        {
            Country = country;
            Age = age;
            Gender = gender;
            GrossSalary = grossSalary;
        }

        public string Country { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public double GrossSalary { get; set; }
    }
}

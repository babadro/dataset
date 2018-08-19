using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDataSet
{
    class Program
    {
        static void Main(string[] args)
        {
            var persons = new List<Person>
            {
                #region "big data"
                //new Person("Russia", 18, "Male", 30000),
                //new Person("Russia", 18, "Male", 180000),
                //new Person("Russia", 40, "Male", 50000),
                //new Person("Russia", 40, "Male", 120),
                //new Person("Russia", 18, "Female", 15000),
                //new Person("Russia", 18, "Female", 20000),
                //new Person("Russia", 40, "Female", 55000),
                //new Person("Russia", 40, "Female", 70000),

                //new Person("USA", 20, "Male", 1000),
                //new Person("USA", 20, "Male", 3000),
                //new Person("USA", 30, "Male", 2000),
                //new Person("USA", 30, "Male", 4000),
                //new Person("USA", 40, "Male", 4000),
                //new Person("USA", 40, "Male", 6000),
                //new Person("USA", 50, "Male", 9000),
                //new Person("USA", 50, "Male", 11000),
                //new Person("USA", 20, "Female", 2000),
                //new Person("USA", 20, "Female", 4000),
                //new Person("USA", 30, "Female", 4000),
                //new Person("USA", 20, "Female", 6000),
                //new Person("USA", 40, "Female", 6000),
                //new Person("USA", 20, "Female", 8000),
                //new Person("USA", 50, "Female", 9000),
                //new Person("USA", 20, "Female", 11000),
                #endregion

                new Person("USA", 20, "Male", 2000),
                new Person("USA", 30, "Male", 3000),
                new Person("USA", 40, "Male", 5000),
                new Person("USA", 50, "Male", 10000),
                new Person("USA", 20, "Female", 3000),
                new Person("USA", 30, "Female", 5000),
                new Person("USA", 40, "Female", 7000),
                new Person("USA", 50, "Female", 10000),

                new Person("UK", 20, "Male", 2500),
                new Person("UK", 30, "Male", 3500),
                new Person("UK", 40, "Male", 4500),
                new Person("UK", 50, "Male", 7000),
                new Person("UK", 20, "Female", 2000),
                new Person("UK", 30, "Female", 3000),
                new Person("UK", 40, "Female", 4000),
                new Person("UK", 50, "Female", 5000)
            };

            var obj = new MyDataSet(persons);
            foreach (var country in obj.Countries)
                foreach (var age in obj.Ages)
                    foreach (var gender in obj.Genders)
                        Console.WriteLine($"{country} age: {age} gender: {gender} average: {obj.GetAverageGrossSalary(country, age, gender)}");

            //{
            //    var average = obj.GetAverageGrossSalary(country, age);
            //    obj.SetAvarageGrossSalary(country, age, average);
            //    Console.WriteLine($"{country} age: {age} average: {average}");
            //}

            Console.WriteLine(String.Format("|{0,10}|{1,10}|{2,10}|{3,10}|", "first row", 11, true, 33.2));
            Console.ReadLine();
        }
    }
}

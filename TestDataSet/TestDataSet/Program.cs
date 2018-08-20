using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDataSet
{
    class Program
    {
        static int tableWidth = 77;

        static void PrintLine()
        {
            Console.WriteLine(new string('-', tableWidth));
        }

        static void PrintRow(params (string, int)[] columns)
        {
            //var columnsCount = columns.Aggregate<>;
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "|";

            foreach (var column in columns)
            {
                var w = width * column.Item2;
                row += $"{AlignCentre(column.Item1, width)}|";
            }

            Console.WriteLine(row);
        }

        static string AlignCentre(string text, int width)
        {
            if (text != null)
                text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }

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

            //PrintRow(new[] { ("Average", 1), ("Male", 4), ("Female", 4) });
            //PrintRow(new[] { "", "20", "30", "40", "50", "20", "30", "40", "50" });

            var person = persons.First();
            var temp = person?.GetType().GetProperty("Gender")?.PropertyType;//.GetValue(person, null);
            Console.WriteLine(temp);

            Console.ReadLine();
        }
    }
}

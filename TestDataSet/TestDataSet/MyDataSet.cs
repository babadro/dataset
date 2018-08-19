using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDataSet
{
    public class MyDataSet
    {
        private List<Person> _persons;
        private Dictionary<(string, int), double> _average;

        public MyDataSet(List<Person> persons)
        {
            _persons = persons;
            _average = new Dictionary<(string, int), double>();
        }

        public double GetAverageGrossSalary(string country, int age)
        {
            if (_average.TryGetValue((country, age), out double average))
                return average;

            return _persons
                .Where(p => p.Country == country && p.Age == age)
                .Average(p => p.GrossSalary);
        }

        public IEnumerable<string> Countries => _persons.Select(p => p.Country).Distinct();

        public IEnumerable<int> Ages => _persons.Select(p => p.Age).Distinct();

        public void SetAvarageGrossSalary(string country, int age, double average)
        {
            _average[(country, age)] = average;
        }
    }
}

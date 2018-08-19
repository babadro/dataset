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
            if (_average.TryGetValue(new Tuple<string, int>(country, age), out double value)
            return _persons
                .Where(p => p.Country == country && p.Age == age)
                .Average(p => p.GrossSalary);
        }
    }
}

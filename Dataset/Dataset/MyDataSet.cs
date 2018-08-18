using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dataset
{
    public class MyDataSet
    {
        private List<Person> _persons;
        private Dictionary<Tuple<string, int>, double> _average;

        public MyDataSet(List<Person> persons)
        {
            _persons = persons;
            _average = new Dictionary<Tuple<string, int>, double>();
        }

        public double GetAverageGrossSalary(string country, int age)
        {
            if (_average.TryGetValue())
            return _persons
                .Where(p => p.Country == country && p.Age == age)
                .Average(p => p.GrossSalary);
        }
    }
}

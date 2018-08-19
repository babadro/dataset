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
        private Dictionary<(string, string, int), double> _average2;
        //private Dictionary<string, object> _results;

        public MyDataSet(List<Person> persons)
        {
            _persons = persons;
            _average = new Dictionary<(string, int), double>();
            _average2 = new Dictionary<(string, string, int), double>();
        }

        //public MyDataSet(List<Person> persons, string row, string group, Func<string, string> aggregateFunc)
        //{
        //
        //}
        //
        //public MyDataSet(List<Person> persons, string row, string[] groups, Func<IEnumerable<T>, string> aggregateFunc)
        //{
        //
        //}

        public double GetAverageGrossSalary(string country, int age)
        {
            if (_average.TryGetValue((country, age), out double average))
                return average;

            return _persons
                .Where(p => p.Country == country && p.Age == age)
                .Average(p => p.GrossSalary);
        }

        public double GetAverageGrossSalary(string country, int age, string gender)
        {
            if (_average2.TryGetValue((country, gender, age), out double average))
                return average;

            return _persons
                .Where(p => p.Country == country && p.Age == age && p.Gender == gender)
                .Average(p => p.GrossSalary);
        }

        public IEnumerable<string> Countries => _persons.Select(p => p.Country).Distinct();

        public IEnumerable<int> Ages => _persons.Select(p => p.Age).Distinct();

        public IEnumerable<string> Genders => _persons.Select(p => p.Gender).Distinct();

        public void SetAvarageGrossSalary(string country, int age, double average)
        {
            _average[(country, age)] = average;
        }

        public void SetAvarageGrossSalary(string country, string gender, int age, double average)
        {
            _average2[(country, gender, age)] = average;
        }

        public void SetAvarageGrossSalary(string row, params string[] groups)
        {
            //_average[(country, age)] = average;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace TestDataSet
{
    public class MyDataSet<T>
    {
        private List<Person> _persons;
        private Dictionary<(string, int), double> _average;
        private Dictionary<(string, string, int), double> _average2;
        //private Dictionary<string, object> _results;
        private Dictionary<string, T> _data;
        private Func<List<Person>, T> _aggregateFunc;
        private string _row;
        private string _group;
        private PropertyInfo _rowInfo;
        private PropertyInfo _groupInfo;
        private readonly IEnumerable<Item<Person>> _items;

        public MyDataSet(List<Person> persons)
        {
            _persons = persons;
            _average = new Dictionary<(string, int), double>();
            _average2 = new Dictionary<(string, string, int), double>();
        }

        public MyDataSet(List<Person> persons, string row, string group, Func<List<Person>, T> aggregateFunc)
        {
            if (persons == null)
                throw new ArgumentNullException(nameof(persons));
            if (row == null)
                throw new ArgumentNullException(nameof(row));
            if (group == null)
                throw new ArgumentNullException(nameof(group));


            var rowInfo = typeof(Person).GetProperty(_row);
            var groupInfo = typeof(Person).GetProperty(_group);

            if (rowInfo == null)
                throw new ArgumentException($"Row {row} hasn't been found.", row);
            if (groupInfo == null)
                throw new ArgumentException($"Row {group} hasn't been found.", group);

            _persons = persons;
            _data = new Dictionary<string, T>();
            _aggregateFunc = aggregateFunc;
            _row = row;
            _group = group;
            _items = _persons.Select(item => new Item<Person>(item, _rowInfo.GetValue(item), _groupInfo.GetValue(item)));
        }
        
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

        public T GetValue(string prop1Val, string prop2Val, Func<List<Person>, T> aggregateFunc)
        {
            //var rowInfo = _persons.GetType().GetProperty(row);
            //var rowType = rowInfo?.PropertyType;
            var filteredPersons = _persons.Where(p =>
                p.GetType().GetProperty(_row).GetValue(p, null).ToString() == prop1Val
                && p.GetType().GetProperty(_group).GetValue(p, null).ToString() == prop2Val
            );

            

            

            var filteredPersons2 = _items.Where(item => prop1Val == null ?
                item.RowVal == null
                : item.RowVal != null && Object.Equals(item.RowVal, ))


        }

        //private T3 GetValue<T1, T2, T3>(T1 row, T2 group, Func<List<Person>, T3> aggregateFunc)
        //{
        //    return _persons
        //        .Where(p => p.row == row)
        //}
        

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

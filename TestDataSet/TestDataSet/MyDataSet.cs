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
        public Dictionary<string, T> Data;
        private readonly IEnumerable<Item<Person>> _items;

        public MyDataSet(List<Person> persons, string row, string group, Func<List<Person>, T> aggregateFunc)
        {
            if (persons == null)
                throw new ArgumentNullException(nameof(persons));
            if (row == null)
                throw new ArgumentNullException(nameof(row));
            if (group == null)
                throw new ArgumentNullException(nameof(group));


            var rowInfo = typeof(Person).GetProperty(row);
            var groupInfo = typeof(Person).GetProperty(group);

            if (rowInfo == null)
                throw new ArgumentException($"Row {row} hasn't been found.", row);
            if (groupInfo == null)
                throw new ArgumentException($"Row {group} hasn't been found.", group);
            
            Data = new Dictionary<string, T>();
            _items = persons.Select(item => new Item<Person>(item, rowInfo.GetValue(item).ToString(), groupInfo.GetValue(item).ToString()));
            foreach (var rowVal in Rows)
                foreach (var groupVal in Groups)
                    SetValue(rowVal, groupVal, GetValue(rowVal, groupVal, aggregateFunc));
        }

        public T GetValue(string prop1Val, string prop2Val, Func<List<Person>, T> aggregateFunc)
        {
         var input = _items.Where(item => string.Equals(item.RowVal.ToString(), prop1Val) && string.Equals(item.GroupVal.ToString(), prop2Val)).Select(item => item.Value).ToList();
            var result = aggregateFunc(input);
            return result;
        }

        public void SetValue(object row, object group, T value)
        {
            var key = string.Concat(row, group);
            Data[key] = value;
        }

        public IEnumerable<string> Rows => _items.Select(i => i.RowVal.ToString()).Distinct();

        public IEnumerable<string> Groups => _items.Select(i => i.GroupVal.ToString()).Distinct();
    }
}

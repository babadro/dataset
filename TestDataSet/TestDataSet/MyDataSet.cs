using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace TestDataSet
{
    public class MyDataSet<T1, T2>
    {
        public Dictionary<string, T2> Data;
        private readonly IEnumerable<Item<T1>> _itemsInfo;

        public MyDataSet(IEnumerable<T1> items, Func<IEnumerable<T1>, T2> aggregateFunc, string row, params string[] groups)
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));
            if (row == null)
                throw new ArgumentNullException(nameof(row));
            if (groups == null)
                throw new ArgumentNullException(nameof(groups));
            if ()

            var rowInfo = typeof(Person).GetProperty(row);
            var groupInfoList;
            foreach (var group in groups)
                groupInfoList.
            var groupInfo = typeof(Person).GetProperty(group);

            if (rowInfo == null)
                throw new ArgumentException($"Row {row} hasn't been found.", row);
            if (groupInfo == null)
                throw new ArgumentException($"Row {group} hasn't been found.", group);
            
            Data = new Dictionary<string, T2>();
            _itemsInfo = items.Select(item => new Item<T1>(item, rowInfo.GetValue(item).ToString(), groupInfo.GetValue(item).ToString()));
            foreach (var rowVal in Rows)
                foreach (var groupVal in Groups)
                    SetValue(rowVal, groupVal, GetValue(rowVal, groupVal, aggregateFunc));
        }

        public T2 GetValue(string prop1Val, string prop2Val, Func<IEnumerable<T1>, T2> aggregateFunc)
        {
         var input = _itemsInfo.Where(item => string.Equals(item.RowVal.ToString(), prop1Val) && string.Equals(item.GroupVal.ToString(), prop2Val)).Select(item => item.Value);
            var result = aggregateFunc(input);
            return result;
        }

        public void SetValue(object row, object group, T2 value)
        {
            var key = string.Concat(row, group);
            Data[key] = value;
        }

        public IEnumerable<string> Rows => _itemsInfo.Select(i => i.RowVal.ToString()).Distinct();

        public IEnumerable<string> Groups => _itemsInfo.Select(i => i.GroupVal.ToString()).Distinct();
    }
}

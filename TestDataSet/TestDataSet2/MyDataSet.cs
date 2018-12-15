using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestDataSet2
{
    public class MyDataSet
    {
        private Func<IEnumerable<Person>, double> _aggregateFunc;
        
        public MyDataSet(IEnumerable<Person> items, string[] rows, string[] cols, Func<IEnumerable<Person>, double> aggregateFunc)
        {
            _aggregateFunc = aggregateFunc;
        }

        private double GetResult(List<Person> items, List<string> groups)
        {
            if (groups.Count == 0)
                return _aggregateFunc(items);

            groups.RemoveAt(0);
            items.RemoveAt(0); // Mocking filtering items;
            return GetResult(items, groups);
        }
    }
}

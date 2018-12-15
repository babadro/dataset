using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestDataSet2
{
    public class MyDataSet
    {
        private Func<IEnumerable<Person>, double> _aggregateFunc;
        private List<Row> _table;
        
        public MyDataSet(IEnumerable<Person> items, string[] rowNames, string[] cols, Func<IEnumerable<Person>, double> aggregateFunc)
        {
            _aggregateFunc = aggregateFunc;
            foreach (var rowName in rowNames)
            {
                var cells
                var row = new Row() { Name = rowName };
            }
        }

        private double GetResult(List<Person> items, List<string> colNames)
        {
            if (colNames.Count == 0)
                return _aggregateFunc(items);

            colNames.RemoveAt(0);
            items.RemoveAt(0); // Mocking filtering items;
            return GetResult(items, colNames);
        }
    }
}

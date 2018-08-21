using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDataSet
{
    public class Item<T>
    {
        public Item(T value, object rowVal, object groupVal)
        {
            Value = value;
            RowVal = rowVal;
            GroupVal = groupVal;
        }

        public T Value;
        public object RowVal;
        public object GroupVal;
    }
}

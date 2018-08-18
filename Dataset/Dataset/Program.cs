using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Dataset
{
    class Program
    {
        public DataTable ToDataTable<T>(IEnumerable<T> collection)
        {
            DataTable dt = new DataTable("DataTable");
            Type t = typeof(T);
            PropertyInfo[] pia = t.GetProperties();

            //Inspect the properties and create the columns in the DataTable
            foreach (PropertyInfo pi in pia)
            {
                Type ColumnType = pi.PropertyType;
                if ((ColumnType.IsGenericType))
                {
                    ColumnType = ColumnType.GetGenericArguments()[0];
                }
                dt.Columns.Add(pi.Name, ColumnType);
            }

            //Populate the data table
            foreach (T item in collection)
            {
                DataRow dr = dt.NewRow();
                dr.BeginEdit();
                foreach (PropertyInfo pi in pia)
                {
                    if (pi.GetValue(item, null) != null)
                    {
                        dr[pi.Name] = pi.GetValue(item, null);
                    }
                }
                dr.EndEdit();
                dt.Rows.Add(dr);
            }
            return dt;
        }

        static void Main(string[] args)
        {
            var dataSet = new DataSet("Persons");
            var data = new List<Person>
            {
                //new Person("Russia", 18, "Male", 30000),
                //new Person("Russia", 18, "Male", 180000),
                //new Person("Russia", 40, "Male", 50000),
                //new Person("Russia", 40, "Male", 120),
                //new Person("Russia", 18, "Female", 15000),
                //new Person("Russia", 18, "Female", 20000),
                //new Person("Russia", 40, "Female", 55000),
                //new Person("Russia", 40, "Female", 70000),

                new Person("USA", 20, "Male", 2000),
                new Person("USA", 30, "Male", 3000),
                new Person("USA", 40, "Male", 5000),
                new Person("USA", 50, "Male", 10000),
                new Person("USA", 20, "Female", 3000),
                new Person("USA", 30, "Female", 5000),
                new Person("USA", 40, "Female", 7000),
                new Person("USA", 50, "Female", 10000),

                new Person("UK", 20, "Male", 2500),
                new Person("UK", 30, "Male", 3500),
                new Person("UK", 40, "Male", 4500),
                new Person("UK", 50, "Male", 7000),
                new Person("UK", 20, "Female", 2000),
                new Person("UK", 30, "Female", 3000),
                new Person("UK", 40, "Female", 4000),
                new Person("UK", 50, "Female", 5000),
            };
        }
    }
}

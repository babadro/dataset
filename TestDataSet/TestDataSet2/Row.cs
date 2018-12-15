using System;
using System.Collections.Generic;
using System.Text;

namespace TestDataSet2
{
    public class Row
    {
        public string Name { get; set; }
        public List<Cell> Cells { get; set; }
    }

    public class Cell
    {
        public string Name { get; set; }
        public double Val { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace FinalVersion
{
    public class DataSet : Expression
    {
        private List<double> DSValues;

        public DataSet() : base("Dataset", "ds","m")
        {
            DSValues = new List<double>();
        }

        // To-Do: different methods for passed fetched/unfetched string dataset.
        public void SetValues(List<double> xValues) { DSValues = xValues; }

        public List<double> GetDSValues() { return DSValues; }

        // To-Do: Fetch dataSet method.

    }
}
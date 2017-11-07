using System;

namespace FinalVersion
{
    public class DataSet : Expression
    {
        private double[] DSValues;

        public DataSet()
        {
            Titles.Add("Values");
            InputTypes.Add("m");
        }

        // To-Do: different methods for passed fetched/unfetched string dataset.
        public void SetValues(double[] xValues) { DSValues = xValues; }

        public double[] GetDSValues() { return DSValues; }

        // To-Do: Fetch dataSet method.

    }
}
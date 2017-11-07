using System;

namespace FinalVersion
{
    public class DataSet : Expression
    {
        private double[] Values;

        public DataSet()
        {
            Title = "Values";
            InputType = "m";
        }

        // To-Do: different methods for passed fetched/unfetched string dataset.
        public void SetValues(double[] xValues) { Values = xValues; }

        public double[] GetValues() { return Values; }


        // To-Do: Fetch dataSet method.

    }
}
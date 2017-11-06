using System;
namespace cnit255team
{
    class T_Value
    {
        // Data
        private double Value;
        private double Population_Mean;
        private DataSet DataSet;
        // Sys Data
        public string[] ToChooseData = new string[1];
        public string[,] ToPrintData = new string[1, 2] { { "Pop. Mean:", "s" } };

        public T_Value(double xPop_Mean, DataSet xDataSet)
        {
            SetPopulation_Mean(xPop_Mean);
            SetDataSet(xDataSet);
        }


        public void SetValue(double xValue) { Value = xValue; }
        public void SetPopulation_Mean(double xPop_Mean) { Population_Mean = xPop_Mean; }
        public void SetDataSet(DataSet xDataSet) { DataSet = xDataSet; }

        public double GetValue() { return Value; }
        public double GetPop_Mean() { return Population_Mean; }
        public DataSet GetDataSet() { return DataSet; }
    }
}

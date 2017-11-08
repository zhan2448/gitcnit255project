using System;
namespace FinalVersion
{
    class T_Value : ExpressionComposed
    {
        public T_Value() : base() {
            // Data
            // Values[0] – (double)T_Value.
            Values = new object[1];

            Titles.Add("T_Value");
            InputTypes.Add("s");

            // Associated Data
            // SubExpressions[0] – (PopulationMean).
            // SubExpressions[1] – (Sample)
            SubExpressions = new Expression[2];

            SubExpressions[0] = new PopulationMean();
            SubExpressions[1] = new Sample();
        }

        public void CalculateValues(double xPop_Mean, Sample xDataSet) {
            SetPopulation_Mean(xPop_Mean);
            SetSample(xDataSet);
            double Mean = xDataSet.GetSample_Mean();
            double h_mean = xPop_Mean;
            double sd = xDataSet.GetSample_SD();
            double sampleN = xDataSet.GetSample_Size();

            {

                double temp = Mean - h_mean;
                double temp2 = sd / Math.Sqrt(sampleN);
                double temp3 = temp / temp2;
                temp3 = Math.Abs(temp3);
                temp3 = Math.Round(temp3, 4);

                Values[0] = (double)temp3;
            }
        }
        public void SetPopulation_Mean(double xPop_Mean) { ((PopulationMean)SubExpressions[0]).SetValues(new object[] { (double)xPop_Mean }); }
        public void SetSample(Sample xSample) { SubExpressions[1] = xSample; }

        public Sample GetSample() { return (Sample)SubExpressions[1]; }
        public double GetPopulation_Mean() { return (double)(((PopulationMean)SubExpressions[0]).GetValues())[0]; }
    }
}
using System;
namespace FinalVersion
{
    class T_Value : Expression
    {
        // Data
        private PopulationMean Population_Mean;
        private Sample Sample;

        public T_Value() { 
            Title = "T_Value";
            InputType = "s";
        }

        public void CalculateValue(double xPop_Mean, Sample xDataSet) {
            SetPopulation_Mean(xPop_Mean);
            SetSample(Sample);
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

                Value = temp3;
            }
        }
        public void SetPopulation_Mean(double xPop_Mean) { Population_Mean.CalculateValue(xPop_Mean); }
        public void SetSample(Sample xSample) { Sample = xSample; }

        public Sample GetSample() { return Sample; }
        public double GetPopulation_Mean() { return Population_Mean.GetValue(); }
    }
}
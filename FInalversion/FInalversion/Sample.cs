using System;
using System.Linq;

namespace FinalVersion
{
    public class Sample : Expression
    {
        // Data
        // To-Do: Values should have their own class.
        private Sample Values;
        private double Sample_Mean;
        private double Sample_SD;
        private int Sample_Size;

        // Two constructors meaning there should be two ToChooseData elements.
        public Sample()
        {
            Title = "DataSet";
            Type = "";

            // Setting up additional data
            InputNames[0] = "From Data";
            InputNames[1] = "From Values";
            InputList[1, 0] = "Sample Mean";
            InputList[1, 1] = "Sample S.D.";
            InputList[1, 2] = "Sample Size";
        }

        public void CalculateValue(double[] xDataSet)
        {
            SetSample_Values(xDataSet);

            SetSample_Mean(CalculateSample_Mean(xDataSet));
            SetSample_SD(CalculateSD(xDataSet));
            SetSample_Size(CalculateSample_Size(xDataSet));
        }

        public void CalculateValue(double xMean, double xSD, int xSize)
        {
            SetSample_Mean(xMean);
            SetSample_SD(xSD);
            SetSample_Size(xSize);
        }


        private void SetSample_Values(double[] xDataSet) { Values = xDataSet; }
        public void SetSample_Mean(double xMean) { Sample_Mean = xMean; }
        public void SetSample_SD(double xSD) { Sample_SD = xSD; }
        public void SetSample_Size(int xSize) { Sample_Size = xSize; }


        public double[] GetSample_Values() { return Values; }
        public double GetSample_Mean() { return Sample_Mean; }
        public double GetSample_SD() { return Sample_SD; }
        public int GetSample_Size() { return Sample_Size; }

        public double CalculateSample_Mean(double[] xDataSet)
        {
            double x_bar = xDataSet.Sum() / xDataSet.Length;
            return x_bar;
        }

        public double CalculateSD(double[] xDataSet)
        {
            // Declaring the intermediate values.
            double x_bar;
            double sumOfElements = 0;
            double standardDeviation;

            x_bar = xDataSet.Sum() / xDataSet.Length;

            // Finding the sum of elements.
            foreach (int dataElement in xDataSet)
            {
                sumOfElements += Math.Pow(((double)dataElement - x_bar), 2);
            }

            standardDeviation = Math.Sqrt(sumOfElements / (xDataSet.Length - 1));
            return standardDeviation;
        }

        public int CalculateSample_Size(double[] xDataSet) { return xDataSet.Length; }
    }
}
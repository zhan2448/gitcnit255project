﻿using System;
using System.Linq;

namespace FinalVersion
{
    public class Sample : ExpressionComposed
    {
        // Data
        private DataSet Data_Set;
        // Values[0] – (double)Sample Mean.
        // Values[1] – (double)Sample S.D.
        // Values[2] – (int)Sample Size.


        public Sample()
        {
            Segments.Add("From Data");
            Segments.Add("From Values");

            Titles.Add("Sample Mean");
            Titles.Add("Sample S.D.");
            Titles.Add("Sample Size");

            InputTypes.Add("s");
            InputTypes.Add("s");
            InputTypes.Add("s");
        }

        public Sample(int xSelectedSegment) {}

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


        private void SetSample_Values(double[] xDataSet) { Data_Set.SetValues(xDataSet); }
        public void SetSample_Mean(double xMean) { Values[0] = xMean; }
        public void SetSample_SD(double xSD) { Values[1] = xSD; }
        public void SetSample_Size(int xSize) { Values[2] = xSize; }

        public double[] GetSample_Values() { return Data_Set.GetValues(); }
        public double GetSample_Mean() { return (double)Values[0]; }
        public double GetSample_SD() { return (double)Values[1]; }
        public int GetSample_Size() { return (int)Values[2]; }

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
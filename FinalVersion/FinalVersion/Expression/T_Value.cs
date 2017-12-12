using System;
using System.Linq;
using System.Collections.Generic;

namespace FinalVersion
{
    class T_Value : ExpressionConnected
    {
        public T_Value(bool isPrimitive) : base(
            isPrimitive,
            typeof(T_Value),
        "T_Value",
        "t",
        "s"
        )
        {
            if (isPrimitive)
                return;
            
            // Associated Data
            SegmentsTitles.Add("From Sample");
            SegmentsTitles.Add("From DataSet");

            Expression[] secondSegment = new Expression[4];
            secondSegment[0] = new PopulationMean();
            secondSegment[1] = new Sample_Mean(false);
            secondSegment[2] = new Sample_SD(false);
            secondSegment[3] = new Sample_Size(false);

            Expression[] thirdSegment = new Expression[2];
            thirdSegment[0] = new PopulationMean();
            thirdSegment[1] = new DataSet();


            SubExpressions.Add(secondSegment);
            SubExpressions.Add(thirdSegment);

        }


        public void CalculateValues(PopulationMean xPop_Mean, DataSet xDataSet)
        {
            SetPopulation_Mean((double)xPop_Mean.GetValue());
            SetSample(xDataSet.GetDSValues());
            SetSampleValues(xDataSet);

            double Mean = (double)((Sample_Mean)SubExpressions[1][1]).GetValue();
            double h_mean = (double)((PopulationMean)SubExpressions[2][0]).GetValue();
            double sd = (double)((Sample_SD)SubExpressions[1][2]).GetValue();
            int sampleN = (int)((Sample_Size)SubExpressions[1][3]).GetValue();

            double temp = Mean - h_mean;
            double temp2 = sd / Math.Sqrt(sampleN);
            double temp3 = temp / temp2;
            temp3 = Math.Abs(temp3);
            temp3 = Math.Round(temp3, 4);

            Value = (double)temp3;
        }

        private void SetPopulation_Mean(double xPop_Mean) {
            ((PopulationMean)SubExpressions[1][0]).CalculateValue(xPop_Mean);
        }

        private void SetSample(List<double> xValues) {
            ((DataSet)SubExpressions[2][1]).CalculateValues(xValues);
        }

        private void SetSampleValues(DataSet xDataSet) {
            ((Sample_Mean)SubExpressions[1][1]).CalculateValue(xDataSet.GetDSValues().ToArray());
            ((Sample_SD)SubExpressions[1][2]).CalculateValue(xDataSet.GetDSValues().ToArray());
            ((Sample_Size)SubExpressions[1][3]).CalculateValue(xDataSet.GetDSValues().ToArray());
        }
    }
}
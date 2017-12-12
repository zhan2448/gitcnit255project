using System;
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


        //public void CalculateValues(PopulationMean xPop_Mean, Sample xDataSet) {
            
        //    SetPopulation_Mean((double)xPop_Mean.GetValues()[0]);
        //    SetSample(xDataSet);
        //    double Mean = xDataSet.GetSample_Mean();
        //    double h_mean = (double)xPop_Mean.GetValues()[0];
        //    double sd = xDataSet.GetSample_SD();
        //    double sampleN = xDataSet.GetSample_Size();
        //    {

        //        double temp = Mean - h_mean;
        //        double temp2 = sd / Math.Sqrt(sampleN);
        //        double temp3 = temp / temp2;
        //        temp3 = Math.Abs(temp3);
        //        temp3 = Math.Round(temp3, 4);
        //        Values[0] = (double)temp3;
        //    }
           
        //}

        //public void SetPopulation_Mean(double xPop_Mean) { ((PopulationMean)SubExpressions[0]).SetValues(new object[] { (double)xPop_Mean }); }
        //public void SetSample(Sample xSample) { SubExpressions[1] = xSample; }
        //public Sample GetSample() { return (Sample)SubExpressions[1]; }

        //public double GetPopulation_Mean() { return (double)(((PopulationMean)SubExpressions[0]).GetValues())[0]; }
    }
}
using System;
namespace FinalVersion
{
    class T_Value : ExpressionConnected
    {
        
        public T_Value() : base() {
            // Data
            // Values[0] – (double)T_Value.
            Values = new object[1];

            Titles.Add("T_Values");
            InputTypes.Add("s");


            // Associated Data
            SegmentsTitles = new string[2];
            SegmentsTitles[0] = "From Sample";
            SegmentsTitles[0] = "From DataSet";

            Expression[] firstDimention = new Expression[4];
            firstDimention[0] = new PopulationMean();
            firstDimention[1] = new Sample_Mean();
            ((ExpressionConnected)firstDimention[1]).SetDisableSubexpressions(false);

            firstDimention[2] = new Sample_SD();
            ((ExpressionConnected)firstDimention[2]).SetDisableSubexpressions(false);

            firstDimention[3] = new Sample_Size();
            ((ExpressionConnected)firstDimention[3]).SetDisableSubexpressions(false);


            Expression[] secondDimention = new Expression[2];
            secondDimention[0] = new PopulationMean();
            secondDimention[1] = new DataSet();


            SubExpressions = new Expression[][] { firstDimention, secondDimention };
            //SubExpressions[1].selectedvalue(0,1);
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
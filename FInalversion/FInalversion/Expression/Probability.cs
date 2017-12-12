using System;
namespace FinalVersion
{
    public class Probability : ExpressionConnected
    {
        public Probability(bool isPrimitive) : base(
            isPrimitive,
            typeof(Probability),
            "Probability",
            "p",
            "s"
        )
        {
            if (isPrimitive)
                return;

            SegmentsTitles.Add("From T_Value");

            Expression[] secondSegment = new Expression[1];
            secondSegment[0] = new T_Value(false);

            SubExpressions.Add(secondSegment);
        }

        public void CalculateValue(double xValue) { Value = (double)xValue; }

        public void CalculateValue(T_Value xT) { 
            double[] p = new double[2];

            String[,] t_table = xT.GetT_Table();
            int df = (int)((Sample_Size)xT.GetSubExressions()[1][3]).GetValue() - 1;
            int df2 = 0;
            for (int temp = 1; temp < 36; temp++)
            {
                if (double.Parse(t_table[temp, 0]) > df)
                {
                    df2 = temp - 1;
                    break;
                }
            }

            if (0 == (double)xT.GetValue())
            {
                p = new double[1];
                p[0] = 1.0;
                Value = p[0];
            }
            else if ((double)xT.GetValue() > double.Parse(t_table[df2, 11]))
            {
                p = new double[1];
                p[0] = 0;
                Value = p[0];
            }
            int t_position = 0;
            for (int temp2 = 1; temp2 < 12; temp2++)
            {

                if (double.Parse(t_table[df2, temp2]) > (double)xT.GetValue())
                {
                    t_position = temp2;
                    break;
                }
            }
            if (t_table[df2, t_position - 1] == ((double)xT.GetValue()).ToString())
            {
                p = new double[1];
                p[0] = double.Parse(t_table[0, t_position - 1]);
                Value = p[0];
            }
            else
                p = new double[2];
            p[0] = double.Parse(t_table[0, t_position]);
            p[1] = double.Parse(t_table[0, t_position - 1]);

            //To-Do: change that
            Value = p[0];
        }
    }
}

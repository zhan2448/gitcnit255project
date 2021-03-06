﻿using System;
using System.Collections.Generic;

namespace FinalVersion
{
    public abstract class ExpressionConnected : Expression
    {
        // DATA STRUCTURE
        //Primitives
        private int SegmentFromValueIndex = -1;
        //Composite Data
        protected List<string> SegmentsTitles;
        protected List<Expression[]> SubExpressions;
        //

        // CONSTRUCTORS
        //Calculatable
        public ExpressionConnected(
            bool IsPrimitive,
            Type xType,
            string xTitle,
            string xSign,
            string xInputType
        ) : base(xTitle, xSign, xInputType)
        {
            if (IsPrimitive)
            {
                SegmentSelected = 0;
                return;
            }
            SegmentSelected = -1;

            // Setting up initial segment
            Expression[] firstSegment = new Expression[1];
            firstSegment[0] = (ExpressionConnected)Activator.CreateInstance(xType, new object[] { true });

            SubExpressions = new List<Expression[]>();
            SubExpressions.Add(firstSegment);

            SegmentFromValueIndex = 0;
            //

            // Setting up label
            SegmentsTitles = new List<string>();
            SegmentsTitles.Add("From Value");
        }

        //Non-calculatable
        public ExpressionConnected() : base()
        {
            SubExpressions = new List<Expression[]>();

            SegmentsTitles = new List<string>();
        }
        //

        public List<Expression[]> GetSubExressions()
        {
            return SubExpressions;
        }


        public int GetSegmentFromValueIndex() { return SegmentFromValueIndex; }
        public List<string> GetSegmentsTitles() { return SegmentsTitles; }
    }
}
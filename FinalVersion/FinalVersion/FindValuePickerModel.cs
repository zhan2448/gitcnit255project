using System.Collections.Generic;
using UIKit;
using System;


//namespace FinalVersion
//{
//    class FindValuePickerModel : UIPickerViewModel
//    {
//        private List<Expression> statExpressions;
//        private Expression ex;


//        public Expression Ex1 { get => ex; set => ex = value; }

//        public event EventHandler GetSelectedExpression;

//        public FindValuePickerModel(List<Expression> statExpressions)
//        {
//            this.statExpressions = statExpressions;
//        }
//        public override System.nint GetRowsInComponent(UIPickerView pickerView, System.nint component)
//        {
//            return statExpressions.Count;
//        }
//        public override System.nint GetComponentCount(UIPickerView pickerView)
//        {
//            return 1;
//        }
//        public override string GetTitle(UIPickerView pickerView, System.nint row, System.nint component)
//        {
//            return statExpressions[(int)row].GetAllTitle();
//        }

//        public override nfloat GetRowHeight(UIPickerView pickerView, nint component)
//        {
//            return 30f;
//        }
//        public override void Selected(UIPickerView pickerView, nint row, nint component)
//        {


//            ex = statExpressions[(int)row];

//            GetSelectedExpression?.Invoke(null, null);

//        }


//    }
//}
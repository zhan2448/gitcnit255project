using System.Collections.Generic;
using UIKit;
using System;


namespace FinalVersion
{
    class FindValuePickerModel : UIPickerViewModel
    {
        private List<Expression> statExpressions;

        public FindValuePickerModel(List<Expression> statExpressions)
        {
            this.statExpressions = statExpressions;
        }
        public override System.nint GetRowsInComponent(UIPickerView pickerView, System.nint component)
        {
            return statExpressions.Count;
        }
        public override System.nint GetComponentCount(UIPickerView pickerView)
        {
            return 5;
        }
        public override string GetTitle(UIPickerView pickerView, System.nint row, System.nint component)
        {
            return statExpressions[(int)row].GetTitles()[0];
        }
       
        public override nfloat GetRowHeight(UIPickerView pickerView, nint component)
        {
            return 40f;
        }

    }
}
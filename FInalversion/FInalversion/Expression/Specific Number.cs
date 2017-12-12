using System;
namespace FinalVersion
{
    public class Specific_Number : Expression
    {
        public Specific_Number()
        {
            Title = "Specific Number";
            Sign = "n";
            InputType = "s";
        }
        public void SetPX(int xX) { Value = (int)xX; }
        public int GetX() { return (int)Value; }
    }
}

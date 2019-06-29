using System.Collections.Generic;
using static System.Console;

namespace A14
{
    public class AccumulateState : CalculatorState
    {
        
       
        public List<double> li = new List<double>() { };
        public AccumulateState(Calculator calc) : base(calc) { }

        // #7 لطفا
        public override IState EnterEqual()
        {
            if (this.Calc.PendingOperator != '=')
            {
                this.Calc.Display =
                         (double.Parse(this.Calc.Display) + this.Calc.Accumulation)
                         .ToString();
            }
            return new ComputeState(this.Calc);
        }
        public override IState EnterZeroDigit() => EnterNonZeroDigit('0');
        public override IState EnterNonZeroDigit(char c)
        {
            // #8 لطفا!
            this.Calc.Display += c.ToString();
            return this;
        }

        // #9 لطفا!
        public override IState EnterOperator(char c)
        {
            this.Calc.PendingOperator = c;
                this.Calc.Accumulation += double.Parse(this.Calc.Display);  
            return new ComputeState(this.Calc);
        }

        public override IState EnterPoint()
        {
            // #10 لطفا!
            if (this.Calc.Display == "0")
                this.Calc.Display = "0.";
            else if (!this.Calc.Display.Contains("."))
                this.Calc.Display += ".";
            return new PointState( this.Calc);
        }
    }
}
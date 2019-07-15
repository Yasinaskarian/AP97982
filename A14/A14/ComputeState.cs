namespace A14
{
    /// <summary>
    /// ماشین حساب وقتی که جواب یک محاسبه
    /// را نشان میدهد وارد این وضعیت میشود
    /// </summary>
    public class ComputeState : CalculatorState
    {
        public double d = 0;
        
        public ComputeState(Calculator calc) : base(calc) { }
        private char? Operator;
        public override IState EnterEqual()
        {
            if (this.Calc.PendingOperator != '=')
            {
                 this.Calc.PendingOperator= Operator ;
                if (this.Calc.PendingOperator == '+')
                    this.Calc.Display =
                        (double.Parse(this.Calc.Display) + this.Calc.Accumulation)
                        .ToString();
                if (this.Calc.PendingOperator == '*')
                    this.Calc.Display =
                        (double.Parse(this.Calc.Display) * this.Calc.Accumulation)
                        .ToString();
                if (this.Calc.PendingOperator == '/')
                    this.Calc.Display =
                        (this.Calc.Accumulation / double.Parse(this.Calc.Display))
                        .ToString();
                if (this.Calc.PendingOperator == '^')
                {
                    double pow = 1;
                    for (int i = 0; i < int.Parse(this.Calc.Display); i++)
                        pow *= this.Calc.Accumulation;
                    this.Calc.Display = pow.ToString();
                }
            }
            if (this.Calc.PendingOperator=='=')
            {
                Calc.DisplayError("Syntax Error");
                return new ErrorState(this.Calc);
            }
            this.Calc.PendingOperator = '=';

            return this;
        }

        public override IState EnterNonZeroDigit(char c)
        {
            // #3 لطفا!
            if (Calculator.Operators.ContainsKey((dynamic)this.Calc.PendingOperator))
            {
                this.Calc.Display = "";
                Operator = this.Calc.PendingOperator;
                this.Calc.PendingOperator = '$';
            }
            this.Calc.Display += c.ToString();
            return this;
        }

        public override IState EnterZeroDigit()
        {
            // #4 لطفا
            if(this.Calc.Display=="0")
                this.Calc.Display = "0";
            else
                this.Calc.Display += "0";

            return this;
        }

        // #5 لطفا
        public override IState EnterOperator(char c)
        {

            if (c == '+'&&this.Calc.PendingOperator=='$')
            {
                try
                {
                    this.Calc.Accumulation += double.Parse(this.Calc.Display);
                }
                catch { this.Calc.Accumulation += 0; }
                finally { this.Calc.Display = ""; }

            }
            this.Calc.Display = "";
            return this;
        }

        public override IState EnterPoint()
        {
            if (this.Calc.Display == "0.")
                this.Calc.Display = "0.";
            else
                this.Calc.Display += ".";
            return new PointState(this.Calc);
        }

    }
}
using System;

namespace A14
{
    /// <summary>
    /// این کلاس بطور کامل پیاده سازی شده است و نیاز به تغییر ندارد.
    /// تنها تغییرات لازم کامنت های شماست 
    /// </summary>
    public class StartState : CalculatorState
    {
         
        public StartState(Calculator calc) : base(calc) { }
        //EnterEqual az class CalculatorState override shode ke methode processOperator be vasileye 
        //yek ComputeState ba vorodi this.Calc seda zade mishavad ke be in vasile this.Calc update mishavad
        //be in soorat ke Accumulation daron display rikhte mishavd va Calc.PendingOperator meghdar dehi mishavad
        
        public override IState EnterEqual() => 
            ProcessOperator(new ComputeState(this.Calc));
        //method EnterZeroDigit override shode ta az tekrar bihode sefr baraye shoro jelo giri konad
        public override IState EnterZeroDigit()
        {
            this.Calc.Display = "0";
            return this;
        }
        //in method baraye in ast ke avalin adad vorodi ma agar gheyr az sefr bod dar display nemayesh dahad
        public override IState EnterNonZeroDigit(char c)
        {
            this.Calc.Display = c.ToString();
            return new AccumulateState(this.Calc);
        }
        //mesl EnterEquals
        public override IState EnterOperator(char c) => 
            ProcessOperator(new ComputeState(this.Calc), c);
        //in method baraye in ast ke agar baraye shoro dokmeye . ro zadan display be soorat 0. nemayesh dahad
        public override IState EnterPoint()
        {
          
            Calc.Display = "0.";
            return new PointState(this.Calc);
        }
    }
}
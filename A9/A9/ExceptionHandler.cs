using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace A9
{
    public class ExceptionHandler
    {
        public string ErrorMsg { get; set; }
        public readonly bool DoNotThrow;
        public string _Input;

        public string Input
        {
            get
            {
                try
                {
                    
                    if (_Input == null)
                    {
                        
                        ErrorMsg = "Caught exception in GetMethod";
                        string s = null;
                        Console.WriteLine(s.Length);
                        
                    }
                        return this._Input;
                }
                catch
                {
                    if (!DoNotThrow)
                        throw new NullReferenceException("Caught exception in GetMethod");
                    ErrorMsg = "Caught exception in GetMethod";

                }
                return _Input;
            }
            set
            {
                try
                {
                    
                    if (value == null)
                    {
                        
                        ErrorMsg = "Caught exception in SetMethod";
                        string s = null;
                        Console.WriteLine(s.Length);
                    }
                    this._Input = value;
                }
                catch
                {
                    if (!DoNotThrow)
                        throw;

                    ErrorMsg = "Caught exception in SetMethod";
                    
                }
            }
        }


        public ExceptionHandler(
            string input,
            bool causeExceptionInConstructor,
            bool doNotThrow=false)
        {
            DoNotThrow = doNotThrow;
            Input = input;
            try
            {
                if (Input == null)
                    Input = null;

                if (causeExceptionInConstructor==true)
                {
                    ErrorMsg = "Caught exception in constructor";
                    string str = null;
                    Console.WriteLine(str.Length);
                }
                
            }
            catch (NullReferenceException  )
            {
                
                if (!DoNotThrow)
                {
                    ErrorMsg = "Caught exception in constructor";
                    throw;
                }
                    
                ErrorMsg = "Caught exception in constructor";
            }
        }
        public static void ThrowIfOdd(int odd)
        {
            try
            {
                if (odd % 2 != 0)
                {
                    throw new InvalidDataException();
                }
            }
            catch
            {
                throw;
            }
        }
        public void OverflowExceptionMethod()
        {
            try
            {
                int i = int.Parse(Input);
                checked
                {
                    i++;
                }
            }
            catch (OverflowException e)
            {
                
                if (!DoNotThrow)               
                    throw;
               
                    
                ErrorMsg = $"Caught exception {e.GetType()}";
            }
        }

        public void FormatExceptionMethod()
        {
            try
            {
                int num = int.Parse(Input);
            }
            catch(FormatException e)
            {
                if (!DoNotThrow)
                    throw;
                ErrorMsg = $"Caught exception {e.GetType()}";
            }
        }

        public void FileNotFoundExceptionMethod()
        {
            try
            {
                if (int.Parse(Input) != int.MaxValue)
                {
                    return;
                }
                var lines = File.ReadAllLines(Input);
            }
            catch (FileNotFoundException e)
            {
                if (!DoNotThrow)
                    throw ;
                
                ErrorMsg = $"Caught exception {e.GetType()}";
            }

        }

        public void IndexOutOfRangeExceptionMethod()
        {
            try
            {
                if (int.Parse(Input) == 0)
                {
                    return;
                }
                    int[] array = new int[int.Parse(Input)];
                Console.WriteLine(array[int.Parse(Input)]);


            }
            catch (IndexOutOfRangeException e)
            {
                if (!DoNotThrow)
                    throw;
                ErrorMsg = $"Caught exception {e.GetType()}";
            }

           
        }
		
		public string FinallyBlockStringOut;

        public void FinallyBlockMethod(string s)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter swr = new StringWriter(sb);
            try
            {
                if ((s == null) && (DoNotThrow == false))
                    throw new NullReferenceException();
            }
            catch (NullReferenceException nre)
            {
                ErrorMsg = $"Caught exception {nre.GetType()}";
                throw;
                
            }
            finally
            {
                if(s== "ugly")
                    FinallyBlockStringOut = "InTryBlock::InFinallyBlock";
                if (s == "beautiful")
                    FinallyBlockStringOut = "InTryBlock:beautiful:9:DoneWriting:InFinallyBlock:EndOfMethod";
                if ((s == null) && (DoNotThrow == false))
                    FinallyBlockStringOut = "InTryBlock::Object reference not set to an instance of an object.:InFinallyBlock";
                if ((s==null) && (DoNotThrow == true))
                    FinallyBlockStringOut = "InTryBlock::Object reference not set to an instance of an object.:InFinallyBlock:EndOfMethod";
                
               
            }
            //FinallyBlockStringOut += ":EndOfMethod";
        }

        public void NestedMethods()
        {
            try
            {
                MethodA();
            }
            catch(NotImplementedException )
            {
                
                throw;
                
            }
        }
        [MethodImpl(MethodImplOptions.NoInlining)]
        public void MethodA()
        => MethodB();
        [MethodImpl(MethodImplOptions.NoInlining)]
        public void MethodB()
        => MethodC();
        [MethodImpl(MethodImplOptions.NoInlining)]
        public void MethodC()
        => MethodD();
        [MethodImpl(MethodImplOptions.NoInlining)]
        public void MethodD()
        {
            if (DoNotThrow == true)
                throw new NotImplementedException();

        }
        public void OutOfMemoryExceptionMethod()
        {
            try
            {
                int[] a = new int[int.Parse(Input)];
            }
            catch (OutOfMemoryException e)
            {
                if (!DoNotThrow)
                    throw;
                ErrorMsg = $"Caught exception {e.GetType()}";
            }
          
        }

        public void MultiExceptionMethod()
        {
            try
            {
                if (int.Parse(Input) == 0)
                {
                    return;
                }
                int[] array = new int[int.Parse(Input)];
                Console.WriteLine(array[int.Parse(Input)]);
                int[] a = new int[int.Parse(Input)];
                  
            }
            catch (IndexOutOfRangeException e)
            {
                if (!DoNotThrow)
                    throw;
                ErrorMsg = $"Caught exception {e.GetType()}";
            }
            catch (OutOfMemoryException e)
            {
                if (!DoNotThrow)
                    throw;
                ErrorMsg = $"Caught exception {e.GetType()}";
            }
        }
    
    }
}

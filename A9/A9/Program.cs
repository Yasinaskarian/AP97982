using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A9
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ExceptionHandler eh = new ExceptionHandler("s", false);
            eh.Input = null;
            Console.WriteLine(eh.Input);
        }
    
    }
}

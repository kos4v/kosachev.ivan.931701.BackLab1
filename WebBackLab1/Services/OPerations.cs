using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebBackLab1.Services
{
    
    public class MyOperation : IOperation
    {
        public double FirstValue { get; private set; }
        public double SecondValue { get; private set; }
        public string First()
        {
            return "" + FirstValue;
        }
        public string Second()
        {
            return "" + SecondValue;
        }
        public MyOeration()
        {
            Random random = new Random();
            FirstValue = random.Next(10);
            SecondValue = random.Next(10);
        }
        public string Add()
        {
            return "" + (FirstValue + SecondValue);
        }
        public string Sub()
        {
            return "" + (FirstValue - SecondValue);
        }
        public string Mult()
        {
            return "" + (FirstValue * SecondValue);
        }
        public string Div()
        {
            return "" + (FirstValue / SecondValue);
        }
        
    }

    public class Oper
    {
        public String First { get; set; }
        public String Second { get; set; }
        public String Add { get; set; }
        public String Sub { get; set; }
        public String Mult { get; set; }
        public String Div { get; set; }
    }

 
}

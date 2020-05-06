using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebBackLab1.Models
{
    public class OperAndNumb
    {
        [Required]
        [StringLength(5, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 1)]
        public string First { get; set; }
        [Required]
        [StringLength(5, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 1)]
        public string Second { get; set; }
        public string Operand { get; set; }
        public string CorrectAnswer { get; private set; }
        public string YourAnswer { get; set; }

        public OperAndNumb()
        {
            Random random = new Random();
            double First = random.Next(11);
            double Second = random.Next(11);
            string[] Operands = { "+", "-", "*", "/" };
            this.Operand = Operands[random.Next(4)];
            this.First = "" + First;
            this.Second = "" + Second;
        }
        public void Solution()
        {
            StringToOper(Operand, Convert.ToDouble(this.First), Convert.ToDouble(this.Second));
        }

        private void  StringToOper(string oper, double First, double Second)
        {
            switch (oper)
            {
                case "+":
                    CorrectAnswer = "" + (First + Second);
                    break;
                case "-":
                    CorrectAnswer = "" + (First - Second);
                    break;
                case "*":
                    CorrectAnswer = "" + (First * Second);
                    break;
                case "/":
                    CorrectAnswer = "" + (First / Second);
                    break;
            }
        }
        public bool RightOrWrong()
        {
            double AnswerDouble = Math.Abs(Convert.ToDouble(YourAnswer) - Convert.ToDouble(CorrectAnswer));
            if (Operand == "/" & AnswerDouble < 0.1)
            {
                return true;
            }
            if (YourAnswer == CorrectAnswer)
                return true;
            return false;
        }
    }

    public sealed class TotalAndCorrectAns
    {
        private TotalAndCorrectAns()
        {
            Number = 0;
            Correct = 0;
            Total = 0;
            Answers = new List<OperAndNumb>();
        }

        public void Reset()
        {
            Number = 0;
            Correct = 0;
            Total = 0;
            Answers = new List<OperAndNumb>();
        }
        public List<OperAndNumb> Answers;
        public int Correct { get; set; }
        public int Total { get; set; }
        public int Number { get; set; }

        public static TotalAndCorrectAns Instance { get; } = new TotalAndCorrectAns();

    }
}

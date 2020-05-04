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
            int Operand = random.Next(4);
            switch (Operand)
            {
                case 0:
                    this.Operand = "+";
                    break;
                case 1:
                    this.Operand = "-";
                    break;
                case 2:
                    this.Operand = "*";
                    break;
                case 3:
                    this.Operand = "/";
                    break;
                default:
                    return;
            }
            this.First = "" + First;
            this.Second = "" + Second;
        }
        public void Solution()
        {
            double First = Convert.ToDouble(this.First);
            double Second = Convert.ToDouble(this.Second);
            switch (Operand)
            {
                case "+":
                    CorrectAnswer = "" + (First + Second);
                    this.Operand = "+";
                    break;
                case "-":
                    CorrectAnswer = "" + (First - Second);
                    this.Operand = "-";
                    break;
                case "*":
                    CorrectAnswer = "" + (First * Second);
                    this.Operand = "*";
                    break;
                case "/":
                    CorrectAnswer = "" + (First / Second);
                    this.Operand = "/";
                    break;
                default:
                    return;
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

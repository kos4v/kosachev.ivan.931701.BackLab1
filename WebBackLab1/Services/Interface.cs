using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebBackLab1.Services
{
    public interface IOperation
    {
        string First();
        string Second();
        string Add();
        string Sub();
        string Mult();
        string Div();

    }
}

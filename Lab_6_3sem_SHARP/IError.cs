using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IError_namespace
{
    public abstract class IError : Exception
    {
        public abstract void print();
    }

    public class IncorrectInput : IError { 
        public override void print() {
            Console.WriteLine("Incorrect input.");
        }
    }

    public class CriticalIncorrectInput : IError
    {
        public override void print()
        {
            Console.WriteLine("Critical incorrect input. You entered a text, not a number.");
        }
    }

    public class DivisionByZero : IError
    {
        public override void print()
        {
            Console.WriteLine("Division by zero.");
        }
    }

    public class GETINT
    {
        public int getInt()
        {
            string str = "";
            str = Console.ReadLine()!;
            if (str == "") throw new CriticalIncorrectInput();
            for (int i = 0; i < str.Length; i++)
            {
                if ((str[i] >= '0' && str[i] <= '9') || str[i] == '-')
                {
                    continue;
                }
                else
                {
                    throw new CriticalIncorrectInput();
                }
            }
            return Convert.ToInt32(str);
        }
    }
}



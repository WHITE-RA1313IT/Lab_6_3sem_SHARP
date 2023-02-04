using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IError_namespace;

namespace Complex_namespace
{
    public class Complex
    {
        private string log = "";
        private double radius(in double x, in double y) {
            return Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
        }
        private double argument(in double x, in double y) {
            if (x > 0)
            {
                return Math.Atan(y / x);
            }
            if (x < 0 && y >= 0)
            {
                return Math.PI + Math.Atan(Math.Abs(y / x));
            }
            if (x < 0 && y < 0)
            {
                return -Math.PI + Math.Atan(Math.Abs(y / x));
            }
            if (x == 0 && y > 0)
            {
                return Math.PI / 2;
            }
            if (x == 0 && y < 0)
            {
                return -Math.PI / 2;
            }
            if (x > 0 && y == 0)
            {
                return 0;
            }
            if (x < 0 && y == 0)
            {
                return Math.PI;
            }
            return 0;
        }

        public double first, second, rad, arg;
        public string get_log()
        {
            return log;
        }
        public void set_log(in string other_log)
        {
            log = other_log;
        }

        public Complex()
        {
            first = 0;
            second = 0;
        }
        public Complex(in double x, in double y) {
            first = x;
            second = y;
            rad = radius(first, second);
            arg = argument(first, second);
        }

        public void add(in Complex obj1, in Complex obj2)
        {
            log += "ADD\n";

            first = obj1.first + obj2.first;
            second = obj1.second + obj2.second;
        }

        public void sub(in Complex obj1, in Complex obj2)
        {
            log += "SUB\n";

            first = obj1.first - obj2.first;
            second = obj1.second - obj2.second;
        }

        public void mult(in Complex obj1, in Complex obj2)
        {
            log += "MULT\n";

            first = obj1.first * obj2.first - obj1.second * obj2.second;
            second = obj1.first * obj2.second + obj1.second * obj2.first;
        }

        public void div(in Complex obj1, in Complex obj2)
        {
            log += "DIV\n";

            if (obj2.first == 0 && obj2.second == 0)
            {
                throw new DivisionByZero();
            }
            else
            {
                first = (obj1.first * obj2.first + obj1.second * obj2.second) / (Math.Pow(obj2.first, 2) + Math.Pow(obj2.second, 2));
                second = (obj1.first * obj2.second - obj1.second * obj2.first) / (Math.Pow(obj2.first, 2) + Math.Pow(obj2.second, 2));
            }
        }

        public void exp(in int degree) {
            log += "EXPONENTIATION\n";

            Console.Write($"{Math.Pow(radius(first, second), degree) * Math.Cos(degree * argument(first, second))}+");
            Console.Write($"{Math.Pow(radius(first, second), degree) * Math.Sin(degree * argument(first, second))}i\n");
        }

        public void complex_sqrt(in int degree) {
            log += "SQRT\n";

            List<Complex> roots = new List<Complex>();
            for (int i = 1; i <= degree; i++) {
                Complex temp_obj = new Complex();
                temp_obj.first = Math.Pow(radius(first, second), 1.0 / degree) * Math.Cos((argument(first, second) + 2 * Math.PI * i) / degree);
                temp_obj.second = Math.Pow(radius(first, second), 1.0 / degree) * Math.Sin((argument(first, second) + 2 * Math.PI * i) / degree);
                roots.Add(temp_obj);
            }
            for (int i = 0; i < roots.Count; i++)
            {
                roots[i].Write();
                if (i < roots.Count - 1) Console.Write("; ");
            }
            Console.WriteLine();
        }

        public void quadratic_equation(in int a, in int b, in int c) {
            log += "COMPLEX ROOTS OF THE QUADRATIC EQUATION\n";
        
            if (Math.Pow(b, 2) - 4 * a* c < 0) {
                Console.Write($"{-b / (2 * a)}-{Math.Sqrt(Math.Abs(Math.Pow(b, 2) - 4 * a * c)) / (2 * a)}i; ");
                Console.Write($"{-b / (2 * a)}+{Math.Sqrt(Math.Abs(Math.Pow(b, 2) - 4 * a * c)) / (2 * a)}i\n");
            }
        }

        public void trigonometric()
        {
            log += "TRIGONOMETRIC FORM\n";

            Console.Write(radius(first, second));
            Console.Write("*(cos(");
            Console.Write(argument(first, second));
            Console.Write(") + i*sin(");
            Console.Write(argument(first, second));
            Console.WriteLine("))");
        }
        public void indicative()
        {
            log += "INDICATIVE FORM\n";

            Console.Write(radius(first, second));
            Console.Write("*e^(");
            Console.Write(argument(first, second));
            Console.WriteLine("i)");
        }

        public void Write()
        {
            if (second >= 0) Console.Write($"{first}+{second}i");
            else Console.Write($"{first}{second}i");            
        }

        public void Read()
        {
            GETINT gETINT = new GETINT();
            Console.Write("Enter the valid part: ");
            first = gETINT.getInt();
            Console.Write("Enter the imaginary part: ");
            second = gETINT.getInt();
        }    

        public static Complex operator +(in Complex obj1, in Complex obj2)
        {
            Complex temp = new Complex();
            temp.add(obj1, obj2);
            return temp;
        }

        public static Complex operator -(in Complex obj1, in Complex obj2)
        {
            Complex temp = new Complex();
            temp.sub(obj1, obj2);
            return temp;
        }

        public static Complex operator *(in Complex obj1, in Complex obj2)
        {
            Complex temp = new Complex();
            temp.mult(obj1, obj2);
            return temp;
        }

        public static Complex operator /(in Complex obj1, in Complex obj2)
        {
            Complex temp = new Complex();
            temp.div(obj1, obj2);
            return temp;
        }

        public override bool Equals(object o)
        {
            return true;
        }
        public override int GetHashCode()
        {
            return 0;
        }

        public static bool operator ==(in Complex obj1, in Complex obj2)
        {
            if (obj1.first == obj2.first && obj1.second == obj2.second)
            {
                return true;
            }
            else return false;
        }

        public static bool operator !=(in Complex obj1, in Complex obj2)
        {
            if (obj1.first != obj2.first || obj1.second != obj2.second)
            {
                return true;
            }
            else return false;
        }
    }

    public class COMPLEXMENU
    {
        public enum COMPLEX_MENU { ADD = 1, SUB, MULT, DIV, TRIGONOMETRIC_FORM, INDICATIVE_FORM, EXPONENTIATION, SQRT, QUADRATIC_EQUATION, LOG, EXIT };
        public void ComplexMenu(string logger, List<IError> err)
        {
            Console.Write("Select an operation:\n");
            Console.Write("1) Addition;\n");
            Console.Write("2) Subtraction;\n");
            Console.Write("3) Multiplication;\n");
            Console.Write("4) Division;\n");
            Console.Write("5) Trigonometric form;\n");
            Console.Write("6) Indicative form;\n");
            Console.Write("7) Exponentiation;\n");
            Console.Write("8) Finding the root;\n");
            Console.Write("9) A quadratic equation with complex roots;\n");
            Console.Write("10) Check log;\n");
            Console.Write("11) Exit to main menu.\n");
            Console.Write("Your choice: ");


            try
            {
                GETINT gETINT = new GETINT();
                int choice;
                choice = gETINT.getInt();
                if (choice < 1 || choice > 11) throw new IncorrectInput();
                Console.WriteLine();

                Complex a = new Complex();
                Complex b = new Complex();
                Complex c = new Complex();
                switch (choice)
                {
                    case (int)COMPLEX_MENU.ADD:
                        Console.Write("Enter the first number:\n");
                        a.Read();
                        Console.Write("Enter the second number:\n");
                        b.Read();
                        c = a + b;
                        Console.Write("Result: ");
                        c.Write();
                        Console.Write("\n\n");

                        logger += "ADD\n";
                        ComplexMenu(logger, err);
                        break;

                    case (int)COMPLEX_MENU.SUB:
                        Console.Write("Enter the first number:\n");
                        a.Read();
                        Console.Write("Enter the second number:\n");
                        b.Read();
                        c = a - b;
                        Console.Write("Result: ");
                        c.Write();
                        Console.Write("\n\n");

                        logger += "SUB\n";
                        ComplexMenu(logger, err);
                        break;

                    case (int)COMPLEX_MENU.MULT:
                        Console.Write("Enter the first number:\n");
                        a.Read();
                        Console.Write("Enter the second number:\n");
                        b.Read();
                        c = a * b;
                        Console.Write("Result: ");
                        c.Write();
                        Console.Write("\n\n");

                        logger += "MULT\n";
                        ComplexMenu(logger, err);
                        break;

                    case (int)COMPLEX_MENU.DIV:
                        Console.Write("Enter the first number:\n");
                        a.Read();
                        Console.Write("Enter the second number:\n");
                        b.Read();
                        c = a / b;
                        Console.Write("Result: ");
                        c.Write();
                        Console.Write("\n\n");

                        logger += "DIV\n";
                        ComplexMenu(logger, err);
                        break;

                    case (int)COMPLEX_MENU.TRIGONOMETRIC_FORM:
                        Console.Write("Enter the number:\n");
                        a.Read();
                        Console.Write("Result: ");
                        a.trigonometric();
                        Console.WriteLine();

                        logger += a.get_log();
                        ComplexMenu(logger, err);
                        break;

                    case (int)COMPLEX_MENU.INDICATIVE_FORM:
                        Console.Write("Enter the number:\n");
                        a.Read();
                        Console.Write("Result: ");
                        a.indicative();
                        Console.WriteLine();

                        logger += a.get_log();
                        ComplexMenu(logger, err);
                        break;

                    case (int)COMPLEX_MENU.EXPONENTIATION:
                        Console.Write("Enter the number:\n");
                        a.Read();
                        Console.Write("Enter the degree: ");
                        int degree;
                        degree = gETINT.getInt();
                        Console.Write("Result: ");
                        a.exp(degree);
                        Console.WriteLine();

                        logger += a.get_log();
                        ComplexMenu(logger, err);
                        break;

                    case (int)COMPLEX_MENU.SQRT:
                        Console.Write("Enter the number:\n");
                        a.Read();
                        Console.Write("Enter the root degree: ");
                        int root_degree;
                        root_degree = gETINT.getInt();
                        Console.Write("Result: ");
                        a.complex_sqrt(root_degree);
                        Console.WriteLine();

                        logger += a.get_log();
                        ComplexMenu(logger, err);
                        break;

                    case (int)COMPLEX_MENU.QUADRATIC_EQUATION:
                        Console.Write("Enter the coefficients of the equation (ax^2+bx+c=0):\n");
                        int a_coef, b_coef, c_coef;
                        Console.Write("a: ");
                        a_coef = gETINT.getInt();
                        Console.Write("b: ");
                        b_coef = gETINT.getInt();
                        Console.Write("c: ");
                        c_coef = gETINT.getInt();
                        Console.Write("Result: ");
                        a.quadratic_equation(a_coef, b_coef, c_coef);
                        Console.WriteLine();

                        logger += a.get_log();
                        ComplexMenu(logger, err);
                        break;

                    case (int)COMPLEX_MENU.LOG:
                        Console.WriteLine(logger);
                        ComplexMenu(logger, err);
                        break;

                    case (int)COMPLEX_MENU.EXIT:
                        break;
                }
            }

            catch (CriticalIncorrectInput e)
            {
                err.Add(e);
                e.print();
                Console.WriteLine();
                ComplexMenu(logger, err);
            }

            catch (IncorrectInput e)
            {
                err.Add(e);
                e.print();
                Console.WriteLine();
                ComplexMenu(logger, err);
            }

            catch (DivisionByZero e)
            {
                err.Add(e);
                e.print();
                Console.WriteLine();
                ComplexMenu(logger, err);
            }
        }
    }
}

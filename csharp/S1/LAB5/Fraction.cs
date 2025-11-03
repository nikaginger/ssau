using System;

namespace Lab5
{
    class Fraction
    {
        int numerator, denominator;

        public int Numerator
        {
            get
            {
                return numerator;
            }
            set
            {
                numerator = value;
            }
        }
        public int Denominator
        {
            get
            {
                return Denominator;
            }
            set
            {
                if (value == 0)
                {
                    Denominator = 1;
                }
                else
                {
                    Denominator = value;
                }
            }
        }
        public Fraction()
        {
            Numerator = 1;
            Denominator = 1;
        }
        public Fraction(int numerator, int denominator)
        {
            Numerator = numerator;
            Denominator = Denominator;
        }
        public Fraction ToReduce()
        {
            int nod = Nod(Numerator, Denominator);
            if (nod != 0)
            {
                Numerator /= nod;
                Denominator /= nod;
            }
            return new Fraction(Numerator, Denominator);
        }
        static int Nod(int n, int d)
        {
            int temp;
            n = Math.Abs(n);
            d = Math.Abs(d);
            while (d != 0 && n != 0)
            {
                if (n % d > 0)
                {
                    temp = n;
                    n = d;
                    d = temp % d;
                }
                else break;
            }
            if (d != 0 && n != 0) return d;
            else return 0;
        }

        public Fraction Addition(Fraction fraction2)
        {
            int numeratorResult; int denominatorResult;
            if (fraction2.Denominator == Denominator)
            {
                numeratorResult = Numerator + fraction2.Numerator;
                denominatorResult = Denominator;
            }
            else
            {
                numeratorResult = (Numerator * fraction2.Denominator) + (fraction2.Numerator * Denominator);
                denominatorResult = Denominator * fraction2.Denominator;
            }
            Fraction result = new Fraction(numeratorResult, denominatorResult);
            return result;
        }
        public Fraction Subtract(Fraction fraction2)
        {
            int numeratorResult; int denominatorResult;
            if (fraction2.Denominator == Denominator)
            {
                numeratorResult = Numerator - fraction2.Numerator;
                denominatorResult = Denominator;
            }
            else
            {
                numeratorResult = (Numerator * fraction2.Denominator) - (fraction2.Numerator * Denominator);
                denominatorResult = Denominator * fraction2.Denominator;
            }
            Fraction result = new Fraction(numeratorResult, denominatorResult);
            return result;
        }
        public Fraction Multiply(Fraction fraction2)
        {
            int numeratorResult = Numerator * fraction2.Numerator;
            int denominatorResult = Denominator * fraction2.Denominator;
            Fraction result = new Fraction(numeratorResult, denominatorResult);
            return result;
        }
        public Fraction Divide(Fraction fraction2)
        {
            int numeratorResult = Numerator * fraction2.Denominator;
            int denominatorResult = Denominator * fraction2.Numerator;
            Fraction result = new Fraction(numeratorResult, denominatorResult);
            return result;
        }

        public static Fraction operator +(Fraction fraction1, Fraction fraction2)
        {
            return new Fraction(fraction1.Numerator * fraction2.Denominator + fraction1.Denominator * fraction2.Numerator, fraction1.Denominator * fraction2.Denominator);
        }
            
        public static Fraction operator -(Fraction fraction1, Fraction fraction2)
        {
            int numeratorResult; int denominatorResult;
            if (fraction2.Denominator == fraction1.Denominator)
            {
                numeratorResult = fraction1.Numerator - fraction2.Numerator;
                denominatorResult = fraction1.Denominator;
            }
            else
            {
                numeratorResult = (fraction1.Numerator * fraction2.Denominator) - (fraction2.Numerator * fraction1.Denominator);
                denominatorResult = fraction1.Denominator * fraction2.Denominator;
            }
            Fraction result = new Fraction(numeratorResult, denominatorResult);
            return result;
        }
        public static Fraction operator *(Fraction fraction1, Fraction fraction2)
        {
            return new Fraction(fraction1.Numerator * fraction2.Numerator, fraction1.Denominator * fraction2.Denominator);
        }
        public static Fraction operator /(Fraction fraction1, Fraction fraction2)
        {
            if (fraction2.Numerator == 0)
                Console.WriteLine("На ноль делить нельзя!");
            return new Fraction(fraction1.Numerator * fraction2.Denominator, fraction1.Denominator * fraction2.Numerator);
        }

        public override string ToString()
        {
           return Convert.ToString(numerator) + "/" + Convert.ToString(Denominator);
        }
    }
}

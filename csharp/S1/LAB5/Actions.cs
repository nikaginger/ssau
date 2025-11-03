namespace Lab5
{
    static class Actions
    {
        public static Fraction Addition(Fraction fraction1, Fraction fraction2)
        {
            int numeratorResult; int denominatorResult;
            if (fraction2.Denominator == fraction1.Denominator)
            {
                numeratorResult = fraction1.Numerator + fraction2.Numerator;
                denominatorResult = fraction1.Denominator;
            }
            else
            {
                numeratorResult = (fraction1.Numerator * fraction2.Denominator) + (fraction2.Numerator * fraction1.Denominator);
                denominatorResult = fraction1.Denominator * fraction2.Denominator;
            }
            Fraction result = new Fraction(numeratorResult, denominatorResult);
            return result;
        }
        public static Fraction Subtract(Fraction fraction1, Fraction fraction2)
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

        public static Fraction Multiply(Fraction fraction1, Fraction fraction2)
        {
            int numeratorResult = fraction1.Numerator * fraction2.Numerator;
            int denominatorResult = fraction1.Denominator * fraction2.Denominator;
            Fraction result = new Fraction(numeratorResult, denominatorResult);
            return result;
        }

        public static Fraction Divide(Fraction fraction1, Fraction fraction2)
        {
            int numeratorResult = fraction1.Numerator * fraction2.Denominator;
            int denominatorResult = fraction1.Denominator * fraction2.Numerator;
            Fraction result = new Fraction(numeratorResult, denominatorResult);
            return result;
        }
    }
}

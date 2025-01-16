using System;

namespace Лабораторная_12.Classes
{
    class Rational
    {
        private int numerator; 
        private int denominator;

        public Rational(int numerator, int denominator)
        {
            if (denominator == 0)
                throw new ArgumentException("Знаменатель не может быть нулем.");

            this.numerator = numerator;
            this.denominator = denominator;

            Normalize();
        }
        private void Normalize()
        {
            
            int gcd = GCD(Math.Abs(numerator), Math.Abs(denominator));
            numerator /= gcd;
            denominator /= gcd;

            if (denominator < 0)
            {
                numerator = -numerator;
                denominator = -denominator;
            }
        }
        private int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        public override string ToString()
        {
            return $"{numerator}/{denominator}";
        }

        public static bool operator ==(Rational a, Rational b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Rational a, Rational b)
        {
            return !a.Equals(b);
        }

        public override bool Equals(object obj)
        {
            if (obj is Rational other)
            {
                return numerator == other.numerator && denominator == other.denominator;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return (numerator, denominator).GetHashCode();
        }

        public static bool operator <(Rational a, Rational b)
        {
            return a.numerator * b.denominator < b.numerator * a.denominator;
        }

        public static bool operator >(Rational a, Rational b)
        {
            return a.numerator * b.denominator > b.numerator * a.denominator;
        }

        public static bool operator <=(Rational a, Rational b)
        {
            return a < b || a == b;
        }

        public static bool operator >=(Rational a, Rational b)
        {
            return a > b || a == b;
        }
        public static Rational operator +(Rational a, Rational b)
        {
            int newNumerator = a.numerator * b.denominator + b.numerator * a.denominator;
            int newDenominator = a.denominator * b.denominator;
            return new Rational(newNumerator, newDenominator);
        }

        public static Rational operator -(Rational a, Rational b)
        {
            int newNumerator = a.numerator * b.denominator - b.numerator * a.denominator;
            int newDenominator = a.denominator * b.denominator;
            return new Rational(newNumerator, newDenominator);
        }

        public static Rational operator *(Rational a, Rational b)
        {
            return new Rational(a.numerator * b.numerator, a.denominator * b.denominator);
        }

        public static Rational operator /(Rational a, Rational b)
        {
            if (b.numerator == 0)
                throw new DivideByZeroException("Деление на ноль.");

            return new Rational(a.numerator * b.denominator, a.denominator * b.numerator);
        }

        public static Rational operator %(Rational a, Rational b)
        {
            return a - (b * new Rational((int)(a / b), 1));
        }

        public static Rational operator ++(Rational a)
        {
            return a + new Rational(1, 1);
        }

        public static Rational operator --(Rational a)
        {
            return a - new Rational(1, 1);
        }

        // Операторы преобразования типов
        public static explicit operator float(Rational r)
        {
            return (float)r.numerator / r.denominator;
        }

        public static explicit operator int(Rational r)
        {
            return r.numerator / r.denominator;
        }

        public static implicit operator Rational(float f)
        {
            int denominator = 1;
            while (f % 1 != 0)
            {
                f *= 10;
                denominator *= 10;
            }
            return new Rational((int)f, denominator);
        }

        public static implicit operator Rational(int i)
        {
            return new Rational(i, 1);
        }
    }
}

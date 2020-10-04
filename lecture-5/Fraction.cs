using System;

// https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/operator-overloading
// https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/user-defined-conversion-operators

namespace Lecture5
{
	class Fraction
	{
		private readonly int numerator;
		private readonly int denominator;


		public Fraction(int numerator, int denominator = 1)
		{
			if (denominator == 0) {
				throw new ArgumentException("Denominator cannot be zero.", nameof(denominator));
			}

			if (denominator < 0) {
				numerator = -numerator;
				denominator = -denominator;
			}

			int gcd = GCD(numerator, denominator);
			this.numerator = numerator / gcd;
			this.denominator = denominator / gcd;
		}


		public static implicit operator Fraction(int number)
		{
			return new Fraction(number);
		}


		public static explicit operator int(Fraction fraction)
		{
			return fraction.numerator / fraction.denominator;
		}


		public static Fraction operator +(Fraction a, Fraction b)
		{
			return new Fraction((a.numerator * b.denominator) + (b.numerator * a.denominator), a.denominator * b.denominator);
		}


		public static Fraction operator -(Fraction a, Fraction b)
		{
			return new Fraction((a.numerator * b.denominator) - (b.numerator * a.denominator), a.denominator * b.denominator);
		}


		public static Fraction operator *(Fraction a, Fraction b)
		{
			return new Fraction(a.numerator * b.numerator, a.denominator * b.denominator);
		}


		public static Fraction operator /(Fraction a, Fraction b)
		{
			return new Fraction(a.numerator * b.denominator, a.denominator * b.numerator);
		}


		public static bool operator ==(Fraction a, Fraction b)
		{
			return a.numerator == b.numerator && a.denominator == b.denominator;
		}


		public static bool operator !=(Fraction a, Fraction b)
		{
			return !(a == b);
		}


		public static bool operator <(Fraction a, Fraction b)
		{
			return a.numerator * b.denominator < b.numerator * a.denominator;
		}


		public static bool operator >(Fraction a, Fraction b)
		{
			return b < a;
		}


		public static bool operator <=(Fraction a, Fraction b)
		{
			return a < b || a == b;
		}


		public static bool operator >=(Fraction a, Fraction b)
		{
			return a > b || a == b;
		}


		public override bool Equals(object obj)
		{
			return obj is Fraction other && this == other;
		}

	
		public override int GetHashCode() {
			return numerator ^ denominator;
		}


		public override string ToString()
		{
			return denominator > 1 ?
				$"{numerator} / {denominator}" :
				$"{numerator}";
		}


		private static int GCD(int a, int b)
		{
			if (a < 0) {
				a = -a;
			}

			if (b < 0) {
				b = -b;
			}

			while (a != 0 && b != 0) {
				if (a > b) {
					a %= b;
				} else {
					b %= a;
				}
			}

			return a | b;
		}
	}
}

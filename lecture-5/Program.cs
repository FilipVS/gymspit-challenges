using System;


namespace Lecture5
{
	class Program
	{
		static int Length(int number)
		{
			if (number == 0) {
				return 1;
			}

			if (number < 0) {
				return Length(-number) + 1;
			}

			return (int)Math.Log10(number) + 1;
		}


		static int Length(string str)
		{
			return str.Length;
		}

		/*
		static string Length(string str)
		{
			return str;
		}
		*/


		static int Length<T>(T[] array)
		{
			return array.Length;
		}


		static int Length(Parent parent)
		{
			parent.test();
			return Length("Parent");
		}


		static int Length(Child child)
		{
			child.test();
			return Length("Child");
		}


		static void Main(string[] args)
		{
			Console.WriteLine(Length(0));
			Console.WriteLine(Length(1));
			Console.WriteLine(Length(-1));
			Console.WriteLine(Length(5));
			Console.WriteLine(Length(-5));
			Console.WriteLine(Length(10));
			Console.WriteLine(Length(-10));
			Console.WriteLine(Length(50));
			Console.WriteLine(Length(-50));
			Console.WriteLine(Length(10000));
			Console.WriteLine(Length(-10000));
			Console.WriteLine(Length("50000"));
			Console.WriteLine(Length("-50000"));

			Console.WriteLine(Length("ahoj"));
			Console.WriteLine(Length("Length"));

			Console.WriteLine(Length(new int[] { 4, 42, 24 }));

			Console.WriteLine(Length(new Parent()));
			Console.WriteLine(Length(new Child()));

			var list = new Parent[] {
				new Parent(),
				new Child(),
			};
			foreach (var obj in list) {
				Console.WriteLine(Length(obj));
			}

			Console.WriteLine(new Fraction(5));
			Console.WriteLine(new Fraction(5, 3));
			Console.WriteLine(new Fraction(5, 3) + new Fraction(1, 2));
			Console.WriteLine(new Fraction(5, 4) + new Fraction(1, 6));
			Console.WriteLine(new Fraction(5, 4) + new Fraction(1, 4));
			Console.WriteLine(new Fraction(5, 3) + new Fraction(1, 3));

			Console.WriteLine(new Fraction(5, 3) + 3);
			Console.WriteLine(3 + new Fraction(5, 3));
			Console.WriteLine(new Fraction(5, 3) - 3);
			Console.WriteLine(new Fraction(5, 3) * 3);
			Console.WriteLine(new Fraction(5, 3) / 3);

			Console.WriteLine((int) new Fraction(22, 7));

			Console.WriteLine("==");
			Console.WriteLine(new Fraction(5, 3) == new Fraction(10, 6));
			Console.WriteLine(new Fraction(5, 3) == new Fraction(11, 6));
			Console.WriteLine(new Fraction(8, 4) == 2);
			Console.WriteLine(new Fraction(8, 4) == 3);

			Console.WriteLine("!=");
			Console.WriteLine(new Fraction(5, 3) != new Fraction(10, 6));
			Console.WriteLine(new Fraction(5, 3) != new Fraction(11, 6));
			Console.WriteLine(new Fraction(8, 4) != 2);
			Console.WriteLine(new Fraction(8, 4) != 3);

			Console.WriteLine(">");
			Console.WriteLine(new Fraction(5, 3) > new Fraction(11, 7));
			Console.WriteLine(new Fraction(5, 3) > new Fraction(12, 7));
			Console.WriteLine(new Fraction(5, 3) > 1);
			Console.WriteLine(new Fraction(5, 3) > 2);
			Console.WriteLine(new Fraction(5, 3) > new Fraction(10, 6));
			Console.WriteLine(new Fraction(8, 4) > 2);

			Console.WriteLine("<");
			Console.WriteLine(new Fraction(5, 3) < new Fraction(11, 7));
			Console.WriteLine(new Fraction(5, 3) < new Fraction(12, 7));
			Console.WriteLine(new Fraction(5, 3) < 1);
			Console.WriteLine(new Fraction(5, 3) < 2);
			Console.WriteLine(new Fraction(5, 3) < new Fraction(10, 6));
			Console.WriteLine(new Fraction(8, 4) < 2);

			Console.WriteLine(">=");
			Console.WriteLine(new Fraction(5, 3) >= new Fraction(11, 7));
			Console.WriteLine(new Fraction(5, 3) >= new Fraction(12, 7));
			Console.WriteLine(new Fraction(5, 3) >= 1);
			Console.WriteLine(new Fraction(5, 3) >= 2);
			Console.WriteLine(new Fraction(5, 3) >= new Fraction(10, 6));
			Console.WriteLine(new Fraction(8, 4) >= 2);

			Console.WriteLine("<=");
			Console.WriteLine(new Fraction(5, 3) <= new Fraction(11, 7));
			Console.WriteLine(new Fraction(5, 3) <= new Fraction(12, 7));
			Console.WriteLine(new Fraction(5, 3) <= 1);
			Console.WriteLine(new Fraction(5, 3) <= 2);
			Console.WriteLine(new Fraction(5, 3) <= new Fraction(10, 6));
			Console.WriteLine(new Fraction(8, 4) <= 2);

			Console.ReadKey();
		}
	}
}

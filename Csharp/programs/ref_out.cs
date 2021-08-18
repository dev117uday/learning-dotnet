using System;


class RefOutCs
{
	static void EntryPoint(string[] args)
	{
		int sum = 0, product = 0;
		maths(123, 443, out sum, out product);
		Console.WriteLine(sum + "::" + product);
		refChange(ref sum);
		Console.WriteLine(sum);

	}
	public static void maths(int a, int b, out int sum, out int product)
	{
		sum = a + b;
		product = a * b;
	}
	public static void refChange(ref int x)
	{
		x = 10;
	}
}


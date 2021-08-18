using System;


class ArrayType
{
	static void ArrayOps(string[] args)
	{
		string numstring = Console.ReadLine();

		int num = int.Parse(numstring);
		int[] newArr = new int[num];
		newArr[0] = 0;
		newArr[1] = 1;
		newArr[2] = 2;

		foreach (int i in newArr)
		{
			Console.Write(i + " ");
		}

		Console.WriteLine("\n");

		try
		{
			newArr[7] = 7;
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
		}
		int[] t = new int[2];
		t[0] = 1;
		t[1] = 2;
		int[] a = t;
		a[0] = 3;
		a[1] = 4;

		foreach (int s in t)
		{
			Console.Write(s + " ");
		}
		Console.WriteLine();
		foreach (int s in a)
		{
			Console.Write(s + " ");
		}

	}
}


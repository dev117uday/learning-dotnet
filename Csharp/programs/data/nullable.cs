using System;
class NullableType
{
	static void EntryPoint(string[] args)
	{
		int? ex = null;
		string name = null;
		if (ex == null)
		{
			Console.WriteLine("null");
		}
		else
		{
			Console.WriteLine("not null");
		}
		Console.WriteLine(name);
	}
}




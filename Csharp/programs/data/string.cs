using System;

namespace programs
{
	class StringType
	{
		static void EntryPoint(string[] args)
		{
			Console.WriteLine("Hello World!");
			var name = "Uday Yadav";
			string path = $@"/home/uday/programming/learning-csharp 
				by {name}";
			Console.WriteLine("pwd : " + path);
		}
	}
}



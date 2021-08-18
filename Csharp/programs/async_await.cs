
using System;
using System.Threading.Tasks;

namespace Program
{
	class AsyncAwait
	{
		public static async Task EntryPoint()
		{
			// var result = MakeTea();
			// Console.WriteLine(result);

			var resultasync = await MakeTeaAsync();
			Console.WriteLine(resultasync);
		}

		static public string MakeTea()
		{
			var water = BoilWater();
			Console.WriteLine($"received {water}");
			Console.WriteLine("take out cups");
			Console.WriteLine("add tea and sugar cube");
			var tea = $"put {water} in cups, serve !";
			return tea;
		}

		static public string BoilWater()
		{
			Console.WriteLine("start the kettle");
			Task.Delay(2000).GetAwaiter().GetResult();
			return "hot water";
		}

		static public async Task<string> MakeTeaAsync()
		{
			var boilingwater = BoilWaterAsync();
			
			Console.WriteLine("take out cups");
			Console.WriteLine("add tea and sugar cube");

			var water = await boilingwater;
			Console.WriteLine($"received {water}");


			var tea = $"put {water} in cups, serve !";
			return tea;
		}

		static public async Task<string> BoilWaterAsync()
		{
			Console.WriteLine("start the kettle");
			await Task.Delay(2000);
			return "hot water";
		}

	}
}

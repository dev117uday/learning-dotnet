using System;

namespace Solution
{
	public class EnumType
	{
		public enum SomeRootVegetable
		{
			HorseRadish,
			Radish,
			Turnip
		}

		[Flags]
		public enum Seasons
		{
			None = 0,
			Summer = 1,
			Autumn = 2,
			Winter = 4,
			Spring = 8,
			All = Summer | Autumn | Winter | Spring
		}

		public static void EntryPoint(string[] args)
		{
			var turnip = SomeRootVegetable.Turnip;
			var spring = Seasons.Spring;
			var startingOnEquinox = Seasons.Spring | Seasons.Autumn;
			var theYear = Seasons.All;

			Console.WriteLine(turnip + " " + spring + " " + startingOnEquinox + " " + theYear);
		}
	}
}
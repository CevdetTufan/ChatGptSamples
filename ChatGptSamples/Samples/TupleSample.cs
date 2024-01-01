using BenchmarkDotNet.Attributes;

/*
 * Tuple is data structer that allows you store multiple element of different types in a single variable. Without class, tuple provides returnig multiple values from method.
 */
namespace ChatGptSamples.Samples
{
	[MemoryDiagnoser]
	public class TupleSample
	{
		//C# 7.0
		[Benchmark]
		public Tuple<int,string, double> GetTupleSample()
		{
			var tuple = new Tuple<int, string, double>(1, "Istanbul", 2.3);

			return tuple;
		}

		//C# 7.1
		//Value Tuple is faster than Tuple that acording Benchmark test.
		[Benchmark]
		public (int, string, double) GetValueTupleSample()
		{
			var tuple = (1, "Istanbul", 2.3);

			return tuple;
		}

		public Tuple<string, float> GetLocalWeather()
		{
			var weather = new Tuple<string, float>("Sunny", 24);
			return weather;
		}
	}
}

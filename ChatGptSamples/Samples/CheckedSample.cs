using BenchmarkDotNet.Attributes;

namespace ChatGptSamples.Samples
{
	[MemoryDiagnoser]
	public class CheckedSample
	{
		//taşma kontrolü var, bilinçli yapılmıştır. Hata fırlatır.
		[Benchmark]
		public void CheckedSampleMethod1()
		{
			int a = int.MaxValue; // Maksimum int değeri
			int b = 1;

			try
			{
				checked
				{
					int result = a + b; // Bu işlem taşma oluşturacak
					Console.WriteLine(result);
				}
			}
			catch (OverflowException ex)
			{
				Console.WriteLine("Taşma oluştu: " + ex.Message);
			}
		}

		//Teşma kontrolü yok, hata fırlatmaz. İstenmeyen bir sonuç elde eder.
		[Benchmark]
		public void CheckedSampleMethod2()
		{
			int a = int.MaxValue; // Maksimum int değeri
			int b = 1;

			int result = a + b; // Bu işlem taşma oluşturacak
			Console.WriteLine(result);

		}

		[Benchmark]
		public void UncheckedSampleMethod1()
		{
			byte maxValue = byte.MaxValue; // Byte türünün maksimum değeri
			byte value = 200;

			// unchecked kullanılarak taşma durumu
			unchecked
			{
				byte resultWithUnchecked = (byte)(value + maxValue); // Taşma durumu oluşsa bile istisna fırlatılmaz
				Console.WriteLine("Sonuç (unchecked kullanılarak): " + resultWithUnchecked); // Bu değer wrap-around olacak
			}
		}

		//hata fırlatmaz fakat unchecked kullanılmadığı için performansı etkiler.
		[Benchmark]
		public void UncheckedSampleMethod2()
		{
			byte maxValue = byte.MaxValue; // Byte türünün maksimum değeri
			byte value = 200;

			// unchecked kullanılmadan taşma durumu
			byte resultWithoutUnchecked = (byte)(value + maxValue);
			Console.WriteLine("Sonuç (unchecked kullanılmadan): " + resultWithoutUnchecked); // Bu değer beklenenden farklı olacak
		}
	}
}

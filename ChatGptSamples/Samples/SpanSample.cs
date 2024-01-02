using BenchmarkDotNet.Attributes;

//Bellek kopyalama işini minimize eder. Dizinin bir bölümünden kesit alıp, o kesit üzerinden işlem yapmamıza olanak verir. referans aldığımız değer de aynı zamanda değişir.
namespace ChatGptSamples.Samples
{
	[MemoryDiagnoser]
	public class SpanSample
	{
		public void Sample()
		{
			int[] arrays = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };

			//diziden bir sapn oluşturuldu.
			Span<int> span = arrays.AsSpan();

			//span 1. elemanı 10 olarak değiştirildi ve dizinin 1. elamanınıda 10 olarak değişecek.
			span[1] = 10;

			Console.WriteLine(arrays[1]);
		}

		public int CountWordsInFileSpan(string filePath)
		{
			using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
			using (StreamReader sr = new StreamReader(fs))

			{
				string fileContent = sr.ReadToEnd();

				char[] charArray = fileContent.ToCharArray();

				Span<char> charSpan = charArray.AsSpan();

				int wordCount = 0;
				bool inWord = false;

				foreach (var character in charSpan)
				{
					if (char.IsWhiteSpace(character))
					{
						// Boşluk karakteriyle karşılaşıldığında kelimenin içinde değilse, kelime sayısını artır
						if (inWord)
						{
							wordCount++;
							inWord = false;
						}
					}
					else
					{
						// Boşluk karakteri dışındaki bir karakterle karşılaşıldığında kelimenin içinde olduğunu belirt
						inWord = true;
					}
				}

				// Dosyanın sonunda kelime varsa sayıya ekle
				if (inWord)
				{
					wordCount++;
				}

				return wordCount;
			}
		}

		public int CountWordsInFileArray(string filePath)
		{
			using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
			using (StreamReader sr = new StreamReader(fs))

			{
				string fileContent = sr.ReadToEnd();

				char[] charArray = fileContent.ToCharArray();

				List<char> charList = charArray.ToList();

				int wordCount = 0;
				bool inWord = false;

				foreach (var character in charList)
				{
					if (char.IsWhiteSpace(character))
					{
						// Boşluk karakteriyle karşılaşıldığında kelimenin içinde değilse, kelime sayısını artır
						if (inWord)
						{
							wordCount++;
							inWord = false;
						}
					}
					else
					{
						// Boşluk karakteri dışındaki bir karakterle karşılaşıldığında kelimenin içinde olduğunu belirt
						inWord = true;
					}
				}

				// Dosyanın sonunda kelime varsa sayıya ekle
				if (inWord)
				{
					wordCount++;
				}

				return wordCount;
			}
		}
	}


	[MemoryDiagnoser]
	public class SpanBenchmark
	{
		private byte[] data;

		[Params(1000, 10000, 100000)]
		public int ArraySize;


		[GlobalSetup]
		public void Setup()
		{
			// Her benchmark öncesi veriyi hazırla
			data = new byte[ArraySize];
			new Random().NextBytes(data);
		}

		[Benchmark]
		public int SumArray()
		{
			int sum = 0;
			for (int i = 0; i < data.Length; i++)
			{
				sum += data[i];
			}
			return sum;
		}

		[Benchmark]
		public int SumSpan()
		{
			int sum = 0;
			Span<byte> span = data.AsSpan();
			foreach (var value in span)
			{
				sum += value;
			}
			return sum;
		}

	}
}

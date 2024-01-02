



using ChatGptSamples.Samples;
using Microsoft.DotNet.PlatformAbstractions;

SpanSample spanSample = new SpanSample();

DateTime startTime= DateTime.Now;

//16314 adet kelime 0,0127877 sn.de okundu.
//var wordCount = spanSample.CountWordsInFileSpan($"{ApplicationEnvironment.ApplicationBasePath}/Files/Loremipsum.txt");

//16314 adet kelime 0,005695 sn.de okundu.
var wordCount = spanSample.CountWordsInFileArray($"{ApplicationEnvironment.ApplicationBasePath}/Files/Loremipsum.txt");

DateTime endTime = DateTime.Now;

Console.WriteLine($"{ wordCount} adet kelime {(endTime - startTime).TotalSeconds} sn.de okundu.");





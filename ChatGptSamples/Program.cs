

using BenchmarkDotNet.Running;
using ChatGptSamples.Samples;

var summary = BenchmarkRunner.Run<TupleSample>();

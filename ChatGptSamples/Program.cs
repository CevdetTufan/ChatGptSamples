

using ChatGptSamples.Samples;

SharedCounter sharedCounter = new SharedCounter(0);

// Start two threads to increment the counter concurrently
Thread thread1 = new Thread(sharedCounter.IncrementCounter);
Thread thread2 = new Thread(sharedCounter.IncrementCounter);

thread1.Start();
thread2.Start();

// Wait for both threads to complete
thread1.Join();
thread2.Join();

// Display the final counter value
Console.WriteLine("Final Counter Value: " + sharedCounter.GetCounter());

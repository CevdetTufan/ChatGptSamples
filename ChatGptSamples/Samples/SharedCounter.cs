namespace ChatGptSamples.Samples
{
	public class SharedCounter
	{
		private volatile int counter;

        public SharedCounter(int initialValue)
        {
            counter = initialValue;
        }

		public void IncrementCounter()
		{
			for (int i = 0; i < 1000; i++)
			{
				// Simulate some processing
				Thread.Sleep(1);
				lock (this)
				{

					// Increment the counter in a thread-safe manner
					counter++; 
				}
			}
		}

		public int GetCounter()
		{
			return counter;
		}
	}
}

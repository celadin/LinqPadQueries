<Query Kind="Program" />

void Main()
{
	Thread t = new Thread(DoWork);
	t.Start();


	for (int i = 0; i < 100; i++)
	{
		readyForResult.WaitOne();
		lock (lockObj)
		{
			Console.WriteLine(result);
		}

		Thread.Sleep(10);
		
		setResult.Set();
	}
	
	t.Abort();

}

static object lockObj = new object();
int result = 0;

EventWaitHandle readyForResult = new AutoResetEvent(false);
EventWaitHandle setResult = new AutoResetEvent(false);

void DoWork()
{
	while (true)
	{
		int i = result;

		Thread.Sleep(1);

		readyForResult.Set();
		lock (lockObj)
		{
			result = i + 1;
		}
		setResult.WaitOne();
	}
}

// Define other methods and classes here

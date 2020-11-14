<Query Kind="Program" />

void Main()
{
	Consumers.Add(new Thread(() => { DoWork(ConsoleColor.Red); }));

	Consumers.Add(new Thread(() => { DoWork(ConsoleColor.Green); }));

	Consumers.Add(new Thread(() => { DoWork(ConsoleColor.Yellow); }));

	Consumers.ForEach(t => t.Start());

	var r = new Random();
	while (true)
	{
		EnqueueTask(() =>
		{
			var number = r.Next(10);
			Console.Write("  " + number);
		});

		Thread.Sleep(TimeSpan.FromSeconds(1));
	}

}

private static readonly List<Thread> Consumers = new List<Thread>();

private static readonly Queue<Action> Tasks = new Queue<Action>();

private static readonly object QueueLock = new object();

private static readonly EventWaitHandle NewTaskAvailable = new AutoResetEvent(false);

private static readonly object ConsoleLock = new object();

private static void EnqueueTask(Action task)
{
	lock (QueueLock)
	{
		Tasks.Enqueue(task);
	}

	NewTaskAvailable.Set();
}

private static void DoWork(ConsoleColor color)
{
	while (true)
	{
		Action task = null;
		lock (QueueLock)
		{
			if (Tasks.Count > 0) task = Tasks.Dequeue();
		}

		if (task != null)
		{
			lock (ConsoleLock)
			{
				Console.ForegroundColor = color;
			}

			task();
		}
		else
		{
			NewTaskAvailable.WaitOne();
		}
	}
}





// Define other methods and classes here

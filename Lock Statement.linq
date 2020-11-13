<Query Kind="Program" />

void Main()
{

	Thread t1 = new Thread(DoWork);
	Thread t2 = new Thread(DoWork);

	t1.Start();
	t2.Start();
}

static int value1 = 1;
static int value2 = 1;

//best practice : use private unique sync object
private static object syncObj = new object();

static void DoWork()
{
	lock (syncObj)
	{
		if (value2 > 0)
		{
			Console.WriteLine(value1 / value2);
			value2 = 0;
		}
		else
		{
			Console.WriteLine("value2 smaller than 0");
		}
	}

}

// Define other methods and classes here

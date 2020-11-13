<Query Kind="Program" />

void Main()
{
	Thread t = new Thread(DoWork);
	t.Start();
	
	//t thread çalışmasını bitirinceye kadar main thread ilerlemez.
	//t.Join();
	//t.Interrupt();
	//t.Abort();
	
	DoWork();

}


bool Finished = false;

void DoWork()
{
	if (!Finished)
	{
		//Finished = true;
		Console.WriteLine("Race Condition");
		Finished = true;
	}
}


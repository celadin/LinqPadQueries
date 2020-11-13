<Query Kind="Program" />

void Main()
{
	var t1 = new Thread(new ThreadStart(() => { DoWork("T1"); }));
	t1.Name = "Celalettin Threat";
	t1.Start();

	var t2 = new Thread(() => { DoWork("T2"); });
	t2.Start();

	var t3 = new Thread(DoWork);
	t3.Start("T3");

	DoWork("A");

}

const int REPETITIONS = 1000;

void DoWork(object obj)
{
	string word = obj.ToString();
	for (int i = 0; i < REPETITIONS; i++)
	{
		Console.Write(word);
	}

	Console.WriteLine("");
}

// Define other methods and classes here
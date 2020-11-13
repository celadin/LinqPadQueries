<Query Kind="Program" />

void Main()
{
	A.Add(5,5).Dump("A. Add");
	
	B.Add(5,5).Dump("B. Add");
	
}

// Define other methods and classes here


class A {
	
	public static int Add(int x, int y){
		return x + y;
	}

	public static int Add(int x, int y, int z)
	{
		return x + y + z;
	}
}

class B : A
{

	public static int Add(int x, int y)
	{
		return x + y + 5;
	}

	public static int Add(int x, int y, int z)
	{
		return x + y + z + 5;
	}
}
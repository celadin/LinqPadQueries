<Query Kind="Program" />

void Main()
{
	var a = 5;	
	ChangeByRef(ref a);
	a.Dump("Ref");
	
	int b ;
	ChangeByOut(out b);
	b.Dump("Out");
	
}

void ChangeByRef(ref int i){
	i += 5;
}

void ChangeByOut(out int i)
{
	i = 5;
}

// Define other methods and classes here

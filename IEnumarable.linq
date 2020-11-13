<Query Kind="Program" />

void Main()
{
	//var myparams = new MyParams(1,2,3);
	//foreach (var element in myparams)
	//{
	//	element.Dump();
	//}
	
	var person = new Person("Celalettin", "M.", "Altıntaş");
	foreach (var name in person.Names)
	{
		name.Dump();
	}
}

class MyParams : IEnumerable<int>
{
	private int a, b, c;
	public MyParams(int a, int b, int c)
	{
		this.a = a;
		this.b = b;
		this.c = c;
	}

	public IEnumerator<int> GetEnumerator()
	{
		yield return a;
		yield return b;
		yield return c;
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}

class Person
{
	private string firstName, middleName, lastName;
	public Person(string firstName, string middleName, string lastName)
	{
		this.firstName = firstName;
		this.middleName = middleName;
		this.lastName = lastName;
	}

	public IEnumerable<string> Names
	{
		get
		{
			yield return firstName;
			yield return middleName;
			yield return lastName;
		}
	}
}

// Define other methods and classes here

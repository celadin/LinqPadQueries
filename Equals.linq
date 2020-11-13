<Query Kind="Program" />

void Main()
{
	//string name = "sandeep";
	//string myName = name;
	//Console.WriteLine("== operator result is {0}", name == myName);
	//Console.WriteLine("Equals method result is {0}", name.Equals(myName));


	//object name = "sandeep";
	//char[] values = { 's', 'a', 'n', 'd', 'e', 'e', 'p' };
	//object myName = new string(values);
	//Console.WriteLine("== operator result is {0}", name == myName);
	//Console.WriteLine("Equals method result is {0}", myName.Equals(name));
	
	
	
	var a1 = new A() {MyProperty = 1};
	var a2 = new A() {MyProperty = 1};

	Console.WriteLine("== operator result is {0}", a1 == a2);
	Console.WriteLine("Equals method result is {0}", a1.Equals(a2));
}


class A {
	public int MyProperty { get; set; }
}



// Define other methods and classes here

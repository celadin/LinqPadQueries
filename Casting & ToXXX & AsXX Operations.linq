<Query Kind="Statements" />

var list = new ArrayList();// it is used in an old version of .net
list.Add(1);
list.Add(2);
list.Add(3);

//list.Select(i=> (int)i).Sum().Dump(); //it is not working

list.Cast<int>().Dump();
list.Cast<int>().Average().Dump();
list.Cast<int>().Sum().Dump();

Console.WriteLine("\n///////////////////////////////////////////////////////////////////////////////////\n");



var numbers = Enumerable.Range(1, 10);
var arr = numbers.ToArray();
arr.Dump();

var dict = numbers.ToDictionary(i => (double)i / 10, i => i % 2 == 0);
dict.Dump();


var arr2 = new [] {1,2,3};
IEnumerable<int> arrIEn = arr2.AsEnumerable();





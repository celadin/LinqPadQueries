<Query Kind="Statements" />


Enumerable.Empty<int>().Dump();

Enumerable.Repeat("Hello", 3).Dump();

Enumerable.Range(1,10).Dump();

Enumerable.Range('a', 'z'-'a' + 1).Select(s=>(char)s).Dump();

Enumerable.Range(1,10).Select(n=> new String('x', n)).Dump();
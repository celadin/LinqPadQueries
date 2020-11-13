<Query Kind="Statements" />

Console.WriteLine("\n////////////////////////////// Select Operation (Mapping) /////////////////////////////////////////////\n");

var numbers = Enumerable.Range(1, 4);
var squares = numbers.Select(x => x * x);
//squares.Dump();

string sentence = "This is a nice sentence";
var wordLengths = sentence.Split().Select(w => w.Length);
//wordLengths.Dump();

var wordsWithLength = sentence.Split().Select(w => new { Word = w, Length = w.Length });
//wordsWithLength.Dump();

var rand = new Random();
var randomNumbers = Enumerable.Range(1, 10).Select(_ => rand.Next(10));
//randomNumbers.Dump();


Console.WriteLine("\n////////////////////////////SelectMany Operation (Flattening) //////////////////////////////////////////\n");

var sequences = new[] { "red,green,blue", "orange", "white,pink" };
var allWords = sequences.SelectMany(s=> s.Split(','));
allWords.Dump();










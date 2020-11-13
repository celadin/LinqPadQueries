<Query Kind="Program" />

void Main()
{

}

string GetCanonicalForm(string searchTerm)
{
	return searchTerm
	.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
	.Select(x => x.ToUpper())
	.OrderBy(x => x)
	.Aggregate(string.Empty, (x, y) => x + " " + y)
	.Trim();
}


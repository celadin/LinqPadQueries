<Query Kind="Program" />

void Main()
{
	FindOddValues(Enumerable.Range(1, 10).ToList()).Dump("Odds 1");
	FindOddValues2(Enumerable.Range(1, 10).ToList()).Dump("Odds 2");
}

IList<int> FindOddValues(IList<int> values)
{
	var allOdds = new List<int>();

	void Helper(IList<int> valuesUnchecked)
	{
		if (!valuesUnchecked.Any())
			return;

		if (valuesUnchecked.First() % 2 != 0)
		{
			allOdds.Add(valuesUnchecked.First());
		}

		Helper(valuesUnchecked.Skip(1).ToList());
	}

	Helper(values);

	return allOdds;
}

IList<int> FindOddValues2(IList<int> values){
	var newValues = new List<int>();
	if(!values.Any())
		return newValues;
		
	if(values.First() % 2 != 0)
		newValues.Add(values.First());
		
	newValues = newValues.Concat(FindOddValues2(values.Skip(1).ToList())).ToList();
	
	return newValues;
}




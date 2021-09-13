<Query Kind="Program" />

void Main()
{
	var graph = new Graph();
	graph.
		AddVertex("Batman").
		AddVertex("Istanbul").
		AddVertex("Amsterdam");

	graph.
		AddEdge("Batman", "Amsterdam").
		AddEdge("Istanbul", "Amsterdam").
		AddEdge("Istanbul", "Batman");
	graph.Print("Complete List");
	
	graph.
		RemoveEdge("Istanbul", "Batman");
	graph.Print("After removing an edge (Istanbul - Batman)");
	
	graph.RemoveVertex("Istanbul");
	graph.Print("After removing a vertex (Istanbul)");
}

class Graph
{
	private IDictionary<string, IList<string>> adjacencyList;
	public Graph()
	{
		adjacencyList = new Dictionary<string, IList<string>>();
	}

	public Graph AddVertex(string vertex)
	{
		if (!adjacencyList.ContainsKey(vertex))
		{
			adjacencyList.Add(vertex, new List<string>());
		}

		return this;
	}

	public Graph RemoveVertex(string vertex)
	{
		var neighbors = adjacencyList[vertex];

		foreach (var neighbor in neighbors)
		{
			adjacencyList[neighbor].Remove(vertex);
		}

		adjacencyList.Remove(vertex);

		return this;
	}

	public Graph AddEdge(string vertex1, string vertex2)
	{
		adjacencyList[vertex1].Add(vertex2);
		adjacencyList[vertex2].Add(vertex1);

		return this;
	}

	public Graph RemoveEdge(string vertex1, string vertex2)
	{
		adjacencyList[vertex1].Remove(vertex2);
		adjacencyList[vertex2].Remove(vertex1);

		return this;
	}

	public void Print(string specialTitle)
	{
		adjacencyList.Dump(specialTitle);
	}
}
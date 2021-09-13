<Query Kind="Program" />

void Main()
{
	var graph = new Graph();
	graph.
		AddVertex("A").
		AddVertex("B").
		AddVertex("C").
		AddVertex("D").
		AddVertex("E").
		AddVertex("F");

	graph.
		AddEdge("A", "B").
		AddEdge("A", "C").
		AddEdge("B", "D").
		AddEdge("C", "E").
		AddEdge("D", "E").
		AddEdge("D", "F").
		AddEdge("E", "F");

	graph.RecursiveDepthFirst("A").Dump("DFS : Recursive Solution : A Traverse Order");

	graph.IterativeDepthFirst("A").Dump("DFS : Iterative Solution : A Traverse Order");

	graph.RecursiveBreadthFirst("A").Dump("BFS : Recursive Solution : A Traverse Order");

	graph.IterativeBreadthFirst("A").Dump("BFS : Iterative Solution : A Traverse Order");
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

	public List<string> RecursiveDepthFirst(string startingPoint)
	{
		var traversed = new List<string>();

		Traverse(startingPoint);

		return traversed;

		void Traverse(string vertex)
		{
			if (!adjacencyList.ContainsKey(vertex))
				return;

			traversed.Add(vertex);

			foreach (var neighbor in adjacencyList[vertex])
			{
				if (!traversed.Contains(neighbor))
				{
					Traverse(neighbor);
				}
			}
		}
	}

	public List<string> IterativeDepthFirst(string startingPoint)
	{
		var traversed = new List<string>();

		var stack = new Stack<string>();
		stack.Push(startingPoint);

		string vertex;
		while (stack.Any())
		{
			vertex = stack.Pop();
			if (!traversed.Contains(vertex))
			{
				traversed.Add(vertex);

				foreach (var neighbor in adjacencyList[vertex])
				{
					stack.Push(neighbor);
				}
			}
		}

		return traversed;
	}


	public List<string> RecursiveBreadthFirst(string startingPoint)
	{
		var traversed = new List<string>();

		Traverse(startingPoint);

		void Traverse(string vertex)
		{
			if (!adjacencyList[vertex].Any())
				return;

			if (traversed.Contains(vertex))
				return;

			traversed.Add(vertex);

			var willBeRecursed = new List<string>();
			foreach (string neighbor in adjacencyList[vertex])
			{
				if (!traversed.Contains(neighbor))
				{
					traversed.Add(neighbor);
					willBeRecursed.Add(neighbor);
				}
			}

			foreach (string recursed in willBeRecursed)
			{
				foreach (var neighbor in adjacencyList[recursed])
				{
					Traverse(neighbor);
				}
			}
		}

		return traversed;
	}

	public List<string> IterativeBreadthFirst(string startingPoint)
	{
		var traversed = new List<string>();

		var queue = new Queue<string>();
		queue.Enqueue(startingPoint);

		string vertex;
		while (queue.Any())
		{
			vertex = queue.Dequeue();
			traversed.Add(vertex);

			foreach (var neighbor in adjacencyList[vertex])
			{
				if (!traversed.Contains(neighbor) && !queue.Contains(neighbor))
				{
					queue.Enqueue(neighbor);
				}
			}
		}

		return traversed;
	}

}

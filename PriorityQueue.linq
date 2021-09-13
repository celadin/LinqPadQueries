<Query Kind="Program" />

void Main()
{
	var queue = new PriorityQueue();
	queue.Enqueue("cold", 5);
	queue.Enqueue("flu", 4);
	queue.Enqueue("covid", 3);
	queue.Enqueue("before terminal", 2);
	queue.Enqueue("terminal", 1);
	queue.Enqueue("just for fun", 6);

	queue.GetElements().Dump("All Elements");

	Console.WriteLine("=================================");

	while (queue.Dequeue() != null)
	{
		queue.GetElements().Dump("Last Situtation After Dequeue");
		Console.WriteLine("=================================");
	}
}

class Node
{
	public string Value { get; }
	public int Priority { get; }

	public Node(string value, int priority)
	{
		this.Value = value;
		this.Priority = priority;

	}

	public override string ToString()
	{
		return $"Value : {Value}, Priority : {Priority}";
	}
}

/// using min binary heap structure
class PriorityQueue
{
	private Node[] elements;
	private int heapSize;

	public Node[] GetElements() => elements;

	public PriorityQueue Enqueue(string value, int priority)
	{
		Array.Resize<Node>(ref elements, ++heapSize);

		elements[heapSize - 1] = new Node(value, priority);

		BubbleUp();

		return this;
	}

	public Node Dequeue()
	{
		if (heapSize == 0)
			return null;

		var min = elements[0];

		Swap(heapSize - 1, 0);

		Array.Resize<Node>(ref elements, --heapSize);

		SinkDown();

		return min;
	}

	void SinkDown()
	{
		int idx = 0;
		while (idx < heapSize)
		{
			var leftChildIdx = 2 * idx + 1;
			var leftChild = leftChildIdx >= heapSize ? null : elements[leftChildIdx];

			var rightChildIdx = 2 * idx + 2;
			var rightChild = rightChildIdx >= heapSize ? null : elements[rightChildIdx];

			if (leftChild == null && rightChild == null)
				break;

			Node element = elements[idx];
			if (element.Priority > leftChild?.Priority || element.Priority > rightChild?.Priority)
			{
				if (leftChild != null && rightChild == null)
				{
					Swap(idx, leftChildIdx);
					idx = leftChildIdx;
					continue;
				}

				if (rightChild != null && leftChild == null)
				{
					Swap(idx, rightChildIdx);
					idx = rightChildIdx;
					continue;
				}

				if (leftChild.Priority < rightChild.Priority)
				{
					Swap(idx, leftChildIdx);
					idx = leftChildIdx;
				}
				else
				{
					Swap(idx, rightChildIdx);
					idx = rightChildIdx;
				}
			}
		}
	}

	private void BubbleUp()
	{
		int newValueIdx = heapSize - 1;
		int parentValueIdx = (newValueIdx - 1) / 2;

		while (elements[parentValueIdx] != null && elements[newValueIdx].Priority < elements[parentValueIdx].Priority)
		{
			Swap(newValueIdx, parentValueIdx);

			newValueIdx = parentValueIdx;
			parentValueIdx = (parentValueIdx - 1) / 2;
		}
	}

	private void Swap(int newValueIdx, int parentValueIdx)
	{
		Node temp = elements[parentValueIdx];
		elements[parentValueIdx] = elements[newValueIdx];
		elements[newValueIdx] = temp;
	}
}

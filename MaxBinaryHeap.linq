<Query Kind="Program" />

void Main()
{
	var heap = new MaxBinaryHeap();

	heap
	.Insert(10)
	.Insert(20)
	.Insert(30)
	.Insert(25)
	.Insert(32)
	.Insert(5);

	while (heap.ExtractMax() != 0)
	{
		heap.GetElements().Dump("Last Situtation After Extraction");
		Console.WriteLine("=================================");
	}
}


class MaxBinaryHeap
{
	private int[] elements;
	private int heapSize;

	public int[] GetElements() => elements;

	public MaxBinaryHeap Insert(int value)
	{
		//Nice method, But don't use it as much as possible
		Array.Resize<int>(ref elements, ++heapSize);

		elements[heapSize - 1] = value;

		BubbleUp();

		return this;
	}

	public int ExtractMax()
	{
		if (heapSize == 0)
			return 0;

		var max = elements[0];

		Swap(heapSize - 1, 0);		

		//the max is thrown
		Array.Resize<int>(ref elements, --heapSize);

		SinkDown();
		
		return max;
	}

	void SinkDown()
	{
		int idx = 0;
		while (idx < heapSize)
		{
			var leftChildIdx = 2 * idx + 1;
			var leftChild = leftChildIdx >= heapSize ? 0 : elements[leftChildIdx];

			var rightChildIdx = 2 * idx + 2;
			var rightChild = rightChildIdx >= heapSize ? 0 : elements[rightChildIdx];

			if (leftChild == 0 && rightChild == 0)
				break;

			int element = elements[idx];
			if (element < leftChild || element < rightChild)
			{
				if (leftChild > rightChild)
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

		while (elements[parentValueIdx] > 0 && elements[newValueIdx] > elements[parentValueIdx])
		{
			Swap(newValueIdx, parentValueIdx);

			newValueIdx = parentValueIdx;
			parentValueIdx = (parentValueIdx - 1) / 2;
		}
	}

	private void Swap(int newValueIdx, int parentValueIdx)
	{
		int temp = elements[parentValueIdx];
		elements[parentValueIdx] = elements[newValueIdx];
		elements[newValueIdx] = temp;
	}
}
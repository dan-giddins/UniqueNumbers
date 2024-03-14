var inputs = new List<int>();

for (var i = 1; i < 1000; i++)
{
	inputs.Add(i);
	if (!isDistinct(inputs))
	{
		_ = inputs.Remove(i);
	};
}

bool isDistinct(List<int> inputs)
{
	var outputs = new List<int>();

	performOperation(-1, (a, b) => 0, 0, inputs, outputs);

	var orderedOutputs = outputs.Order();

	var distinct = outputs.Count == outputs.Distinct().Count();
	if (distinct)
	{
		Console.WriteLine(string.Join(", ", inputs));
		Console.WriteLine(string.Join(", ", orderedOutputs));
		Console.WriteLine();
	}
	return distinct;
}

void performOperation(int index, Func<int, int, int> operation, int total, List<int> inputs, List<int> outputs)
{
	total = operation.Invoke(total, index++);
	if (index < inputs.Count)
	{
		performOperation(index, (a, b) => a + inputs[b], total, inputs, outputs);
		performOperation(index, (a, b) => a - inputs[b], total, inputs, outputs);
		performOperation(index, (a, b) => a, total, inputs, outputs);
	}
	else
	{
		outputs.Add(total);
	}
}
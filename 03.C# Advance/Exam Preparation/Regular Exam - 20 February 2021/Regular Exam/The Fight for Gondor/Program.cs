
int numberOfWaves = int.Parse(Console.ReadLine());

LinkedList<int> plates = new LinkedList<int>(Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse));

Stack<int> warriorOrcs = new Stack<int>();

int waveCnt = 0;

for (int i = 0; i < numberOfWaves; i++)
{
    int[] orcs = (Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray());

    warriorOrcs = new Stack<int>(orcs);

    waveCnt++;

    if (waveCnt == 3)
    {
        int extraPlate = int.Parse(Console.ReadLine());
        plates.AddLast(extraPlate);
        waveCnt = 0;
    }

    int plateHealth = plates.First();
    plates.RemoveFirst();

    while (plates.Count != 0 && warriorOrcs.Count != 0)
    {
        

        if (warriorOrcs.Peek() > plateHealth)
        {
            int token = warriorOrcs.Pop();
            token -= plateHealth;
            warriorOrcs.Push(token);
            token = 0;
        }
        if (plateHealth > warriorOrcs.Peek())
        {
            plateHealth -= warriorOrcs.Peek();
            warriorOrcs.Pop();
        }
        else
        {
            warriorOrcs.Pop();
        }
    }

    if (plates.Count == 0)
    {
        break;
    }
}

Console.WriteLine(plates.Any()
    ? $"The people successfully repulsed the orc's attack.\nPlates left: {string.Join(", ", plates)}"
    : $"The orcs successfully destroyed the Gondor's defense.\nOrcs left: {string.Join(", ", warriorOrcs)}");

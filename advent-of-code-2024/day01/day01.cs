namespace advent_of_code_2024.day01;

internal static class day01
{
    public static void Run()
    {
        var input = File.ReadAllText("day01/input").Split("\n").ToArray();

        var list1 = new List<int>();
        var list2 = new List<int>();

        foreach (var line in input)
        {
            if (line.Length == 0)
            {
                continue;
            }
            list1.Add(int.Parse(line.Substring(0, line.IndexOf(' '))));
            list2.Add(int.Parse(line.Substring(line.IndexOf(' '))));
        }

        list1 = [.. list1.OrderBy(x => x)];
        list2 = [.. list2.OrderBy(x => x)];


        var result = 0;
        for (var i = 0; i < list1.Count; i++)
        {
            var distance = Math.Abs(list2[i] - list1[i]);
            result += distance;
        }

        var resultPart2 = 0;
        for (var i = 0; i < list1.Count; i++)
        {
            var countInList2 = list2.Count(x => x == list1[i]);
            resultPart2 += (countInList2 * list1[i]);
        }


        Console.WriteLine($"{result} - {resultPart2}");
    }
}

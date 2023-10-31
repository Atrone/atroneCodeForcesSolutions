int line_number = 1;
int n = 0;
int k = 0;
int q = 0;
List<int> a = new List<int>();


using (StreamReader reader = new StreamReader("t.txt"))
{
    while (!reader.EndOfStream)
    {
        string line = reader.ReadLine();
        if (line_number == 1)
        {
            n = int.Parse(line.Split(" ")[0]);
            k = int.Parse(line.Split(" ")[1]);
            q = int.Parse(line.Split(" ")[2]);
        }
        else
        {
            foreach(var l in line.Split(" "))
            {
                a.Add(int.Parse(l));
            }
        }
        line_number = line_number + 1;
    }
}
List<List<int>> sub_lists = new List<List<int>>();

int i = 0;
int prev_i = 0;
foreach(var ai in a)
{
    if(i == prev_i && ai <= q)
    {
        sub_lists.Add(new List<int>{ai});
        i = i + 1;
    }
    else if(ai <= q)
    {
        sub_lists[prev_i].Add(ai);
    }
    else
    {
        prev_i = i;
    }
}

int all_combos = 0;

foreach(List<int> sub_list in sub_lists)
{
    if(sub_list.Count >= k && sub_list.Count <= n)
    {
        Permutations.GetPermutations(sub_list, sub_list.Count);
        all_combos = all_combos + Permutations.count;
    }
}

Console.WriteLine(all_combos);


public class Permutations
{
    public static int count {get; set;}
    
    public static void GetPermutations<T>(List<T> list, int permutationLength)
    {
        count = 0;
        GetPermutations(new List<T>(), list, permutationLength);
    }

    private static void GetPermutations<T>(List<T> current, List<T> remaining, int length)
    {
        if (current.Count == length)
        {
            count = count + 1;
            return;
        }

        for (int i = 0; i < remaining.Count; i++)
        {
            List<T> newRemaining = new List<T>(remaining);
            newRemaining.RemoveAt(i);

            List<T> newCurrent = new List<T>(current) { remaining[i] };
            GetPermutations(newCurrent, newRemaining, length);
        }
    }
}

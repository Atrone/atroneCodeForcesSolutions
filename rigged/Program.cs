// See https://aka.ms/new-console-template for more information
// given n athletes with strength s and endurance e, find weight w such that
// n1 lifts it the most times

// if n == 2 and n1 == n2, print -1
// else: sort by s, map with e, choose sSorted[sSorted.indexOf(s1)-1] as w
// if sSorted.indexOf(s1)-1 < 0, print -1
// if any sSorted.indexOf(s1)+i (where sSorted.indexOf(s1)+i < n) e value > e1
// print -1

int line_number = 1;
int n = 0;
Dictionary<int,int> athletes = new Dictionary<int,int>();
using (StreamReader reader = new StreamReader("t.txt"))
{
    while (!reader.EndOfStream)
    {
        string line = reader.ReadLine();
        if (line_number == 1)
        {
            n = int.Parse(line);
        }
        else
        {
            athletes[int.Parse(line.Split(" ")[0])] = int.Parse(line.Split(" ")[1]);
        }
        line_number = line_number + 1;
    }
}
if(n == 2 && athletes.First().Key == athletes.Last().Key && athletes.First().Value == athletes.Last().Value)
{
    Console.WriteLine("-1");
}
else
{
    SortedDictionary<int,int> sortedAthletes = new SortedDictionary<int,int>(athletes);
    List<int> s = new List<int>();
    List<int> e = new List<int>();
    foreach(KeyValuePair<int,int> kvp in sortedAthletes)
    {
        s.Add(kvp.Key);
        e.Add(kvp.Value);
    }
    if(s.IndexOf(athletes.First().Key)-1 < 0)
    {
        Console.WriteLine("-1");
    }
    else
    {
        int i = 1;
        bool flag = true;
        foreach(var strength in s)
        {
            if(s.IndexOf(athletes.First().Key)+i > e.Count - 1)
            {
                break;
            }
            if(e[s.IndexOf(athletes.First().Key)+i] > athletes.First().Value)
            {
                flag = false;
                Console.WriteLine("-1");
            }
        }
        if(flag)
        {
            Console.WriteLine(s[s.IndexOf(athletes.First().Key)-1] + 1);
        }
    }

}



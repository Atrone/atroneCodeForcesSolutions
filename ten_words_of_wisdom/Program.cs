int line_number = 1;
int n = 5;
List<int> qualities = new List<int>();
List<int> lengths = new List<int>();
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
            qualities.Add(int.Parse(line.Split(" ")[1]));
            lengths.Add(int.Parse(line.Split(" ")[0]));
        }
        line_number = line_number + 1;
    }
}


int biggest = 0;
foreach(var quality in qualities)
{
    if(lengths[qualities.IndexOf(quality)] < 10)
    {
        if(quality > biggest)
        {
            biggest = quality;
        }
    }
}
Console.WriteLine(biggest);
int n = 5;
if(n == 1)
{
    Console.WriteLine('0');
}
else
{
    Dictionary<int,int> coords = new Dictionary<int,int>();
    for(int i = 0; i < n; i++)
    {
        if(i == 0)
        {
           coords[i] = i;
        }   
        else
        {
           coords[i] = i;
           if(coords.Count >= n)
           {break;}
           coords[-i] = -i;
           if(coords.Count >= n)
           {break;}
        }
    }
    int biggest_cost = 0;
    int cost = 0;
    foreach(KeyValuePair<int,int> kvp in coords)
    {
        cost = kvp.Key;
        if(cost < 0)
        {
            cost = cost * -1;
        }
        if(cost > biggest_cost)
        {
	        biggest_cost = cost;
        }
    }
    Console.WriteLine(biggest_cost);
}

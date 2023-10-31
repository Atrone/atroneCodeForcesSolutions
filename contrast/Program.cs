int n = 5;
int i = 0;
List<int> a = new List<int>{1,3,3,3,7};
while(true)
{
    i = i + 1;
	if(i + 1 >= a.Count)
	{
		break;
	}
	if(a.Count > 2)
	{
		if(a[i-1] == a[i] && a[i] == a[i+1])
		{
			a.RemoveAt(i);
			i = 0;
		}
		else if(Math.Abs(a[i-1] - a[i+1]) >= Math.Abs(a[i-1] - a[i]) + Math.Abs(a[i] - a[i+1]))
		{
			a.RemoveAt(i);
			i = 0;
		}
	}
	else if(a.Count == 2)
	{
		if(a[i] == a[i+1])
		{
			Console.WriteLine('1');
		}
		else
		{
			Console.WriteLine('2');
		}
	}
}
Console.WriteLine(a.Count);
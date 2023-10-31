// See https://aka.ms/new-console-template for more information
// reverse engineer the sequence game
// ignore all but last digit
// b1 = a1
// if n = 1 then a = b
// a2 = 1
// a2 < a3, a3 = b2
// if(b2+i+1 < b2+i)
//    a5 = b2+i+1, a6 = b2+i+1
// if(b3 > b2)
//    a5 = b2+i+1

int n = 5;
int[] b = {1,2,2,1,1};
List<int> a = new List<int>();


a.Add(b[0]);

if(n == 1)
{
    foreach(var a1 in a)
    {
        //Console.WriteLine(a1);
    }
}
else
{
    a.Add(b[1]-1);
    a.Add(b[1]);
    int i = 0;
    while((a.Count < (b.Length * 2 - i)-1))
    {
        if(b[1+i+1] < b[1+i])
        {
            a.Add(b[1+i+1]);
            a.Add(b[1+i+1]);
        }
        else
        {
            a.Add(b[1+i+1]);
        }
        if(i+2 < b.Length-1)
        {
            i = i + 1;
        }
    }
}
foreach(var a2 in a)
{
    Console.WriteLine(a2);
}

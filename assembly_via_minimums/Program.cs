using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    public static IEnumerable<IEnumerable<T>> GetCombinations<T>(IEnumerable<T> list, int length)
    {
        if (length == 0)
        {
            return new[] { new T[0] };
        }

        return list.SelectMany((value, index) => 
               GetCombinations(list.Skip(index + 1), length - 1)
               .Select(combination => new[] { value }.Concat(combination)));
    }

    public static List<List<T>> CreateXCombinations<T>(T[] array, int y)
    {
        var combinations = GetCombinations(array, y);
        List<List<T>> n_combs = new List<List<T>>();
        int counter = 1;
        foreach (var combination in combinations)
        {
            n_combs.Add(combination.ToList());
            Console.WriteLine($"List {counter}: {string.Join(", ", combination)}");
            counter++;
        }
        return n_combs;
    }

    static void Main(string[] args)
    {
        int[] array = new[] { 7,5,3,5,3,3 };
        int n = 4;
        var combinations = CreateXCombinations(array, 2);

        int counter = 0;
        if(array.Length == n)
        {
            foreach (var combination in combinations)
            {
                Console.WriteLine(combination.Max());
            }
        }
        else if(array.Length > n)
        {
            foreach (var combination in combinations)
            {
                if(counter == 0)
                {
                    Console.WriteLine(combination[0]);
                }
                Console.WriteLine(combination[1]);
                counter++;
                if(counter - 1 > (n/(n-1)*2))
                {
                    break;
                }
            }
        }
    }
}

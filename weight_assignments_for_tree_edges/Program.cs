// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
int n = 2;
int[] b = {3, 1, 3, 3, 1};
int[] p = {3, 1, 2, 5, 4};

if (n == 1)
{
    if(b.SequenceEqual(p))
    {
        Console.WriteLine("1");
    }
    else
    {
        Console.WriteLine("None");
    }
}
else
{
    int[] root = {0,0};
    for (int i2 = 0; i2 < b.Length; i2++)
    {
        if(b[i2] == i2 + 1)
        {
            root = new int[] {b[i2],i2 + 1};
            break;
        }
    }
    foreach(var i3 in root)
    {
        //Console.WriteLine(i3);
    }
    Dictionary<int, List<Dictionary<int,int>>> tree = new Dictionary<int, List<Dictionary<int,int>>>();
    tree.Add(root[0], new List<Dictionary<int,int>>());
    int tree_sum = 0;
    int current_sum = 0;
    int i = 0;
    int current = root[0];
    while(true)
    {
        tree_sum = 0;
        foreach(KeyValuePair<int, List<Dictionary<int,int>>> kvp in tree)
        {
            tree_sum = tree_sum + kvp.Value.Count;
        }
        if (tree_sum == b.Length - 1)
        {
            break;
        }
        if (b.Length <= i)
        {
            i = 0;
        }
        if (current == root[0])
        {   
            current_sum = 0;
            foreach(var i5 in b)
            {
                if(i5 == current)
                {
                    current_sum += 1;
                }
            }
            if (tree.Keys.Contains(current) && tree[current].Count == current_sum - 1)
            {
                if(b[i] != current)
                {
                    current = b[i];
                }
                else
                {
                    i += 1;
                    continue;
                }
            }
        }
        else
        {
            current_sum = 0;
            foreach(var i5 in b)
            {
                if(i5 == current)
                {
                    current_sum += 1;
                }
            }
            if (tree.Keys.Contains(current) && tree[current].Count == current_sum)
            {
                if(b[i] != current)
                {
                    current = b[i];
                }
                else
                {
                    i += 1;
                    continue;
                }
            }
        }
        if (b[i] == current && b[i] != i + 1)
        {
            if (tree.Keys.Contains(current))
            {
                tree[current].Add(new Dictionary<int, int>{{i+1,0}});
            }
            else
            {
                tree[current] = new List<Dictionary<int, int>>();
                tree[current].Add(new Dictionary<int, int>{{i+1,0}});
            }
        }
        i = i + 1;
    }
    foreach(KeyValuePair<int, List<Dictionary<int,int>>> kvp2 in tree)
    {
        //Console.WriteLine(kvp2);
    }
    Dictionary<int, List<int>> children_builder = new Dictionary<int, List<int>>();
    foreach(KeyValuePair<int, List<Dictionary<int,int>>> kvp2 in tree)
    {
        //Console.WriteLine(kvp2);
        if (kvp2.Key == root[0])
        {
            continue;
        }
        else
        {
            foreach(var kvp3 in kvp2.Value)
            {
                if(children_builder.ContainsKey(kvp2.Key))
                {
                    children_builder[kvp2.Key].Add(kvp3.Keys.First());
                }
                else
                {
                    children_builder[kvp2.Key] = new List<int>{kvp3.Keys.First()};
                }
            }
        }
    }
    List<int> root_children = new List<int>();
    foreach(var kvp4 in tree[root[0]])
    {
        foreach(KeyValuePair<int,int> kvp5 in kvp4)
        {
            root_children.Add(kvp5.Key);
        }
    }
    foreach(var rc2 in root_children)
    {
        //Console.WriteLine(rc2);
    }
    List<int> non_root_children = new List<int>();
    List<int> non_root_nodes_with_children = new List<int>();

    foreach(KeyValuePair<int, List<int>> cb in children_builder)
    {
        non_root_children = non_root_children.Concat(cb.Value).ToList();
        non_root_nodes_with_children.Add(cb.Key);
    }
    int[] copyP = new int[p.Length];
    int[] copyP2 = new int[p.Length];
    Array.Copy(p, copyP, p.Length);
    Array.Copy(p, copyP2, p.Length);
    copyP = copyP[1..(copyP.Length)];
    Array.Reverse(copyP, 0,copyP.Length);
    Dictionary<int, int> dist = new Dictionary<int,int>();
    int init_val = 99999999;
    int back_init_val = 0;
    int rn = 1;
    foreach(var v in copyP)
    {
        if(root_children.Contains(v) && !non_root_nodes_with_children.Contains(v) && !dist.Keys.Contains(v))
        {
            dist[v] = init_val - back_init_val;
            init_val = init_val + 1;
        }
        else if(non_root_children.Contains(v))
        {
            foreach(KeyValuePair<int, List<int>> cb2 in children_builder)
            {
                if(cb2.Value.Contains(v))
                {
                    if(!root_children.Contains(cb2.Key) && Array.IndexOf(p,cb2.Key) < Array.IndexOf(p,v))
                    {
                        dist[cb2.Key] = back_init_val;
                        dist[v] = init_val - back_init_val - 1;
                        back_init_val = back_init_val + 1;
                    }
                    foreach(var x in new ArraySegment<int>(p,0,cb2.Key+1))
                    {
                        if(root_children.Contains(x))
                        {
                            if(root_children.Contains(cb2.Key) && Array.IndexOf(p,cb2.Key) < Array.IndexOf(p,v))
                            {
                                copyP2 = p[1..(cb2.Key+1)];
                                Array.Reverse(copyP2,0,copyP2.Length);
                                foreach(var x2 in copyP2)
                                {
                                    if(root_children.Contains(x2))
                                    {
                                        dist[x] = back_init_val;
                                        rn = rn + 1;
                                    }
                                }
                                dist[cb2.Key] = back_init_val;
                                back_init_val = back_init_val + 1;
                                dist[v] = init_val - back_init_val - 1;
                            }
                        }
                    }                    
                }
            }
        }
    }
    foreach(KeyValuePair<int,int> kvp_final in dist)
    {
        Console.WriteLine(kvp_final);
        Console.WriteLine(kvp_final);
    } 
}

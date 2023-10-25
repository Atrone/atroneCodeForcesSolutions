# TREE DEFINITIONS
# rooted tree: connected unidirected graph without cycles and a root
# trees are specified by an array of ancestors
# example  b=[3,1,3,3,1]; b[1-(1)]=3; 3 is ancestor of vertex with number 1 (0+1)
# root is bi = i, in example: root is b[3-(1)]=3; 3 is ancestor of vertex with number 3 (2+1)

# PERMUTATION DEFINITIONS
# if possible, with tree b, add weights (representing distance) to the edges and create
# an array representing the distance from each vertex to the root ({vertex: distance_to_root})
# such that the vertices sorted by distance equals permutation of vertices P


# CASES
# n == 1:
#  if b == p:
#   then print('1')
#  if b != p:
#   then print('none')
# n > 1:
#   create {vertex: distance_to_root} for b, sort by value, and compare to p
#   how?
#   find i such that b[i] = i, add {root: 0}
#   find i such that b[i] = root, add {root: {i: 0, i2: 0}}
#   find i such that b[i] = previous i, add {root: {i: {i3: 0, i4: 0}, i2: 0}}
#   how to determine distance_to_root?
#   biggest to smallest:
#       nodes with most children need to have least weight

n = 5
b = [3, 1, 3, 3, 1]
p = [3, 1, 2, 5, 4]

if n == 1:
    if b == p:
        print('1')
    if b != p:
        print('none')
else:
    root = next((node, i) for i, node in enumerate(b) if node == (i + 1))
    tree = {root[0]: []}
    i = 0
    current = root[0]
    while True:
        if sum([len(v) for t, v in tree.items()]) == len(b) - 1:
            break
        if len(b) <= i:
            i = 0
        if current == root[0]:
            if current in tree and len(tree[current]) == len([n for n in b if n == current]) - 1:
                if b[i] != current:
                    current = b[i]
                else:
                    i += 1
                    continue
        else:
            if current in tree and len(tree[current]) == len([n for n in b if n == current]):
                if b[i] != current:
                    current = b[i]
                else:
                    i += 1
                    continue
        if b[i] == current and b[i] != i + 1:
            if current in tree:
                tree[current].append({i + 1: 0})
            else:
                tree[current] = [{i + 1: 0}]
        i += 1
    print(tree)
    children_builder = {}
    for t, k in tree.items():
        if t == root[0]:
            continue
        else:
            for t2 in k:
                if t in children_builder:
                    children_builder[t].append(list(t2.keys())[0])
                else:
                    children_builder[t] = [list(t2.keys())[0]]
    root_children = [list(rc.keys())[0] for rc in tree[root[0]]]
    non_root_children = []
    non_root_nodes_with_children = []
    for t, c in children_builder.items():
        non_root_children += c
        non_root_nodes_with_children.append(t)
    print(root_children)
    print(non_root_children)
    print(non_root_nodes_with_children)
    print(children_builder)
    # [5,2,8,9,12]
    # [1,6,5]
    dist = {}
    init_val = 999999999
    back_init_val = 0
    rn = 1

    for v in p[1:][::-1]:
        if v in root_children and v not in non_root_nodes_with_children and v not in dist:
            dist[v] = init_val - back_init_val
            init_val -= 1
        elif v in non_root_children:
            for n, c in children_builder.items():
                if v in c:
                    if n not in root_children and p.index(n) < p.index(v):
                        dist[n] = back_init_val
                        dist[v] = init_val - back_init_val - 1
                        back_init_val += 1
                    elif n in root_children and p.index(n) < p.index(v) and any(
                            [x for x in p[:n + 1] if x in root_children]):
                        for x in p[:n + 1][::-1]:
                            if x in root_children:
                                dist[x] = back_init_val - rn
                                rn += 1
                        dist[n] = back_init_val
                        dist[v] = init_val - back_init_val - 1
                        back_init_val += 1
                    else:
                        print('none')
    print(dist)

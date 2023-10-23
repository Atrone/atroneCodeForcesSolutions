# if all fruits > k, output 0
# if any fruit > k, remove that tree
# with remaining fruits,
# find a continuous divisible subarray
# sum fruits
# repeat starting one shift right

n,k = 1, 10
a = [11]
h = [1]


sub_arrays = [[] for _ in h]
for oi, _ in enumerate(h):
    for i, hi in enumerate(h[oi:]):
        if i + 1 + oi >= len(h):
            break
        if str(hi/h[i+1+oi]).split('.')[1] == '0':
            if i + oi + 1 not in sub_arrays[oi]:
                sub_arrays[oi].append(i + oi + 1)
            if i + oi not in sub_arrays[oi]:
                sub_arrays[oi].append(i + oi)
        else:
            break
print(max([len(sub_array) for sub_array in sub_arrays]))

#sums = []
#for sub_array in sub_arrays:
#    s = sum([app for app in a if a.index(app) in sub_array])
#    if s < k:
#        sums.append(s)

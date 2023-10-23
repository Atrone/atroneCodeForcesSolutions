# write problem
# imagine you are problem
# solve its specific cases
# generalize

# input string of 0s and 1s
# imagine square len(string) x len(string)
# shift movement to the right one time each line
# if no 1s, ZERO
# if only 1, 1
# if no ones next to each other, ZERO
# if 2 1s next to each other, keep track of their locations each shift, count match with previous


s = '101010'
m = []
if '1' not in s:
    print('0')
elif ('11' not in s) and (s[0] + s[-1] != '11'):
    print('0')
elif len(s) == 1:
    print('1')
else:
    ones = [i for i, c in enumerate(s) if c == '1']
    for c in s:
        s = "".join([s[i - 1] for i, c2 in enumerate(s)])
        ones_next = [i for i, c3 in enumerate(s) if c3 == '1']
        m.append(sum([2 for on in ones_next if on in ones]))
        ones = [s.index(c) for c4 in s if c4 == '1']
    print(max(m))
# 101
# 110
# 011

# 011110
# 001111
# 100111
# 110011
# 111001
# 111100

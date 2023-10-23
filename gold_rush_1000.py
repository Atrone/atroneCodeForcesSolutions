# take n, see if divisible by 3
# then we have 2/3n and 1/3n as 2 new ns
# repeat until we reach n = m

found = False


def divide(n, m):
    if n == m:
        global found
        found = True
        return True
    elif n % 3 != 0 or m > n:
        return False
    n1, n2 = 2 * n / 3, n / 3
    divide(n1, m)
    divide(n2, m)
    return True


if divide(746001, 2984004) and found:
    print('yes')
else:
    print('no')

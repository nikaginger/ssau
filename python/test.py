def maxChet(f, maxm):
    s = f % 10
    if (s > maxm and s % 2 == 0):
        maxm = s
    if s < 10:
        return s
    else:
        return maxChet(f(x)//10, maxm)
    return maxm

print(maxChet(34256, 0))

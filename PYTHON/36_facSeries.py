def fact(n):
    fact = 1
    for i in range(1, n+1):
        fact = fact*i
    return fact


ans = 0
n = int(input("Enter n: "))

for j in range(1, n+1):
    ans = ans+(1/fact(j))
print(ans)
5

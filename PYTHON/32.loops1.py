# for i in range(3,30+1,3): #n-1
#     print(i)

#     #for(int =1; i<=12; i+2)

for i in range(5):
    for j in range(5):
        if (i == 0 or i == 4 or j == 0 or j == 4):
            print("*", end="")
        else:
            print(" ", end="")

    print()

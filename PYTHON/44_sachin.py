for i in range(100, 200+1):
    # print(i)
    i2=i
    sum1=0
    while(i!=0):
        rem= i%10
        sum1=sum1+rem
        i=i//10
    # print(sum1)
    if(sum1%2==0):
        print(i2)



x = int(input("Enter number: "))

match x:
    case 0:
        print("num is 0")
    case 1:
        print("num is 1") 
    case _ if(x==3):
        print("num is 3")
    case _:
        print("invalid")
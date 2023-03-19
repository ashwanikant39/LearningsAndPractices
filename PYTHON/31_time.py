print("\n\n\n")
hour=0
for hour in range(24):
    if(hour==0):
        print("Midnight")
        continue
    elif(hour<12):
        print(hour,"Am")
    elif(hour==12):
        print("Noon")
    elif(hour>12):
         print(hour%12,"Pm")
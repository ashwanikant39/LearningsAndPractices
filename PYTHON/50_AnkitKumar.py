# Name: Ankit Kumar
# Roll no: 2104935
import random


passlen = int(input("enter the length of password: "))
s = "abcdefghijklmnopqrstuvwxyz01234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ!@#$%^&*()?"
p = "".join(random.sample(s, passlen))
print(p)

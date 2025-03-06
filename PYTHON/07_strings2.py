# upper and lowel case
name = "Aditya"
print(name.upper())
print(name.lower())

# replace string
x= "Aditya"
print(x.replace("Adi", "Ashwani"))

# delete is we give last characters
a = "Adityaaaaaaaaaa"
print(a.rstrip(""))

# it make list by give character
b = "Silver spoon"
print(b.split(" "))

# capitalize only first
c = "aditya PandeY"
print(c.capitalize())

#  give space in center
d = "Hey this is Aditya"
print(d.center(50))

print("lenght of d without center", len(d))
print(len(d.center(50)))

e = "Aditya"
print(e.count("A"))


# check end string
name2 = "welcome to the console!!!"
print(name2.endswith("!!!"))

name3 = "Welcome to the console!!!"
print(name3.endswith("to", 4, 10))

y="he's a nice boy,and also he is a good player, he is bad in study"
print(y.find("is"))

z="jkhrrjhfuirhhjnbLH000JKHjshhjfdbfnjbffdbifh"
print(z.isalnum())

w="jfijdhfnNIdjishjndihfn11229"
print(w.isalpha())

# printable
v="Aditya"  #true
 #v="Aditya\n"   #false because of /n
print(v.isprintable())


# white space
u=" "
print(u.isspace())

# q="Aditya pandey"  #false
q="Aditya Pandey"  #true
print(q.istitle())
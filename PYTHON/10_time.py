import time
print()
times = time.strftime('%H:%M:%S')  # time
print(times, "\n")

timesHour = int(time.strftime('%H'))
print(timesHour)

timesMin = int(time.strftime('%M'))
print(timesMin)

timesSec = int(time.strftime('%S'))
print(timesSec)

if (timesHour >= 5 and timesHour < 12):
    print("Hey, Good morning")
elif (timesHour >= 12 and timesHour < 17):
    print("Hey, Good afternoon")
else:
    print("Hey, Good evening")


# times2 = time.strftime('Month- %h,%m\n  ')
# print(times2)

# https://docs.python.org/3/library/time.html#time.strftime

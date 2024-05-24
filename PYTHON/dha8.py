def check_speed(speed):
    speed_limit = 70
    demerit_points = 0
    
    if speed <= speed_limit:
        print("OK")
    else:
        demerit_points = (speed - speed_limit) // 5
        print("Demerit Points:", demerit_points)
        
        if demerit_points > 12:
            print("License Suspended")

# Test the function with different speeds
check_speed(65)  # Should print "OK"
check_speed(80)  # Should print "Demerit Points: 2."
check_speed(150) # Should print "Demerit Points: 16. License Suspended"

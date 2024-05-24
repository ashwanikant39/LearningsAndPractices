try:
    # Code that might raise an exception
    result = int("abc")
except (ValueError, ZeroDivisionError):
    # Handling code for ValueError or ZeroDivisionError
    print("An error occurred.")

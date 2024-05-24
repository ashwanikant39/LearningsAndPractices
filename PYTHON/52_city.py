# def city_country(city, country):
#     return city + ", " + country

# # Call the function three times with different city-country pairs
# print(city_country("Sydney", "Australia"))
# print(city_country("Paris", "France"))
# print(city_country("Tokyo", "Japan"))

def city_country(city="unknown city", country="unknown country"):
    return city+ ", " + country

# Call the function once with arguments
print(city_country("Sydney", "Australia"))

# Call the function with no arguments (using default values)
print(city_country())


cost_price = float(input("Enter the cost price of the item: Rs ")) #take input(cost orice)
sell_price = float(input("Enter the sell price of the item: Rs ")) #take input(sell price)
 
#compare prices
if sell_price > cost_price:
    profit = sell_price - cost_price
    print("You made a profit of Rs", profit)
elif sell_price < cost_price:
    loss = cost_price - sell_price
    print("You incurred a loss of Rs", loss)
else:
    print("You sold the item at the same price as the cost price. There is neither profit nor loss.")

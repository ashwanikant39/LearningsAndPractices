customers = []

def add_customer():
    name = input("Enter customer name: ")
    account_number = input("Enter account number: ")
    balance = float(input("Enter initial balance: "))
    customers.append({"name": name, "account_number": account_number, "balance": balance})
    print("Customer added successfully.")

def list_customers():
    print("List of Customers:")
    for customer in customers:
        print(f"Name: {customer['name']}, Account Number: {customer['account_number']}, Balance: {customer['balance']}")

def deposit_money():
    account_number = input("Enter account number: ")
    amount = float(input("Enter amount to deposit: "))
    for customer in customers:
        if customer['account_number'] == account_number:
            customer['balance'] += amount
            print("Deposit successful.")
            break
    else:
        print("Customer not found.")

def withdraw_money():
    account_number = input("Enter account number: ")
    amount = float(input("Enter amount to withdraw: "))
    for customer in customers:
        if customer['account_number'] == account_number:
            if customer['balance'] >= amount:
                customer['balance'] -= amount
                print("Withdrawal successful.")
            else:
                print("Insufficient funds.")
            break
    else:
        print("Customer not found.")

def transfer_money():
    from_account = input("Enter your account number: ")
    to_account = input("Enter recipient's account number: ")
    amount = float(input("Enter amount to transfer: "))
    for sender in customers:
        if sender['account_number'] == from_account:
            if sender['balance'] >= amount:
                for recipient in customers:
                    if recipient['account_number'] == to_account:
                        sender['balance'] -= amount
                        recipient['balance'] += amount
                        print("Transfer successful.")
                        break
                else:
                    print("Recipient not found.")
            else:
                print("Insufficient funds.")
            break
    else:
        print("Sender not found.")

def balance_check():
    account_number = input("Enter account number: ")
    for customer in customers:
        if customer['account_number'] == account_number:
            print(f"Balance for account {account_number} is {customer['balance']}")
            break
    else:
        print("Customer not found.")

def display_options():
    print("Options:")
    print("1: Add Customer")
    print("2: List Customers")
    print("3: Deposit Money")
    print("4: Withdraw Money")
    print("5: Transfer Money")
    print("6: Balance Check")
    print("7: Close the App")

# def main():
infinite=1
while (infinite):
        display_options()
        option = input("Enter option number: ")

        if option == "1":
            add_customer()
        elif option == "2":
            list_customers()
        elif option == "3":
            deposit_money()
        elif option == "4":
            withdraw_money()
        elif option == "5":
            transfer_money()
        elif option == "6":
            balance_check()
        elif option == "7":
            print("Closing the application. Goodbye!")
            infinite=0

            # break
        else:
            print("Invalid option. Please try again.")

# if __name__ == "__main__":
#     main()

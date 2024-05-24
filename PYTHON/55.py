customers = [] #Declare an empty List for store customer's data

def add_customer():
    print("\n-----------Adding Customers-----------")
    
    name = input("Enter Customer name: ")
    aadhaar_number = input("Enter Aadhaar number: ")
    pan_number = input("Enter PAN: ")
    balance = float(input("Enter initial balance: "))

    customers.append({"name": name, "aadhaar_number": aadhaar_number, "pan_number": pan_number, "balance": balance})
    print("------------------------------------")
    print("Customer added successfully.")


    add_More_cust=input("Do you want to add more customer? (Y/N): ")
    if(add_More_cust=="Y" or add_More_cust=="y"):
        add_customer()
        # print("y")
          
    elif(add_More_cust=="N" or add_More_cust=="n"):
        print("---Back to home page---\n")
        # print("n")
     
    else:
        print("**Please enter your choice in (Y/N) only\n")
  


def list_customers():
    print("\n-----------------------Displaying Customers------------------------")

    if(len(customers)==0): #check if list is empty or not
        print("**No customers found")
    else:
        for customer in customers:
            print(customers.index(customer),"Name:", customer['name'],", ", "Aadhaar Number:", customer['aadhaar_number'],", ", "PAN number:", customer['pan_number'],", ", "Balance:", customer['balance'])
    
    print("-------------------------------------------------------------------\n")

    

def deposit_money():
    if(len(customers))==0:
        print("**Bank has no Customars for adding Amount, First of all Add some customers\n")
    else:
        print("\n-----------------------Diposit Money-----------------------")
        account_number=int(input("Enter account number: "))
        amount_to_add=float(input("Enter Amount to Added: "))
     
        for customar in customers:
            if(account_number== customers.index(customar)):
           
            # print("name", customar['name'])
                customar['balance']+=amount_to_add
                print("Amount added successfully.")
                break
        else:
            print("**Customer Not found")
                
        print("------------------------------------------------------------\n")
   

def withdraw_money():
    if(len(customers))==0:
        print("**Bank has no Customars for Withdraw Amount, First of all Add some customers\n")
    else:
        print("\n-----------------------Withdraw Money-----------------------")
        account_number=int(input("Enter account number: "))
        amount_to_withdraw=float(input("Enter Amount to Withdraw: "))
     
        for customar in customers:
            if(account_number== customers.index(customar)):
                if(customar['balance']>=amount_to_withdraw):
                    customar['balance']-=amount_to_withdraw
                    print("Withdrawal successful.")
                else:
                    print("Insufficient funds.")
                break
        else:
            print("**Customer not found")
                
        print("------------------------------------------------------------\n")


def transfer_money():
    
    print("5")

def balance_check():
    print("\n-----------------------Balance check------------------------")

    if(len(customers)==0): #check if list is empty or not
        print("**Bank has no Customers ")
    else:
        customar_num=int(input("Enter the Customar Number:  "))

        
        for customer in customers:
            if(customers.index(customer)==customar_num):
                print("Name:", customer['name'],", ", "Aadhaar Number:", customer['aadhaar_number'],", ", "PAN number:", customer['pan_number'],", ", "Balance:", customer['balance'])
                break
        else:
            print("**Customar not found")
            
    print("------------------------------------------------------------\n")

    # print("6")
    


# Start the program from here
print("\n\n*********************************************\n\n\tInternational Bank of python\n\n*********************************************\n")

# infinity=1  #True
while(True):
    print("----------- Here are your Options -----------")
    print("1: Add Customer")
    print("2: List Customers")
    print("3: Deposit Money")
    print("4: Withdraw Money")
    print("5: Transfer Money")
    print("6: Balance Check")
    print("7: Close the App")
    print("---------------------------------------------")
    
    
    choice=input("Enter your choice number:")

    if choice == "1":
        add_customer()
    elif choice == "2":
        list_customers()
    elif choice == "3":
        deposit_money()
    elif choice == "4":
        withdraw_money()
    elif choice == "5":
        transfer_money()
    elif choice == "6":
        balance_check()
    elif choice=="7":
        print("--Program closed--")
        # infinity=0  #flip the infinity's value(FAlse)
        # break

    else:
        print("**You entered the wrong choice, Please try again\n")


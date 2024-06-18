customers_list = [] #Declare an empty List for store customer's data

def add_customer():  #Function for add customers
    print("\n--------------Adding Customers--------------")
    
    name = input("Enter Customer Name: ")
    aadhaar_number = input("Enter Aadhaar number: ")
    pan_number = input("Enter PAN: ")
    balance = float(input("Enter initial balance: "))  
    
    #store user's details in a dictionary and We will add(append) every dictionary into list
    user_detail_dict={"name": name, "aadhaar_number": aadhaar_number, "pan_number": pan_number, "balance": balance}   
    customers_list.append(user_detail_dict)
    
    print("--------------------------------------------")
    print("Customer added successfully.")

    add_More_cust=input("\nDo you want to add more customer? (Y/N): ")
    if(add_More_cust=="Y" or add_More_cust=="y"):
        add_customer() #if user want to add more customers, call same function(add_customer()) again)
        
    elif(add_More_cust=="N" or add_More_cust=="n"):
        print("---Back to home page---\n")  

    else:
        print("**You can enter your choice in (Y/N) only\n")
  

def list_customers():  #Function for print all customer with their details
    print("\n-----------------------Displaying Customers------------------------")

    if(len(customers_list)==0): #check if list is empty or not using len() funtion
        print("**No customers found, First of all Add some customers")
    else:
        for customar in range(len(customers_list)): #loop run on list's indexes and print every dictionary
            print(customers_list[customar] )

    print("-------------------------------------------------------------------\n")


def deposit_money(): #funtion for Deposit money
    
    print("\n-----------------------Diposit Money-----------------------")
    customer_number=int(input("Enter Customer number: ")) #corvert into (int) because list's index will be in int so it can match easly
        
    for customar in range(len(customers_list)):

        if(customer_number== customar): #Remember, we assume that list's indexing or Customer number is same
            amount_to_add=float(input("Enter Amount to Added: "))

            customers_list[customer_number]['balance']+=amount_to_add  #Add amount in customer's balance
            print("\nAmount added successfully.")
            break
    else:
        print("\n**Customer Not found")
       
    print("-----------------------------------------------------------\n") 
   

def withdraw_money():
    print("\n-----------------------Withdraw Money-----------------------")

    customer_number=int(input("Enter Customer number for withdraw money: "))

    while(True): 
        amount_for_wd=float(input("Enter Amount that you want to withdraw: "))

        if(customer_number>=len(customers_list) ):  #check if user exists or not in list(if Customer number greater than list's length, its mean user not exists)
            print("\n**Customer not found")
            break
      
        elif(amount_for_wd<=customers_list[customer_number]['balance']):  #check balance in customer's account is greater than we want to withdraw or not

            customers_list[customer_number]['balance']-=amount_for_wd  #subtract the money from that customer's account
            print("\nYour Money withdrawn")
            break

        else:
            #if money is not enough, ask again for enter money
            print("\n**Money is not enough in this Account")
            print("Please reEnter the valid amount\n")
    print("------------------------------------------------------------\n")


def transfer_money():
    print("\n-----------------------Transfer Money-----------------------")

    sender_customerNum=int(input("Enter Sender's Customer number: "))
    receiver_customerNum=int(input("Enter  Receiver's Customer number: "))

    sender_exist=True  #assume that sender exists

    #check sender's details(existence and enough money)
    while(True):
        amount_for_wd=float(input("Enter Amount that you want to transfer: "))
        print("------------------------------------------------------------")

        if(sender_customerNum>=len(customers_list) ):  #check if sender exists or not 
            print("**Sender not found\n")
            sender_exist=False  #its means sender doesn't exist
            break

        #check balance in sender's account is greater than we want to transfer or not
        elif(amount_for_wd<=customers_list[sender_customerNum]['balance']): 
            # print("yes, withdraw in working...")
            break
        else:
            print("**You have entered more money than is in sender's account")
            print("Please reEnter the valid amount\n")


    #check receiver's existence
    for customar in range(len(customers_list)):
            
            if(sender_exist==False): #if sender doesn't exist, Break the loop
                # print("Kitti baar kahu, sender nhi hai!")
                break

            elif(receiver_customerNum== customar ): #match the receiver's Customer number in list, if not found, break the loop

                customers_list[sender_customerNum]['balance']-=amount_for_wd  #subtract the money from the Sender's account
                customers_list[receiver_customerNum]['balance']+=amount_for_wd #Add money into Receiver's account
                print("Amount transfer successfully.\n")
                break

    else:
            print("\n**Receiver Not found\n")


def balance_check():
    print("\n----------------Balance check----------------")
    customar_num=int(input("Enter the Customar Number:  "))

    if(customar_num>=len(customers_list)): #check if user exists or not
        print("\n**Customer not found ")
    else:
        print("\n--------------Customer details---------------")
        print("Customar Name      :",customers_list[customar_num]['name'], "\nAadhaar            :",customers_list[customar_num]['aadhaar_number'], "\nPAN                :", customers_list[customar_num]['pan_number'], "\nBalance            :",customers_list[customar_num]['balance'])
            
    print("---------------------------------------------\n")


# Start the program from here--------->>>>  
print("\n\n\t\tPrachi Yadav\n*********************************************\n\n\tInternational Bank of python\n\n*********************************************\n")

while(True): #Run the loop infinity until user enter "7" 
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

    #call the functions according to user's input
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
        print("--Program closed--\n")
        break
    else:
        print("**You entered the wrong choice, Please try again\n")
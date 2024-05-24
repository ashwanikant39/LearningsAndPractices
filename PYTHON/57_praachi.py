customars_list = [] #Declare an empty List for store customer's data

def add_customer():
    print("\n-----------Adding Customers-----------")
    
    name = input("Enter Customer name: ")
    aadhaar_number = input("Enter Aadhaar number: ")
    pan_number = input("Enter PAN: ")
    balance = float(input("Enter initial balance: "))

    customars_list.append({"name": name, "aadhaar_number": aadhaar_number, "pan_number": pan_number, "balance": balance})
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
        print("**You can enter your choice in (Y/N) only\n")
  


def list_customers():
    print("\n-----------------------Displaying Customers------------------------")

    if(len(customars_list)==0): #check if list is empty or not
        print("**No customers found, First of all Add some customers")
    else:
        for customar in range(len(customars_list)):
            # print(customar,"Name:", customars_list[customar]['name'],", ", "Aadhaar Number:", customars_list[customar]['aadhaar_number'],", ", "PAN number:", customars_list[customar]['pan_number'],", ", "Balance:", customars_list[customar]['balance'])
            print(customars_list[customar] )

        # for customer in customars_list:
        #     print(customars_list.index(customer),"Name:", customer['name'],", ", "Aadhaar Number:", customer['aadhaar_number'],", ", "PAN number:", customer['pan_number'],", ", "Balance:", customer['balance'])
    
    print("-------------------------------------------------------------------\n")

    

def deposit_money():
    # if(len(customars_list)==0):
    #     print("**Bank has no Customars for adding Amount, First of all Add some customers\n")
    # else:
        print("\n-----------------------Diposit Money-----------------------")
        account_number=int(input("Enter account number: ")) #corvert into (int) because list's index will be in int so it can match easly
        # amount_to_add=float(input("Enter Amount to Added: "))

        # customars_list[account_number]['balance']=customars_list[account_number]['balance']+amount_to_add
        # print(customars_list[account_number]['balance']+amount_to_add)

        for customar in range(len(customars_list)):
            # if(account_number== customars_list.index(customar) or len(customars_list)==0):
            if(account_number== customar):
                amount_to_add=float(input("Enter Amount to Added: "))

           
            # print("name", customar['name'])
                customars_list[customar]['balance']+=amount_to_add
                print("Amount added successfully.")
                break
        else:
            print("**Customer Not found")

        # for customar in customars_list:
        #     # if(account_number== customars_list.index(customar)):
           
        #     # print("name", customar['name'])
        #         customar['balance']+=amount_to_add
        #         print("Amount added successfully.")
        #         break
        # else:
        #     print("**Customer Not found")
                
        print("------------------------------------------------------------\n") 
   

def withdraw_money():

    # if(len(customars_list)==0):
    #     print("**Bank has no Customars for withdraw Amount, First of all Add some customers\n")
        
    # else:
    account_number=int(input("Enter Account number for withdraw money: "))

    while(True):
        # account_number=int(input("Enter Account number for withdraw money: "))
        amount_for_wd=float(input("Enter Amount that you want to withdraw: "))
        if(account_number>=len(customars_list) ):
        # if(len(customars_list)==0 or account_number>=len(customars_list) ):
            print("**Customer not found\n")
            break

              
        elif(amount_for_wd<=customars_list[account_number]['balance']): 
            customars_list[account_number]['balance']-=amount_for_wd
            print("yes, withdraw in working...")
            break
        else:
            print("**Money is not enough in this Account")
            print("Please reEnter the valid amount")
              
    
    # customars_list[account_number]['balance']-=amount_for_wd
    # print("After withdraw")


    # if(len(customars_list))==0:
    #     print("**Bank has no Customars for Withdraw Amount, First of all Add some customers\n")
    # else:
    #     print("\n-----------------------Withdraw Money-----------------------")
    #     account_number=int(input("Enter account number: "))
    #     amount_to_withdraw=float(input("Enter Amount to Withdraw: "))
     
    #     for customar in customars_list:
    #         if(account_number== customars_list.index(customar)):
    #             if(customar['balance']>=amount_to_withdraw):
    #                 customar['balance']-=amount_to_withdraw
    #                 print("Withdrawal successful.")
    #             else:
    #                 print("Not enough funds.")
    #             break
    #     else:
    #         print("**Customer not found")
                
    print("------------------------------------------------------------\n")


def transfer_money():
    sender_accountNum=int(input("Enter Sender's Account number: "))
    receiver_accountNum=int(input("Enter  Receiver's Account number: "))


    while(True):
        amount_for_wd=float(input("Enter Amount that you want to transfer: "))
        if(sender_accountNum>=len(customars_list) ):
        # if(len(customars_list)==0 or account_number>=len(customars_list) ):
            print("**Sender not found\n")
            break

            
        elif(amount_for_wd<=customars_list[sender_accountNum]['balance']):
            print("yes, withdraw in working...")
            break
        else:
            print("**You have entered more money than is in sender's account")
            print("Please reEnter the valid amount")

    

              
    
    # customars_list[sender_accountNum]['balance']-=amount_for_wd


    for customar in range(len(customars_list)):
            # if(account_number== customars_list.index(customar) or len(customars_list)==0):
            if(receiver_accountNum== customar):
                customars_list[sender_accountNum]['balance']-=amount_for_wd
           
            # print("name", customar['name'])
                customars_list[customar]['balance']+=amount_for_wd
                print("Amount transfer successfully.")
                break
    else:
            print("**Receiver Not found")



    
    # print("5")

def balance_check():
    print("\n----------------Balance check----------------")
    customar_num=int(input("Enter the Customar Number:  "))
    # print(len(customars_list))

    # if(len(customars_list)==0): #check if list is empty or not
    if(customar_num>=len(customars_list)): #check if list is empty or not
    
        print("**Customer not found ")
    else:
         
        # customar_num=int(input("Enter the Customar Number:  "))
        # print("Name:", customer['name'],", ", "Aadhaar Number:", customer['aadhaar_number'],", ", "PAN number:", customer['pan_number'],", ", "Balance:", customer['balance'])
        print("\n--------------Customer details--------------")
        print("Customar Name      :",customars_list[customar_num]['name'], "\nAadhaar            :",customars_list[customar_num]['aadhaar_number'], "\nPAN                :", customars_list[customar_num]['pan_number'], "\nBalance            :",customars_list[customar_num]['balance'])

        
    # for customer in range(len(customars_list)):
            # if(customars_list[customer]==customar_num):
        # print("Name:", customer['name'],", ", "Aadhaar Number:", customer['aadhaar_number'],", ", "PAN number:", customer['pan_number'],", ", "Balance:", customer['balance'])
                # break
    # else:
            # print("**Customar not found")
            
    print("---------------------------------------------\n")

    # print("6")
    


# Start the program from here
print("\n\n\t\tPrachi Yadav\n*********************************************\n\n\tInternational Bank of python\n\n*********************************************\n")

infinity=1  #True
while(infinity):
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
        break
        # infinity=0  #flip the infinity's value(FAlse)

    else:
        print("**You entered the wrong choice, Please try again\n")

# print("hello")
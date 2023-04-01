#include <iostream>
using namespace std;

int toDecimal(string number1, int base)

{
    int length2 = number1.size();
    int x = 1;
    int y;
    int ans = 0;
    int rem;
    for (int i = length2 - 1; i >= 0; i--)
    {

        if (number1[i] >= '0' && number1[i] <= '9')
        {
            y = x * (number1[i] - 48); // because string 0 ki int value 48, or string 1 ki 49
            ans = ans + y;
        }
        else if (number1[i] >= 'A' && number1[i] <= 'Z')
        {
            y = x * (number1[i] - 55);
            ans = ans + y;
        }
        else if (number1[i] >= 'a' && number1[i] <= 'z')
        {
            y = x * (number1[i] - 87); // 97-87=10 =A=a
            ans = ans + y;
        }

        x = x * base;
    }
    return ans;
}

void fromDecimal(int number, int toBase)
{
    int arr[32];
    int i = 0;
    while (number > 0)
    {
        arr[i] = number % toBase;
        number = number / toBase;
        i++;
    }
    char x;
    cout << "(";
    for (int j = i - 1; j >= 0; j--)
    {
        if (arr[j] >= 0 && arr[j] <= 9)
        {
            cout << arr[j];
        }
        else if (arr[j] >= 10 && arr[j] <= 35)
        {
            x = arr[j] + 55; // 10+55=65 means  A
            cout << x;
        }
    }
    cout << ")_" << toBase << "\n\n";
}

int *onesComplement(int number)
{
    static int arr[64];
    int rem1;
    int i = 0;
    while (number != 0)
    {
        rem1 = number % 10;
        if (rem1 == 0)
        {
            arr[i] = 1;
        }
        else if(rem1==1)
        {
            arr[i] = 0;
        }
        number = number / 10;
        i++;
    }
    return arr;
}

int main()
{
    int choice, choice1, choice3, length, fromBase, toBase, baseRange = true;
    string number;
    int underBase = true;

    int isBinary = true;
    int isOctal = true;
    int isHexa = true;

    int rem;

    int decimalNum1;
    string binaryNum1, octalNum1, hexaNum1;
    int *value;

    cout << "\n\n\t\twelcome\n\n";
    cout << "\t1. for convertion \n\t2. for Find 1's complement\n\t3. for Find 2'S complement\n\t4. For Additionn\n\t";

    cout << "\nEnter choice(1-4): ";
    cin >> choice;

    switch (choice)
    {
    case 1:
        cout << "\n\t1. For Your own base(From & to both) \n\t2. For predefined 12 combination\n\n";

        cout << "Enter choice(1-2): ";
        cin >> choice1;

        switch (choice1)
        {
        case 1:
            cout << "Enter number that you want convert: ";
            cin >> number;
            cout << "Enter base between 2 to 36: ";
            cin >> fromBase;
            if (fromBase > 36)
            {
                cout << "*** Sorry, You can enter base only 2 to 36";
                baseRange = false;
                break;
            }
            if (baseRange)
            {

                // underBase=true;

                length = number.size();

                for (int i = length - 1; i >= 0; i--)
                {
                    if (57 >= int(number[i]) && int(number[i]) >= 48)
                    {
                        if ((int(number[i]) - 48) >= fromBase)
                        {
                            cout << "digt can not be equal or greater than base\n";
                            underBase = false;
                            break;
                        }
                    }
                    else if (65 <= int(number[i]) && int(number[i]) <= 90)
                    {
                        if ((int(number[i]) - 55) >= fromBase)
                        {
                            cout << "digt can not be equal or greater than base\n";
                            underBase = false;
                            break;
                        }
                    }
                    else if (97 <= int(number[i]) && int(number[i]) <= 122)
                    {
                        if ((int(number[i]) - 87) >= fromBase)
                        {
                            cout << "digt can not be equal or greater than base\n";
                            underBase = false;
                            break;
                        }
                    }
                    else
                    {
                        cout << "Symbols are not allowed";
                        underBase = false;
                        break;
                    }
                }
                if (underBase)
                {
                    // for any base to decimal convert
                    int decimalNumber = toDecimal(number, fromBase);
                    // cout << decimalNumber;

                    cout << "\n\nEnter the base you want to convert: ";
                    cin >> toBase;

                    // int *value;
                    cout << "(" << number << ")_" << fromBase << " = ";
                    fromDecimal(decimalNumber, toBase);
                    // for (int j = 0; j <= 50; j++)
                    // {
                    //     cout << value[j];
                    // }
                }
            }

            break;
        case 2:

            cout << "\n\t1. for DECIMAL to BINARY\n\t2. For DECIMAL to OCTAL\n\t3. For DECIMAL to HEXADECIMAL\n\t4. For BINARY to DECIMAL\n\t5. For BINARY to OCTAL\n\t6. For BINARY to HEXADECIMAL\n\t7. For OCTAL to BINARY\n\t8. For OCTAL to DECIMAL\n\t9. For OCTAL to HEXADCIMAL\n\t10. For HEXADECIMAL to BINARY\n\t11. For HEXADECIMAL to DECIMAL\n\t12. For HEXADECIMAL to OCTAL\n\t\n ";
            cout << "Enter choice(1-12): ";
            cin >> choice3;
            switch (choice3)
            {
            case 1:

                cout << "Enter your DECIMAL number: ";
                cin >> decimalNum1;
                cout << "DECIMAL to BINARY result= ";
                fromDecimal(decimalNum1, 2);
                break;

            case 2:
                cout << "Enter your DECIMAL number: ";
                cin >> decimalNum1;
                cout << "DECIMAL to OCTAL result= ";
                fromDecimal(decimalNum1, 8);

                break;

            case 3:
                cout << "Enter your DECIMAL number: ";
                cin >> decimalNum1;
                cout << "DECIMAL to HEXADECIMAL result= ";
                fromDecimal(decimalNum1, 16);

                break;

            case 4:
                cout << "Enter BINARY number: ";
                cin >> binaryNum1;
                for (int i = binaryNum1.size() - 1; i >= 0; i--)
                {
                    if (!(0 <= int(binaryNum1[i] - 48) && int(binaryNum1[i] - 48) <= 1))
                    {
                        cout << "Invalid BINARY number**";
                        isBinary = false;
                        break;
                    }
                }

                if (isBinary)
                {
                    cout << "BINARY to DECIMAL result = ";
                    fromDecimal(toDecimal(binaryNum1, 2), 10);
                }

                break;

            case 5:
                cout << "Enter BINARY number: ";
                cin >> binaryNum1;
                for (int i = binaryNum1.size() - 1; i >= 0; i--)
                {
                    if (!(0 <= int(binaryNum1[i] - 48) && int(binaryNum1[i] - 48) <= 1))
                    {
                        cout << "Invalid BINARY number**";
                        isBinary = false;
                        break;
                    }
                }

                if (isBinary)
                {
                    cout << "BINARY to OCTAL result = ";
                    fromDecimal(toDecimal(binaryNum1, 2), 8);
                }

                break;

            case 6:
                cout << "Enter BINARY number: ";
                cin >> binaryNum1;
                for (int i = binaryNum1.size() - 1; i >= 0; i--)
                {
                    if (!(0 <= int(binaryNum1[i] - 48) && int(binaryNum1[i] - 48) <= 1))
                    {
                        cout << "Invalid BINARY number**";
                        isBinary = false;
                        break;
                    }
                }

                if (isBinary)
                {
                    cout << "BINARY to HEXADCIMAL result = ";
                    fromDecimal(toDecimal(binaryNum1, 2), 16);
                }

                break;

            case 7:
                cout << "Enter OCTAL number: ";
                cin >> octalNum1;
                for (int i = octalNum1.size() - 1; i >= 0; i--)
                {
                    if (!(0 <= int(octalNum1[i]) - 48 && int(octalNum1[i]) - 48 <= 7))
                    {
                        cout << "Invalid OCTAL number";
                        isOctal = false;
                        break;
                    }
                }

                if (isOctal)
                {
                    cout << "OCTAL to BINARY result= ";
                    fromDecimal(toDecimal(octalNum1, 8), 2);
                }

                break;

            case 8:
                cout << "Enter OCTAL number: ";
                cin >> octalNum1;
                for (int i = octalNum1.size() - 1; i >= 0; i--)
                {
                    if (!(0 <= int(octalNum1[i]) - 48 && int(octalNum1[i]) - 48 <= 7))
                    {
                        cout << "Invalid OCTAL number";
                        isOctal = false;
                        break;
                    }
                }

                if (isOctal)
                {
                    cout << "OCTAL to DECIMAL result= ";
                    fromDecimal(toDecimal(octalNum1, 8), 10);
                }

                break;

            case 9:
                cout << "Enter OCTAL number: ";
                cin >> octalNum1;
                for (int i = octalNum1.size() - 1; i >= 0; i--)
                {
                    if (!(0 <= int(octalNum1[i]) - 48 && int(octalNum1[i]) - 48 <= 7))
                    {
                        cout << "Invalid OCTAL number";
                        isOctal = false;
                        break;
                    }
                }

                if (isOctal)
                {
                    cout << "OCTAL to HEXADECIMAL result= ";
                    fromDecimal(toDecimal(octalNum1, 8), 16);
                }

                break;

            case 10:

                cout << "Enter your HEXADECIMAL number: ";
                cin >> hexaNum1;

                for (int i = hexaNum1.size() - 1; i >= 0; i--)
                {
                    if (!((hexaNum1[i] <= 'F' && hexaNum1[i] >= 'A') || (hexaNum1[i] <= 'f' && hexaNum1[i] >= 'a') || (hexaNum1[i] >= '0' && hexaNum1[i] <= '9')))
                    {
                        cout << "\n\n***Wrong entry\n Because hexadecimal can take only 1 to F,f\n\n";
                        isHexa = false;
                        break;
                    }
                }
                if (isHexa)
                {
                    cout << "HEXADECIMAL to BINARY result= ";
                    fromDecimal(toDecimal(hexaNum1, 16), 2);
                }

                break;

            case 11:
                cout << "Enter your HEXADECIMAL number: ";
                cin >> hexaNum1;

                for (int i = hexaNum1.size() - 1; i >= 0; i--)
                {
                    if (!((hexaNum1[i] <= 'F' && hexaNum1[i] >= 'A') || (hexaNum1[i] <= 'f' && hexaNum1[i] >= 'a') || (hexaNum1[i] >= '0' && hexaNum1[i] <= '9')))
                    {
                        cout << "\n\n***Wrong entry\n Because hexadecimal can take only 1 to F,f\n\n";
                        isHexa = false;
                        break;
                    }
                }
                if (isHexa)
                {
                    cout << "HEXADECIMAL to DECIMAL result= ";
                    fromDecimal(toDecimal(hexaNum1, 16), 10);
                }

                break;

            case 12:
                cout << "Enter your HEXADECIMAL number: ";
                cin >> hexaNum1;

                for (int i = hexaNum1.size() - 1; i >= 0; i--)
                {
                    if (!((hexaNum1[i] <= 'F' && hexaNum1[i] >= 'A') || (hexaNum1[i] <= 'f' && hexaNum1[i] >= 'a') || (hexaNum1[i] >= '0' && hexaNum1[i] <= '9')))
                    {
                        cout << "\n\n***Wrong entry\n Because hexadecimal can take only 1 to F,f\n\n";
                        isHexa = false;
                        break;
                    }
                }
                if (isHexa)
                {
                    cout << "HEXADECIMAL to OCTAL result= ";
                    fromDecimal(toDecimal(hexaNum1, 16), 8);
                }

                break;

            default:

                cout << "You entered wrong choice**";
                break;
            }

            break;
        default:
            cout << "You entered wrong choice**";
            break;
        }

        break;
    case 2:
        value = onesComplement(10101);
        for (int i = 0; i < sizeof(value) - 1; i++)
        {
            cout << value[i];
        }

        break;
    case 3:

        break;
    case 4:

        break;
    default:
        cout << "You entered wrong choice**";
        break;
    }

    return 0;
}

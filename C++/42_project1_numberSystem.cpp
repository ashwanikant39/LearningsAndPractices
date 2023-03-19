#include <iostream>
using namespace std;

void decimalTobinary()
{
    int num;
    cout << "Enter your Decimal number: ";
    cin >> num;
    int i = 0;
    int arr[32];
    while (num > 0)
    {
        arr[i] = num % 2;
        num = num / 2;
        i++;
    }
    cout << "Decimal to binary number is: ";
    for (int j = i - 1; j >= 0; j--)
    {
        cout << arr[j];
    }
}
void binaryTodecimal()
{
    int num;
    cout << "Enter your Binary number: ";
    cin >> num;

    int x = 1;
    int y;
    int ans = 0;
    int rem;
    while (num != 0)
    {
        rem = num % 10;
        y = rem * x;
        ans = ans + y;
        x = x * 2;
        num = num / 10;
    }
    cout << "Binary to Decimal number is: " << ans;
}

void octalTodecimal(int num)
{
    int x = 1;
    int ans = 0;
    int rem;
    int y;
    while (num != 0)
    {
        rem = num % 10;
        y = rem * x;
        ans = ans + y;
        x = x * 8;
        num = num / 10;
    }
    cout << "Octal to decimal number is: " << ans;
}

void hexadeimalTodecimal()
{

    string num;
    cout << "Enter your HEXADECIMAL number: ";
    cin >> num;
    int x = 1;
    int ans = 0;
    int y;

    int leng = num.size();
    // cout<<leng;
    int isHexa = true;

    for (int i = leng - 1; i >= 0; i--)
    {
        if (!((num[i] <= 'F' && num[i] >= 'A') || (num[i] <= 'f' && num[i] >= 'a') || (num[i] >= '0' && num[i] <= '9')))
        {
            cout << "\n\n***Wrong entry\n Because hexadecimal can take only 1 to F,f\n\n";
            isHexa = false;
            break;
        }
    }

    if (isHexa)
    {
        for (int i = leng - 1; i >= 0; i--)
        {

            if (num[i] >= '0' && num[i] <= '9')
            {
                y = x * (num[i] - 48); // because string 0 ki int value 48, or string 1 ki 49
                ans = ans + y;
            }
            else if (num[i] >= 'A' && num[i] <= 'F')
            {
                y = x * (num[i] - 55);
                ans = ans + y;
            }
            else if (num[i] >= 'a' && num[i] <= 'f')
            {
                y = x * (num[i] - 87); // 97-87=10 =A=a
                ans = ans + y;
            }
            // else
            // {
            //     cout << "\n\n***Wrong entry\n Because hexadecimal can take only 1 to F\n\n";

            // }
            x = x * 16;
        }
        cout << "Hexadecimal to decimal number is: " << ans;
    }
}
void decimalTooctal()
{
    int num;
    cout << "Enter your decimal number: ";
    cin >> num;
    int arr[32];

    int i = 0;
    while (num != 0)
    {
        arr[i] = num % 8;
        num = num / 8;
        i++;
    }
    cout << "Decimal to octal number is: ";
    for (int j = i - 1; j >= 0; j--)
    {
        cout << arr[j];
    }
}
void decimalTohexa()
{

    int num;
    cout << "Enter your decimal number: ";
    cin >> num;
    int arr[32];
    int i = 0;
    while (num > 0)
    {
        arr[i] = num % 16;
        num = num / 16;
        i++;
    }
    char x;
    cout << "Decimal to hexadecimal number is: ";
    for (int j = i - 1; j >= 0; j--)
    {
        if (arr[j] >= 0 && arr[j] <= 9)
        {
            cout << arr[j];
        }
        else if (arr[j] >= 10 && arr[j] <= 15)
        {
            x = arr[j] + 55; // 10+55=65 means  A
            cout << x;
        }
    }
}
void binaryTooctal()
{
    int num;
    cout << "Enter your Binary number: ";
    cin >> num;
    int x = 1;
    int y;
    int ans = 0;
    int rem;
    while (num != 0)
    {
        rem = num % 10;
        y = rem * x;
        ans = ans + y;
        x = x * 2;
        num = num / 10;
    }

    int arr[32];

    int i = 0;
    while (ans != 0)
    {
        arr[i] = ans % 8;
        ans = ans / 8;
        i++;
    }
    cout << "Binary to octal number is: ";
    for (int j = i - 1; j >= 0; j--)
    {
        cout << arr[j];
    }
}
void binaryTohexa()
{
    int num;
    cout << "Enter your binary number: ";
    cin >> num;
    int x = 1;
    int y;
    int ans = 0;
    int rem;
    while (num != 0)
    {
        rem = num % 10;
        y = rem * x;
        ans = ans + y;
        x = x * 2;
        num = num / 10;
    }

    int arr[32];
    int i = 0;
    while (ans > 0)
    {
        arr[i] = ans % 16;
        ans = ans / 16;
        i++;
    }
    char z;
    cout << "Binary to hexadecimal number is: ";
    for (int j = i - 1; j >= 0; j--)
    {
        if (arr[j] >= 0 && arr[j] <= 9)
        {
            cout << arr[j];
        }
        else if (arr[j] >= 10 && arr[j] <= 15)
        {
            z = arr[j] + 55; // 10+55=65 means  A
            cout << z;
        }
    }
}
void octalTobinary(int num)
{
    int x = 1;
    int ans = 0;
    int rem;
    int y;
    while (num != 0)
    {
        rem = num % 10;
        y = rem * x;
        ans = ans + y;
        x = x * 8;
        num = num / 10;
    }

    int i = 0;
    int arr[32];
    while (ans > 0)
    {
        arr[i] = ans % 2;
        ans = ans / 2;
        i++;
    }
    cout << "Octal to binary number is: ";
    for (int j = i - 1; j >= 0; j--)
    {
        cout << arr[j];
    }
}
void octalTohexa(int num)
{

    int x = 1;
    int ans = 0;
    int rem;
    int y;
    while (num != 0)
    {
        rem = num % 10;
        y = rem * x;
        ans = ans + y;
        x = x * 8;
        num = num / 10;
    }

    int arr[32];
    int i = 0;
    while (ans > 0)
    {
        arr[i] = ans % 16;
        ans = ans / 16;
        i++;
    }
    char z;
    cout << "Octal to hexadecimal number is: ";
    for (int j = i - 1; j >= 0; j--)
    {
        if (arr[j] >= 0 && arr[j] <= 9)
        {
            cout << arr[j];
        }
        else if (arr[j] >= 10 && arr[j] <= 15)
        {
            z = arr[j] + 55; // 10+55=65 means  A
            cout << z;
        }
    }
}
void hexaTobinary()
{
    string num;
    cout << "Enter your HEXADECIMAL number: ";
    cin >> num;
    int x = 1;
    int ans = 0;
    int y;

    int leng = num.size();
    // cout<<leng;
    int isHexa = true;

    for (int i = leng - 1; i >= 0; i--)
    {
        if (!((num[i] <= 'F' && num[i] >= 'A') || (num[i] <= 'f' && num[i] >= 'a') || (num[i] >= '0' && num[i] <= '9')))
        {
            cout << "\n\n***Wrong entry\n Because hexadecimal can take only 1 to F,f\n\n";
            isHexa = false;
            break;
        }
    }

    if (isHexa)
    {
        for (int i = leng - 1; i >= 0; i--)
        {

            if (num[i] >= '0' && num[i] <= '9')
            {
                y = x * (num[i] - 48); // because string 0 ki int value 48, or string 1 ki 49
                ans = ans + y;
            }
            else if (num[i] >= 'A' && num[i] <= 'F')
            {
                y = x * (num[i] - 55);
                ans = ans + y;
            }
            else if (num[i] >= 'a' && num[i] <= 'f')
            {
                y = x * (num[i] - 87); // 97-87=10 =A=a
                ans = ans + y;
            }
            // else
            // {
            //     cout << "\n\n***Wrong entry\n Because hexadecimal can take only 1 to F\n\n";

            // }
            x = x * 16;
        }
        // cout << "Hexadecimal to decimal number is: " << ans;
    }

    int i = 0;
    int arr[32];
    while (ans > 0)
    {
        arr[i] = ans % 2;
        ans = ans / 2;
        i++;
    }
    cout << "Hexadecimal to binary number is: ";
    for (int j = i - 1; j >= 0; j--)
    {
        cout << arr[j];
    }
}

void hexaTooctal()
{
    string num;
    cout << "Enter your HEXADECIMAL number: ";
    cin >> num;
    int x = 1;
    int ans = 0;
    int y;

    int leng = num.size();
    // cout<<leng;
    int isHexa = true;

    for (int i = leng - 1; i >= 0; i--)
    {
        if (!((num[i] <= 'F' && num[i] >= 'A') || (num[i] <= 'f' && num[i] >= 'a') || (num[i] >= '0' && num[i] <= '9')))
        {
            cout << "\n\n***Wrong entry\n Because hexadecimal can take only 1 to F,f\n\n";
            isHexa = false;
            break;
        }
    }

    if (isHexa)
    {
        for (int i = leng - 1; i >= 0; i--)
        {

            if (num[i] >= '0' && num[i] <= '9')
            {
                y = x * (num[i] - 48); // because string 0 ki int value 48, or string 1 ki 49
                ans = ans + y;
            }
            else if (num[i] >= 'A' && num[i] <= 'F')
            {
                y = x * (num[i] - 55);
                ans = ans + y;
            }
            else if (num[i] >= 'a' && num[i] <= 'f')
            {
                y = x * (num[i] - 87); // 97-87=10 =A=a
                ans = ans + y;
            }
            // else
            // {
            //     cout << "\n\n***Wrong entry\n Because hexadecimal can take only 1 to F\n\n";

            // }
            x = x * 16;
        }
        // cout << "Hexadecimal to decimal number is: " << ans;
    }
    int arr[32];

    int i = 0;
    while (ans != 0)
    {
        arr[i] = ans % 8;
        ans = ans / 8;
        i++;
    }
    cout << "Hexadecimal to octal number is: ";
    for (int j = i - 1; j >= 0; j--)
    {
        cout << arr[j];
    }
}
int main()
{
    // while (true)
    // {
    int choice;
    int num, i, IsOctal, digitArr[40], temNum;
    cout << "\n\n\n\t\t---HELLO, WELCOME TO NUMBER SYSTEM CONVERTOR--- \n\n 1. for Decimal to binary \n 2. for Decimal to Octal \n 3. for Decimal to Hexadecimal \n 4. for Binary to decimal \n 5. for Binary to Octal  \n 6. for Binary to Hexadecimal \n 7. for Octal to Decimal \n 8. for Octal to Binary \n 9. for Octal to Hexadecimal \n 10. for Hexadecimal to Decimal \n 11. for Hexadecimal to Binary \n 12. for Hexadecimal to Octal\n\n Enter your choice: ";
    cin >> choice;
    switch (choice)
    {
    case 1:
        decimalTobinary();
        break;

    case 2:
        decimalTooctal();
        break;

    case 3:
        decimalTohexa();
        break;

    case 4:
        binaryTodecimal();
        break;

    case 5:
        binaryTooctal();
        break;

    case 6:
        binaryTohexa();
        break;

    case 7:
        // int num, temNum, i, IsOctal, digitArr[40];

        cout << "Enter your octal number: ";
        cin >> num;
        temNum = num;
        i = 0;

        while (temNum != 0)
        {
            digitArr[i] = temNum % 10;
            temNum = temNum / 10;
            i++;
        }
        IsOctal = true;

        for (int j = 0; j <= i - 1; j++)
        {
            if (!(digitArr[j] >= 0 && digitArr[j] <= 7))
            {
                cout << "\n***WRONG ENTRY***\n because digits, greater than 7 are not consider\n\n";
                IsOctal = false;
                break;
            }
        }
        if (IsOctal)
        {
            octalTodecimal(num);
        }
        break;
    case 8:
        // int num, temNum, i, IsOctal, digitArr[40];

        cout << "Enter your octal number: ";
        cin >> num;
        temNum = num;

        i = 0;

        while (temNum != 0)
        {
            digitArr[i] = temNum % 10;
            temNum = temNum / 10;
            i++;
        }
        IsOctal = true;

        for (int j = 0; j <= i - 1; j++)
        {
            if (!(digitArr[j] >= 0 && digitArr[j] <= 7))
            {
                cout << "\n***WRONG ENTRY***\n because digits, greater than 7 are not consider\n\n";
                IsOctal = false;
                break;
            }
        }
        if (IsOctal)
        {
            octalTobinary(num);
        }
        break;

    case 9:
        cout << "Enter your octal number: ";
        cin >> num;
        temNum = num;

        i = 0;

        while (temNum != 0)
        {
            digitArr[i] = temNum % 10;
            temNum = temNum / 10;
            i++;
        }
        IsOctal = true;

        for (int j = 0; j <= i - 1; j++)
        {
            if (!(digitArr[j] >= 0 && digitArr[j] <= 7))
            {
                cout << "\n***WRONG ENTRY***\n because digits, greater than 7 are not consider\n\n";
                IsOctal = false;
                break;
            }
        }
        if (IsOctal)
        {
            octalTohexa(num);
        }
        break;

    case 10:
        hexadeimalTodecimal();
        break;

    case 11:
        hexaTobinary();
        break;

    case 12:
        hexaTooctal();
        break;

    default:
        cout << "Invalid entry***";
        break;
    }
    // }
    return 0;
}
#include <iostream>
using namespace std;
int main()
{

    cout<<"--- No. 1 ---"<<endl;
    int n1 = 6;
    for (int i = 1; i <= n1; i++)
    {
        for (int j = 1; j <= n1; j++)
        {
            cout << "* ";
        }
        cout << endl;
    }

    cout << "\n\n";

        cout<<"--- No. 2 ---"<<endl;


    for (int i = 1; i <= n1; i++)
    {
        for (int j = 1; j <= n1; j++)
        {
            if (i == 1 || j == 1 || i == n1 || j == n1)
            {
                cout << "* ";
            }
            else
            {
                cout << "  ";
            }
        }
        cout << endl;
    }

    cout << "\n\n";


    cout<<"--- No. 3 ---"<<endl;

    for (int i = n1; i >= 1; i--)
    {
        for (int j = 1; j <= i; j++)
        {
            cout << "* ";
        }
        cout << endl;
    }

    cout << "\n\n";


    cout<<"--- No. 4 ---"<<endl;

    for (int i = 1; i <= n1; i++)
    {
        for (int j = n1; j >= 1; j--)
        {
            if (j > i)
            {
                cout << "  ";
            }
            else
            {
                cout << "* ";
            }
        }
        cout << endl;
    }

    cout << "\n\n";


    cout<<"--- No. 5 ---"<<endl;

    int num = 1;
    for (int i = 1; i <= 5; i++)
    {
        for (int j = 1; j <= i; j++)
        {
            cout << num << " ";
            // cout << i<< " ";   /*optional*/
        }
        num++;
        cout << endl;
    }

    cout << "\n\n";


    cout<<"--- No. 6 ---"<<endl;

    int num2 = 1;
    for (int i = 1; i <= n1; i++)
    {
        for (int j = 1; j <= i; j++)
        {
            cout << num2 << " ";
            num2++;
        }
        cout << endl;
    }

    cout << "\n\n";

        cout<<"--- No. 7 ---"<<endl;


    for (int i = 6; i >= 1; i--)
    {
        for (int j = 1; j <= i; j++)
        {
            cout << j << " ";
        }
        cout << endl;
    }

    cout << "\n\n";

        cout<<"--- No. 8 ---"<<endl;


    for (int i = n1; i >= 1; i--)
    {
        for (int j = 1; j <= i; j++)
        {
            cout << " ";
        }
        for (int k = 1; k <= n1; k++)
        {
            cout << "* ";
        }
        cout << endl;
    }

    cout << "\n\n";


    cout<<"--- No. 9 ---"<<endl;

    for (int i = 1; i <= n1; i++)
    {
        for (int j = 1; j <= (n1 - i); j++)
        {
            cout << " ";
        }
        for (int j = 1; j <= i; j++)
        {
            cout << j << " ";
        }
        cout << endl;
    }

    cout << "\n\n";


    cout<<"--- No. 10 ---"<<endl;

    int n2 = 6;
    for (int i = 1; i <= n2; i++)
    {
        for (int j = n2; j >= 1; j--)
        {
            if (i < j)
            {
                cout << "  ";
            }
            else
            {
                cout << j << " ";
            }
        }
        for (int j = 2; j <= i; j++)
        {
            cout << j << " ";
        }
        cout << endl;
    }

    cout << "\n\n";

        cout<<"--- No. 11 ---"<<endl;


    int n3 = 3;
    for (int i = 1; i <= n3; i++)
    {
        for (int j = n3; j >= 1; j--)
        {
            if (i == j)
            {
                cout << "* ";
            }
            else
            {
                cout << "  ";
            }
        }
        for (int j = 2; j <= n3; j++)
        {
            if (i == j)
            {
                cout << "* ";
            }
            else
            {
                cout << "  ";
            }
        }
        cout << endl;
    }

    return 0;
}

#include <iostream>
using namespace std;
int main()
{
    int num=1;
    for (int i = 1; i <= 15; i++)
    {
        for (int j = 1; j <= 15; j++)
        {
            for (int k = 1; k <= 15; k++)
            {
                cout << i << " " << j << " " << k <<", "<<"num= "<<num<< endl;
                num++;
            }
        }
    }

    return 0;
}
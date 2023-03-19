#include <iostream>
using namespace std;

struct students
{
    int rolNo;
    float fee;
    char name[50];
};

int main()
{
struct students s;
s.fee=5000;
cout<<s.fee;
    

    return 0;
}
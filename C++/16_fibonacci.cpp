#include<iostream>
using namespace std;

void fib(int range){
    int a=0, b=1;
    cout<<a<<" "<<b<<" ";
    for(int i=1; i<=range; i++){
        int c=a+b;
        cout<<c<<" ";
        a=b;
        b=c;
    }
}
int main(){
    int range;
cout<<"Enter range: ";
cin>>range;

fib(range);


    return 0;
}
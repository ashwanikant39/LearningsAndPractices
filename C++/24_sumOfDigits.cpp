#include<iostream>
using namespace std;
int main(){
    int num;
    cout<<"Enter number: ";
    cin>>num;
int rem, ans=0;
    while(num!=0){
        rem=num%10;
        ans= ans+rem;
        num/=10;
    }
    cout<<"sum= "<<ans;

    return 0;
}
#include <iostream>
using namespace std;
int main()
{

cout<<"\n\n";
for(int i=6; i>=1; i--){
    for(int j=1; j<=6; j++ ){
        if(i>j){
            cout<<" ";
        }else{
            cout<<"* ";
        }
        }cout<<endl;
    }
    for(int i=4; i>=1; i--){
    for(int j=1; j<=6; j++ ){
        if(i>j){
            cout<<" ";
        }else{
            cout<<"* ";
        }
        }cout<<endl;
    }
    for(int i=4; i>=1; i--){
    for(int j=1; j<=6; j++ ){
        if(i>j){
            cout<<" ";
        }else{
            cout<<"* ";
        }
        }cout<<endl;
    }
    for(int i=1; i<=5; i++){
        for(int j=1; j<=6; j++){
            if(j<5){
                cout<<" ";
            }else{
            cout<<"#";}
        }cout<<endl;
    }
cout<<endl;
    return 0;
}
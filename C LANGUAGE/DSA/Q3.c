// Name: Ashwani Kant    Roll No: 2104939
#include <stdio.h> 
void LinearSearch(int LSA[], int n, int key) 
{ 
	int flag= 1;
	for (int i= 0; i<n; i++) 
	{
		if (LSA[i] == key) 
		{
			flag=0;
			printf("Key Found : %d",key); 
        }
	}
if(flag==1)
{
	printf("\n Desired key not found\n");
}
}
int main() 
{ 
	int k, arr[] = { 2, 3, 4, 10, 40 };  
	int n = sizeof(arr) / sizeof(arr[0]);  
	printf("Enter the Element to be Searched: ");
	scanf("%d",&k);
	LinearSearch(arr,n,k);
	return 0; 
}
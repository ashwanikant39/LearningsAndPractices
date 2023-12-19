// Name: Ashwani Kant    Roll No: 2104939
#include <stdio.h> 
void BinarySearch(int LSA[], int n, int key) 
{ 
	int lb, ub, flag;
	lb= 0;
	ub= n-1;
	flag= 1;
	while(lb <= ub) 
	{
		int mid;
		mid=(lb+ub)/2;
		if (key== LSA[mid]) 
		{
			flag=0;
			printf("Key Found : %d",key); 
        }
        else if(key>LSA[mid])
		{
			lb= mid+1;
		} 
		else
		{
			ub= mid-1;
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
	BinarySearch(arr,n,k);
	return 0; 
}
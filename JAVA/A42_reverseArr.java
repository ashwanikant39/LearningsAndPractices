public class A42_reverseArr {
    public static void reverseA(int number[]) {
        int start =0, end=number.length-1;
         while(start<end){
            int tem=number[start];
            number[start]=number[end];
            number[end]=tem;
            start++;
            end--;
         }

    }

    public static void main(String[] args) {
        int arr[]={100,2,25,4,5};
        reverseA(arr);
        for(int i=0; i<=arr.length-1; i++){
            System.out.print(arr[i]+" ");
        }

    }

}

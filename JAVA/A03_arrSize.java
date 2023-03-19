import java.util.*;

public class A03_arrSize {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        System.out.print("Enter the Array size:");
        int size = sc.nextInt();
        int arr[] = new int[size];
        System.out.println("Enter arr number");
        for (int i = 0; i < size; i++) {
            arr[i] = sc.nextInt();

        }
        int x=5;
        System.out.println("---you entered---");
        for (int i = 0; i < size; i++) {
            System.out.println(arr[i]);
        }

        for (int i = 0; i < size; i++) {
            if(arr[i]==x){
                System.out.println("X("+x+") found at "+i+"th index");
            }
        }
        System.out.println("lenght of array is " + arr.length);
    }
}

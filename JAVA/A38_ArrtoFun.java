import java.util.Scanner;

public class A38_ArrtoFun {
    public static void update(int arr[]) {

        for (int i = 0; i < arr.length; i++) {
            arr[i] = arr[i] + 1;
        }

    }

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        int arr[] = new int[5];
        // int arr[] = { 1, 2, 3 };
        System.out.println(arr.length);
        for (int i = 0; i < arr.length; i++) {
            System.out.print("Enter your " + i + " Array: ");
            arr[i] = sc.nextInt();

        }

        update(arr);

        for (int i = 0; i < arr.length; i++) {
            System.out.println(arr[i]);
        }

    }

}

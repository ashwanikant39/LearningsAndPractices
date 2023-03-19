import java.util.Scanner;

public class A02_ARR {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int arr[] = new int[4];

        System.out.println("Enter num: ");
        for (int i = 0; i < 4; i++) {
            arr[i] = sc.nextInt();
        }

        System.out.println();

        System.out.println("------You entred-----");
        for (int i = 0; i < 4; i++) {
            System.out.println(arr[i]);
        }
    }
}
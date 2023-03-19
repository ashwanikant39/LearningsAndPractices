import java.util.Scanner;

public class A18_valueSearchARR {

    public static void main(String[] args) {
        int[] arr = { 3, 5, 1, 5, 19, 12 };

        Scanner sc = new Scanner(System.in);
        System.out.print("Enter number for search: ");
        int num = sc.nextInt();
        for (int i = 0; i <= arr.length-1; i++) {
            if (num == arr[i]) {
                System.out.print("Your number find in index " + i);
            }

        }
    }

}

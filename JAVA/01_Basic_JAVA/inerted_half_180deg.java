
import java.util.Scanner;

public class inerted_half_180deg {
    public static void main(String[] args) {

        Scanner sc = new Scanner(System.in);
        System.out.print("Enter the number n: ");
        int n = sc.nextInt();
        // int m= sc.nextInt();

        for (int i = n; i >= 1; i--) {
            for (int j = 1; j <= n; j++) {
                if (j <= (i - 1)) {
                    System.out.print(" ");
                } else
                    System.out.print("*");
            }
            System.out.println();

        }

    }

}

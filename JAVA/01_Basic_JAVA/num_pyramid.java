import java.util.Scanner;

public class num_pyramid {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        System.out.println("Enter the number: ");
        int n = sc.nextInt();
        int number = 1;
        for (int i = n; i >= 1; i--) {
            for (int j = 1; j <= n; j++) {
                if (j <= i - 1) {
                    System.out.print(" ");
                } else {
                    System.out.print(number + " ");
                }

            }
            number++;
            System.out.println();
        }

    }
}

import java.util.Scanner;

public class sumoddnum {
    public static int sum(int n) {
        int sum1 = 0;
        for (int i = 1; i <= n; i++) {
            if (i % 2 != 0) {
                sum1 = sum1 + i;

            }
        }
        return sum1;
    }

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        System.out.print("Enter the num: ");
        int n = sc.nextInt();

        System.out.println("Sum of odd num till " + n + " is " + sum(n));
    }

}

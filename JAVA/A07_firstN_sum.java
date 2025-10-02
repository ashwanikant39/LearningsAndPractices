import java.util.Scanner;

public class A07_firstN_sum {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        System.out.print("Enter number: ");
        int n = sc.nextInt();
        int i = 1, c;
        int sum = 0;
        while (i <= n * 2) {
            if (i % 2 == 0) {
                sum = sum + i;

            }
            i++;

        }
        System.out.println(sum);

    }

}

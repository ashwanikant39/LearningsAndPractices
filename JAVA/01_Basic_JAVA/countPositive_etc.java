import java.util.Scanner;

public class countPositive_etc {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        System.out.print("Enter range that you want: ");
        int n = sc.nextInt();
        int i = 1;
        int positive = 0;
        int negative = 0;
        int zero = 0;
        while (i <= n) {
            System.out.print("Enter num: ");
            int num = sc.nextInt();
            if (num > 0) {
                positive++;
            }
            if (num < 0) {
                negative++;
            }
            if (num == 0) {
                zero++;
            }
            i++;

        }
        System.out.println("positive= " + positive);
        System.out.println("negative= " + negative);
        System.out.println("zero= " + zero);

    }

}

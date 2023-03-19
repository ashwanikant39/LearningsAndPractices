import java.util.Scanner;

import javax.swing.SpringLayout;

public class palindrome {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        System.out.print("Enter five digit number: ");
        int mainNum = sc.nextInt();
        int d1 = mainNum % 10;
        int num = mainNum / 10;
        int d2 = num % 10;
        num = num / 10;
        int d3 = num % 10;
        num = num / 10;
        int d4 = num % 10;
        num = num / 10;
        int d5 = num % 10;
        int reverse = 10000 * d1 + 1000 * d2 + 100 * d3 + 10 * d4 + d5;
        System.out.println(reverse);

        if (mainNum == reverse) {
            System.out.println("it is palindrome");
        } else {
            System.out.println("it is not palindrome");
        }

    }

}

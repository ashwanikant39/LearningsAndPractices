import java.util.*;

public class practice {

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        System.out.print("Enter a: ");
        int a = sc.nextInt();
        System.out.print("Enter b: ");

        int b = sc.nextInt();
        System.out.println("Enter 1 for +: ");
        System.out.println("Enter 2 for -: ");
        System.out.println("Enter 3 for *: ");
        System.out.println("Enter 4 for /: ");
        System.out.println("Enter 5 for %: ");

        System.out.print("Enter your choice: ");

        int operator = sc.nextInt();

        switch (operator) {
            case 1:
                System.out.println(a + b);
                break;
            case 2:
                System.out.println(a - b);
                break;
            case 3:
                System.out.println(a * b);
                break;
            case 4:
                if (b == 0) {

                    System.out.println("invaid devision");
                } else {
                    System.out.println(a / b);
                }
                break;
            case 5:
                if (b == 0) {
                    System.out.println("invalid division");
                } else {
                    System.out.println(a % b);
                }
                break;
            default:
                System.out.println("invalid operator");
        }

    }
}

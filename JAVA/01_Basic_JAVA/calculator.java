import java.util.Scanner;

public class calculator {
    public static void main(String[] args) {
        float a, b;
        Scanner sc = new Scanner(System.in);
        System.out.println("1 for add: ");
        System.out.println("2 for sub: ");
        System.out.println("3 for multyply: ");
        System.out.println("4 for devide: ");
        System.out.println("5 for remainder: \n");

        System.out.println("Enter your choice:");

        int choice = sc.nextInt();
        switch (choice) {
            case 1:
                System.out.println("Enter a: ");
                a = sc.nextFloat();
                System.out.println("Enter b: ");
                b = sc.nextFloat();
                float sum = a + b;
                System.out.println(sum);
                break;
            case 2:
                System.out.println("Enter a: ");
                a = sc.nextFloat();
                System.out.println("Enter b: ");
                b = sc.nextFloat();
                float sub = a - b;
                System.out.println(sub);
                break;
            case 3:
                System.out.println("Enter a: ");
                a = sc.nextFloat();
                System.out.println("Enter b: ");
                b = sc.nextFloat();
                float multiple = a * b;
                System.out.println("multiply=" + multiple);
                break;
            case 4:
                System.out.println("Enter a: ");
                a = sc.nextFloat();
                System.out.println("Enter b: ");
                b = sc.nextFloat();
                float devide = a / b;
                System.out.println(devide);
                break;
            case 5:
                System.out.println("Enter a:");
                int x = sc.nextInt();
                System.out.println("Enter b: ");
                int y = sc.nextInt();
                int remainder = x % y;
                System.out.println("Remainder= " + remainder);
                break;

        }
    }
}
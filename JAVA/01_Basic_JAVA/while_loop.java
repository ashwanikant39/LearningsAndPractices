import java.util.Scanner;

public class while_loop {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int fact = 1;
        int i = 1;
        System.out.println("Enter the number for FACTORIAL: ");
        int num = sc.nextInt();
        while (i <= num) {
            fact = i * fact;

            i++;
        }
        System.out.println("Factorial= " + fact);

    }

}

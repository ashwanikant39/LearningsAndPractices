import java.util.Scanner;

public class factorial {

    public static int calFact(int n) {

        int fact = 1;
        for (int i = 1; i <= n; i++) {
            fact = fact * i;
        }
        return fact;
    }

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        System.out.print("Enter the number: ");
        int n = sc.nextInt();

        int Z = calFact(n);

        System.out.println(Z);
        // System.out.println("Factorial is= " + calFact(n));

    }

}

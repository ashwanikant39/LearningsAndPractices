import java.util.Scanner;;

public class A44_checkPrime {

    public static void primeNum(int range) {
        for (int i = 1; i <= range; i++) {
            for (int j = 2; j < i; j++) {
                if (i % j == 0) {
                    // System.out.println(i + " is Not prime");
                    break;
                }
                if (j == i) {
                    System.out.println(i);
                }
                // System.out.println(j + " " + i + "is prime");
                // break;
                // System.out.println(i);

            }
        }

    }

    public static void main(String[] args) {

        // System.out.println("hello");

        Scanner sc = new Scanner(System.in);

        System.out.println("Enter tha range: ");
        int range = sc.nextInt();

        primeNum(range);
    }

}

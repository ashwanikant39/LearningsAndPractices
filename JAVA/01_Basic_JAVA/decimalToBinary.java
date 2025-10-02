import java.util.Scanner;

public class decimalToBinary {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        int i = 1;
        int binary = 0;
        int rem;
        int y;

        // Enter the decimal number
        System.out.println("Enter a number");
        int num = sc.nextInt();

        // Divide by 2 until number reduces to 0
        while (num != 0) {
            rem = num % 2; // 1
              
            y = i * rem; // 1*1

            binary = binary + y; // concatenate remainders in bottom-up manner

            num = num / 2; //
            i = i * 10; //
        }

        // Output the binary number
        System.out.println("Binary: " + binary);
    }
}

import java.util.Scanner;

public class A34_updateBit {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        System.out.println("Enter 1 for make 1(set)\nEnter 0 for make 0(clear)  ");
        int a = sc.nextInt();

        int num = 10;
        int position = 2;
        int bitmask = 1 << position;

        if (a == 1) {
            int newNumber = bitmask | num;
            System.out.println(newNumber);

        } else {
            int notBitMask= ~(bitmask);
            int newNumber= notBitMask & num;
            System.out.println(newNumber);

        }
    }
}

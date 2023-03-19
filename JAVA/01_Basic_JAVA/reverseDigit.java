import java.util.Scanner;

// import javax.swing.SpringLayout;

public class reverseDigit {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        System.out.print("Enter number: ");
        int num = sc.nextInt();
        int mainNum = num;
        int rem;
        int sum = 0;
        System.out.print("After reverse= ");
        while (num > 0) {
            rem = num % 10;
            System.out.print(rem);
            sum = sum + rem;
            num = num / 10;
        }
        System.out.println();
        System.out.println("sum=" + sum);

        System.out.println(mainNum);
        System.out.println(num);

    }
}

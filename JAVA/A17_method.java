import java.util.Scanner;

public class A17_method {

    static void table() {

        for (int i = 1; i <= 10; i++) {
            for (int j = 2; j <= 5; j++) {
                System.out.print(j+"*"+i+"="+i*j+"  ");
            }System.out.println();
        }

    }

    public static void main(String[] args) {
        // Scanner sc = new Scanner(System.in);
        // int n = sc.nextInt();

        table();

    }

}

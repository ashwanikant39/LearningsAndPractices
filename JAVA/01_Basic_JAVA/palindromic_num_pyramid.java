import java.net.SocketTimeoutException;
import java.util.Scanner;

public class palindromic_num_pyramid {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        System.out.println("Entet the num: ");
        int n = sc.nextInt();
        for (int i = 1; i <= n; i++) {
            for (int j = n; j >= 1; j--) {
                if (j > i) {
                    System.out.print(" ");
                } else {
                    System.out.print(j);
                }

            }
          
                for(int l=2; l<=i; l++){
                    System.out.print(l);
                }System.out.println();
               

            }
            System.out.println();
        }
    }


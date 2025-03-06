import java.util.Scanner;

public class butterfly_pattern {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        System.out.println("Enter the number: ");
        int n = sc.nextInt();
        for (int i = 1; i <= n-1; i++) {
            for (int j = 1; j <= n; j++) {
                if (j <= i) {
                    System.out.print("*");
                } else {
                    System.out.print(" ");
                }

            }
            for (int j = n; j >= 1; j--) {
                if (j> i) {
                    System.out.print(" ");
                } else {
                    System.out.print("*");
                }

            }
            System.out.println();

        }

        for(int i=1; i<=n; i++){
            for(int j=n; j>=1; j--){
                if(j>=i){
                System.out.print("*");
                }else{
                    System.out.print(" ");
                }
            }
            for(int k=1; k<=n; k++){
                if(k<i){
                    System.out.print(" ");
                }else{
                    System.out.print("*");
                }
            }

            System.out.println();
        }
    }

}

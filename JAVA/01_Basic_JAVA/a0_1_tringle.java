
import java.util.Scanner;

public class a0_1_tringle {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        System.out.println("Enter row nomber & number: ");
        int n = sc.nextInt();
        int number= 1;
        for (int i = 1; i <= n; i++) {
            for(int j=1; j<=i; j++){
                int sum= i+j;
                if(sum%2==0){
                    System.out.print("1 ");
                }else{
                    System.out.print("0 ");
                }
                
            }System.out.println();
            
            
            


        }

    }

}

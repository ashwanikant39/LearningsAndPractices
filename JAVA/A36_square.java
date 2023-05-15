
import java.util.Scanner;

class A36_square {
    public static void main(String[] args) {
        int num;
        Scanner sc = new Scanner(System.in);
        System.out.print("Enter number: ");
        num= sc.nextInt();
        
        int ans=1;
        for (int i = 1; i <= 8; i++) {
            System.out.println(num+"^"+i+"= "+num*ans);
            ans=ans*num;



            
        }
    }
}
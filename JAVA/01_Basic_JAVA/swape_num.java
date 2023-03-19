import java.util.Scanner;

public class swape_num {
    public static void main(String[] args){
        Scanner sc= new Scanner(System.in);
        System.out.println("Enter a: ");
        int a= sc.nextInt();
        System.out.println("Enter b: ");
        int b= sc.nextInt();

        int t=a;
        a=b;
        b=t;
        System.out.println("a= "+a);
        System.out.println("b= "+b);
    }
    
}

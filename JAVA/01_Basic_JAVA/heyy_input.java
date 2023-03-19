import java.util.Scanner;

public class heyy_input {
    
    public static void main(String[] args){
        Scanner sc= new Scanner(System.in);
        System.out.print("Enter a: ");
        float a= sc.nextFloat();
        System.out.print("Enter b: ");
        float b= sc.nextFloat();
        float multy= a*b;
        System.out.println(multy);
    }
}

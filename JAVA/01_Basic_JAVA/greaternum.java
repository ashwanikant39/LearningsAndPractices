import java.util.Scanner;

public class greaternum {
    public static int retGreat(int a, int b){
        if(a>b){
            return a;
        }else return b;
    }
    public static void main(String[] args){
        Scanner sc=new Scanner(System.in);
        System.out.print("Enter number: ");
        int a=sc.nextInt();
        int b=sc.nextInt();
        System.out.println("Greater number is: "+retGreat(a,b));
    }
    
}

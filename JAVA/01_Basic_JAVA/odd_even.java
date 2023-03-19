import java.util.Scanner;

public class odd_even {
    public static void main(String[] args){
        Scanner sc= new Scanner(System.in);
        System.out.println("Enter number: ");
        int a= sc.nextInt();

        if(a>=18){
            System.out.println("Adult");

        }else{
            System.out.println("Not Adult");
        }

    }
}

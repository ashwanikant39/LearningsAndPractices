import java.util.Scanner;
public class A23_deletStr {
    public static void main(String[] args) {
        Scanner sc= new Scanner(System.in);
        System.out.print("Input your EMAIL: ");
        String email= sc.nextLine();

        for(int i=0; i<=email.length(); i++){
            if(email.charAt(i)=='@'){
                break;
            }
            else{
                System.out.print(email.charAt(i));
            }
        }
       



        
    }
    
}

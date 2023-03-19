import java.util.Scanner;
public class oddnum_sum{
    public static float calAvg(float a, int b, int c){
        float avg=(a+b+c)/3;
        return avg;
    }

    public static void main(String[] args){
        Scanner sc=new Scanner(System.in);
        System.out.print("Enter three number: ");
        float a= sc.nextInt();
        int b= sc.nextInt();
        int c= sc.nextInt();
        System.out.println("Avarege= "+calAvg(a,b,c));

    }

}

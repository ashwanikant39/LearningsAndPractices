import java.util.Scanner;

public class HCF {
    public static void main(String[] args) {
        int a, b, i, hcf = 1;
        Scanner sc = new Scanner(System.in);
        System.out.print("Enter two number: ");
        a = sc.nextInt();
        b = sc.nextInt();

        for (i = 1; i <= a || i <= b; i++) {

            if (a % i == 0 && b % i == 0)

                hcf = i;
                // break;

        }
        System.out.println(hcf);
    }

}

// // // import java.util.*;

// // // public class HCF {
// // // public static void main(String args[]) {
// // // Scanner sc = new Scanner(System.in);
// // // int n1 = sc.nextInt();
// // // int n2 = sc.nextInt();

// // // while(n1 != n2) {
// // // if(n1>n2) {
// // // n1 = n1 - n2;
// // // } else {
// // // n2 = n2 - n1;
// // // }
// // // }
// // // System.out.println("GCD is : "+ n2);
// // // }
// // // }

// import java.util.Scanner;
// public class HCF {
// public static void main(String args[]){
// int a, b, i, hcf = 0;
// Scanner sc = new Scanner(System.in);
// System.out.println("Enter first number :: ");
// a = sc.nextInt();
// System.out.println("Enter second number :: ");
// b = sc.nextInt();

// for(i = 1; i <= a || i <= b; i++) {
// if( a%i == 0 && b%i == 0 )
// hcf = i;
// }
// System.out.println("HCF of given two numbers is ::"+hcf);
// }
// }
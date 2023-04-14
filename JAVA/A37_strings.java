import java.io.*;
import java.util.*;

public class A37_strings {

    public static void main(String[] args) {

        String n = "";
        Scanner sc = new Scanner(System.in);
        // String A = "12321";

        System.out.println("ENter string");
        String A = sc.next();

        for (int i = A.length() - 1; i >= 0; i--) {
            n = n + (A.charAt(i));
        }
        // for (int i = 0; i <= A.length()-1; i++) {
        // n = n + (A.charAt(i));
        // }
        System.out.println("A=" + A + " ,Size=" + A.length());
        System.out.println("n=" + n + " ,Size=" + n.length());

        if (A.toLowerCase().equals(n.toLowerCase())) {
            System.out.println("Yes");
        } else {
            System.out.println("No");
        }
    }
}

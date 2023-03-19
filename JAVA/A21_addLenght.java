import java.util.*;

public class A21_addLenght {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        System.out.print("Input your first string: ");
        String str1 = sc.nextLine();

        System.out.print("Input your Second string: ");
        String str2 = sc.nextLine();

        int totalLen = str1.length() + str2.length();
        System.out.println(totalLen);

        // int size = sc.nextInt();
        // String array[] = new String[size];
        // int totLength = 0;

        // for (int i = 0; i < size; i++) {
        // array[i] = sc.next();
        // totLength += array[i].length();
        // }

        // System.out.println(totLength);

    }

}

import java.util.*;

public class A12_reverseArre {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int[] entArr=new int[5];
        int[] arr = new int[5];

System.out.print("Enter Array: ");
        for (int i = 0; i <= 4; i++) {
            entArr[i] = sc.nextInt();  //store array in entArr
        }

        // loop for reverse
        System.out.print("After reverse= ");
        for (int i = 4; i >= 0; i--) {
            System.out.print(entArr[i] + " ");
        }

    }
}

public class primenum {
    public static void main(String[] args) {
        int i;
        int j;
        for (i = 1; i <= 10; i++) {
            for (j = 2; j < i; j++) {
                if (i % j == 0) {
                    // System.out.println(i);
                    break;
                }
                System.out.println("i=" + i);
                System.out.println("j=" + j);
            }
            if (j == i) {
                System.out.println("I=" + i);
                System.out.println("J=" + j);
                System.out.println(i + " ");
            }
        }
    }
}

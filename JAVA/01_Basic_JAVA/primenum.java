public class primenum {
    public static void main(String[] args) {
        int i;
        int j;
        for (i = 1; i <= 10; i++) {
            for (j = 2; j < i; j++) {
                if (i % j == 0)
                    break;
            }
            if (j == i) {
                System.out.print(i + " ");
            }
        }

    }
}

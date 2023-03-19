public class odd_evennum {
    public static void main(String[] args) {

        System.out.println();
        System.out.println();

        System.out.print("Odd number between 1 tp 100 are= ");
        for (int i = 1; i <= 100; i++) {
            if (i % 2 != 0) {
                System.out.print(i + " ");
            }
        }

        System.out.println();
        System.out.println();

        System.out.print("Even number between 1 to 100= ");
        for (int i = 1; i <= 100; i++) {
            if (i % 2 == 0) {
                System.out.print(i + " ");
            }
        }
        System.out.println();
        System.out.println();
    }

}
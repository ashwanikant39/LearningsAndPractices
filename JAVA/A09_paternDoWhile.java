public class A09_paternDoWhile {

    public static void main(String[] args) {
        // int i = 1;
        // int j = 1;
        // while (i <= 6) {
        //     while (j <= 6) {
        //         System.out.print("*");
        //         j++;
        //     }
        //     System.out.println();
        //     i++;
        // }

        System.out.println("\n");

        for (int l = 6; l >= 1; l--) {
            for (int m = 1; m <= 6; m++) {
                if (m <= l) {
                    System.out.print("*");
                }
            }
            System.out.println();
        }

    }
}

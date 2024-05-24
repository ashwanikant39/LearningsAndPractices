import javax.swing.SpringLayout;

public class english_letter {
    public static void main(String[] args) {
        for (int i = 1; i <= 5; i++) {
            for (int j = 5; j >= 1; j--) {
                if (j == i || i == 4 && j < i) {
                    System.out.print("*");
                } else {
                    System.out.print(" ");
                }
            }
            for (int k = 2; k <= 5; k++) {
                if (k == i || i == 4 && k < i) {
                    System.out.print("*");
                } else {
                    System.out.print(" ");
                }
            }
            System.out.println();
        }

        System.out.println();
        System.out.println();

        for (int i = 1; i <= 4; i++) {
            for (int j = 4; j >= 1; j--) {
                if (j == 4 || ((i == 1 || i == 4) && j > 1) || (i == 2 || i == 3) && j == 1) {
                    System.out.print("*");

                } else {
                    System.out.print(" ");
                }
            }

            System.out.println();
        }
        for (int i = 2; i <= 4; i++) {
            for (int j = 4; j >= 1; j--) {
                if (j == 4 || ((i == 1 || i == 4) && j > 1) || (i == 2 || i == 3) && j == 1) {
                    System.out.print("*");

                } else {
                    System.out.print(" ");
                }
            }

            System.out.println();
        }
        System.out.println();
        System.out.println();

        for (int i = 1; i <= 5; i++) {
            for (int j = 5; j >= 1; j--) {
                if (((i == 2 || i == 3 || i == 4) && j == 5) || (i == 1 || i == 5) && (j < 5 && j > 1)
                        || (i == 2 || i == 4) && (j == 1)) {
                    System.out.print("*");
                } else {
                    System.out.print(" ");
                }

            }
            System.out.println();
        }

        System.out.println();
        System.out.println();

        for (int i = 1; i <= 5; i++) {
            for (int j = 4; j >= 1; j--) {
                if (j == 4 || ((i == 1 || i == 5) && j > 1) || (i != 1 && i != 5) && j == 1) {
                    System.out.print("*");
                } else {
                    System.out.print(" ");
                }
            }
            System.out.println();
        }

        System.out.println();
        System.out.println();

        for (int i = 1; i <= 5; i++) {
            for (int j = 3; j >= 1; j--) {
                if (j == 3 || (i == 1 || i == 3 || i == 5) && j <= 3) {
                    System.out.print("*");
                } else {
                    System.out.print(" ");
                }
            }
            System.out.println();
        }

        System.out.println();
        System.out.println();

        for (int i = 1; i <= 5; i++) {
            for (int j = 3; j >= 1; j--) {
                if (j == 3 || (i == 1 || i == 3) && j <= 3) {
                    System.out.print("*");
                } else {
                    System.out.print(" ");
                }
            }
            System.out.println();
        }

        System.out.println();
        System.out.println();

        for (int i = 1; i <= 6; i++) {
            for (int j = 5; j >= 1; j--) {
                if (((i != 1 && i != 6) && j == 5) || ((i == 1 || i == 6) && (j > 1 && j < 5))
                        || ((i == 2 || i == 5 || i == 4) && j == 1) || (i == 4 && j != 4 && j != 3)) {
                    System.out.print("*");
                } else {
                    System.out.print(" ");
                }
            }
            System.out.println();
        }

        System.out.println();
        System.out.println();

        for (int i = 1; i <= 6; i++) {
            for (int j = 1; j <= 5; j++) {
                if (i == 1 || i == 6 || j == 3) {
                    System.out.print("*");
                } else {
                    System.out.print(" ");
                }
            }
            System.out.println();
        }

        System.out.println();
        System.out.println();

        // k
        // int k = 5;
        for (int i = 5; i >= 1; i--) {
            for (int j = 1; j <= i * 2; j++) {
                if (j == 1 || j == i * 2) {

                    System.out.print("*");
                } else {
                    System.out.print(" ");
                }
            }

            System.out.println("");
        }
        for (int i = 3; i <= 5; i++) {
            for (int j = 1; j <= i * 2; j++) {
                if (j == 1 || j == i * 2) {

                    System.out.print("*");
                } else {
                    System.out.print(" ");
                }
            }

            System.out.println("");
        }

        // System.out.println("hello");

    }
}

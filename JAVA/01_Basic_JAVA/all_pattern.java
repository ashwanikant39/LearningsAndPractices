import javax.annotation.processing.SupportedOptions;
import javax.sound.midi.Soundbank;

public class all_pattern {
    public static void main(String[] args) {
        int n = 5;

        System.out.println("--- No-1 ---");
        for (int i = 1; i <= n; i++) {
            for (int j = 1; j <= n; j++) {
                System.out.print("*");

            }
            System.out.println();
        }
        System.out.println();
        System.out.println();

        System.out.println("--- No-2 ---");

        for (int i = 1; i <= n; i++) {
            for (int j = 1; j <= n; j++) {
                if (i == 1 || j == 1 || i == n || j == n) {
                    System.out.print("*");
                } else {
                    System.out.print(" ");
                }
            }
            System.out.println();
        }

        System.out.println();
        System.out.println();

        System.out.println("--- No-3 ---");

        for (int i = 1; i <= n; i++) {
            for (int j = 1; j <= i; j++) {
                System.out.print("*");
            }
            System.out.println();
        }

        System.out.println();
        System.out.println();

        System.out.println("--- No-4 ---");

        for (int i = n; i >= 1; i--) {
            for (int j = 1; j <= i; j++) {
                System.out.print("*");
            }
            System.out.println();
        }

        System.out.println();
        System.out.println();

        System.out.println("--- No-5 ---");

        for (int i = 1; i <= n; i++) {
            for (int j = n; j >= 1; j--) {
                if (j > i) {
                    System.out.print(" ");
                } else {
                    System.out.print("*");
                }
            }
            System.out.println();
        }

        System.out.println("--- No-6 ---");

        for (int i = n; i >= 1; i--) {
            for (int j = 1; j <= n; j++) {
                if (j < i) {
                    System.out.print(" ");
                } else {
                    System.out.print("*");
                }
            }
            System.out.println();
        }

        System.out.println();
        System.out.println();

        System.out.println("--- No-7 ---");

        for (int i = 1; i <= n; i++) {
            for (int j = 1; j <= n; j++) {
                if (j < i) {
                    System.out.print(" ");
                } else {
                    System.out.print("*");
                }
            }
            System.out.println();
        }

        System.out.println("--- No-8 ---");

        for (int i = n; i >= 1; i--) {
            for (int j = n; j >= 1; j--) {
                if (j > i) {
                    System.out.print(" ");
                } else {
                    System.out.print("*");
                }
            }
            System.out.println();
        }

        System.out.println();
        System.out.println();

        System.out.println("--- No-9 ---");

        for (int i = 1; i <= n; i++) {
            for (int j = 1; j <= i; j++) {
                System.out.print(j + " ");
            }
            System.out.println();
        }

        System.out.println();
        System.out.println();

        System.out.println("--- No-10 ---");

        for (int i = n; i >= 1; i--) {
            for (int j = 1; j <= i; j++) {
                System.out.print(j + " ");
            }
            System.out.println();
        }

        System.out.println();
        System.out.println();

        System.out.println("--- No-11 ---");

        int num = 1;

        for (int i = 1; i <= n; i++) {
            for (int j = 1; j <= i; j++) {
                System.out.print(num + " ");
                num++;
            }
            System.out.println();
        }

        System.out.println();
        System.out.println();

        System.out.println("--- No-12 ---");

        for (int i = 1; i <= n; i++) {
            for (int j = 1; j <= i; j++) {
                if ((i + j) % 2 == 0) {
                    System.out.print(1 + " ");
                } else {
                    System.out.print(0 + " ");
                }
            }
            System.out.println();
        }

        System.out.println();
        System.out.println();

        System.out.println("--- No-13 ---");

        for (int i = 1; i <= n; i++) {
            for (int j = 1; j <= n - i; j++) {
                System.out.print(" ");
            }
            for (int j = 1; j <= n; j++) {
                System.out.print("*");
            }
            System.out.println();

        }

        System.out.println("--- No-14 ---");

        for (int i = n; i >= 1; i--) {
            for (int j = 1; j <= n; j++) {
                if (j < i) {
                    System.out.print(" ");
                } else {
                    System.out.print("*");
                }
            }
            for (int j = 1; j <= i; j++) {
                System.out.print("*");
            }
            System.out.println();
        }

        System.out.println();
        System.out.println();

        System.out.println("--- No-15 ---");

        int number = 1;
        for (int i = n; i >= 1; i--) {
            for (int j = 1; j <= n; j++) {
                if (j < i) {
                    System.out.print(" ");
                } else {
                    System.out.print(number + " ");
                }
            }
            number++;
            System.out.println();
        }

        System.out.println("--- No-16 ---");

        int number2 = 1;
        for (int i = 1; i <= n; i++) {
            for (int j = 1; j <= n - i; j++) {
                System.out.print(" ");
            }
            for (int j = 1; j <= i; j++) {
                System.out.print(number2 + " ");
            }
            number2++;
            System.out.println();
        }

        System.out.println();
        System.out.println();

        System.out.println("--- No-17 ---");

        for (int i = 1; i <= n; i++) {
            for (int j = n; j >= 1; j--) {
                if (j > i) {
                    System.out.print(" ");
                } else {
                    System.out.print(j);
                }
            }
            for (int k = 2; k <= i; k++) {
                System.out.print(k);
            }
            System.out.println();

        }

        System.out.println();
        System.out.println();

        System.out.println("--- No-18 ---");

        // for upper part
        for (int i = 1; i <= n-1; i++) {
            for (int j = 1; j <= n; j++) {
                if (j <= i) {
                    System.out.print("*");
                } else {
                    System.out.print(" ");
                }
            }
            for (int j = n; j >= 1; j--) {
                if (j > i) {
                    System.out.print(" ");
                } else {
                    System.out.print("*");
                }
            }
            System.out.println();
        }
        // for lower part
        for (int i = n; i >= 1; i--) {
            for (int j = 1; j <= n; j++) {
                if (j <= i) {
                    System.out.print("*");
                } else {
                    System.out.print(" ");
                }
            }
            for (int j = n; j >= 1; j--) {
                if (j > i) {
                    System.out.print(" ");
                } else {
                    System.out.print("*");
                }
            }
            System.out.println();
        }

        System.out.println();
        System.out.println();

        System.out.println("--- No-19 ---");

        for (int i = n; i >= 1; i--) {
            for (int j = 1; j <= n; j++) {
                if (j <= i) {
                    System.out.print("*");
                } else {
                    System.out.print(" ");
                }
            }
            for (int j = n; j >= 1; j--) {
                if (j > i) {
                    System.out.print(" ");
                } else {
                    System.out.print("*");
                }
            }
            System.out.println();
        }

        // System.out.println("--- No-20 ---");

        for (int i = 1; i <= n; i++) {
            for (int j = 1; j <= n; j++) {
                if (j <= i) {
                    System.out.print("*");
                } else {
                    System.out.print(" ");
                }
            }
            for (int j = n; j >= 1; j--) {
                if (j > i) {
                    System.out.print(" ");
                } else {
                    System.out.print("*");
                }
            }
            System.out.println();
        }

        System.out.println();
        System.out.println();

        System.out.println("--- No-21 ---");

        for (int i = n; i >= 1; i--) {
            for (int j = 1; j <= n; j++) {
                if (j < i) {
                    System.out.print(" ");
                } else {
                    System.out.print("*");
                }
            }
            for (int j = 2; j <= (n - i) + 1; j++) {
                System.out.print("*");
            }
            System.out.println();
        }

        // System.out.println("--- No-22 ---");

        for (int i = 1; i <= n; i++) {
            for (int j = 1; j <= n; j++) {
                if (j < i) {
                    System.out.print(" ");
                } else {
                    System.out.print("*");
                }
            }
            for (int j = n; j >= 1; j--) {
                if (j > i) {
                    System.out.print("*");
                }
            }
            System.out.println();
        }

        System.out.println();
        System.out.println();

        System.out.println("--- No-23 ---");

        for (int i = 1; i <= n-1; i++) {
            for (int j = 1; j <= n; j++) {
                if (j == 1 || j == i) {
                    System.out.print("*");
                } else {
                    System.out.print(" ");
                }
            }
            for (int j = n; j >= 1; j--) {
                if (j > i) {
                    System.out.print(" ");
                } else if (j == i || j == 1) {
                    System.out.print("*");
                } else {
                    System.out.print(" ");
                }
            }
            System.out.println();
        }

        // System.out.println("--- No-24 ---");

        for (int i = n; i >= 1; i--) {
            for (int j = 1; j <= n; j++) {
                if (j == 1 || j == i) {
                    System.out.print("*");
                } else {
                    System.out.print(" ");
                }
            }
            for (int j = n; j >= 1; j--) {
                if (j > i) {
                    System.out.print(" ");
                } else if (j == 1 || j == i) {
                    System.out.print("*");
                } else {
                    System.out.print(" ");
                }
            }

            System.out.println();
        }

        System.out.println();
        System.out.println();

        System.out.println("--- No-25 ---");

        for (int i = 1; i <= n; i++) {
            for (int j = 1; j <= (n - i); j++) {
                System.out.print(" ");
            }
            for (int j = 1; j <= n; j++) {
                if (j == 1 || j == n || i == 1 || i == n) {
                    System.out.print("*");
                } else {
                    System.out.print(" ");
                }
            }
            System.out.println();
        }

        System.out.println();
        System.out.println();

        System.out.println("--- No-26 ---");

        for (int i = 1; i <= n; i++) {
            for (int j = 1; j <= (n - i); j++) {
                System.out.print(" ");
            }
            for (int j = 1; j <= i; j++) {
                System.out.print(j + " ");
            }
            System.out.println();
        }

        System.out.println();
        System.out.println();

        System.out.println("--- No-27 ---");

        int num3 = 1;
        for (int i = n; i >= 1; i--) {
            for (int j = 1; j <= i; j++) {
                System.out.print(num3);
            }
            num3++;
            System.out.println();
        }

        System.out.println();
        System.out.println();

        System.out.println("--- No-28 ---");

        int line = 5;
        for (int i = line; i >= 1; i--) {
            for (int j = line; j >= i; j--) {

                System.out.print(j + " ");
            }
            for (int k = 1; k <= line; k++) {
                if (!(i <= k)) {
                    System.out.print(i + " ");
                }
            }
            for (int l = 2; l <= i; l++) {
                System.out.print(i + " ");
            }
            for (int m = 2; m <= line; m++) {
                if (!(m <= i)) {
                    System.out.print(m + " ");
                }
            }

            System.out.println();
        }
        for (int i = 2; i <= line; i++) {
            for (int j = line; j >= i; j--) {

                System.out.print(j + " ");
            }
            for (int k = 1; k <= line; k++) {
                if (!(i <= k)) {
                    System.out.print(i + " ");
                }
            }
            for (int l = 2; l <= i; l++) {
                System.out.print(i + " ");
            }
            for (int m = 2; m <= line; m++) {
                if (!(m <= i)) {
                    System.out.print(m + " ");
                }
            }

            System.out.println();
        }
        System.out.println();
        System.out.println();
    }

}

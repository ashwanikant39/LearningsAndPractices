public class A11_addMatrix {
    public static void main(String[] args) {
        int mat3[][] = new int[2][3];
        int[][] mat1 = { { 4, 12, 2 }, { 3, 6, 1 }
        };
        int[][] mat2 = {
                { 7, 6, 2 }, { 5, 6, 9 }
        };

        // print matrix 1
        System.out.print("\t---matrix 1---\n");
        for (int i = 0; i <= 1; i++) {
            for (int j = 0; j <= 2; j++) {
                System.out.print(mat1[i][j] + " ");
            }
            System.out.println();

        }

        // print matrix 2
        System.out.print("\t---Matrix 2---\n");
        for (int i = 0; i <= 1; i++) {
            for (int j = 0; j <= 2; j++) {
                System.out.print(mat2[i][j] + " ");
            }
            System.out.println();
        }

        // add both matrix
        for (int i = 0; i <= 1; i++) {
            for (int j = 0; j <= 2; j++) {
                mat3[i][j] = mat1[i][j] + mat2[i][j];
            }
        }

        // print sum of matrix
        System.out.print("\t---Sum of matrix---\n");
        for (int i = 0; i <= 1; i++) {
            for (int j = 0; j <= 2; j++) {
                System.out.print(mat3[i][j] + " ");
            }
            System.out.println();
        }

    }
}

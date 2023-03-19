import java.util.Scanner;

public class A19_input2Darray {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        System.out.print("Enter row size: ");
        int row = sc.nextInt();
        System.out.print("Enter colum size: ");
        int col = sc.nextInt();

        int[][] arr = new int[row][col];
        System.out.println("Enter values for 2D arrar: ");

        for(int i=0; i<row; i++){
            for(int j=0; j<col; j++){
                arr[i][j]=sc.nextInt();
            }
        }

        for(int i=0; i<row; i++ ){
            for(int j=0; j<col; j++){
                System.out.print(arr[i][j]+" ");
            }
            System.out.println();
        }




    }

}

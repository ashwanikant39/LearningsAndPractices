public class A43_pairs {

    public static void printPairs(int num[]) {

        for (int i = 0; i <= num.length - 1; i++) {
            for (int j = i + 1; j <= num.length - 1; j++) {
                if (num[i] == num[j]) {
                    continue;
                } else {
                    System.out.print("(" + num[i] + "," + num[j] + ") ");
                }
            }
            System.out.println();
        }
    }

    public static void main(String[] args) {
        int arr[] = { 2, 4, 6, 8, 8, 10 };
        printPairs(arr);

    }
}

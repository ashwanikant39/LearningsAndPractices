public class A13_maxInArr {
    public static void main(String[] args) {
        int[] arr = { 5, 9, 1, 10, 50, 8 };
        int max = arr[0];
        for (int i = 0; i <= 5; i++) {
            if (arr[i] > max) {
                max = arr[i];
            }
        }
        System.out.println(max);
    }
}

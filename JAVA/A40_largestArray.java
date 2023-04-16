public class A40_largestArray {
    public static int findLargest(int arr1[]) {
        int big = arr1[0];

        for (int i = 0; i <= arr1.length - 1; i++) {
            if (arr1[i] > big) {
                big = arr1[i];
            }

        }
        return big;
    }

    public static void main(String[] args) {
        int arr[] = { 1, 9, 3, 10, 11, 20, 18 };
        // System.out.println(Integer.MIN_VALUE);  for -infinity

        System.out.println("Largest number is: :"+findLargest(arr));

    }

}

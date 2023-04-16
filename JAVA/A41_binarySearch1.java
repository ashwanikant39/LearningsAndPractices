public class A41_binarySearch1 {

    public static int findLargest(int arr1[], int key) {

        int start = 0;
        int end = arr1.length - 1;

        while (start <= end) {
            int mid = (start + end) / 2;
            if (arr1[mid] == key) {
                return mid;

            }
            if (arr1[mid] < key) {
                start = mid + 1;
            } else {
                end = mid - 1;
            }
        }

        return -1;
    }

    public static void main(String[] args) {

        int arr1[] = { 1, 4, 8, 9, 12, 15, 20 };
        int key = 8;
        System.out.println("Found at index:" + findLargest(arr1, key));
    }

}

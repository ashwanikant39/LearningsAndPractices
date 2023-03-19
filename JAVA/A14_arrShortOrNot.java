public class A14_arrShortOrNot {
    public static void main(String[] args) {

        int[] arr = { 2, 5, 7, 8, 9, 5 };
        boolean arrShort = true;
        System.out.println(arr.length);

        for (int i = 0; i < arr.length - 1; i++) {
            if (arr[i] > (arr[i + 1])) {
                arrShort = false;
                break;

            }
        }
        if (arrShort) {
            System.out.print("Array is short");
        } else {
            System.out.print("Array is not short");
        }

    }
}

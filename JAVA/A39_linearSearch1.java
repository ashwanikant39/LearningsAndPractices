public class A39_linearSearch1 {

   public static int key5(int number[], int key1) {
        for (int i = 0; i < number.length; i++) {
            if (number[i] == key1) {
                return i;
            }
        }
        return -1;
    }


    static public void main(String[] args) {
        int numbers[] = { 1, 6, 2, 9, 10, 7 };
        int key = 10;

        int ans = key5(numbers, key);
        System.out.println(key+" Found at index "+ans);

    }

}

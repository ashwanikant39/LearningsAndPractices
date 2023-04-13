public class A31_getBit {
    public static void main(String[] args) {
        int n = 1010; // 101
        int position = 2;
        int bitmask = 1 << position;
        int newNumber = bitmask & n;

        // System.out.println(newNumber);
        if ((bitmask & n) == 0) {
            System.out.print("A zero bit");
        } else {
            System.out.print("A non zero bit");
        }

    }
}

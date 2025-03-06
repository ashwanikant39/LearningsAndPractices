public class A32_setBit {
    public static void main(String[] args) {
        int num = 5; //1010
        int position = 1;
        int bitmask = 1 << position;

        int newNumber = bitmask | num;
        System.out.println(newNumber);
    }
}

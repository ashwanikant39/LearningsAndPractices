public class A37_addBinary {
    static void addBinary(String a, String b) {
        int carry = 0;
        String d = "";
        int size_a = a.length() - 1;
        int size_b = b.length() - 1;
        // System.out.println(size_a);

        while (size_a >= 0 || size_b >= 0 || carry >= 0) {
            carry = carry + ((size_a >= 0) ? a[size_a] - '0' : 0);
        }

    }

    public static void main(String[] args) {
        String a = "10";
        String b = "11";

        addBinary(a, b);

    }
}
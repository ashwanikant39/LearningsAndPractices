public class A30_patternWithRecursion {
    static void pattern(int n) {
        if (n == 1) {
            System.out.println("*");
        } else {
            System.out.println("*");
            pattern(n-1);
        }
    }

    public static void main(String[] args) {

    }
}

public class A28_sumOfNWithrecursion {
    static int sum(int n) {
        if (n == 1) {
            return 1;
        } else {
            return n + sum(n - 1);
        }
    }

    public static void main(String[] args) {
        int x = 6;
        System.out.println("Sum is: " + sum(x));
    }
}

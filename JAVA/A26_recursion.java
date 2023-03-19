public class A26_recursion {

    static int fact(int x) {
        if (x == 0 || x == 1) {
            return 1;
        } else {
            return (x * fact(x - 1));
        }
    }

    public static void main(String[] args) {

        int x = 5;
        System.out.println(fact(x));

    }
}
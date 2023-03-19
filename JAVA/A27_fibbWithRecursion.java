public class A27_fibbWithRecursion {

    static int fibb(int n) {
        if (n <=1) {
            return n;
        } else {
            return fibb(n - 1) + fibb(n - 2);
        }
    }

    public static void main(String[] args) {
        int x = 3;
        System.out.println(fibb(x)); 

    }
}

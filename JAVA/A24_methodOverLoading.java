public class A24_methodOverLoading {

    static void hey() {
        System.out.println("Hello");
    }

    static void hey(int a) {
        a = a * a;
        System.out.println("Square= " + a);
    }

    static void hey(int a, int b) {
        int sum = a + b;
        System.out.println("Sum= " + sum);
    }

    // ---this will not work cos method can't be same parameter and deff return
    // type---
    // static int hey(int a, int b) {
    // int sum = a + b;
    // System.out.println("Sum= " + sum);
    // }

    static int hey(int a, int b, int c) {
        int sum = a + b + c;
        System.out.println("Sum= " + sum);
        return sum;
    }

    public static void main(String[] args) {
        int a = 2;
        int b = 5;
        int c = 7;
        hey();
        hey(a);
        hey(a, b);
        System.out.println("sum= "+hey(a, b, c));

    }

}

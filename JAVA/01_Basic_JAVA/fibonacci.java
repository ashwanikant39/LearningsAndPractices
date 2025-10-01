public class fibonacci {
    static void fibb(int n) {
        int a = 0, b = 1, c;

        for (int i = 1; i <= n; i++) {

            c = a + b;
            System.out.println(c + " ");
            a = b;
            b = c;

        }

    }

    public static void main(String[] args) {
        int n = 8;
        fibb(n);

        // int a=0;
        // int b=1;
        // int c;
        // for(int i=1; i<=8; i++){
        // c=a+b;
        // System.out.print(c+" ");
        // a=b;
        // b=c;

        // }
    }

}

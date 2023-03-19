public class fact {
    public static void main(String[] args) {

        int num = 7;

        int fac = 1;
        for (int i = 1; i <= num; i++) {
            fac = fac * i;
        }
        System.out.println("factorial= " + fac);
    }

}

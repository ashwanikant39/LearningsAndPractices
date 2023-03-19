public class A10_arrSum {
    public static void main(String[] args) {

        float[] num = { 12.1f, 3.02f, 4.50f, 1.07f, 4f };
        float sum = 0;
        // System.out.println(num.length);
        for (int i = 0; i <= num.length - 1; i++) {
            sum = sum + num[i];
        }
        System.out.println("Sum= " + sum);
    }
}
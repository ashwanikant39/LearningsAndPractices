public class A29_AverageArgument {

    static void avg(int... arr) {

        float sum = 0;
        System.out.println("Length= " + arr.length);

        for (int i = 0; i < arr.length; i++) {
            sum = sum + arr[i];
        }
        System.out.println("Sum=" + sum);

        float average = sum / arr.length;
        System.out.println(average);

    }

    public static void main(String[] args) {
        avg(5, 20, 4, 7, 9, 8);

    }

}

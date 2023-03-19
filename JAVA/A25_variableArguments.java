
public class A25_variableArguments {

    static void sum(int... arr) {
        int result = 0;
        for (int i = 0; i <= arr.length; i++) {
            result = result + i;

        }
        System.out.println(result);
    }

    public static void main(String[] args) {
        sum(1, 2, 3, 4, 5);
        sum(1, 2, 3, 4, 5, 6, 7, 8);

    }

}

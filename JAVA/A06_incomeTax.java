import java.util.*;

public class A06_incomeTax {

    public static void main(String[] args) {
        float tax;

        Scanner sc = new Scanner(System.in);
        System.out.print("Enter the \"income\" (in lac): ");
        float income = sc.nextFloat();
        if (income >= 2.5 && income <= 5.0) {
            tax = (income * 5.0f) / 100;
            System.out.println(income + tax + "lac");

        } else if (income >= 5.0 && income <= 10.0) {
            tax = (income * 20) / 100;
            System.out.println(income + tax + "lac");
        } else if (income >= 10.0) {
            tax = (income * 30) / 100;
            System.out.println(income + tax + "lac");
        } else {
            System.out.println("there is no tax");
        }

    }

}

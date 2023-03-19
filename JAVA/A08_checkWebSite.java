import java.util.*;

public class A08_checkWebSite {
    public static void main(String[] args) {

        Scanner sc = new Scanner(System.in);

        System.out.print("Enter URL:");
        String web = sc.nextLine();

        if (web.endsWith(".com")) {
            System.out.println("Commercial website");
        } else if (web.endsWith(".org")) {
            System.out.println("Organigation website");
        } else if (web.endsWith("in")) {
            System.out.println("Indian website");
        } else {
            System.out.println("invalid entry");
        }

    }
}

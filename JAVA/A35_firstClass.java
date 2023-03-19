
class students {
    int id=25;
    String name;
    public void fun(){
        System.out.println("My name is "+name);
        System.out.print("My id is "+id);
    }

}

public class A35_firstClass {

    public static void main(String[] args) {
        students aditya = new students();
        // aditya.id=39;
        aditya.name="Aditya";

        // System.out.println(aditya.id);
        // System.out.println(aditya.name);
        aditya.fun();

    }

}
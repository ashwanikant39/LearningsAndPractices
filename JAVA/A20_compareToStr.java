public class A20_compareToStr {
    public static void main(String[] args) {
        String name1 = "cditya";
        String name2 = "bditya";
        if((name1.compareTo(name2))==0){
            System.out.println("both are equal");
        }else if(name1.compareTo(name2)>=0){
            System.out.println(" name1 is greater");
        }
        else{
            System.out.println("name1 is smaller");
        }
    }
}
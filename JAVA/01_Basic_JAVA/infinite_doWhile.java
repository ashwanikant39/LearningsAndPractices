public class infinite_doWhile {
    public static void main(String[] args){
        int i=1;
        do{
            System.out.println(i);
            // i++; if we remove this line, our code run till infinite
        }while(i<10);
    }
    
}

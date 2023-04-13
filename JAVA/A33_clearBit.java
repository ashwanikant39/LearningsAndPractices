import javax.sound.midi.Soundbank;

public class A33_clearBit {
    public static void main(String[] args) {
        int n= 5; //1101
        int position= 0;
        int bitmask= 1<<position;
    
        int notOfNum= ~bitmask;
        int newNumber= notOfNum & n;
        System.out.println(newNumber);

    }
    
}

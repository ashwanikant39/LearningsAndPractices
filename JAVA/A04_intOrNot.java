
// import java.util.Scanner;

// public class A04_intOrNot {
//     public static void main(String[] args) {
//         Scanner s = new Scanner(System.in);
//         int num;
//         System.out.print("Enter Number: ");

//         num = s.nextInt();

//     }

// }


import java.util.Scanner;
public class A04_intOrNot 
{ 
	public static void main(String[] args)   
	{ 
		Scanner sc = new Scanner(System.in);   
		if(sc.hasNextInt()) {
		   System.out.println(sc.nextInt()+" is valid Integer");
		}
		else
		{
			 System.out.println(sc.nextInt()+" is valid Integer");
		}
		sc.close();
	} 
}
import java.util.Scanner;

public class Infection {
    public static void main(String[] args){
        Scanner in = new Scanner(System.in);

        Long n = in.nextLong();

        if(n != 1){
            n = (n-1)*4;
        }
        
        System.out.println(n);

        in.close();
    }
}

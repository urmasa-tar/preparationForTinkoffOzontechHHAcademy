import java.util.Scanner;

public class Gaus_Task {
    
    public static void main(String[] args){
        Scanner in = new Scanner(System.in);

        Long n = in.nextLong();

        if(n % 2 == 0){
            n = (1 + n)*n/2 - 5050 + 100;
        }else{
            n = (n)*(n - 1)/2 + n - 5050 + 100;
        }

        System.out.println(n);

        in.close();
    }
}
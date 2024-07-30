import java.util.Scanner;

public class RecurentStack {

    // public static boolean[] status;

    public static void main(String[] args){
        Scanner in = new Scanner(System.in);

        int n = in.nextInt();
        int[] arrOfLn = new int[n];
        int[] status = new int[n];
        int[][] arrayOfLists = new int[n][n];

        for(int i = 0; i < n; i++){
            arrOfLn[i] = in.nextInt();
            status[i] = -1;
            // arrayOfLists[i] = readForProc(arrOfLn[i], n);
            for(int j = 0; j < n; j++){
                if(j < arrOfLn[i]){ arrayOfLists[i][j] = in.nextInt(); }
                else{ arrayOfLists[i][j] = 0; }
            }
        }

        System.out.println(RecurentStart(n, arrOfLn, status, arrayOfLists));

        in.close();
    }
    /* 
    private static int[] readForProc(int num, int ln){
        Scanner localInp = new Scanner(System.in);

        int[] resOfInp = new int[ln];
        for(int i = 0; i < ln; i++){
            if(i < num){ resOfInp[i] = localInp.nextInt(); }
            else{ resOfInp[i] = 0; }
        }

        localInp.close();
        return resOfInp;
    }
    */
    private static int CalcMax(int n, int m){
        int res = 0;
        if(n > m){
            res = n;
        }else{
            res = m;
        }
        return res;
    }

    private static int CalcMax(int[] n){
        int res = 0;
        int ln = n.length;
        for(int i = 0; i < ln; i++){
            if(n[i] > res){ res = n[i]; }
        }
        return res;
    }

    private static int RecurentStart(int n, int[] numBefore, int[] status, int[][] arrayOfLists){
        int[] resTime = status;
        for(int i = 0; i < n; i++){
            if(numBefore[i] == 0){
                status[i] = 1;
            }else{
                resTime = Recursion(i+1, numBefore, status, arrayOfLists);
            }
        }
        return CalcMax(resTime);
    }

    private static int[] Recursion(int proc, int[] before, int[] status, int[][] arrayOfLists){
        int[] resTime = status;
        resTime[proc - 1] = 1;
        for(int i = 0; i < before[proc - 1]; i++){
            int priv = arrayOfLists[proc - 1][i];

            if(resTime[priv-1] != -1){
                resTime[proc - 1] = CalcMax(resTime[proc - 1], resTime[priv - 1] + 1);
            }else{
                resTime = Recursion(priv, before, resTime, arrayOfLists);
                resTime[proc - 1] = CalcMax(resTime[proc - 1], resTime[priv - 1] + 1);
            }
        }
        
        return resTime;
    }
}

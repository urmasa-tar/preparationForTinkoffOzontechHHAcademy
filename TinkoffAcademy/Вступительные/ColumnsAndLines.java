import java.util.Scanner;

public class ColumnsAndLines {
    public static void main(String[] args){
        Scanner in = new Scanner(System.in);

        int n = in.nextInt();

        //int[][] matrix = matrixInp(n);
        long[][] matrix = new long[n][n];
        for(int line = 0; line < n; line++){
            for(int column = 0; column < n; column++){
                matrix[line][column] = in.nextLong();
            }
        }

        long[] sumForColumns = new long[n];
        long[] sumForLines = new long[n];

        for(int line = 0; line < n; line++){
            for(int column = 0; column < n; column++){
                if(line == 0){
                    sumForColumns[column] = matrix[line][column];
                }else{
                    sumForColumns[column] += matrix[line][column];
                }

                if(column == 0){
                    sumForLines[line] = matrix[line][column];
                }else{
                    sumForLines[line] += matrix[line][column];
                }
            }
        }

        // outforMatrix(matrix, n);
        System.out.println(calcForIntrestingZone(matrix, sumForLines, sumForColumns, n));
        in.close();
    }

    private static int calcForIntrestingZone(long matr[][], long[] sumLine, long[] sumCol, int n){
        int res = 0;
        for(int line = 0; line < n; line++){
            for(int column = 0; column < n; column++){
                long localCheck = CalcFromMax(sumLine[line], sumCol[column]);

                if(localCheck <= matr[line][column]){ res+= 1; }
            }
        }
        return res;
    }

    private static long CalcFromMax(long n, long m){
        long res = 0;
        if(n > m){
            res = n - m;
        }else{
            res = m - n;
        }
        return res;
    }

    /*
    private static int[][] matrixInp(int n){
        int[][] matr = new int[n][n];
        Scanner localInp = new Scanner(System.in);
        for(int line = 0; line < n; line++){
            for(int column = 0; column < n; column++){
                matr[line][column] = localInp.nextInt();
            }
        }
    
        localInp.close();
        return matr;
    }
    */

    public static void outforMatrix(int[][] matr, int n){
        for(int i = 0; i < n; i++){
            for(int j = 0; j < n; j++){
                System.out.print(matr[i][j] + " ");
            }
            System.out.print("\n");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PriviousYears
{
    public class TableSort
    {
        public TableSort() { }

        public List<List<int>> sortKTimesForTable()
        {
            List<List<int>> tableByCol = readTable();
            int kRequest = int.Parse(Console.ReadLine());
            for(int i = 0; i < kRequest; i++)
            {
                int colNum = int.Parse(Console.ReadLine());

                tableByCol[colNum].Sort();
            }

            return tableByCol;
        }

        private List<List<int>> readTable()
        {
            using var input = new StreamReader(Console.OpenStandardInput());
            List<List<int>> inpTab = new List<List<int>>();

            var s = input.ReadToEnd().Split(' ');
            int row_n = int.Parse(s[0]);
            int col_m = int.Parse(s[1]);

            for(int row = 0; row < row_n; row++)
            {
                if(row == 0)
                {
                    var st_row = input.ReadToEnd().Split();
                    for(int col = 0; col < col_m; col++)
                    {
                        List<int> newRowList = new List<int>() { int.Parse(st_row[col])};
                        inpTab.Add(newRowList);
                    }
                }
                else
                {
                    var st_row = input.ReadToEnd().Split();
                    for(int col = 0; col < col_m; col++)
                    {
                        inpTab[col].Add(int.Parse(st_row[col]));
                    }
                }
            }

            return inpTab;
        }
    }
}

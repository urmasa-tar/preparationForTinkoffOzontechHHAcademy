using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriviousYears
{
    public class placesInTrain
    {
        private readonly Dictionary<string, int> operDic = new Dictionary<string, int>
        {
            { "add", 0 }, // Add on place 1/2 in space number k if it's free
            { "rem", 1 }, // 
            { "fst", 2 }  // 
        };
        public void requestInput(int n, int m)
        {
            using var input = new StreamReader(Console.OpenStandardInput());
            SortedSet<int> freeSpace = new SortedSet<int>();
            SortedSet<int> underCover = new SortedSet<int>();

            for(int place = 1; place <= n; place++)freeSpace.Add(place);
            
            //operations
            for(int opNum = 0; opNum < m; opNum++)
            {
                var st_row = input.ReadToEnd().Split(' ');
                string comang = st_row[0];
                if (operDic[comang] == 0)
                {
                    if (freeSpace.Contains(int.Parse(st_row[1]) * 2 + int.Parse(st_row[2])))
                    {
                        underCover.Add(int.Parse(st_row[1]) * 2 + int.Parse(st_row[2]));
                        freeSpace.Remove(int.Parse(st_row[1]) * 2 + int.Parse(st_row[2]));
                    }
                }else if (operDic[comang] == 1)
                {
                    if (underCover.Contains(int.Parse(st_row[1]) * 2 + int.Parse(st_row[2])))
                    {
                        underCover.Remove(int.Parse(st_row[1]) * 2 + int.Parse(st_row[2]));
                        freeSpace.Add(int.Parse(st_row[1]) * 2 + int.Parse(st_row[2]));
                    }
                }
                else
                {
                   for(int i = 0; i < n/2; i++)
                    {
                        if(freeSpace.Contains(i * 2 + 1) && freeSpace.Contains(i * 2 + 2))
                        {
                            freeSpace.Remove(i * 2 + 1);
                            freeSpace.Remove(i * 2 + 2);
                            underCover.Add(i * 2 + 1);
                            underCover.Add(i * 2 + 2);
                            break;
                        }
                    } 
                }
            }
        }
    }
}

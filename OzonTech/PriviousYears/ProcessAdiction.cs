using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriviousYears
{
    public class ProcessAdiction
    {
        List<List<int>> procAdic;
        List<bool> loadedMod;
        public ProcessAdiction()
        {
            procAdic = new List<List<int>>();
            loadedMod = new List<bool>();
        }

        public void adictionOut(int n, int m)
        {
            using var input = new StreamReader(Console.OpenStandardInput());

            for (int procNum = 0; procNum< n; procNum++)
            {
                var st_row = input.ReadToEnd().Split(' ');
                loadedMod.Add(false);
                List<int> procInNeed = new List<int>();
                foreach (var procN in st_row)
                { 
                    procInNeed.Add(int.Parse(procN));
                }
                procAdic.Add(procInNeed);
            }

            for(int i = 0; i < m; i++)
            {
                int procN = int.Parse(input.ReadToEnd().Split(' ')[0]);
                List<int> toDo = recurtionLoad(procN);
                for(int outP = 0; outP < toDo.Count; outP++)
                {
                    if (outP != toDo.Count - 1) { Console.Write(toDo[outP] + " "); }
                    else { Console.WriteLine(toDo[outP] + '\n'); }
                }
            }
        }

        private List<int> recurtionLoad(int num)
        {
            List<int> res = new List<int>();
            if (loadedMod[num])
            {
                res.Add(-1);
            }
            else
            {
                res = recStep(num, res);
            }
            return res;
        }

        private List<int> recStep(int n, List<int> queueToDo)
        {
            List<int> lokalQueue = queueToDo;

            foreach(int proc in procAdic[n])
            {
                if (!loadedMod[proc])
                {
                    lokalQueue = recStep(proc, lokalQueue);
                }
            }
            lokalQueue.Add(n);
            return lokalQueue;
        }
    }
}

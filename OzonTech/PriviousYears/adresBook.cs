using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriviousYears
{
    public class adresBook
    {
        public adresBook() { }

        public void callList(int n)
        {
            using var input = new StreamReader(Console.OpenStandardInput());
            Dictionary<string, List<string>> dicCallNumByName = new Dictionary<string, List<string>>();

            // O()
            for(int i = 0; i < n; i++)
            {
                var st_row = input.ReadToEnd().Split(' ');
                string personName = st_row[0];
                string personNumb = st_row[1];

                if (dicCallNumByName.ContainsKey(personName))
                {
                    bool will = true;
                    foreach(string st in dicCallNumByName[personName])
                    {
                        if(st == personNumb)
                        {
                            // Добавить удаление по номеру

                            will = false;
                            break;
                        }
                    }
                    if(will)dicCallNumByName[personName].Add(personNumb);
                }
                else
                {
                    dicCallNumByName[personName] = new List<string>() { personNumb };
                }
            }
        }

        public void writeLastByName(string Name, Dictionary<string, List<string>> dicCallNumByName)
        {
            if (dicCallNumByName[Name].Count >= 5){
                for(int i = 1; i < 6; i++)
                {
                    Console.Write(dicCallNumByName[Name][dicCallNumByName[Name].Count - i]);
                    if (i != 5) Console.Write(" ");
                    else Console.Write("\n");
                }
            }
            else
            {
                for (int i = dicCallNumByName[Name].Count - 1; i >= 0; i--)
                {
                    Console.Write(dicCallNumByName[Name][i]);
                    if (i != 0) Console.Write(" ");
                    else Console.Write("\n");
                }
            }
        }
    }
}

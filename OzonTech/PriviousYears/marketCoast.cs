using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriviousYears
{
    public class marketCoast
    {
        public marketCoast() { }

        public int marketCoastSum()
        {
            int res = 0;
            int[] arrayOfCoast = new int[10] { 1, 1, 1, 1, 3, 1, 1, 1, 2, 1};

            Array.Sort(arrayOfCoast); // n * log(n)

            int inrow = 0;
            for(int i = 0; i < arrayOfCoast.Length; i++) // O(n)
            {
                if (i > 0)
                {
                    if ((arrayOfCoast[i] == arrayOfCoast[i - 1]))
                    {
                        inrow += 1;
                    }
                    else
                    {
                        if(inrow >= 3)
                        {
                            res += (arrayOfCoast[i - 1] * inrow) - (arrayOfCoast[i - 1] * inrow / 3);
                        }
                        else
                        {
                            res += arrayOfCoast[i - 1] * inrow;
                        }
                        inrow = 1;
                    }
                }
                else
                {
                    // res += arrayOfCoast[i];
                    inrow += 1;
                    continue;
                }
            }

            return res;
        }

        public int HashMapCoastSum()
        {
            int res = 0;
            int[] arr = new int[10] { 1, 2, 2, 3, 4, 4, 4, 5, 6, 4};
            Dictionary<int, int> mapOfCoast = new Dictionary<int, int>();

            // O(n)
            for(int i = 0; i < arr.Length; i++)
            {
                if (mapOfCoast.ContainsKey(arr[i]))
                {
                    mapOfCoast[arr[i]] += 1;
                }
                else
                {
                    mapOfCoast.Add(arr[i], 1);
                }
            }

            foreach (var item in mapOfCoast)
            {
                res += (item.Key * item.Value) - (item.Key * (item.Value / 3));
            }
            return res;
        }
    }
}

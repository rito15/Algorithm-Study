using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CSharp_Algorithm_study.Sort;

namespace CSharp_Algorithm_study
{
    class MainClass
    {
        public static void Main()
        {
            new BubbleSort().Sort(new int[] { 4, 2, 5, 3, 1 });


            new BubbleSort().Sort(new int[] { 10, 2, 7, 8, 6, 7, 2, 0, 1 });
        }
    }
}

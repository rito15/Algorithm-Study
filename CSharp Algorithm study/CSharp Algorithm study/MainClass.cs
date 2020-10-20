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
            //new BubbleSort().Sort(new int[] { 10, 2, 7, 8, 6, 7, 2, 0, 1, 3 });
            //new SelectionSort().Sort(new int[] { 10, 2, 7, 8, 6, 7, 2, 0, 1, 3 });
            //new InsertionSort().Sort(new int[] { 10, 2, 7, 8, 6, 7, 2, 0, 1, 3 });
            new QuickSort().Sort(new int[] { 10, 2, 7, 8, 6, 7, 2, 0, 1, 3 });
        }
    }
}

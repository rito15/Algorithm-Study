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
            int[] arr = { 10, 2, 7, 8, 6, 7, 2, 0, 1, 3 };

            //new BubbleSort().   Sort(arr);
            //new SelectionSort().Sort(arr);
            //new InsertionSort().Sort(arr);
            //new QuickSort().    Sort(arr);
            //new MergeSort().    Sort(arr);
            new HeapSort().      Sort(arr);
        }
    }
}

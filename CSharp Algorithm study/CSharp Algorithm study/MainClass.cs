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
            // 축
            //BresenhamAlgorithm.Run((0,0), (15, 0));  // +x
            //BresenhamAlgorithm.Run((0,0), (-15, 0)); // -x
            //BresenhamAlgorithm.Run((0,0), (0, 15));  // +y
            //BresenhamAlgorithm.Run((0,0), (0, -15)); // -y

            // 1사분면
            //BresenhamAlgorithm.Run((0,0), (15, 15));
            //BresenhamAlgorithm.Run((0,0), (15, 4));
            //BresenhamAlgorithm.Run((0,0), (4, 15));

            // 2사분면
            //BresenhamAlgorithm.Run((0,0), (-15, 15));
            //BresenhamAlgorithm.Run((0,0), (-4, 15));
            //BresenhamAlgorithm.Run((0,0), (-15, 4));

            // 3사분면
            //BresenhamAlgorithm.Run((0,0), (-15, -15));
            //BresenhamAlgorithm.Run((0,0), (-4, -15));
            //BresenhamAlgorithm.Run((0,0), (-15, -4));

            // 4사분면
            //BresenhamAlgorithm.Run((0,0), (15, -15));
            //BresenhamAlgorithm.Run((0,0), (4, -15));
            //BresenhamAlgorithm.Run((0,0), (15, -4));

            Bresenham bh = new Bresenham((-5, 2), (0, 15));
            //foreach (var point in bh)
            //    Console.WriteLine(point);

            for (int i = 0; i < bh.Count; i++)
            {
                Console.WriteLine(bh[i]);
            }
        }

        public static void Main_Sort()
        {
            int[] arr = { 9, 2, 7, 8, 6, 7, 2, 0, 1, 3 };
            //int[] arr = { 1, 2, 2, 1, 2, 0, 1, 2, 0 };
            int[] orgArr = new int[arr.Length];
            arr.CopyTo(orgArr, 0);

            //new BubbleSort().   Sort(arr);
            //new SelectionSort().Sort(arr);
            //new InsertionSort().Sort(arr);
            new QuickSort().    Sort(arr);
            //new MergeSort().    Sort(arr);
            //new HeapSort().     Sort(arr);
            //new CountingSort(). Sort(arr);

            ShowArray(orgArr);
            ShowArray(arr);


            void ShowArray<T>(T[] array)
            {
                for (int i = 0; i < array.Length; i++)
                    Console.Write($"{array[i]} ");
                Console.WriteLine();
            }
        }
    }
}

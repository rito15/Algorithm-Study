using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Algorithm_study.Sort
{
    // 2020. 10. 14. 버블 정렬
    // https://gyoogle.dev/blog/algorithm/Bubble%20Sort.html

    // 시간복잡도 : O(n^2)
    // 공간복잡도 : O(n)

    // Asc 기준
    // i = 1 ~ (length - 1)
    // j = 0 ~ (length - i) 범위를 순회하며 arr[j]가 arr[j+1]보다 크면 서로 교환
    public class BubbleSort : SortBase
    {
        public override void Sort(int[] arr)
        {
            int len = arr.Length;

            for (int i = 1; i < len; i++)
            {
                for (int j = 0; j < len - i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        Swap(ref arr[j], ref arr[j + 1]);

                        VisualizeArray(arr);
                        Console.ReadKey();
                    }
                }
            }
        }
    }
}

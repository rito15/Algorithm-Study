using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Algorithm_study.Sort
{
    // 2020. 12. TODO-----------------------------------------. 기수 정렬
    // https://gyoogle.dev/blog/algorithm/Radix%20Sort.html
    // https://lktprogrammer.tistory.com/48

    // 시간복잡도 : O(dn)
    // 공간복잡도 : ??
    // 안정 정렬(Stable Sort)
    class RadixSort : SortBase
    {
        // exp : 자릿수(1, 10, 100, ...)
        private void CountSort(int[] arr, int exp)
        {
            int len = arr.Length;
            int[] buffer = new int[len]; // 임시 버퍼 배열

            // 각 기수(0~9)에 해당하는 숫자의 개수
            // 예> exp = 10일 때 30, 36이 있으면 count[3] = 2
            int[] count = new int[10];

            // 1. 각 기수의 개수 초기화
            for (int i = 0; i < len; i++)
            {
                count[(arr[i] / exp) % 10]++;
            }

            // 2. 누적합 구하기
            for (int i = 1; i < 10; i++)
            {
                count[i] += count[i - 1];
            }

            for (int i = len - 1; i >= 0; i--)
            {

                int cnt = count[(arr[i] / exp) % 10];
                buffer[cnt - 1] = arr[i];
            }
        }

        public override void Sort(int[] arr)
        {
            int max = arr.Max();
            int exp = 1;

            for (; max / exp > 0; exp *= 10)
            {
                CountSort(arr, exp);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Algorithm_study.Sort
{
    // 2020. 10. 15. 선택 정렬
    // https://gyoogle.dev/blog/algorithm/Selection%20Sort.html

    // 시간복잡도 : O(n^2)
    // 공간복잡도 : O(n)
    // 불안정 정렬(Unstable Sort) : 같은 키값을 가진 원소의 순서가 정렬 후에 유지되지 않음

    // Asc 기준
    // i = (0 ~ len-1)
    // i 시행(i : 0 ~ len-1)마다 j를 (i ~ len-1) 내에서 순회시키며 가장 작은 값의 인덱스를 찾는다.
    // i 시행 마지막에 arr[i]와 arr[indexMin]의 위치를 바꾼다.

    // Bubble Sort와 효율은 유사하지만, 비교 횟수가 많을 뿐이지 교환 횟수는 적다.
    class SelectionSort : SortBase
    {
        public override void Sort(int[] arr)
        {
            int len = arr.Length;

            for (int i = 0; i < len; i++)
            {
                int indexMin = i;

                // 이번 i 시행에서 가장 작은 값의 인덱스 찾아오기
                for (int j = i + 1; j < len; j++)
                {
                    if (arr[j] < arr[indexMin])
                        indexMin = j;
                }

                Swap(ref arr[i], ref arr[indexMin]);
                VisualizeArray(arr);
            }
        }
    }
}

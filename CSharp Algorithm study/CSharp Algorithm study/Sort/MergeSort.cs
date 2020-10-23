using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Algorithm_study.Sort
{
    // 2020. 10. 22. 합병 정렬
    // https://gyoogle.dev/blog/algorithm/Merge%20Sort.html

    // 
    // 시간복잡도 : O(nlog2n) - 최선,평균,최악
    // 공간복잡도 : O(n)
    // 안정 정렬(Stable Sort) : 같은 키값을 가진 원소의 순서가 정렬 후에도 동일하게 보장된다.

    // 분할-정복 방식 : 영역을 쪼갤 수 없을 때까지 쪼갬(MergeSort) -> 정렬(Merge)
    // 순차적인 비교를 통해 정렬하므로 링크드리스트의 정렬에 효율적이다.

    class MergeSort : SortBase
    {
        public override void Sort(int[] arr)
        {
            DoMergeSort(arr, 0, arr.Length - 1);
        }

        private void DoMergeSort(int[] arr, int left, int right)
        {
            // 1. Condition
            if (left >= right)
                return;

            // 2. Divide
            int mid = (left + right) / 2;

            // 3. Conquer
            DoMergeSort(arr, left,    mid);
            DoMergeSort(arr, mid + 1, right);

            // 4. Combine
            Merge(arr, left, mid, right);
        }

        private void Merge(int[] arr, int left, int mid, int right)
        {
            // 1. 2개의 임시 서브배열 복제
            int i = 0;
            int j = 0;
            int k = left;
            int lLen = mid - left + 1;
            int rLen = right - mid;

            int[] L = new int[lLen]; // indexRange : left ~ (mid + 1)
            int[] R = new int[rLen]; // indexRange : (mid + 1) ~ (right + 1)

            Array.Copy(arr, left,    L, 0, lLen);
            Array.Copy(arr, mid + 1, R, 0, rLen);

            // 2. 양측을 확인하며 작은 것부터 원래 배열에 담기
            while (i < lLen && j < rLen)
            {
                if (L[i] <= R[j]) arr[k++] = L[i++];
                else              arr[k++] = R[j++];
            }

            // 3. 나머지 그대로 옮겨 담기
            while (i < lLen) arr[k++] = L[i++];
            while (i < rLen) arr[k++] = R[j++];

            VisualizeArray(arr);
        }
    }
}

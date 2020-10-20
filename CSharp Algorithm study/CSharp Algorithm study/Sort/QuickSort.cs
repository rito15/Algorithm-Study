using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Algorithm_study.Sort
{
    // 2020. 10. 20. 퀵 정렬
    // https://gyoogle.dev/blog/algorithm/Quick%20Sort.html

    //              [최악]   [평균]      [최선] 
    // 시간복잡도 : O(n^2) ~ O(nlog2n) ~ O(nlog2n)
    // 공간복잡도 : O(n)
    // 불안정 정렬(Unstable Sort) : 같은 키값을 가진 원소의 순서가 정렬 후에 보장되지 않음

    // 분할 - 정복 방식
    // ** 평균적으로 가장 빠른 정렬 알고리즘 **
    // 최악의 시간복잡도 : Partition()에서 피벗 인덱스가 최소 또는 최댓값일 때
    public class QuickSort : SortBase
    {
        public override void Sort(int[] arr)
        {
            RunQuickSort(arr, 0, arr.Length - 1);
        }

        private void RunQuickSort(int[] arr, int left, int right)
        {
            if (left >= right) return;

            int pivotIndex = Partition(arr, left, right);

            // 피벗을 제외한 양쪽으로 분할 정복
            RunQuickSort(arr, left, pivotIndex - 1);
            RunQuickSort(arr, pivotIndex + 1, right);
        }

        private int Partition(int[] arr, int left, int right)
        {
            int pivot = arr[left];
            int L = left;
            int R = right;

            while (L < R)
            {
                // 피벗보다 작거나 같은 arr[R]을 찾을 때까지 인덱스 R을 좌측으로 이동
                while (pivot < arr[R])
                {
                    R--;
                }
                // 피벗보다 큰 arr[L]을 찾을 때까지 인덱스 L을 우측으로 이동
                while (pivot >= arr[L])
                {
                    if (L >= R)
                        break;

                    L++;
                }

                // arr[L] > pivot >= arr[R] 인 상태에서 양측을 교환
                Swap(ref arr[L], ref arr[R]);

                VisualizeArray(arr);
            }

            // left      <= L ,
            // arr[left] >  arr[L] 이므로 서로를 교환
            Swap(ref arr[L], ref arr[left]);

            // 이 때, arr[left] == pivot임
            // arr[left] = arr[L];
            // arr[L] = pivot;

            VisualizeArray(arr);

            return L;
        }
    }
}

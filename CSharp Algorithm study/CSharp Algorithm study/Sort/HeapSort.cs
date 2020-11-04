using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Algorithm_study.Sort
{
    // 2020. 11. 04. 힙 정렬
    // https://gyoogle.dev/blog/algorithm/Heap%20Sort.html

    // 시간복잡도 : O(nlog2n) - 최선, 평균, 최악
    // 공간복잡도 : O(n)
    // 불안정 정렬(Unstable Sort)

    // 완전 이진트리 기반의 최대 힙(Max Heap)을 이용한 정렬
    // 1. Max Heap을 구성한다.
    // 2. 루트의 값(가장 큰 값)을 마지막 값과 바꾸고,
    //    루트를 제거하여 크기가 하나 줄어든 Max Heap을 구성한다.
    // 3. 크기가 1보다 크면 2를 계속 반복
    class HeapSort : SortBase
    {
        public override void Sort(int[] arr)
        {
            int len = arr.Length;

            // 1. 최초 맥스 힙 생성
            for (int i = len / 2; i >= 0; i--)
            {
                Heapify(arr, i, len - 1);
            };

            // 2. 최댓값을 하나씩 끝으로 보내며 (i-1) 개의 요소를 맥스힙화
            for (int i = len - 1; i > 0; i--)
            {
                Swap(arr, 0, i);
                Heapify(arr, 0, i - 1);
            }

            VisualizeArray(arr);
        }

        // 배열 내에서 parent 인덱스와 두 자식을 맥스 힙 형태로 만듦
        // 이 때, maxIndex까지만 인덱스 제한을 두고 maxIndex 이후는 무시
        private void Heapify(int[] arr, int parent, int maxIndex)
        {
            int lChild = parent * 2 + 1;
            int rChild = parent * 2 + 2;

            // Parent <-> Left
            if (lChild <= maxIndex &&
                arr[parent] < arr[lChild])
            {
                Swap(arr, parent, lChild);
                Heapify(arr, lChild, maxIndex);
                // 특정 자식에 스왑해주었을 경우, 해당 자식을 부모로 Heapify 재귀 호출 해야 함
            }

            // Parent <-> Right
            if (rChild <= maxIndex &&
                arr[parent] < arr[rChild])
            {
                Swap(arr, parent, rChild);
                Heapify(arr, rChild, maxIndex);
            }
        }
    }
}

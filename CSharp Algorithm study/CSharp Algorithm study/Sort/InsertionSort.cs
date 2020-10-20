using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Algorithm_study.Sort
{
    // 2020. 10. 19. 삽입 정렬
    // https://gyoogle.dev/blog/algorithm/Insertion%20Sort.html

    //              [최악]   [평균]   [최선]
    // 시간복잡도 : O(n^2) ~ O(n^2) ~ O(n)
    // 공간복잡도 : O(n)
    // 안정 정렬(Stable Sort) : 같은 키값을 가진 원소의 순서가 정렬 후에도 유지

    // Selection Sort와 유사, 더 효율적
    // 최선의 경우 O(n) 가능
    class InsertionSort : SortBase
    {
        /*

           { 5 4 3 2 1 }

           [1번째 시행]
           - i = 1
           - [i = 1]4를 기억
           - [j = i - 1 = 0] 위치 확인
           - arr[j] > arr[i] 확인
           - [0]5가 [1]4보다 크므로 [0]5를 [1]4의 위치로 밀어옴
           - j >= 0 && arr[j]
           - 기억했던 4를 [1]에 삽입
           { 4 5 3 2 1 }

           [2번째 시행]
           - 3을 기억
           - 5를 3의 위치로 밀어옴
           - 4를 5의 위치로 밀어옴
           - 기억했던 3을 4의 위치에 삽입
        */

        public override void Sort(int[] arr)
        {
            int len = arr.Length;
            VisualizeArray(arr);

            for (int i = 1; i < len; i++)
            {
                int current = arr[i]; // 이번 시행의 대상 기억하기
                int j = i - 1;

                // 대상으로부터 -1 인덱스에서 시작하여
                // 좌측으로 이동하며, current보다 클 경우 한 칸 오르쪽으로 밀기
                for (; j >= 0 && arr[j] > current; j--)
                {
                    arr[j + 1] = arr[j];

                    /* 테스트용으로 시행 끝난 위치 지워주기 표현 */
                    arr[j] = 0;
                    /* ----------------------------------------- */

                    VisualizeArray(arr);
                }
                
                // 밀기가 끝난 위치에 current 삽입
                arr[j + 1] = current;

                VisualizeArray(arr);
            }
        }
    }
}

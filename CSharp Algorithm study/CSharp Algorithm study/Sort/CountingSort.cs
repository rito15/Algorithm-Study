using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Algorithm_study.Sort
{
    // 2020. 12. 27. 계수 정렬
    // https://gyoogle.dev/blog/algorithm/Counting%20Sort.html
    // https://bowbowbow.tistory.com/8

    // k : 배열 내에서 등장하는 최댓값
    // 시간복잡도 : O(n + k)
    // 공간복잡도 : O(k)
    // 안정 정렬(Stable Sort)

    // [장점]
    // 비교를 수행하지 않고, 시간복잡도가 O(n)에 수렴하므로 
    // 중복값이 많고 최댓값이 작을수록 효율적임

    // [단점]
    // 최댓값이 클수록 불필요한 초기화가 많고, count배열이 커지므로
    // 최솟값~최댓값의 편차가 큰 경우 굉장히 비효율적임
    class CountingSort : SortBase
    {
        public override void Sort(int[] arr)
        {
            int len = arr.Length;
            int maxValue = arr.Max();

            int[] sortedArr = new int[len];

            // count 배열 : 원래 배열(arr) 내 각 숫자의 개수를 저장
            /* [예시]
               arr = { 3, 0, 0, 4, 1 }
               countArr
                과정 1 => { 2, 1, 0, 0, 1, 1 }
                과정 2 => { 2, 3, 3, 3, 4, 5 }
            */
            int[] countArr = new int[maxValue + 1];

            // 과정 1. count 배열 초기화
            for (int i = 0; i < len; i++)
            {
                countArr[arr[i]]++;
            }

            // 과정 2. count 배열을 앞 인덱스의 누적합으로 만들어주기
            //         countArr[해당 값] 은 sortedArr의 인덱스로 사용됨
            for (int i = 1; i < maxValue + 1; i++)
            {
                countArr[i] += countArr[i - 1];
            }

            // 과정 3. 뒤에서부터 배열을 순회하며 해당하는 값의 인덱스에 초기화
            for (int i = len - 1; i >= 0; i--)
            {
                countArr[arr[i]]--;              // 빼주기
                int countSum = countArr[arr[i]]; // arr[i] 해당 값의 개수의 누적합
                sortedArr[countSum] = arr[i];

                //VisualizeArray(sortedArr);
            }

            sortedArr.CopyTo(arr, 0);
        }
    }
}

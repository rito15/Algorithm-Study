using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Algorithm_study.Sort
{
    /// <summary> 
    /// 정렬을 위한 베이스 클래스
    /// </summary>
    public abstract class SortBase
    {
        /// <summary> 콘솔 출력 옵션 </summary>
        [Flags]
        public enum ConsoleOption
        {
            /// <summary> 콘솔 일시 정지(키보드 입력 대기) </summary>
            Pause = 1,
            /// <summary> 콘솔 내용 지우기 </summary>
            Refresh = 2,
        }

        /// <summary> 정렬 수행 </summary>
        public abstract void Sort(int[] arr);

        /// <summary> 배열을 콘솔에 시각화하여 출력 </summary>
        public void VisualizeArray(int[] arr, ConsoleOption consoleOption = ConsoleOption.Pause | ConsoleOption.Refresh)
        {
            if (consoleOption.HasFlag(ConsoleOption.Refresh))
                Console.Clear();

            // 전체 스트링
            StringBuilder sbFull = new StringBuilder("");

            for (int i = 0; i < arr.Length; i++)
            {
                // 한 줄 스트링
                StringBuilder sb = new StringBuilder($"[{i}] ");

                for (int j = 0; j < arr[i]; j++)
                {
                    sb.Append("■");
                }
                sb.AppendLine();
                sbFull.Append(sb);
            }

            Console.WriteLine(sbFull);

            // 콘솔 입력 대기
            if (consoleOption.HasFlag(ConsoleOption.Pause))
                Console.ReadKey();
        }

        // 인덱스 기반 스왑
        public void Swap(int[] arr, int indexA, int indexB)
        {
            int tmp = arr[indexA];
            arr[indexA] = arr[indexB];
            arr[indexB] = tmp;
        }

        // 요소를 직접 스왑
        public void Swap(ref int a, ref int b)
        {
            //a = a + b;
            //b = a - b;
            //a = a - b;
            int tmp = a;
            a = b;
            b = tmp;
        }
    }
}

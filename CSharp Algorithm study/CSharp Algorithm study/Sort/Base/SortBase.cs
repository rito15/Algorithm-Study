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
        /// <summary> 정렬 수행 </summary>
        public abstract void Sort(int[] arr);

        /// <summary> 배열을 콘솔에 시각화하여 출력 </summary>
        public void VisualizeArray(int[] arr, bool refreshConsole = true)
        {
            if (refreshConsole)
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
        }

        public void Swap(ref int a, ref int b)
        {
            a = a + b;
            b = a - b;
            a = a - b;
        }
    }
}

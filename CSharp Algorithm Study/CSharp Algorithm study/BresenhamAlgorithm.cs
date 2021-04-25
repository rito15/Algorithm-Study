using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Algorithm_study
{
    public struct Point
    {
        public int x;
        public int y;
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public static implicit operator Point((int x, int y) p)
        {
            return new Point(p.x, p.y);
        }
        public override string ToString()
        {
            return $"({x}, {y})";
        }
    }
    class BresenhamAlgorithm
    {
        // 좌표 (x1, y1) ~ (x2, y2) 사이에서 직선 그리기
        public static void Run(Point p1, Point p2)
        {
            int W = p2.x - p1.x; // width
            int H = p2.y - p1.y; // height;
            int absW = Math.Abs(W);
            int absH = Math.Abs(H);

            int xSign = Math.Sign(W);
            int ySign = Math.Sign(H);

            // 기울기 절댓값
            float absM = (W == 0) ? float.MaxValue : (float)absH / absW;

            int k;  // 판별값
            int kA; // p가 0 이상일 때 p에 더할 값
            int kB; // p가 0 미만일 때 p에 더할 값

            int x = p1.x;
            int y = p1.y;

            // 1. 기울기 절댓값이 1 미만인 경우 => x 기준
            if (absM < 1f)
            {
                k = 2 * absH - absW; // p의 초깃값
                kA = 2 * absH;
                kB = 2 * (absH - absW);

                for (; W >= 0 ? x <= p2.x : x >= p2.x; x += xSign)
                {
                    Console.WriteLine($"[{x,2},{y,2}], k : {k}");

                    if (k < 0)
                    {
                        k += kA;
                    }
                    else
                    {
                        k += kB;
                        y += ySign;
                    }
                }
            }
            // 기울기 절댓값이 1 이상인 경우 => y 기준
            else
            {
                k = 2 * absW - absH; // p의 초깃값
                kA = 2 * absW;
                kB = 2 * (absW - absH);

                for (; H >= 0 ? y <= p2.y : y >= p2.y; y += ySign)
                {
                    Console.WriteLine($"[{x,2},{y,2}], k : {k}");

                    if (k < 0)
                    {
                        k += kA;
                    }
                    else
                    {
                        k += kB;
                        x += xSign;
                    }
                }
            }
        }
    }

    /// <summary> Enumerable 브레즌햄 </summary>
    internal class Bresenham : IEnumerable
    {
        private readonly List<Point> points;

        public int Count { get; private set; }

        public Point this[int index]
        {
            get => points[index];
        }

        public Bresenham(Point p1, Point p2)
        {
            int w = Math.Abs(p2.x - p1.x);
            int h = Math.Abs(p2.y - p1.y);
            points = new List<Point>(w + h);

            SetPoints(p1, p2);
            Count = points.Count;
        }

        private void SetPoints(in Point p1, in Point p2)
        {
            int W = p2.x - p1.x; // width
            int H = p2.y - p1.y; // height;
            int absW = Math.Abs(W);
            int absH = Math.Abs(H);

            int xSign = Math.Sign(W);
            int ySign = Math.Sign(H);

            // 기울기 절댓값
            float absM = (W == 0) ? float.MaxValue : (float)absH / absW;

            int k;  // 판별값
            int kA; // p가 0 이상일 때 p에 더할 값
            int kB; // p가 0 미만일 때 p에 더할 값

            int x = p1.x;
            int y = p1.y;

            // 1. 기울기 절댓값이 1 미만인 경우 => x 기준
            if (absM < 1f)
            {
                k = 2 * absH - absW; // p의 초깃값
                kA = 2 * absH;
                kB = 2 * (absH - absW);

                for (; W >= 0 ? x <= p2.x : x >= p2.x; x += xSign)
                {
                    points.Add((x, y));

                    if (k < 0)
                    {
                        k += kA;
                    }
                    else
                    {
                        k += kB;
                        y += ySign;
                    }
                }
            }
            // 기울기 절댓값이 1 이상인 경우 => y 기준
            else
            {
                k = 2 * absW - absH; // p의 초깃값
                kA = 2 * absW;
                kB = 2 * (absW - absH);

                for (; H >= 0 ? y <= p2.y : y >= p2.y; y += ySign)
                {
                    points.Add((x, y));

                    if (k < 0)
                    {
                        k += kA;
                    }
                    else
                    {
                        k += kB;
                        x += xSign;
                    }
                }
            }
        }

        public IEnumerator GetEnumerator()
        {
            return points.GetEnumerator();
        }
    }
}

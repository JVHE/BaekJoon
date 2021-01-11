namespace BaekJoon.Problems
{
    using System;
    using System.IO;
    using System.Linq;

    public class P1052 : ISolve
    {
        private static P1052 _instance;
        public static P1052 Instance => _instance ?? (_instance = new P1052());

        private P1052()
        {

        }

        public void Solve()
        {
            using (var inStream = new BufferedStream(Console.OpenStandardInput()))
            using (var outStream = new BufferedStream(Console.OpenStandardOutput()))
            using (var reader = new StreamReader(inStream))
            using (var writer = new StreamWriter(outStream))
            {
                var numbers = reader.ReadLine().Split().Select(int.Parse).ToList();
                writer.WriteLine(GetAnswer(numbers[0], numbers[1]));
            }
        }

        public int GetAnswer(int n, int k)
        {
            if (k == 0) return 0;
            while (k > 1)
            {
                n -= (int)Math.Pow(2, FindLargestExponentOf2ButEqualOrSmallerThanInput(n));
                k--;
            }

            int exponent = FindLargestExponentOf2ButEqualOrSmallerThanInput(n);
            if (exponent == 0) return 0;
            int x = (int)Math.Pow(2, exponent);
            if (x == n) return 0;
            return x * 2 - n;
        }

        private static int FindLargestExponentOf2ButEqualOrSmallerThanInput(int input)
        {
            int result = 0;
            while ((int)Math.Pow(2, result + 1) < input)
            {
                result++;
            }

            return result;
        }
    }
}

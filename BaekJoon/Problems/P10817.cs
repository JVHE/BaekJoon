namespace BaekJoon.Problems
{
    using System;
    using System.IO;
    using System.Linq;

    public class P10817 : ISolve
    {
        private static P10817 _instance;
        public static P10817 Instance => _instance ?? (_instance = new P10817());

        public void Solve()
        {
            using (var inStream = new BufferedStream(Console.OpenStandardInput()))
            using (var outStream = new BufferedStream(Console.OpenStandardOutput()))
            using (var reader = new StreamReader(inStream))
            using (var writer = new StreamWriter(outStream))
            {
                var numbers = reader.ReadLine().Split().Select(int.Parse).ToList();
                writer.WriteLine(GetMiddleNumber(numbers[0], numbers[1], numbers[2]));
            }
        }

        public string GetMiddleNumber(int n1, int n2, int n3)
        {
            var result =
                n1 > n2
                    ? n3 > n2
                        ? Math.Min(n1, n3)
                        : n2
                    : n1 < n3
                        ? Math.Min(n2, n3)
                        : n1;
            return result.ToString();
        }
    }
}

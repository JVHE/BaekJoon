namespace BaekJoon.Problems
{
    using System;
    using System.IO;
    using System.Linq;

    public class P1074 : ISolve
    {
        private static P1074 _instance;
        public static P1074 Instance => _instance ?? (_instance = new P1074());

        public void Solve()
        {
            using (var inStream = new BufferedStream(Console.OpenStandardInput()))
            using (var outStream = new BufferedStream(Console.OpenStandardOutput()))
            using (var reader = new StreamReader(inStream))
            using (var writer = new StreamWriter(outStream))
            {
                var numbers = reader.ReadLine().Split().Select(int.Parse).ToList();
                writer.WriteLine(GetOrder(numbers[0], numbers[1], numbers[2]));
            }
        }

        public int GetOrder(int times, int row, int col)
        {
            if (times == 1)
            {
                int result = row * 2 + col;
                return result;
            }

            times--;
            int middle = (int) Math.Pow(2, times);

            var r = row >= middle;
            var c = col >= middle;
            return (r ? middle * middle * 2 : 0) + (c ? middle * middle : 0) +
                   GetOrder(times, row % middle, col % middle);
        }
    }
}

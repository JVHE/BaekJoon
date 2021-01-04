using BaekJoon.Problems;

namespace BaekJoon
{
    class Program
    {
        static void Main(string[] args)
        {
            P3048.Instance.Solve();
        }
    }

    internal interface ISolve
    {
        void Solve();
    }
}
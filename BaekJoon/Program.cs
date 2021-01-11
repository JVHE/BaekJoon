using BaekJoon.Problems;

namespace BaekJoon
{
    class Program
    {
        static void Main(string[] args)
        {
            P1052.Instance.Solve();
        }
    }

    internal interface ISolve
    {
        void Solve();
    }
}
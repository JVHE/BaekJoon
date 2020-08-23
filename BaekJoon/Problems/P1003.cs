namespace BaekJoon.Problems
{
    using System;
    using System.IO;

    class P1003 : ISolve
    {
        private static P1003 _instance;
        public static P1003 Instance => _instance ?? (_instance = new P1003());
    
        public void Solve()
        {
            using (var inStream = new BufferedStream(Console.OpenStandardInput()))
            using (var outStream = new BufferedStream(Console.OpenStandardOutput()))
            using (var reader = new StreamReader(inStream))
            using (var writer = new StreamWriter(outStream))
            {
                SaveFibonacci();
                int testCases = int.Parse(reader.ReadLine());
                for (int i = 0; i < testCases; i++)
                {
                    int pos = int.Parse(reader.ReadLine());
                    writer.WriteLine($"{_dataStoreZero[pos]} {_dataStoreOne[pos]}");
                }
            }
        }
    
        private static int[] _dataStoreZero;
        private static int[] _dataStoreOne;

        public static void SaveFibonacci()
        {
            _dataStoreZero = new int[41];
            _dataStoreOne = new int[41];
            _dataStoreZero[0] = 1;
            _dataStoreZero[1] = 0;
            _dataStoreOne[0] = 0;
            _dataStoreOne[1] = 1;
            for (int i = 2; i < _dataStoreOne.Length; i++)
            {
                _dataStoreZero[i] = _dataStoreZero[i - 1] + _dataStoreZero[i - 2];
                _dataStoreOne[i] = _dataStoreOne[i - 1] + _dataStoreOne[i - 2];
            }
        }
    }

}

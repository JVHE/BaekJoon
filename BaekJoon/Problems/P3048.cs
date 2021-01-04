namespace BaekJoon.Problems
{
    using System;
    using System.IO;
    using System.Linq;

    class P3048 : ISolve
    {
        private static P3048 _instance;
        public static P3048 Instance => _instance ?? (_instance = new P3048());

        public void Solve()
        {
            using (var inStream = new BufferedStream(Console.OpenStandardInput()))
            using (var outStream = new BufferedStream(Console.OpenStandardOutput()))
            using (var reader = new StreamReader(inStream))
            using (var writer = new StreamWriter(outStream))
            {
                var lengthArr = reader.ReadLine()?.Split();
                var line1 = reader.ReadLine();
                var line2 = reader.ReadLine();
                
                var charArr = new char[line1.Length + line2.Length];
                for (int i = 0; i < line1.Length; i++)
                {
                    charArr[line1.Length - i - 1] = line1[i];
                }
                for (int i = 0; i < line2.Length; i++)
                {
                    charArr[line1.Length + i] = line2[i];
                }

                var boolArr = new bool[charArr.Length];
                for (int i = Convert.ToInt32(lengthArr[0]); i < boolArr.Length; i++)
                {
                    boolArr[i] = true;
                }

                var second = int.Parse(reader.ReadLine());
                for (int j = 0; j < second; j++)
                {
                    for (int i = 0; i < boolArr.Length - 1; i++)
                    {
                        // swap
                        if (!boolArr[i] && boolArr[i + 1])
                        {
                            var tempChar = charArr[i];
                            charArr[i] = charArr[i + 1];
                            charArr[i + 1] = tempChar;

                            boolArr[i] = true;
                            boolArr[i + 1] = false;

                            i++;
                        }
                    }
                }

                writer.WriteLine(new string(charArr));
            }
        }
    }

}
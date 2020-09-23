namespace BaekJoon.Problems
{
    using System;
    using System.IO;
    using System.Linq;

    class P15684 : ISolve
    {
        private static P15684 _instance;
        public static P15684 Instance => _instance ?? (_instance = new P15684());

        public void Solve()
        {
            // 선 하나 그으면 두개 바뀜.
            // 7개 이상 다른 경우면 불가능?
            // 최대 6개까지 바꿀 수 있다.
            // 바뀐 조합은 홀수가 있는가? ㅇ
            // 하나만 있을 수 있는가? x
            // 2~6까지면 가능

            // 교정하고자 하는 숫자를 찾음. 두가지가 쌍이면 더 좋고?
            // 바꾸고자 하는 경우의 수가 있으면, 그거를 시작으로 조합한 모든 배열을 돌리면서 뽑아낸다?
            // 아냐 이런 방법은 좋은 성능을 내겠지만, 시간이 오래 걸린다. 지금 주어진 시간은 한 시간 뿐

            // 가능 영역을 전부 찾은 다음에, 선을 그으면서 배열 내부의 숫자를 전부 바꿔버리기?
            // 한번, 두번, 세번 찾아낸다?

            // 선을 긋기 위한 조건? 선이 그어져 있지 않으면서 양옆에 선이 없어야 한다.
            // 0부터 크기 + 2까지 배열을 만들어내면 될듯?



            // 이론상, 전부 

            // 배열이 필요하다. 
            // 배열에 필요한 것은 
            using (var inStream = new BufferedStream(Console.OpenStandardInput()))
            using (var outStream = new BufferedStream(Console.OpenStandardOutput()))
            using (var reader = new StreamReader(inStream))
            using (var writer = new StreamWriter(outStream))
            {
                // [0]: 세로선 갯수 [1]: 가로선 갯수 [2]: 세로선마다 가로선을 놓을 수 있는 갯수
                var firstLine = reader.ReadLine().Split().Select(int.Parse).ToArray();
                var numOfColumns = firstLine[0];
                var numOfGivenHorizontalLines = firstLine[1];
                var numOfPossibleHorizontalLinesPerColumn = firstLine[2];
                // 배열에 필요한 값?
                // 2차원 배열 선언 [0]: 사다리 놓여져 있는지 확인 [1]: 현재 숫자 값 
                // 0: 가능 1: 놓여짐 -1: 놓을 수 없음
                int[,,] matrix = new int[numOfPossibleHorizontalLinesPerColumn + 1, numOfColumns + 2, 2];

                // 가로선 받아서 넣기
                for (int i = 0; i < numOfGivenHorizontalLines; i++)
                {
                    var lineData = reader.ReadLine().Split().Select(int.Parse).ToArray();
                    matrix[lineData[0], lineData[1], 0] = 1;
                    matrix[lineData[0], lineData[1] - 1, 0] = 2;
                    matrix[lineData[0], lineData[1] + 1, 0] = 2;
                }
                // 초기값 설정
                for (int j = 1; j <= numOfColumns; j++)
                {
                    matrix[0, j, 1] = j;
                }
                // 사다리 타기 시작
                for (int i = 1; i <= numOfPossibleHorizontalLinesPerColumn; i++)
                {
                    for (int j = 1; j <= numOfColumns; j++)
                    {
                        // 만약 [0]값이 1이면 스왑, 그리고 j++, 아니면 위에값 그대로
                        if (matrix[i, j, 0] == 1)
                        {
                            matrix[i, j, 1] = matrix[i - 1, j + 1, 1];
                            matrix[i, j + 1, 1] = matrix[i - 1, j, 1];
                            j++;
                        }
                        else
                        {
                            matrix[i, j, 1] = matrix[i - 1, j, 1];
                        }
                    }
                }
                // 선 하나 그으면 두개 바뀜.
                // 7개 이상 다른 경우면 불가능?
                // 최대 6개까지 바꿀 수 있다.
                // 바뀐 조합은 홀수가 있는가? ㅇ
                // 하나만 있을 수 있는가? x
                // 2~6까지면 가능
                //0번 체크
                if (IsAnswer(numOfColumns, matrix, numOfPossibleHorizontalLinesPerColumn))
                {
                    writer.Write(0);
                    return;
                }

                int cnt = 0;
                for (int j = 1; j <= numOfColumns; j++)
                {
                    if (matrix[numOfPossibleHorizontalLinesPerColumn, j, 1] != j) cnt++;
                }
                if (cnt > 6)
                {
                    writer.Write(-1);
                    return;
                }
                // 모든 경우의 수를 다 돌려서 체크?
                // 한 번 돌리기
                if (GetValue1(numOfPossibleHorizontalLinesPerColumn, numOfColumns, matrix))
                {
                    writer.Write(1);
                    return;
                }

                // 두 번 돌리기
                if (GetValue2(numOfPossibleHorizontalLinesPerColumn, numOfColumns, matrix))
                {
                    writer.Write(2);
                    return;
                }
                for (int i = 1; i <= numOfPossibleHorizontalLinesPerColumn; i++)
                {
                    for (int j = 1; j <= numOfColumns; j++)
                    {
                        // 만약 0이면 넣고 아니면 패스
                        if (matrix[i, j, 0] != 0 || matrix[i, j + 1, 0] == 1 || matrix[i, j - 1, 0] == 1) continue;
                        int t1 = matrix[i, j, 0];
                        int t2 = matrix[i, j + 1, 0];
                        int t3 = matrix[i, j - 1, 0];
                        matrix[i, j, 0] = 1;
                        matrix[i, j + 1, 0] = 2;
                        matrix[i, j - 1, 0] = 2;

                        var newMatrix = GetNextMatrix(numOfPossibleHorizontalLinesPerColumn, numOfColumns, matrix);

                        if (GetValue2(numOfPossibleHorizontalLinesPerColumn, numOfColumns, newMatrix))
                        {
                            writer.Write(3);
                            return;
                        }

                        matrix[i, j, 0] = t1;
                        matrix[i, j + 1, 0] = t2;
                        matrix[i, j - 1, 0] = t3;
                    }
                }
                writer.Write(-1);
                return;
                // // 세 번 돌리기
                // // 테스트 출력
                // for (int i = 0; i <= numOfPossibleHorizontalLinesPerColumn; i++)
                // {
                //     for (int j = 1; j <= numOfColumns; j++)
                //     {
                //         Console.Write($"{matrix[i, j, 1]} ");
                //     }
                //     Console.WriteLine();
                //     for (int j = 1; j <= numOfColumns; j++)
                //     {
                //         Console.Write($"{matrix[i, j, 0]} ");
                //     }
                //     Console.WriteLine();
                // }

            }
        }

        private static bool GetValue2(int numOfPossibleHorizontalLinesPerColumn, int numOfColumns, int[,,] matrix)
        {
            for (int i = 1; i <= numOfPossibleHorizontalLinesPerColumn; i++)
            {
                for (int j = 1; j <= numOfColumns; j++)
                {
                    // 만약 0이면 넣고 아니면 패스
                    if (matrix[i, j, 0] != 0 || matrix[i, j + 1, 0] == 1 || matrix[i, j - 1, 0] == 1) continue;
                    int t1 = matrix[i, j, 0];
                    int t2 = matrix[i, j + 1, 0];
                    int t3 = matrix[i, j - 1, 0];
                    matrix[i, j, 0] = 1;
                    matrix[i, j + 1, 0] = 2;
                    matrix[i, j - 1, 0] = 2;

                    var newMatrix = GetNextMatrix(numOfPossibleHorizontalLinesPerColumn, numOfColumns, matrix);

                    if (GetValue1(numOfPossibleHorizontalLinesPerColumn, numOfColumns, newMatrix))
                    {
                        return true;
                    }

                    matrix[i, j, 0] = t1;
                    matrix[i, j + 1, 0] = t2;
                    matrix[i, j - 1, 0] = t3;
                }
            }

            return false;
        }

        private static bool GetValue1(int numOfPossibleHorizontalLinesPerColumn, int numOfColumns, int[,,] matrix)
        {
            for (int i = 1; i <= numOfPossibleHorizontalLinesPerColumn; i++)
            {
                for (int j = 1; j <= numOfColumns; j++)
                {
                    // 만약 0이고 양옆이 1이 아니면 넣고 아니면 패스
                    if (matrix[i, j, 0] != 0 || matrix[i, j + 1, 0] == 1 || matrix[i, j - 1, 0] == 1) continue;
                    int t1 = matrix[i, j, 0];
                    int t2 = matrix[i, j + 1, 0];
                    int t3 = matrix[i, j - 1, 0];
                    matrix[i, j, 0] = 1;
                    matrix[i, j + 1, 0] = 2;
                    matrix[i, j - 1, 0] = 2;
                    var newMatrix = GetNextMatrix(numOfPossibleHorizontalLinesPerColumn, numOfColumns, matrix);
                    if (IsAnswer(numOfColumns, newMatrix, numOfPossibleHorizontalLinesPerColumn))
                    {
                        return true;
                    }

                    matrix[i, j, 0] = t1;
                    matrix[i, j + 1, 0] = t2;
                    matrix[i, j - 1, 0] = t3;
                }
            }

            return false;
        }

        private static bool IsAnswer(int numOfColumns, int[,,] matrix, int numOfPossibleHorizontalLinesPerColumn)
        {
            for (int j = 1; j <= numOfColumns; j++)
            {
                if (matrix[numOfPossibleHorizontalLinesPerColumn, j, 1] != j) return false;
            }

            return true;
        }

        private static int[,,] GetNextMatrix(int numOfPossibleHorizontalLinesPerColumn, int numOfColumns, int[,,] matrix)
        {
            int[,,] newMatrix = new int[numOfPossibleHorizontalLinesPerColumn + 1, numOfColumns + 2, 2];
            // 복사
            for (int i = 0; i <= numOfPossibleHorizontalLinesPerColumn; i++)
            {
                for (int j = 0; j <= numOfColumns + 1; j++)
                {
                    newMatrix[i, j, 0] = matrix[i, j, 0];
                }
            }
            // 초기값 설정
            for (int j = 1; j <= numOfColumns; j++)
            {
                newMatrix[0, j, 1] = j;
            }
            // 사다리 타기 시작
            for (int i = 1; i <= numOfPossibleHorizontalLinesPerColumn; i++)
            {
                for (int j = 1; j <= numOfColumns; j++)
                {
                    // 만약 [0]값이 1이면 스왑, 그리고 j++, 아니면 위에값 그대로
                    if (newMatrix[i, j, 0] == 1)
                    {
                        newMatrix[i, j, 1] = newMatrix[i - 1, j + 1, 1];
                        newMatrix[i, j + 1, 1] = newMatrix[i - 1, j, 1];
                        j++;
                    }
                    else
                    {
                        newMatrix[i, j, 1] = newMatrix[i - 1, j, 1];
                    }
                }
            }

            return newMatrix;
        }
    }
}
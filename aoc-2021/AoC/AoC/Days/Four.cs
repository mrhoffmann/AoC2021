using System.Collections.Generic;
using System.Linq;

namespace AoC.Days
{
    internal class Four : Day
    {
        public override (int Part1, int Part2) Run()
        {
            return (Part1(), Part2());
        }

        private record struct Cell(int Number, bool State);

        public override int Part1()
        {
            (List<Cell[,]> boards, int[] numbers) = ParseInput(Helpers.GetStringInput($@"{GetType().Name}\{System.Reflection.MethodBase.GetCurrentMethod().Name}"));

            foreach (int number in numbers)
            {
                foreach (var board in boards)
                {
                    for (int r = 0; r < 5; ++r)
                    {
                        for (int c = 0; c < 5; ++c)
                        {
                            if (board[c, r].Number == number)
                                board[c, r].State = true;

                            if (IsState(board))
                            {
                                return GetScore(board, number);
                            }
                        }
                    }
                }
            }
            return 0;
        }

        public override int Part2()
        {
            (List<Cell[,]> boards, int[] numbers) = ParseInput(Helpers.GetStringInput($@"{GetType().Name}\{System.Reflection.MethodBase.GetCurrentMethod().Name}"));
            List<(Cell[,] Board, int Score)> winningBoards = new();

            foreach (int number in numbers)
            {
                foreach (var board in boards)
                {
                    for (int r = 0; r < 5; ++r)
                    {
                        for (int c = 0; c < 5; ++c)
                        {
                            if (board[c, r].Number == number)
                                board[c, r].State = true;

                            if (IsState(board))
                            {
                                int score = GetScore(board, number);
                                if (winningBoards.All(x => x.Board != board))
                                    winningBoards.Add((board, score));
                            }
                        }
                    }
                }
            }

            int result = winningBoards.Last().Score;
            return result;
        }

        private (List<Cell[,]> Boards, int[] Number) ParseInput(string[] input)
        {
            int[] numbers = input[0].Split(',').Select(x => int.Parse(x)).ToArray();
            List<Cell[,]> boards = new();
            int row = 0;

            for (int i = 1; i < input.Length; ++i)
            {
                string line = input[i];

                if (line == "")
                {
                    boards.Add(new Cell[5, 5]);
                    row = 0;
                }
                else
                {
                    int[] cols = line.Split(' ').Where(x => x.Length > 0).Select(x => int.Parse(x)).ToArray();
                    Cell[,] board = boards.Last();
                    for (int c = 0; c < cols.Length; ++c)
                        board[c, row] = new Cell(cols[c], false);
                    row++;
                }
            }

            return (boards, numbers);
        }

        private static int GetScore(Cell[,] board, int number)
        {
            int unmarkedSum = 0;
            for (int r = 0; r < 5; ++r)
                for (int c = 0; c < 5; ++c)
                    if (!board[c, r].State)
                        unmarkedSum += board[c, r].Number;
            return unmarkedSum * number;
        }

        private static bool IsState(Cell[,] board)
        {
            for (int r = 0; r < 5; ++r)
            {
                int StatesInRow = 0;
                int StatesInCol = 0;
                for (int c = 0; c < 5; ++c)
                {
                    if (board[c, r].State)
                        StatesInRow++;
                    if (board[r, c].State)
                        StatesInCol++;
                }

                if (StatesInRow == 5 || StatesInCol == 5)
                    return true;
            }

            return false;
        }
    }
}

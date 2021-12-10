using System.Collections.Generic;
using System.Linq;

namespace AoC.Days
{
    internal class Four : Day
    {
        private record struct Cell(int Number, bool State);

        public override long Part1()
        {
            var (boards, numbers) = ParseInput(Part1Input);

            foreach (var number in numbers)
                foreach (var board in boards)
                    for (var r = 0; r < 5; ++r)
                        for (var c = 0; c < 5; ++c)
                        {
                            if (board[c, r].Number == number)
                                board[c, r].State = true;

                            if (IsState(board))
                                return GetScore(board, number);
                        }
            return -404;
        }

        public override long Part2()
        {
            var (boards, numbers) = ParseInput(Part2Input);
            List<(Cell[,] Board, int Score)> winningBoards = new();

            foreach (var number in numbers)
                foreach (var board in boards)
                    for (var r = 0; r < 5; ++r)
                        for (var c = 0; c < 5; ++c)
                        {
                            if (board[c, r].Number == number)
                                board[c, r].State = true;

                            if (!IsState(board)) continue;
                            var score = GetScore(board, number);
                            if (winningBoards.All(x => x.Board != board))
                                winningBoards.Add((board, score));
                        }

            var result = winningBoards.Last().Score;
            return result;
        }

        private (List<Cell[,]> Boards, int[] Number) ParseInput(IReadOnlyList<string> input)
        {
            var numbers = input[0].Split(',').Select(int.Parse).ToArray();
            List<Cell[,]> boards = new();
            var row = 0;

            for (var i = 1; i < input.Count; ++i)
            {
                var line = input[i];

                if (line == "")
                {
                    boards.Add(new Cell[5, 5]);
                    row = 0;
                }
                else
                {
                    var cols = line.Split(' ').Where(x => x.Length > 0).Select(int.Parse).ToArray();
                    var board = boards.Last();
                    for (var c = 0; c < cols.Length; ++c)
                        board[c, row] = new Cell(cols[c], false);
                    row++;
                }
            }
            return (boards, numbers);
        }

        private static int GetScore(Cell[,] board, int number)
        {
            var unmarkedSum = 0;
            for (var r = 0; r < 5; ++r)
                for (var c = 0; c < 5; ++c)
                    if (!board[c, r].State)
                        unmarkedSum += board[c, r].Number;
            return unmarkedSum * number;
        }

        private static bool IsState(Cell[,] board)
        {
            for (var r = 0; r < 5; ++r)
            {
                var statesInRow = 0;
                var statesInCol = 0;
                for (var c = 0; c < 5; ++c)
                {
                    if (board[c, r].State)
                        statesInRow++;
                    if (board[r, c].State)
                        statesInCol++;
                }

                if (statesInRow == 5 || statesInCol == 5)
                    return true;
            }

            return false;
        }
    }
}

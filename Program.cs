using System;

class Program
{
    static int Main(string[] args)
    {
        if (args.Length != 1)
            return print_help(1);
        uint size;
        if (!uint.TryParse(args[0], out size))
            return print_help(1);
        bool[,] board = init_board(size);
        int solutions = solve_nqueen(board, size, 0);
        Console.WriteLine($"Number of solutions for a board of size {size}: {solutions}");
        return 0;
    }

    static int print_help(int status)
    {
        Console.WriteLine("USAGE:");
        Console.WriteLine($"\tdotnet run BOARD_SIZE");
        Console.WriteLine();
        Console.WriteLine("DESCRIPTION:");
        Console.WriteLine("\tBOARD_SIZE\tis the size of the board, and also the number of queen to place");
        return status;
    }

    static bool[,] init_board(uint size)
    {
        bool[,] board;

        board = new bool[size, size];
        for (int i = 0; i < size; i++)
            for (int j = 0; j < size; j++)
                board[i, j] = false;
        return board;
    }

    static int solve_nqueen(bool[,] board, uint size, int actual_row)
    {
        if (actual_row == size)
            return 1;
        int solutions = 0;
        for (int i = 0; i < size; i++)
        {
            if (is_safe(board, size, actual_row, i))
            {
                board[actual_row, i] = true;
                solutions += solve_nqueen(board, size, actual_row + 1);
                board[actual_row, i] = false;
            }
        }
        return solutions;
    }

    static bool is_safe(bool[,] board, uint size, int x, int y)
    {
        for (int i = 0; i < size; i++)
            if (x - i >= 0 && y - i >= 0 && board[x - i, y - i] ||
                x + i < size && y - i >= 0 && board[x + i, y - i] ||
                x + i < size && y + i < size && board[x + i, y + i] ||
                x - i >= 0 && y + i < size && board[x - i, y + i] ||
                x - i >= 0 && board[x - i, y] ||
                x + i < size && board[x + i, y] ||
                y - i >= 0 && board[x, y - i] ||
                y + i < size && board[x, y + i])
                return false;
        return true;
    }
}

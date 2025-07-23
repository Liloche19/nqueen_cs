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
        int[,] board = init_board(size);
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

    static int[,] init_board(uint size)
    {
        int[,] board;

        board = new int[size, size];
        for (int i = 0; i < size; i++)
            for (int j = 0; j < size; j++)
                board[i, j] = 0;
        return board;
    }
}

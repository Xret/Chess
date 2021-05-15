using System;
using System.Collections.Generic;
namespace Chess
{

    class pair<T, M>
    {
        public T First;
        public M Second;

        public pair(T first, M second)
        {
            this.First = first;
            this.Second = second;
        }
    }
    class figure
    {
        public string figure_name;
        public pair<int, int> position;
        public string figure_color;
        public figure()
        {
            this.figure_name = " ";
            this.figure_color = "empty_color";
        }
        public figure(string name, string color, int pos_x, int pos_y)
        {
            this.position = new pair<int, int>(pos_x, pos_y);
            this.figure_name = name;
            this.figure_color = color;
        }
        public static void swap(ref figure first_figure, ref figure second_figure)
        {
            var tmp = first_figure;
            first_figure = second_figure;
            second_figure = tmp;
        }
    }
    class board
    {
        private const int size = 8;

        private figure[,] _board;

        private List<figure> felled_white_figures;

        private List<figure> felled_black_figures;
        private List<figure> felled_figures;

        public board()
        {
            this.felled_black_figures = new List<figure>();
            this.felled_white_figures = new List<figure>();
            this._board = new figure[size, size];
            for (int i = 0; i < size; i++)
            {
                if (i == 1)
                    for (int j = 0; j < size; j++)
                        _board[i, j] = new figure("p", "black", i, j);
                else if (i == 6)
                    for (int j = 0; j < size; j++)
                        _board[i, j] = new figure("p", "white", i, j);
                else if (i == 0)
                    for (int j = 0; j < size; j++)
                    {
                        if (j == 0 || j == size - 1)
                            _board[i, j] = new figure("r", "black", i, j);
                        else if (j == 1 || j == size - 2)
                            _board[i, j] = new figure("h", "black", i, j);
                        else if (j == 2 || j == size - 3)
                            _board[i, j] = new figure("e", "black", i, j);
                        else if (j == 3)
                            _board[i, j] = new figure("Q", "black", i, j);
                        else if (j == 4)
                            _board[i, j] = new figure("K", "black", i, j);
                    }
                else if (i == size - 1)
                    for (int j = 0; j < size; j++)
                    {
                        if (j == 0 || j == size - 1)
                            _board[i, j] = new figure("r", "white", i, j);
                        else if (j == 1 || j == size - 2)
                            _board[i, j] = new figure("h", "white", i, j);
                        else if (j == 2 || j == size - 3)
                            _board[i, j] = new figure("e", "white", i, j);
                        else if (j == 3)
                            _board[i, j] = new figure("Q", "white", i, j);
                        else if (j == 4)
                            _board[i, j] = new figure("K", "white", i, j);
                    }
                else
                    for (int j = 0; j < size; j++)
                        _board[i, j] = new figure();
            }
        }
        public bool move_checker(pair<int, int> figure_position, pair<int, int> where_to_move)
        {
            bool is_some_errors = false;
            if (_board[figure_position.First, figure_position.Second].figure_color == "white")
            {
                switch (_board[figure_position.First, figure_position.Second].figure_name)
                {
                    case "p":
                        if (where_to_move.Second == figure_position.Second && figure_position.First - where_to_move.First == 1)
                        {
                            if (_board[where_to_move.First, where_to_move.Second].figure_color == "empty_color")
                                figure.swap(ref _board[figure_position.First, figure_position.Second], ref _board[where_to_move.First, where_to_move.Second]);
                            else
                                is_some_errors = true;
                        }
                        else if (figure_position.First - where_to_move.First == 1 && Math.Abs(where_to_move.Second - figure_position.Second) == 1)
                        {
                            if (_board[where_to_move.First, where_to_move.Second].figure_color == "black")
                            {
                                felled_black_figures.Add(_board[where_to_move.First, where_to_move.Second]);
                                _board[where_to_move.First, where_to_move.Second] = _board[figure_position.First, figure_position.Second];
                                _board[figure_position.First, figure_position.Second] = new figure();
                            }
                            else
                                is_some_errors = true;
                            int i = 0;

                        }
                        else
                            is_some_errors = true;

                        if (_board[figure_position.First, figure_position.Second].figure_color == "white")
                            i = 1;
                        else if (_board[figure_position.First, figure_position.Second].figure_color == "black")
                            i = -1;

                        break;
                }
            }
            else if (_board[figure_position.First, figure_position.Second].figure_color == "black")
                switch (_board[figure_position.First, figure_position.Second].figure_name)
                {
                switch (_board[figure_position.First, figure_position.Second].figure_name)
            {
                case "p":
                    if (where_to_move.Second == figure_position.Second && figure_position.First - where_to_move.First == -1)
                    {
                        if (_board[where_to_move.First, where_to_move.Second].figure_color == "empty_color")
                            figure.swap(ref _board[figure_position.First, figure_position.Second], ref _board[where_to_move.First, where_to_move.Second]);
                        else
                            is_some_errors = true;
                    }
                    else if (figure_position.First - where_to_move.First == -1 && Math.Abs(where_to_move.Second - figure_position.Second) == -1)
                case "p":
                    if (where_to_move.Second == figure_position.Second && figure_position.First - where_to_move.First == 1 * i)
                    {
                        if (_board[where_to_move.First, where_to_move.Second].figure_color == "empty_color")
                            figure.swap(ref _board[figure_position.First, figure_position.Second], ref _board[where_to_move.First, where_to_move.Second]);
                        else
                            is_some_errors = true;
                    }
                    else if (figure_position.First - where_to_move.First == 1 * i && Math.Abs(where_to_move.Second - figure_position.Second) == 1 * i)
                    {
                        if (_board[where_to_move.First, where_to_move.Second].figure_color == "black")
                        {
                            if (_board[where_to_move.First, where_to_move.Second].figure_color == "white")
                            {
                                felled_white_figures.Add(_board[where_to_move.First, where_to_move.Second]);
                                _board[where_to_move.First, where_to_move.Second] = _board[figure_position.First, figure_position.Second];
                                _board[figure_position.First, figure_position.Second] = new figure();
                            }
                            else
                                is_some_errors = true;


                            felled_figures.Add(_board[where_to_move.First, where_to_move.Second]);
                            _board[where_to_move.First, where_to_move.Second] = _board[figure_position.First, figure_position.Second];
                            _board[figure_position.First, figure_position.Second] = new figure();
                        }
                        else
                            is_some_errors = true;

                    }
                    else
                        is_some_errors = true;
                    break;
            }

            break;
        }

    }
            else
            {
                return false;
            }
return is_some_errors;
        }




        public void print_board()
{
    Console.Write("   ");
    for (int i = 0; i < size; i++)
        Console.Write(i + 1);
    Console.WriteLine();
    for (int i = 0; i < size; i++)
    {
        Console.Write((i + 1) + "  ");
        if (i % 2 == 0)
        {
            for (int j = 0; j < size; j++)
            {

                if (j % 2 == 0)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    if (_board[i, j].figure_color == "white")
                        Console.ForegroundColor = ConsoleColor.Red;
                    else
                        Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(_board[i, j].figure_name);
                    Console.ResetColor();
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    if (_board[i, j].figure_color == "white")
                        Console.ForegroundColor = ConsoleColor.Red;
                    else
                        Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(_board[i, j].figure_name);
                    Console.ResetColor();
                }
            }
            Console.WriteLine();
        }
        else
        {
            for (int j = 0; j < size; j++)
            {
                if (j % 2 == 1)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    if (_board[i, j].figure_color == "white")
                        Console.ForegroundColor = ConsoleColor.Red;
                    else
                        Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(_board[i, j].figure_name);
                    Console.ResetColor();
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    if (_board[i, j].figure_color == "white")
                        Console.ForegroundColor = ConsoleColor.Red;
                    else
                        Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(_board[i, j].figure_name);
                    Console.ResetColor();
                }
            }
            Console.WriteLine();
        }
    }
}
    }
    class Program
{

    static void Main(string[] args)
    {
        board bd = new board();
        {
            int j = 0;
            while (true)
            {
                bd.print_board();
                Console.WriteLine("\nЕсли хотите выйти из игры введите стоку <<exit>> ");
                if (j % 2 == 0)
                    Console.WriteLine("\nХОД БЕЛЫХ\n");
                else
                    Console.WriteLine("\nХОД ЧЁРНЫХ\n");
                Console.WriteLine("Введите координаты фигуры(через пробел): ");
                string figure_position = Console.ReadLine();
                Console.WriteLine("Введите координату куда фигура должна переместиться(через пробел)");
                string where_to_move = Console.ReadLine();
                if (figure_position == "exit")
                    break;
                var numbers = figure_position.Split(" ");
                var move_numbers = where_to_move.Split(" ");
                var pair = new pair<int, int>(Convert.ToInt32(numbers[0]) - 1, Convert.ToInt32(numbers[1]) - 1);
                var move_pair = new pair<int, int>(Convert.ToInt32(move_numbers[0]) - 1, Convert.ToInt32(move_numbers[1]) - 1);

                bd.move_checker(pair, move_pair);

                Console.Clear();
                j++;
            }
        }
    }
}
}

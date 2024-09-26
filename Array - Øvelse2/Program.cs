using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array___Øvelse2
{
    internal class Program
    {
        static void Log(Object input)
        {
            Console.Write(input);
        }
        static void Log(Object input, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(input);
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void Color(ConsoleColor c)
        {
            Console.ForegroundColor = c;
        }
        static void BackColor(ConsoleColor c)
        {
            Console.BackgroundColor = c;
        }
        static Pieces GetChessPiece(string setup, int index, bool isPlayerPieces)
        {
            Pieces value = Pieces.None;
            char piece = setup.ToUpper()[index];
            switch (piece)
            {
                case 'T':
                    value = (isPlayerPieces) ? Pieces.WhiteTower : Pieces.BlackTower;
                    break;
                case 'H':
                    value = (isPlayerPieces) ? Pieces.WhiteHorse : Pieces.BlackHorse;
                    break;
                case 'B':
                    value = (isPlayerPieces) ? Pieces.WhiteBishop : Pieces.BlackBishop;
                    break;
                case 'Q':
                    value = (isPlayerPieces) ? Pieces.WhiteQueen : Pieces.BlackQueen;
                    break;
                case 'K':
                    value = (isPlayerPieces) ? Pieces.WhiteKing : Pieces.BlackKing;
                    break;
                case 'R':
                    value = (isPlayerPieces) ? Pieces.WhiteRook : Pieces.BlackRook;
                    break;
                case ' ':
                    value = Pieces.None;
                    break;
                default:
                    value = Pieces.None;
                    break;
            }

            return value;
        }
        static byte[,] PopulateBoard(byte[,] board)
        {
            int boardDepth = board.Length / board.GetLength(0);
            string setup1 = "THBQKBHT";
            string setup2 = "RRRRRRRR";
            string setup3 = "        ";
            for (int depth = 0; depth < boardDepth; depth++)
            {
                switch (depth)
                {
                    case 0:
                        for (int i = 0; i < setup1.Length; i++)
                        {
                            board[depth, i] = (byte)GetChessPiece(setup1, i, false);
                        }
                        break;
                    case 1:
                        for (int i = 0; i < setup2.Length; i++)
                        {
                            board[depth, i] = (byte)GetChessPiece(setup2, i, false);
                        }
                        break;
                    case 6:
                        for (int i = 0; i < setup2.Length; i++)
                        {
                            board[depth, i] = (byte)GetChessPiece(setup2, i, true);
                        }
                        break;
                    case 7:
                        for (int i = 0; i < setup1.Length; i++)
                        {
                            board[depth, i] = (byte)GetChessPiece(setup1, i, true);
                        }
                        break;
                    default:
                        for (int i = 0; i < setup1.Length; i++)
                        {
                            board[depth, i] = (byte)GetChessPiece(setup3, i, false);
                        }
                        break;
                }
            }
            return board;
        }
        static void DrawBoard(byte[,] board)
        {
            int boardDepth = board.Length / board.GetLength(0);
            Pieces character = Pieces.None;
            string characterAsci = " KQBTHRKQBTHR";
            string[] boardCords = { 
                "ABCDEFGH",
                "87654321"
            };
            for (int i=0; i<boardDepth; i++)
            {
                for (int j=0; j < boardDepth; j++)
                {
                    if (i%2 == 0)
                    {
                        if (j % 2 == 0)
                        {
                            BackColor(ConsoleColor.Black);
                        }
                        else
                        {
                            BackColor(ConsoleColor.White);
                        }
                    } else
                    {
                        if (j % 2 != 0)
                        {
                            BackColor(ConsoleColor.Black);
                        }
                        else
                        {
                            BackColor(ConsoleColor.White);
                        }
                    }
                    character = (Pieces)board[i, j];
                    if ((byte)character > 0 && (byte)character > 6)
                    {
                        Color(ConsoleColor.Red);
                        Log(" " + characterAsci[(byte)character]);
                    } else if ((byte)character > 0 && (byte)character <= 6)
                    {
                        Color(ConsoleColor.Green);
                        Log(" " + characterAsci[(byte)character]);
                    } else
                    {
                        Log("  ");
                    }
                    if (j == boardDepth-1)
                    {
                        BackColor(ConsoleColor.Black);
                        Log(" " + boardCords[1][i], ConsoleColor.Blue);
                    }
                }
                Log("\n");
            }
            BackColor(ConsoleColor.Black);
            for (int i = 0; i < board.GetLength(0); i++)
            {
                Log(" " + boardCords[0][i], ConsoleColor.Blue);
            }
            Log("\n");
        }
        static byte[] InstructionToCordinates(string instruction, out string error)
        {
            byte[] cords = { 50, 50 };
            string[] boardCords = {
                "ABCDEFGH",
                "87654321"
            };
            error = "";
            if (instruction.Length < 3)
            {
                cords[0] = (byte)boardCords[0].IndexOf(instruction[0]);
                cords[1] = (byte)boardCords[1].IndexOf(instruction[1]);
            }
            else
            {
                error = "Instrcution doesn't fit the format!";
            }

            return cords;
        }
        static byte[,] TryMovePiece(byte[,] board, string instructions, out string error)
        {
            bool errorHappened = false;
            byte[,] temp = board;
            error = "";
            string[] arr_instructions = instructions.ToUpper().Split('-');
            byte[] from = InstructionToCordinates(arr_instructions[0], out error);
            byte[] to = InstructionToCordinates(arr_instructions[1], out error);

            byte moovingPiece = board[from[1], from[0]];
            byte fieldToMove = board[to[1], to[0]];

            temp[to[1], to[0]] = moovingPiece;
            temp[from[1], from[0]] = 0;

            if (error != "")
            {
                errorHappened = true;
            }

            return (!errorHappened) ? temp : board;
        }
        static void Main(string[] args)
        {
            string errorMsg = "";
            int boardSize = 8;
            byte[,] board = new byte[boardSize,boardSize];
            bool running = true;
            bool inGame = false;
            string playerInput = "";
            while (running)
            {
                Console.Clear();
                Log("Welcome to Chess!\n", ConsoleColor.Yellow);
                if (errorMsg != "") Log(errorMsg + "\n", ConsoleColor.Red);
                Log("Choose what to do [", ConsoleColor.Yellow);
                Log("Play", ConsoleColor.Green);
                Log(" / ", ConsoleColor.Yellow);
                Log("Quit", ConsoleColor.Red);
                Log("]?: ", ConsoleColor.Yellow);
                playerInput = Console.ReadLine();
                switch (playerInput.ToLower())
                {
                    case "play":
                        board = PopulateBoard(board);
                        inGame = true;
                        break;
                    case "quit":
                        running = false;
                        break;
                    default:
                        errorMsg = "That option doesnt exist!";
                        break;
                }

                while (inGame)
                {
                    Console.Clear();
                    DrawBoard(board);
                    if (errorMsg != "") Log("\n"+errorMsg+"\n", ConsoleColor.Red);
                    Log("You can write Restart or Quit to do each respectively.\n", ConsoleColor.Yellow);
                    Log("What's your move [A2-B3]?: ", ConsoleColor.Yellow);
                    playerInput = Console.ReadLine();
                    if (playerInput != "")
                    {
                        switch (playerInput.ToLower())
                        {
                            case "restart":
                                board = PopulateBoard(board);
                                break;
                            case "quit":
                                inGame = false;
                                break;
                            default:
                                board = TryMovePiece(board, playerInput, out errorMsg);
                                break;
                        }
                    } else
                    {
                        errorMsg = "You need to input an instruction!";
                    }
                }
            }
        }
    }
}

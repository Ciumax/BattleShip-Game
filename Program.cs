using System;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] field = new char[10, 10];
            string[] ships = {"Aircraft Carrier", "Battleship", "Submarine", "Cruiser", "Destroyer"};
            int[] shipsLengths = {5,4,3,3,2};
            int aliveShips = 0;
            field = CreateField();
            ShowField (field);
            for (int i = 0; i < 5; i++) /// testing loop
            {
                Console.WriteLine("Enter coordinates of ship:  (eg. F3 F7)");
                string coordinates = Console.ReadLine();
                int[] numberCoordinates = CheckCoordinates(coordinates);
                field = SetShip(field, numberCoordinates, shipsLengths[i]);
                aliveShips = CountAliveShips(field);
                ShowField(field);

            }
        }

        static char[,] CreateField()
        {
            char[,] Field = new char[10, 10];
            for (int i = 0; i < Field.GetLength(0); i++)
            {
                for (int j = 0; j < Field.GetLength(1); j++)
                {
                    Field[i, j] = '=';
                }
            }
            return Field;
        }

        static void ShowField(char[,] Field)
        {
            char letter = 'A';
            Console.WriteLine("  1 2 3 4 5 6 7 8 9 10");
            for (int i = 0; i < Field.GetLength(0); i++)
            {
                Console.Write(letter + " ");
                for (int j = 0; j < Field.GetLength(1); j++)
                {
                    Console.Write(Field[i, j] + " ");
                }
                letter++;
                Console.WriteLine();
            }
        }

        static int[] CheckCoordinates(string coords)
        {
            string[] halfCoords = coords.Split(" ");
            int[] numberCoords = new int[4];
            switch(halfCoords[0].Substring(0,1))
            {
                case "A": numberCoords[0] = 0; break;
                case "B": numberCoords[0] = 1; break;
                case "C": numberCoords[0] = 2; break;
                case "D": numberCoords[0] = 3; break;
                case "E": numberCoords[0] = 4; break;
                case "F": numberCoords[0] = 5; break;
                case "G": numberCoords[0] = 6; break;
                case "H": numberCoords[0] = 7; break;
                case "I": numberCoords[0] = 8; break;
                case "J": numberCoords[0] = 9; break;
            }
            switch(halfCoords[1].Substring(0,1))
            {
                case "A": numberCoords[2] = 0; break;
                case "B": numberCoords[2] = 1; break;
                case "C": numberCoords[2] = 2; break;
                case "D": numberCoords[2] = 3; break;
                case "E": numberCoords[2] = 4; break;
                case "F": numberCoords[2] = 5; break;
                case "G": numberCoords[2] = 6; break;
                case "H": numberCoords[2] = 7; break;
                case "I": numberCoords[2] = 8; break;
                case "J": numberCoords[2] = 9; break;
            }
            numberCoords[1] = (Int32.Parse(halfCoords[0].Substring(1)) -1);
            numberCoords[3] = (Int32.Parse(halfCoords[1].Substring(1)) -1);
            return numberCoords;
        }

        static char[,] SetShip(char[,] field, int[] coords, int length)
        {
            if (coords[0] == coords[2])
            {
                if (coords[1] - coords[3] == length - 1 || coords[3] - coords[1] == length - 1)
                {
                    for (int j = coords[1]; j <= coords[3]; j++)
                    {
                        field[coords[0], j] = 'O';
                    }
                }
            }
            if (coords[1] == coords[3])
            {
                if (coords[0] - coords[2] == length - 1 || coords[2] - coords[0] == length - 1)
                {
                    for (int j = coords[0]; j <= coords[2]; j++)
                    {
                        field[j, coords[1]] = 'O';
                    }
                }
            }
            return field;
        }
        static int CountAliveShips(char[,] field)
        {
            int aliveShips = 0;
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    if(field[i, j] == 'O')
                    {
                        aliveShips++;
                    }
                }
            }
            return aliveShips;
        }
    }
}

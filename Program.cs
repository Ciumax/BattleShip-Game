using System;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] Field = new char[10, 10];
            Field = CreateField();
            ShowField (Field);
            Console.WriteLine("Enter coordinates of ship:");
            string coordinates = Console.ReadLine();
            int[] numberCoordinates = CheckCoordinates(coordinates);
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
    }
}

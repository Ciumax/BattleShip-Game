using System;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] playerOneField = new char[10, 10];
            char[,] playerTwoField = new char[10, 10];
            char[,] playerOneVisibleField = new char[10, 10];
            char[,] playerTwoVisibleField = new char[10, 10];
            string[] ships = { "Aircraft Carrier", "Battleship", "Submarine", "Cruiser", "Destroyer" };
            int[] shipsLengths = { 5, 4, 3, 3, 2 };
            int playerOneAliveShips = 0;
            int playerTwoAliveShips = 0;
            playerOneField = CreateField();
            playerTwoField = CreateField();
            playerOneVisibleField = CreateField();
            playerTwoVisibleField = CreateField();
            Console.WriteLine("Welcome to this BattleShips Game! Set up ships for both players and start shooting!\r\nIf you ever want to leave type 'exit' (without quotes).");
            for (int i = 0; i < 5;)
            {
                try
                {
                    Console.WriteLine($"Player One! {ships[i]} length is {shipsLengths[i]}. Enter coordinates of ship:  (eg. F3 F7)");
                    string coordinates = Console.ReadLine();
                    if (coordinates == "exit")
                    {
                        break;
                    }
                    int[] numberCoordinates = CheckCoordinates(coordinates);
                    if (CheckSpace(playerOneField, numberCoordinates, shipsLengths[i]))
                    {
                        playerOneField = SetShip(playerOneField, numberCoordinates, shipsLengths[i]);
                        i++;
                        ShowField(playerOneField);
                    }
                    else
                    {
                        ShowField(playerOneField);
                        Console.WriteLine("Wrong place or length, try another coordinates!");
                    }
                }
                catch { continue; }
            }
            for (int i = 0; i < 5;)
            {
                try
                {
                    Console.WriteLine($"Player Two! {ships[i]} length is {shipsLengths[i]}. Enter coordinates of ship:  (eg. F3 F7) ");
                    string coordinates = Console.ReadLine();
                    if (coordinates == "exit")
                    {
                        break;
                    }
                    int[] numberCoordinates = CheckCoordinates(coordinates);
                    if (CheckSpace(playerTwoField, numberCoordinates, shipsLengths[i]))
                    {
                        playerTwoField = SetShip(playerTwoField, numberCoordinates, shipsLengths[i]);
                        i++;
                        ShowField(playerTwoField);
                    }
                    else
                    {
                        ShowField(playerTwoField);
                        Console.WriteLine("Wrong place or length, try another coordinates!");
                    }
                }
                catch { continue; }
            }

            playerOneAliveShips = CountAliveShips(playerOneField);
            playerTwoAliveShips = CountAliveShips(playerTwoField);

            while (playerOneAliveShips != 0 || playerTwoAliveShips != 0)
            {
                try
                {
                    Console.WriteLine("Player One! Take the shoot! (eg F3)");
                    string shootCoordinates = Console.ReadLine();
                    if (shootCoordinates == "exit")
                    {
                        break;
                    }
                    ShowField(playerTwoVisibleField);
                    if (CheckShoot(shootCoordinates))
                    {
                        TakeTheShoot(playerTwoField, shootCoordinates);
                        RewriteFields(playerTwoField, playerTwoVisibleField);
                        ShowField(playerTwoVisibleField);
                        playerTwoAliveShips = CountAliveShips(playerTwoField);
                    }
                    else
                    {
                        Console.WriteLine("You missed the field. No second try!");
                    }

                    if (playerTwoAliveShips == 0)
                    {

                        Console.WriteLine("PLAYER ONE WINS!!!!");
                        break;
                    }
                    Console.WriteLine("Player Two! Take the shoot! (eg F3)");
                    shootCoordinates = Console.ReadLine();
                    if (shootCoordinates == "exit")
                    {
                        break;
                    }
                    ShowField(playerOneVisibleField);
                    if (CheckShoot(shootCoordinates))
                    {
                        TakeTheShoot(playerOneField, shootCoordinates);
                        RewriteFields(playerOneField, playerOneVisibleField);
                        ShowField(playerOneVisibleField);
                        playerOneAliveShips = CountAliveShips(playerOneField);
                    }
                    else
                    {
                        Console.WriteLine("You missed the field. No second try!");
                    }
                    if (playerOneAliveShips == 0)
                    {
                        Console.WriteLine("PLAYER TWO WINS!!!!");
                        break;
                    }
                }
                catch { continue; }
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
            coords = coords.ToUpper();
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
                for (int i = coords[0]; i <= coords[2]; i++)
                {
                    for (int j = coords[1]; j <= coords[3]; j++)
                    {
                        field[i, j] = 'O';
                    }
                }
            }
            if (coords[1] == coords[3])
            {
                for (int i = coords[0]; i <= coords[2]; i++)
                {
                    for (int j = coords[1]; j <= coords[3]; j++)
                    {
                        field[i, j] = 'O';
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
                    if (field[i, j] == 'O')
                    {
                        aliveShips++;
                    }
                }
            }
            return aliveShips;
        }
        static bool CheckSpace(char[,] field, int[] coords, int length)
        {
            if (coords[0] == coords[2])
            {
                if (coords[1] - coords[3] == length - 1 || coords[3] - coords[1] == length - 1)
                {
                    for (int i = coords[0] - 1; i <= coords[2] + 1; i++)
                    {
                        for (int j = coords[1] - 1; j <= coords[3] + 1; j++)
                        {
                            if (i <= 9 && i >= 0 && j <= 9 && j >= 0)
                            {
                                if (field[i, j] == 'O')
                                {
                                    return false;
                                }
                            }
                            else continue;
                        }
                    }
                }
                else
                {
                    return false;
                }
            }
            if (coords[1] == coords[3])
            {
                if (coords[0] - coords[2] == length - 1 || coords[2] - coords[0] == length - 1)
                {
                    for (int i = coords[0] - 1; i <= coords[2] + 1; i++)
                    {
                        for (int j = coords[1] - 1; j <= coords[3] + 1; j++)
                        {

                            if (i <= 9 && i >= 0 && j <= 9 && j >= 0)
                            {
                                if (field[i, j] == 'O')
                                {
                                    return false;
                                }
                            }
                            else continue;
                        }
                    }
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        static char[,] TakeTheShoot(char[,] field, string target)
        {
            int[] shootCoords = new int[2];
            target = target.ToUpper();
            switch (target.Substring(0, 1))
            {
                case "A": shootCoords[0] = 0; break;
                case "B": shootCoords[0] = 1; break;
                case "C": shootCoords[0] = 2; break;
                case "D": shootCoords[0] = 3; break;
                case "E": shootCoords[0] = 4; break;
                case "F": shootCoords[0] = 5; break;
                case "G": shootCoords[0] = 6; break;
                case "H": shootCoords[0] = 7; break;
                case "I": shootCoords[0] = 8; break;
                case "J": shootCoords[0] = 9; break;
            }
            shootCoords[1] = (Int32.Parse(target.Substring(1)) - 1);
            if (field[shootCoords[0], shootCoords[1]] == 'O')
            {
                field[shootCoords[0], shootCoords[1]] = 'X';
            }
            else
            {
                field[shootCoords[0], shootCoords[1]] = 'M';
            }
            return field;
        }
        static bool CheckShoot(string target)
        {
            int[] shootCoords = new int[2];
            target = target.ToUpper();
            switch (target.Substring(0, 1))
            {
                case "A": shootCoords[0] = 0; break;
                case "B": shootCoords[0] = 1; break;
                case "C": shootCoords[0] = 2; break;
                case "D": shootCoords[0] = 3; break;
                case "E": shootCoords[0] = 4; break;
                case "F": shootCoords[0] = 5; break;
                case "G": shootCoords[0] = 6; break;
                case "H": shootCoords[0] = 7; break;
                case "I": shootCoords[0] = 8; break;
                case "J": shootCoords[0] = 9; break;
            }
            shootCoords[1] = (Int32.Parse(target.Substring(1)) - 1);
            if (shootCoords[0] > 9 || shootCoords[0] < 0 || shootCoords[1] > 9 || shootCoords[1] < 0)
            {
                return false;
            }
            return true;
        }
        static char[,] RewriteFields(char[,] field, char[,] visibleField)
        {
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    if (field[i, j] == 'X')
                    {
                        visibleField[i, j] = 'X';
                    }
                    if (field[i, j] == 'M')
                    {
                        visibleField[i, j] = 'M';
                    }
                }
            }
            return visibleField;
        }
    }
}

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
            for (int i = 0; i < Field.GetLength(0); i++)
            {
                for (int j = 0; j < Field.GetLength(1); j++)
                {
                    Console.Write(Field[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}

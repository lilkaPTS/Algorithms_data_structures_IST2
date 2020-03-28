using System;

namespace qwe.Sorts
{
    class Program
    {
        /*
          * Задача 4. Задается словарь. Найти в нем все анаграммы (слова, составленные из одних и тех же букв).
          */
        static bool Check(char[] arr)
        {
            bool c = true;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[0] == arr[i])
                {
                    continue;
                }
                else
                {
                    c = false;
                    break;
                }
            }
            return c;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите текст: ");
            string Input = Console.ReadLine();
            string[] ArrayOfWords = Input.Split(' ');
            Console.Write("Номера слов анаграмм - ");
            for (int i = 0; i < ArrayOfWords.Length; i++)
            {
                char[] ArrayOfChar = ArrayOfWords[i].ToCharArray();
                for (int j = 0; j < ArrayOfChar.Length; j++)
                {
                    int Length = ArrayOfChar.Length;
                    if (Check(ArrayOfChar) == true)
                    {
                        Console.Write($"{i + 1} ");
                        Array.Clear(ArrayOfChar, 0, Length);
                        break;
                    }
                    else
                    {
                        Array.Clear(ArrayOfChar, 0, Length);
                        break;
                    }
                }
            }
            Console.ReadLine();
        }
    }
}

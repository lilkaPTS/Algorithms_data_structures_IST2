using System;
using System.Collections.Generic;
using System.Linq;

namespace qwe.Sorts

{
    class Program
    {
        /*
          * Задача 4. Задается словарь. Найти в нем все анаграммы (слова, составленные из одних и тех же букв).
          */
        
        static void Main(string[] args)
        {
            Console.WriteLine("Введите текст: ");
            string Input = Console.ReadLine();
            var arrReturn = Input.ToLower().Split(' '); //Массив по которому возвращается значение
            var inputToArr = Input.ToLower().Split(' '); // преобразуем введённую строку в массив, без учёта регистра       
            var listArrChar = new List<char[]>(); // список слов в виде: слово = 'c''л''о''в''о'
            for (int i = 0; i < inputToArr.Length; i++)
            {
                listArrChar.Add(inputToArr[i].ToCharArray());                
            }
            var arrToList = new List<List<char>>();
            for (int i = 0; i < listArrChar.Count; i++)
            {
                var charArr = listArrChar[i];
                var charList = new List<char>();
                for (int j = 0; j < listArrChar[i].Length; j++)
                {
                    charList.Add(listArrChar[i][j]);
                }
                arrToList.Add(charList);
                arrToList[arrToList.Count - 1].Sort();
            }            
            var listArrNumber = new List<List<int>>(); // список хранящий индексы анаграмм
            for (int i = 0; i < arrToList.Count; i++)
            {
                var verifiableWord = arrToList[i]; // берём проверяемое слово
                var list = new List<int>(); // лист индексов
                list.Add(i);
                for (int j = 0; j < arrToList.Count; j++)
                {
                    if (i != j && verifiableWord.SequenceEqual(arrToList[j]) == true)
                    {
                        list.Add(j);
                    }
                }
                list.Sort();
                listArrNumber.Add(list);
            }
            var finalList = new List<string>();
            for (int i = 0; i < listArrNumber.Count; i++)
            {
                string a = "";
                for (int j = 0; j < listArrNumber[i].Count; j++)
                {
                    a += listArrNumber[i][j];
                }
                finalList.Add(a);
            }
            finalList = finalList.Distinct().ToList(); //  Distinct() возвращает различающиеся элементы последовательности в виде IEnumerable<T>
            for (int i = 0; i < finalList.Count(); i++)
            {
                string a = "";
                string b = finalList[i]; // получаем слово
                for (int j = 0; j < b.Length; j++)
                {
                    int iter = b[j] - '0';
                    a += $"{arrReturn[iter]} ";
                }
                Console.WriteLine($"{i+1}){a}");
            }
            Console.ReadLine();
        }
    }
}

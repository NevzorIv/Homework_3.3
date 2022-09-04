using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Пользователь вводит число с клавиатуры.
// Необходимо найти ближайшее простое число к этому и вывести его в консоль.
namespace Homework_3._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задание 3");
            double chisloDouble;
            chisloDouble = GetNum("");
            GetAnswer(chisloDouble);
            Console.ReadKey();
        }
        static double GetNum(string chislo)
        {
            Console.Write("Введите число: ", chislo);
            string str = string.Empty;
            ConsoleKeyInfo chisloKeyInfo = new ConsoleKeyInfo();
            while (chisloKeyInfo.Key != ConsoleKey.Enter ||
                str == "-" || str.Length == 0)
            {
                chisloKeyInfo = Console.ReadKey(true);
                char chisloChar = chisloKeyInfo.KeyChar;
                if (chisloChar == '.' || chisloChar == ',')
                {
                    chisloChar = System.Globalization.CultureInfo.CurrentCulture.
                        NumberFormat.NumberDecimalSeparator[0];
                }
                if (ChisloForNum(str + chisloChar))
                {
                    Console.Write(chisloChar);
                    str += chisloChar;
                }
                if (chisloKeyInfo.Key == ConsoleKey.Backspace && str.Length > 0)
                {
                    Console.Write("\b \b");
                    str = str.Remove(str.Length - 1);
                }
            }
            Console.WriteLine();
            return double.Parse(str);
        }
        static bool ChisloForNum(string st)
        {
            if (st.Contains('\0'))
            {
                return false;
            }
            if (double.TryParse(st, out double num))
            {
                return true;
            }
            if (st == "-")
            {
                return true;
            }
            return false;
        }
        static void GetAnswer(double chisloDouble)
        {
            int kol = 0;
            while (chisloDouble * Math.Pow(10, 1 + kol) % 10 != 0) 
            { 
                kol++; 
            }
            kol = kol--;
            if (kol == 0)
            {
                Console.WriteLine($"Ближайшее большее значение: {chisloDouble + 1}");
                Console.WriteLine($"Ближайшее меньшее значение: {chisloDouble - 1}");
            }
            if (kol > 0)
            {
                for (int i = 0; i < kol; i++)
                {
                    chisloDouble *= 10;
                }
                double chisloDoubleMax = chisloDouble + 1;
                double chisloDoubleMin = chisloDouble - 1;
                for (int i = kol; i !=0; i--)
                {
                    chisloDoubleMax /= 10;
                    chisloDoubleMin /= 10;
                }
                //Console.WriteLine("У числа {0} {1} знаков после запятой.", chisloDouble, kol--);
                //Console.WriteLine(chisloDouble);
                Console.WriteLine($"Ближайшее большее значение: {chisloDoubleMax}");
                Console.WriteLine($"Ближайшее меньшее значение: {chisloDoubleMin}");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestProject7

{
    public class Lab1
    {
        // 1.1. Сортировка массива целых чисел (быстрая сортировка)
        public static int[] SortArray(int[] array)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            if (array.Length == 0)
                return array;

            int[] sortedArray = (int[])array.Clone();
            QuickSort(sortedArray, 0, sortedArray.Length - 1);
            return sortedArray;
        }

        private static void QuickSort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = Partition(array, left, right);
                QuickSort(array, left, pivotIndex - 1);
                QuickSort(array, pivotIndex + 1, right);
            }
        }

        private static int Partition(int[] array, int left, int right)
        {
            int pivot = array[right];
            int i = left - 1;

            for (int j = left; j < right; j++)
            {
                if (array[j] <= pivot)
                {
                    i++;
                    Swap(array, i, j);
                }
            }

            Swap(array, i + 1, right);
            return i + 1;
        }

        private static void Swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        // 1.2. Проверка является ли строка палиндромом
        public static bool IsPalindrome(string input)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));

            if (input.Length == 0)
                return true;

            string cleaned = new string(input.Where(char.IsLetterOrDigit).ToArray()).ToLower();

            if (cleaned.Length == 0)
                return true;

            int left = 0;
            int right = cleaned.Length - 1;

            while (left < right)
            {
                if (cleaned[left] != cleaned[right])
                    return false;

                left++;
                right--;
            }

            return true;
        }

        // 1.3. Вычисление факториала для целого числа
        public static long Factorial(int n)
        {
            if (n < 0)
                throw new ArgumentException("Факториал определен только для неотрицательных чисел");

            if (n > 20) // Для n > 20 результат превышает long.MaxValue
                throw new ArgumentException("Слишком большое число для вычисления факториала");

            long result = 1;
            for (int i = 2; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }

        // 1.4. Число Фибоначчи на указанной позиции
        public static long Fibonacci(int position)
        {
            if (position < 0)
                throw new ArgumentException("Позиция должна быть неотрицательной");

            if (position > 92) // Для position > 92 результат превышает long.MaxValue
                throw new ArgumentException("Слишком большая позиция для вычисления числа Фибоначчи");

            if (position == 0) return 0;
            if (position == 1) return 1;

            long prev = 0;
            long current = 1;

            for (int i = 2; i <= position; i++)
            {
                long next = prev + current;
                prev = current;
                current = next;
            }

            return current;
        }

        // 1.5. Поиск подстроки в строке
        public static int FindSubstring(string text, string substring)
        {
            if (text == null)
                throw new ArgumentNullException(nameof(text));

            if (substring == null)
                throw new ArgumentNullException(nameof(substring));

            if (substring.Length == 0)
                return 0;

            if (substring.Length > text.Length)
                return -1;

            for (int i = 0; i <= text.Length - substring.Length; i++)
            {
                bool found = true;
                for (int j = 0; j < substring.Length; j++)
                {
                    if (text[i + j] != substring[j])
                    {
                        found = false;
                        break;
                    }
                }
                if (found)
                    return i;
            }

            return -1;
        }

        // 1.6. Проверка является ли число простым
        public static bool IsPrime(int number)
        {
            if (number < 2)
                return false;

            if (number == 2)
                return true;

            if (number % 2 == 0)
                return false;

            int boundary = (int)Math.Sqrt(number);

            for (int i = 3; i <= boundary; i += 2)
            {
                if (number % i == 0)
                    return false;
            }

            return true;
        }

        // 1.7. Реверс цифр в числе с проверкой переполнения
        public static int ReverseNumber(int x)
        {
            int reversed = 0;
            int sign = Math.Sign(x);
            x = Math.Abs(x);

            while (x > 0)
            {
                int digit = x % 10;
                x /= 10;

                // Проверка на переполнение перед умножением
                if (reversed > (int.MaxValue - digit) / 10)
                    return 0;

                reversed = reversed * 10 + digit;
            }

            return sign * reversed;
        }

        // 1.8. Конвертация числа в римскую систему счисления
        public static string ToRomanNumeral(int number)
        {
            if (number < 1 || number > 3999)
                throw new ArgumentOutOfRangeException(nameof(number), "Число должно быть в диапазоне от 1 до 3999");

            var romanNumerals = new Dictionary<int, string>
        {
            {1000, "M"},
            {900, "CM"},
            {500, "D"},
            {400, "CD"},
            {100, "C"},
            {90, "XC"},
            {50, "L"},
            {40, "XL"},
            {10, "X"},
            {9, "IX"},
            {5, "V"},
            {4, "IV"},
            {1, "I"}
        };

            StringBuilder result = new StringBuilder();
            int remaining = number;

            foreach (var numeral in romanNumerals)
            {
                while (remaining >= numeral.Key)
                {
                    result.Append(numeral.Value);
                    remaining -= numeral.Key;
                }
            }

            return result.ToString();
        }
    }
}
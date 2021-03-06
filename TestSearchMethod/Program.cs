﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSearchMethod
{
    class Program
    {

        public static bool LinearSearch(int[] args, int search_value)
        {
            Console.Write("Линейный поиск: ");
            Stopwatch timer = new Stopwatch();
            timer.Start();
            bool flag = false;
            int count = 0;
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == search_value)
                {
                    flag = true;
                    count = i;
                    break;
                }
            }
            timer.Stop();
            TimeSpan time = timer.Elapsed;
            string elapsed_time = String.Format("{0:00}:{1}", time.Seconds, time.TotalMilliseconds);
            if (flag)
            {
                Console.WriteLine("Значение {0} найдено на позиции {1}!\nВремя: {2} ", search_value, count, elapsed_time);
                return flag;
            }
            Console.WriteLine("Значение не найдено! Время: " + elapsed_time);
            return flag;
        }

        public static bool InterpolationSearch(int[] args, int search_value)
        {
            Console.Write("Интерполяционный поиск: ");
            Stopwatch timer = new Stopwatch();
            timer.Start();
            bool flag = false;
            long mid = 0;
            long low_border = 0;
            long high_border = args.Length - 1;
            while ((args[low_border] < search_value) && (args[high_border] > search_value))
            {
                mid = low_border + ((search_value - args[low_border]) * (high_border - low_border)) / (args[high_border] - args[low_border]);

                if (args[mid] < search_value) low_border = mid + 1;
                else if (args[mid] > search_value) high_border = mid - 1;
                else
                {
                    flag = true;
                    break;
                }
            }
            if ((args[low_border] == search_value) || (args[high_border] == search_value)) flag = true;
            timer.Stop();
            TimeSpan time = timer.Elapsed;
            string elapsed_time = String.Format("{0:00}:{1}", time.Seconds, time.TotalMilliseconds);
            if (flag)
            {
                Console.WriteLine("Значение {0} найдено на позиции {1}!\nВремя: {2} ", search_value, mid, elapsed_time);
                return flag;
            }
            Console.WriteLine("Значение не найдено! Время: " + elapsed_time);
            return flag;
        }

        public static bool Binsearch(int[] args, int search_value)
        {
            Console.Write("Бинарный поиск: ");
            Stopwatch timer = new Stopwatch();
            timer.Start();
            int l = 0;
            int r = args.Length;
            int count = 0;
            bool flag = false;

            while (l <= r)
            {
                int mid = l + (r - l) / 2;
                if (args[mid] == search_value) { flag = true; count = mid; break; };
                if (args[mid] < search_value) l = ++mid;
                if (args[mid] > search_value) r = --mid;
            }
            timer.Stop();
            TimeSpan time = timer.Elapsed;
            string elapsed_time = String.Format("{0:00}:{1}", time.Seconds, time.TotalMilliseconds);
            if (flag)
            {
                Console.WriteLine("Значение {0} найдено на позиции {1}!\nВремя: {2} ", search_value, count, elapsed_time);
                return flag;
            }
            Console.WriteLine("Значение не найдено! Время: " + elapsed_time);
            return flag;
        }

        static void Main(string[] args)
        {
            Random rnd = new Random();
            Console.WriteLine("Создание массива...");
            int[] Array = new int[134217700];
            for (int i = 0; i < Array.Length; i++) //134217700
            {
                Array[i] = rnd.Next(0, 99999999);
            }
            Console.WriteLine("Массив создан!");
            Console.WriteLine("Сортировка массива...");
            System.Array.Sort(Array);
            Console.WriteLine("Массив отсортирован");
            Console.WriteLine();
            char ch = 'n';

            while (ch == 'n')
            {
                Console.WriteLine("Выберите метод поиска: ");
                Console.WriteLine("1.Линейный");
                Console.WriteLine("2.Бинарный");
                Console.WriteLine("3.Интерполяционный");
                Console.WriteLine("4.Выход");
                int l = Convert.ToInt32(Console.ReadLine());
                switch (l)
                {
                    case 1:
                        {
                            Console.Clear();
                            Console.WriteLine("1.Лучший вариант:");
                            LinearSearch(Array, Array[0]);
                            Console.WriteLine("2.Худший вариант:");
                            LinearSearch(Array, Array[Array.Length - 1]);
                            Console.WriteLine("3.Средний вариант:");
                            LinearSearch(Array, Array[Array.Length / 2]);
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }
                    case 2:
                        {
                            Console.Clear();
                            Console.WriteLine("1.Лучший вариант: ");
                            Binsearch(Array, Array[Array.Length / 2]);
                            Console.WriteLine("2.Худший вариант: ");
                            Binsearch(Array, Array[0]);
                            Console.WriteLine("3.Средний вариант: ");
                            Binsearch(Array, Array[Array.Length / 16]);
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }
                    case 3:
                        {
                            Console.Clear();
                            Console.WriteLine("1.Лучший вариант: ");
                            InterpolationSearch(Array, Array[Array.Length - 1]);
                            Console.WriteLine("2.Худший вариант: ");
                            InterpolationSearch(Array, Array[Array.Length / 64]);
                            Console.WriteLine("3.Средний вариант: ");
                            InterpolationSearch(Array, Array[Array.Length / 8]);
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }
                    case 4: { ch = 'a'; break; }
                    default: break;

                }

            }
        }
    }
}

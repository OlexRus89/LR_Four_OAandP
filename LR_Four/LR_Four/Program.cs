using System;
using System.IO;

namespace LR_Four
{
    class Program
    {
        static void Main(string[] args)
        {
            // Вариант 27
            /*
                Во входном файле содержится две строки: первая содержит одно целое
                число N (количество чисел во второй строке), вторая строка содержит N
                целых чисел (каждое от -10 в 5 степени до 10 в 5 степени).
                В результате работы программы должен быть сформирован выходной
                файл, который содержит следующие значения:
                1) количество элементов, кратных 10;
                2) произведение элементов, кратных 100;
                3) модифицированный массив, в котором все элементы кратные 5
                заменены на 5, остальные – на x
             */

            int N;
            string FileName;

            Console.Write("Введите целое число N: ");
            N = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите имя ткстового файла (без расширения .txt): ");
            FileName = Console.ReadLine();
            FileName += ".txt";
            Console.WriteLine("Идет создание рандомных чисел...");

            TextWriter save_out = Console.Out;
            var new_out = new StreamWriter(FileName);
            Console.SetOut(new_out);

            Console.WriteLine(N);

            Random r = new Random(DateTime.Now.Millisecond);
            int x = 0;
            for (int i = 0; i < N; i++)
            {
                x = r.Next(-100000,100001);
                Console.Write(x + " ");
            }

            Console.SetOut(save_out); new_out.Close();
            Console.WriteLine("Файл " + FileName + " была создана!");
            Console.WriteLine();
            Console.WriteLine("Идет расчитывания элементов, кратных 10");
            Console.WriteLine("Идет расчитывания произведения элементов, кратных 100");
            Console.WriteLine("Идет расчитывания массива, кратных 5");

            TextWriter save_out1 = Console.Out;
            TextReader save_in = Console.In;
            var new_out1 = new StreamWriter(@"output.txt");
            var new_in = new StreamReader(FileName);
            Console.SetOut(new_out1);
            Console.SetIn(new_in);

            int N1 = Convert.ToInt32(Console.ReadLine());
            String str_all = Console.ReadLine();
            string[] str_elem = str_all.Split(' ');

            int[] mas = new int[N1];
            for (int i = 0; i < N1; i++)
            {
                mas[i] = Convert.ToInt32(str_elem[i]);
            }

            // Количество элементов, кратных 10
            Console.WriteLine("***Количество элементов, кратных 10***");
            int el = 0;
            for (int i = 0; i< N1; i++)
            {
                if (mas[i] % 10 == 0) 
                {
                    el += 1;
                }
            }
            Console.WriteLine(String.Format("{0}", el));

            // Произведение элементов, кратных 100
            Console.WriteLine("***Произведение элементов, кратных 100***");
            double elmn = 1;
            for (int i = 1; i <= N1-1; i++) 
            {
                if (mas[i] % 100 == 0)
                {
                    elmn *= i;
                }
            }
            if (elmn == 1) 
            {
                Console.WriteLine("0");
            }
            else
            {
                Console.WriteLine(String.Format("{0:0}", elmn));
            }

            // Модифицированный массив, в котором все элементы кратные 5 заменены на 5, остальные – на x
            Console.WriteLine("***Модифицированный массив, в котором все элементы кратные 5 заменены на 5, остальные – на x***");
            for (int i = 0; i < N1; i++)
            {
                if (mas[i] % 5 == 0)
                {
                    mas[i] = 5;
                    Console.Write(String.Format("{0} ", mas[i]));
                }
                else
                {
                    Console.Write("X ");
                }
            }

            Console.SetOut(save_out1); new_out1.Close();
            Console.SetIn(save_in); new_in.Close();
            Console.WriteLine();
            Console.WriteLine("Расчеты были завершены!");
            Console.WriteLine("Результаты " + FileName + " и output.txt находятся в @/LR_Four/LR_Four/bin/Debug/netcoreapp3.1");
        }
    }
}

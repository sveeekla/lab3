//Дано число k и целочисленный массив размера n. Поменять местами 
//первую и k-ю серии равных элементов массива. Если серий в массиве 
//меньше k, то вывести массив без изменений.

using System;
using System.Drawing;

namespace lab3
{
    class Class1
    {
       
        static void Main()
        {
            Console.WriteLine("Введите количество эллеметов в массиве(n): ");
            int n = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите k: ");
            int k = Convert.ToInt32(Console.ReadLine());

            int[] arr = new int[n]; ;
            int choice = 0;
            do
            {
                choice = Menu();
                switch (choice)
                {
                    case 1:
                        for (int i = 0; i < n; ++i)
                            arr[i] = Convert.ToInt32(Console.ReadLine());
                        break;
                    case 2:
                        Console.WriteLine("Введите верхнюю границу: ");
                        int a = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Введите нижнюю границу: ");
                        int b = Convert.ToInt32(Console.ReadLine());

                        Random rand = new Random();
                        for (int i = 0; i < n; ++i)
                            arr[i] = rand.Next(a, b);
                        break;
                    default:
                        Console.WriteLine("Ошибка ввода, повторите попытку:");

                        break;
                }
            } while (choice < 1 || choice > 3);
            Console.WriteLine("Исходный массив:");
            print(arr, n);

            int cnt = 0;
            int IndFirsstSer1 = -1;
            int IndLastSer1 = 0;
            int IndFirsstSerK = 0;
            int IndLastSerK = 0;
            bool fl = false;
            for (int i = 1; i < n && cnt <= k; ++i)
                if (arr[i-1] == arr[i])
                {
                    if (!fl)
                    {
                        ++cnt;
                        if (IndFirsstSer1 == -1) IndFirsstSer1 = i - 1;
                        else IndFirsstSerK = i-1;
                        fl = true;
                    }    
                }
                else 
                {
                    if(fl)
                    {
                        if (cnt == 1) IndLastSer1 = i-1;
                        else IndLastSerK = i-1;
                    }
                    fl = false;
                }
            if (IndFirsstSerK > IndLastSerK ) IndLastSerK = n-1;
            if(cnt >= k)
            {
                int j = 0;
                int[] n_arr = new int[n];
                for (int i = 0; i < IndFirsstSer1; ++i)
                    { n_arr[j] = arr[i]; ++j; }
                for(int i = IndFirsstSerK; i <= IndLastSerK; ++i)
                    { n_arr[j] = arr[i]; ++j; }
                for (int i = IndLastSer1+1; i < IndFirsstSerK; ++i)
                    { n_arr[j] = arr[i]; ++j; }
                for(int i = IndFirsstSer1; i <= IndLastSer1; ++i)
                    { n_arr[j] = arr[i]; ++j; }
                for (int i = IndLastSerK+1; i < n; ++i)
                { n_arr[j] = arr[i]; ++j; }
                arr = n_arr;
            }
            Console.WriteLine("Результат: ");
            print(arr, n);
        }
        static int Menu()
        {
            Console.WriteLine("Как заполнить массив:\n1.С клавиатуры\n2.Рандомными числами\n");
            int choice = Convert.ToInt32(Console.ReadLine());
            return choice;
        }
        static void print(int[] arr, int n)
        {
            int count_backslash = (int)(n / 5) + 1;
            int c = 0;
            while (c < count_backslash)
            {
                for (int j = c * 5; j < 5 * (c + 1) && j < n; j++)
                    Console.Write(string.Format("{0, -16}", string.Format("{0:G8}", arr[j])));
                Console.WriteLine();
                c++;
            }
        }
    }
}

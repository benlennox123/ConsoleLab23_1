using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleLab23_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите целое число - ");
            int n = Convert.ToInt32(Console.ReadLine());
            FactorialisSleepAsync(n);
            int F= FactorialisAsync(n).Result;
            Console.WriteLine("Факториал числа {0} равен - {1}", n, F);
            Console.WriteLine();
            Console.WriteLine("Немного подождите...");
            Console.ReadKey();
        }

        static int Factorialis(int n)
        {
            int F=1;
            for (int i = 2; i <= n; i++)
            {
                F = F * i;
            }
            return F;
        }
        static int FactorialisSleep(int n)
        {
            int F = 1;
            int m = n;
            for (int i = 2; i <= n; i++)
            {
                F = F * i;
                m--;
                Thread.Sleep(1000);
                Console.WriteLine("{0} сек", m);
            }
            return F;
        }

        static async Task<int> FactorialisAsync(int n)
        {
            int result = await Task.Run(() => Factorialis(n));
            return result;
        }

        static async void FactorialisSleepAsync(int n)
        {
            int result = await Task.Run(() => FactorialisSleep(n));
            Console.WriteLine("Готово! {0}", result);
        }
    }
}

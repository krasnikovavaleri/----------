using System;
using System.Globalization;

namespace Methods
{
    class Program
    {
        
        static double f(double x)
        {
            return x * x - 4; 
        }

        static double Bisection(double a, double b, double eps)
        {
            double c = 0;
            int Lich = 0;
            if (f(a) * f(b) > 0)
            {
                Console.WriteLine("На цьому інтервалі кореня немає.");
                return double.NaN;
            }

            while (Math.Abs(b - a) > eps)
            {
                c = (a + b) / 2;
                Lich++;

                if (Math.Abs(f(c)) < eps)
                    break;

                if (f(a) * f(c) < 0) b = c;
                else a = c;
            }

            Console.WriteLine($"[МДН] x = {c:F4}, кількість поділів = {Lich}");
            return c;
        }

        
        static double Newton(double x0, double eps, int kmax)
        {
            int i;
            for (i = 1; i <= kmax; i++)
            {
                double fx = f(x0);
                double fpx = 2 * x0; 
                double dx = fx / fpx;
                x0 = x0 - dx;

                if (Math.Abs(dx) < eps)
                {
                    Console.WriteLine($" [МН] x = {x0:F4}, ітерацій = {i}");
                    return x0;
                }
            }
            Console.WriteLine("Корінь не знайдено за задану кількість ітерацій.");
            return double.NaN;
        }

        static void Main()
        {
            
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            Console.OutputEncoding = System.Text.Encoding.UTF8; 

            Console.WriteLine("=== РОЗВ’ЯЗАННЯ НЕЛІНІЙНОГО РІВНЯННЯ ===");
            Console.WriteLine("Оберіть метод:");
            Console.WriteLine("1 — Метод ділення навпіл (МДН)");
            Console.WriteLine("2 — Метод Ньютона (МН)");
            Console.Write("Ваш вибір: ");
            int choice = int.Parse(Console.ReadLine());

            Console.Write("Введіть точність ε: ");
            double eps = double.Parse(Console.ReadLine().Replace(',', '.'));

            if (choice == 1)
            {
                Console.Write("Введіть a: ");
                double a = double.Parse(Console.ReadLine().Replace(',', '.'));
                Console.Write("Введіть b: ");
                double b = double.Parse(Console.ReadLine().Replace(',', '.'));
                Bisection(a, b, eps);
            }
            else if (choice == 2)
            {
                Console.Write("Введіть початкове наближення x₀: ");
                double x0 = double.Parse(Console.ReadLine().Replace(',', '.'));
                Console.Write("Введіть максимально допустиму кількість ітерацій: ");
                int kmax = int.Parse(Console.ReadLine());
                Newton(x0, eps, kmax);
            }
            else
            {
                Console.WriteLine("❗ Помилка: невірний вибір методу.");
            }

            Console.WriteLine("\nНатисніть Enter для завершення...");
            Console.ReadLine();
        }
    }
}


using System;
using System.Globalization;

namespace Tabulation
{
    class Program
    {
        static double f(double x)
        {
            return x * x - 4; 
        }

        static void Main()
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== ПОШУК ІНТЕРВАЛІВ ЛОКАЛІЗАЦІЇ КОРЕНЯ ===");
            Console.Write("Введіть початок інтервалу Xmin: ");
            double xmin = double.Parse(Console.ReadLine().Replace(',', '.'));
            Console.Write("Введіть кінець інтервалу Xmax: ");
            double xmax = double.Parse(Console.ReadLine().Replace(',', '.'));
            Console.Write("Введіть крок h: ");
            double h = double.Parse(Console.ReadLine().Replace(',', '.'));

            double x1 = xmin;
            double x2 = x1 + h;

            Console.WriteLine("\nТабулювання f(x):");
            Console.WriteLine("  x1\t   x2\t   f(x1)\t   f(x2)");
            while (x2 <= xmax)
            {
                double f1 = f(x1);
                double f2 = f(x2);
                Console.WriteLine($"{x1,6:F2}\t{x2,6:F2}\t{f1,8:F3}\t{f2,8:F3}");

                if (f1 * f2 < 0)
                    Console.WriteLine($"  На проміжку [{x1:F2}; {x2:F2}] є корінь!");

                x1 = x2;
                x2 += h;
            }

            Console.WriteLine("\nПошук завершено. Натисніть Enter для виходу...");
            Console.ReadLine();
        }
    }
}

using System;

namespace NewtonMethod
{
    class Program
    {
        static double f(double x)
        {
            return x * x - 4; 
        }

        static double fp(double x)
        {
            return 2 * x; 
        }

        static void Main(string[] args)
        {
            double x, Eps;
            int Kmax, i;

            Console.WriteLine("Input x0, eps, Kmax:");
            x = Convert.ToDouble(Console.ReadLine());
            Eps = Convert.ToDouble(Console.ReadLine());
            Kmax = Convert.ToInt32(Console.ReadLine());

            for (i = 1; i <= Kmax; i++)
            {
                double Dx = f(x) / fp(x);
                x = x - Dx;

                if (Math.Abs(Dx) < Eps)
                {
                    Console.WriteLine($"Root = {x:F6}, Iterations = {i}");
                    Console.ReadLine();
                    return;
                }
            }

            Console.WriteLine("Root not found with required accuracy.");
            Console.ReadLine();
        }
    }
}

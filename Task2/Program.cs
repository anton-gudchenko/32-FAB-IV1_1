using System.Text.RegularExpressions;

namespace Task2
{
    internal class Program
    {
        static void FullAdder(bool x, bool y, bool p0, out bool z, out bool p1)
        {
            z = x ^ y ^ p0;
            p1 = x && y || x && p0 || y && p0;
        }

        static string AddBinary(string binX, string binY)
        {
            var n = Math.Max(binX.Length, binY.Length);
            var X = new bool[n];
            var Y = new bool[n];
            // Выравнивание слагаемых по длине
            for (var i = 0; i < n; i++)
            {
                X[n - i - 1] = (i < binX.Length) && binX[binX.Length - i - 1] != '0';
                Y[n - i - 1] = (i < binY.Length) && binY[binY.Length - i - 1] != '0';
            }
            var Z = new bool[n + 1];
            var p = false;
            // Побитовое сложение
            for (int i = n - 1; i >= 0; i--)
            {
                FullAdder(X[i], Y[i], p, out Z[i + 1], out p);
            }
            // Последний перенос
            Z[0] = p;
            return string.Join("", Z.Select(z => z ? '1' : '0')).TrimStart('0');
        }

        static bool IsBinary(string? str) => str != null && Regex.IsMatch(str, "^[01]+$");

        static void Main(string[] args)
        {
            string? num1, num2;
            do
            {
                Console.WriteLine("Введите первое число для сумматора:");
                num1 = Console.ReadLine();
            } while (!IsBinary(num1));
            do
            {
                Console.WriteLine("Введите второе число для сумматора:");
                num2 = Console.ReadLine();
            } while (!IsBinary(num2));
            if (num1 is string binX && num2 is string binY)
                Console.WriteLine($"Результат работы сумматора: {AddBinary(binX, binY)}");
        }
    }
}

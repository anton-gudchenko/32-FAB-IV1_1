namespace Task1
{
    internal class Program
    {
        static bool LogicComponent(bool x1, bool x2, bool x3, bool x4, bool x5, bool x6) => (x1 || x2) && (x3 || x4) && !x5 || x6;

        static void Main(string[] args)
        {
            Console.WriteLine("Введите 6 входных сигналов (0|1):");
            bool[] inputs = new bool[6];
            for (int i = 0; i < inputs.Length; i++)
            {
                inputs[i] = Convert.ToInt32(Console.ReadLine()) != 0;
            }
            bool Y = LogicComponent(inputs[0], inputs[1], inputs[2], inputs[3], inputs[4], inputs[5]);
            Console.WriteLine($"Результат работы логического устройства: {(Y ? 1 : 0)}");
        }
    }
}

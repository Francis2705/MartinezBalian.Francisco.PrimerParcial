namespace ejercicio_i_04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string asteriscos;
            Boligrafo birome1 = new Boligrafo(100, ConsoleColor.Blue);
            Boligrafo birome2 = new Boligrafo(50, ConsoleColor.Red);

            birome1.Pintar(27, out asteriscos);
            Console.ForegroundColor = birome1.GetColor();
            Console.WriteLine($"{asteriscos}");
            Console.WriteLine(birome1.GetTinta());
            Console.ResetColor();
            birome1.Recargar();
            Console.WriteLine(birome1.GetTinta());

            birome2.Pintar(60, out asteriscos);
            Console.ForegroundColor = birome2.GetColor();
            Console.WriteLine($"{asteriscos}");
            Console.WriteLine(birome2.GetTinta());
            Console.ResetColor();
            birome2.Recargar();
            Console.WriteLine(birome2.GetTinta());
        }
    }
}
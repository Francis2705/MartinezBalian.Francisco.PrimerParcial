namespace ejercicio_i_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Persona persona1 = new Persona("fran", new DateTime(2004,05,27), 45630934);
            Persona persona2 = new Persona("delia", new DateTime(1946, 05, 19), 04693016);
            Persona persona3 = new Persona("alber", new DateTime(1946, 03, 4), 04545411);
            Persona persona4 = new Persona("cata", new DateTime(2010, 08, 06), 50948392);

            Console.WriteLine($"{persona1.Mostrar()} y {persona1.EsMayorDeEdad()}");
            Console.WriteLine($"{persona2.Mostrar()} y {persona2.EsMayorDeEdad()}");
            Console.WriteLine($"{persona3.Mostrar()} y {persona3.EsMayorDeEdad()}");
            Console.WriteLine($"{persona4.Mostrar()} y {persona4.EsMayorDeEdad()}");

            /*persona1.SetNombre("otro");
            Console.WriteLine($"{persona1.Mostrar()} y {persona1.EsMayorDeEdad()}");*/
        }
    }
}
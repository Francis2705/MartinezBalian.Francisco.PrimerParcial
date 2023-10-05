namespace ejercicio_clase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Creadora objeto1 = new Creadora();
            Creadora objeto2 = new Creadora();
            Creadora objeto3 = new Creadora();
            Creadora objeto4 = new Creadora();

            Console.WriteLine(objeto1.ObtenerDiferencia());
            Console.WriteLine(objeto2.ObtenerDiferencia());
            Console.WriteLine(objeto3.ObtenerDiferencia());
            Console.WriteLine(objeto4.ObtenerDiferencia());
            Console.WriteLine($"Instancias creadas: {Creadora.ObtenerCantidadObjetosCreados()}");
        }
    }
}
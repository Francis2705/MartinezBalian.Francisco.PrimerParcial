using geometria;

namespace ejercicio_i_05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Punto punto1 = new Punto(-2, 5);

            Rectangulo rectangulo = new Rectangulo(punto1, new Punto(5, 6));

            MostrarDatosRectangulo(rectangulo);
        }
        static void MostrarDatosRectangulo(Rectangulo rectangulo)
        {
            Console.WriteLine("Datos del rectángulo:");
            Console.WriteLine("Vértice 1: (" + rectangulo.GetVertice1().GetX() + ", " + rectangulo.GetVertice1().GetY() + ")");
            Console.WriteLine("Vértice 2: (" + rectangulo.GetVertice2().GetX() + ", " + rectangulo.GetVertice2().GetY() + ")");
            Console.WriteLine("Vértice 3: (" + rectangulo.GetVertice3().GetX() + ", " + rectangulo.GetVertice3().GetY() + ")");
            Console.WriteLine("Vértice 4: (" + rectangulo.GetVertice4().GetX() + ", " + rectangulo.GetVertice4().GetY() + ")");
            Console.WriteLine("Área: " + rectangulo.GetArea());
            Console.WriteLine("Perímetro: " + rectangulo.GetPerimetro());
        }
    }
}
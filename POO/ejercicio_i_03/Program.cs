namespace ejercicio_i_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Estudiante alumno1 = new Estudiante("martinez", "4134", "fran");
            Estudiante alumno2 = new Estudiante("perez", "0812", "fede");
            Estudiante alumno3 = new Estudiante("rodriguez", "9819", "seba");

            alumno1.SetNotaPrimerParcial(8);
            alumno1.SetNotaSegundoParcial(9);

            alumno2.SetNotaPrimerParcial(2);
            alumno2.SetNotaSegundoParcial(7);

            alumno3.SetNotaPrimerParcial(6);
            alumno3.SetNotaSegundoParcial(8);

            Console.WriteLine(alumno1.Mostrar());
            Console.WriteLine(alumno2.Mostrar());
            Console.WriteLine(alumno3.Mostrar());
        }
    }
}
namespace ejercicio_i_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string nombre;
            decimal saldoActual;
            bool flagIngreso = true;
            string buffer;
            decimal saldoParaOperar;
            string informacion;

            Console.WriteLine("Ingrese su nombre: ");
            nombre = Console.ReadLine();
            Console.WriteLine("Ingrese su saldo actual: ");
            saldoActual = decimal.Parse(Console.ReadLine());

            Cuenta cajaAhorro = new Cuenta(nombre, saldoActual);

            while (flagIngreso)
            {
                Console.WriteLine("q quiere hacer? i/r: ");
                buffer = Console.ReadLine();

                if (buffer == "i")
                {
                    Console.WriteLine("cuanto quiere ingresar? ");
                    saldoParaOperar = decimal.Parse(Console.ReadLine());
                    cajaAhorro.Ingresar(saldoParaOperar);
                }
                else if (buffer == "r")
                {
                    Console.WriteLine("cuanto quiere retirar? ");
                    saldoParaOperar = decimal.Parse(Console.ReadLine());
                    cajaAhorro.Retirar(saldoParaOperar);
                }
                else
                {
                    Console.WriteLine("no se ingreso un operador valido");
                }

                informacion = cajaAhorro.Mostrar();
                Console.WriteLine(informacion);

                Console.WriteLine("quiere seguir operando? s/n: ");
                buffer = Console.ReadLine();
                if (buffer == "n")
                {
                    flagIngreso = false;
                }
            }
        }
    }
}
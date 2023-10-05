using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio_i_01
{
    internal class Cuenta
    {
        private string titular;
        private decimal cantidad;

        public Cuenta(string titular, decimal cantidad)
        {
            this.titular = titular;
            this.cantidad = cantidad;
        }

        public string GetterTitular()
        {
            return titular;
        }
        public decimal GetterCantidad()
        {
            return cantidad;
        }
        public string Mostrar()
        {
            return $"El titular de la cuenta es {GetterTitular()} y la cantidad es {GetterCantidad()}";
            //se puede cambiar por titular y por cantidad
        }
        public void Ingresar(decimal monto)
        {
            if (monto > 0)
            {
                cantidad += monto;
                Console.WriteLine($"Se ha ingresado {monto} a la cuenta.");
            }
            else
            {
                Console.WriteLine("El monto ingresado debe ser mayor que cero.");
            }
        }
        public void Retirar(decimal monto)
        {
            if (monto > 0)
            {
                cantidad -= monto;
                Console.WriteLine($"Se ha retirado {monto} a la cuenta.");
            }
            else
            {
                Console.WriteLine("no se puede retirar nada o un monto negativo.");
            }
        }
    }
}

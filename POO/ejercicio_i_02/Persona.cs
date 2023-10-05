using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio_i_02
{
    internal class Persona
    {
        private string nombre;
        private DateTime fechaDeNacimiento;
        private int dni;

        public Persona(string nombre, DateTime fecha, int dni)
        {
            this.nombre = nombre;
            this.fechaDeNacimiento = fecha;
            this.dni = dni;
        }
        public void SetNombre(string nombre)
        {
            this.nombre = nombre;
        }
        public void SetFecha(DateTime fecha)
        {
            this.fechaDeNacimiento = fecha;
        }
        public void SetDni(int dni)
        {
            this.dni = dni;
        }
        private int CalcularEdad()
        {
            DateTime fechaActual = DateTime.Today;
            int edad = fechaActual.Year - fechaDeNacimiento.Year;
            return edad;
        }
        public string Mostrar()
        {
            return $"La persona se llama {nombre}, tiene {CalcularEdad()} y su dni es {dni}";
        }
        public string EsMayorDeEdad()
        {
            if (CalcularEdad() > 17)
            {
                return "es mayor de edad";
            }
            else
            {
                return "es menor de edad";
            }
        }
    }
}

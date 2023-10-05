using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio_i_03
{
    internal class Estudiante
    {
        private string apellido;
        private string legajo;
        private string nombre;
        private int notaPrimerParcial;
        private int notaSegundoParcial;
        private static Random random;

        static Estudiante()
        {
            Estudiante.random = new Random();
        }
        public Estudiante(string apellido, string legajo, string nombre)
        {
            this.apellido = apellido;
            this.legajo = legajo;
            this.nombre = nombre;
        }

        public double CalcularNotaFinal()
        {
            if (notaPrimerParcial >= 4 && notaSegundoParcial >= 4)
            {
                return random.NextDouble() * (10 - 6) + 6;
            }
            else
            {
                return -1;
            }
        }
        private float CalcularPromedio(int nota1, int nota2)
        {
            return (nota1 + nota2) / 2;
        }
        public string Mostrar()
        {
            StringBuilder cadena = new StringBuilder();
            cadena.AppendLine("Nombre: " + nombre);
            cadena.AppendLine("Apellido: " + apellido);
            cadena.AppendLine("Legajo: " + legajo);
            cadena.AppendLine("Nota del primer parcial: " + notaPrimerParcial);
            cadena.AppendLine("Nota del segundo parcial: " + notaSegundoParcial);
            cadena.AppendLine("Promedio: " + CalcularPromedio(notaPrimerParcial, notaSegundoParcial));
            if (CalcularNotaFinal() != -1)
            {
                cadena.AppendLine("Nota final: " + CalcularNotaFinal());
            }
            else
            {
                cadena.AppendLine("Alumno desaprobado");
            }
            return cadena.ToString();
        }
        public void SetNotaPrimerParcial(int nota)
        {
            this.notaPrimerParcial = nota;
        }
        public void SetNotaSegundoParcial(int nota)
        {
            this.notaSegundoParcial = nota;
        }
    }
}

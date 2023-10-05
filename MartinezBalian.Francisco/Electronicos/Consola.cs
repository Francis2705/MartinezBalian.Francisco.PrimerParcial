using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electronicos
{
    public sealed class Consola : ArtefactoElectronico
    {
        //Atributos
        private bool aceptaDiscosFisicos;
        private double memoriaTotal;
        private short velocidadDescargaMB;
        private short velocidadCargaMB;

        //Propiedades
        public bool AceptaDiscosFisicos
        {
            get
            {
                return this.aceptaDiscosFisicos;
            }
            set
            {
                this.aceptaDiscosFisicos = value;
            }
        }
        public double MemoriaTotal
        {
            get
            {
                return this.memoriaTotal;
            }
            set
            {
                this.memoriaTotal = value;
            }
        }
        public short VelocidadDescargaMB
        {
            get
            {
                return this.velocidadDescargaMB;
            }
            set
            {
                this.velocidadDescargaMB = value;
            }
        }
        public short VelocidadCargaMB
        {
            get
            {
                return this.velocidadCargaMB;
            }
            set
            {
                this.velocidadCargaMB = value;
            }
        }

        //Constructores
        public Consola(double precio, double medidaAlto, string nombre, string descripcion, ETipoOrigen tipoOrigen, bool aceptaDiscosFisicos)
            : base(precio, medidaAlto, nombre, descripcion, tipoOrigen)
        {
            this.aceptaDiscosFisicos = aceptaDiscosFisicos;
            this.memoriaTotal = 256;
            this.velocidadDescargaMB = 10;
            this.velocidadCargaMB = 10;
        }
        //Sobrecarga (que no es sobrecarga en realidad) a eleccion ↑
        public Consola(double precio, double medidaAlto, string nombre, string descripcion, ETipoOrigen tipoOrigen, bool aceptaDiscosFisicos,
            short velocidadDescargaMB, short velocidadCargaMB) : this(precio, medidaAlto, nombre, descripcion, tipoOrigen, aceptaDiscosFisicos)
        {
            this.velocidadDescargaMB = velocidadDescargaMB;
            this.velocidadCargaMB = velocidadCargaMB;
        }
        //Sobrecarga de uno menos ↑
        public Consola(double precio, double medidaAlto, string nombre, string descripcion, ETipoOrigen tipoOrigen, bool aceptaDiscosFisicos,
            short velocidadDescargaMB, short velocidadCargaMB, double memoriaTotal) : this(precio, medidaAlto, nombre, descripcion, tipoOrigen, 
                aceptaDiscosFisicos, velocidadDescargaMB, velocidadCargaMB)
        {
            this.memoriaTotal = memoriaTotal;
        }
        //Sobrecarga de todos los atributos ↑

        //Sobrescritura de metodos virtual e implementacion del abstract
        public override string MostrarDatosGenerales()
        {
            string cadena = "Esto es una consola\n";
            return cadena + base.MostrarDatosGenerales();
        }
        public override string MostrarCaracteristicasEspecificas()
        {
            StringBuilder sb = new StringBuilder();

            if (this.aceptaDiscosFisicos)
            {
                sb.AppendLine("Acepta discos fisicos");
            }
            else
            {
                sb.AppendLine("No acepta discos fisicos");
            }

            sb.AppendLine($"Memoria total: {this.memoriaTotal}");
            sb.AppendLine($"Velocidad de descarga en MB: {this.velocidadDescargaMB}");
            sb.AppendLine($"Velocidad de dcarga en MB: {this.velocidadCargaMB}");

            return sb.ToString();
        }

        //Faltan: sobrecargar el == y el !=, hacer una sobrecarga implicita y otra explicita con el nombre, sobrescribir los metodos
        //Equals() (usar el == sobrecargado) y ToString() (ver alguna relacion con el metodo de MostrarDatosGenerales())
        //y hacer metodos normales y alguna sobrecarga (recargar bateria, aniadir memoria, etc) <- Ejemplos genericos, hacer especificos
    }
}

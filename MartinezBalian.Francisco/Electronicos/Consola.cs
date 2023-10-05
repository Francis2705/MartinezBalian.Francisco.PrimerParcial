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
            return "Esto es una consola\n" + base.ToString();
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

        //Sobrecarga implicita y explicita
        public static implicit operator Consola(string nombreConsola)
        {
            return new Consola(10000, 15, nombreConsola, "Consola sin descripcion", ETipoOrigen.INTERNACIONAL, false);
        }
        public static explicit operator string(Consola nombreConsola) 
        {
            return nombreConsola.nombre;
        }

        //Sobrecarga del operador ==
        public static bool operator ==(Consola con1, Consola con2)
        {
            return (((ArtefactoElectronico)con1) == con2) && con1.velocidadDescargaMB == con2.velocidadDescargaMB;
        }
        public static bool operator !=(Consola con1, Consola con2)
        {
            return !(con1 == con2);
        }

        //Sobrescritura del Equals(), ToString() y el GetHashCode()
        public override bool Equals(object? obj)
        {
            bool retorno = false;
            if (obj is Consola)
            {
                retorno = this == (Consola)obj;
            }
            return retorno;
        }
        public override string ToString()
        {
            return this.MostrarDatosGenerales();
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        //Metodos "normales" y sobrecarga
        public int AgregarMemoria() //Si retorna 1 muestra mensaje, sino retorna 0 y no muestra nada (validar en el Forms) (Agregado rapido!)
        {
            int retorno = 0;
            this.memoriaTotal += 50;
            if (this.memoriaTotal > 500)
            {
                this.memoriaTotal = 500;
                retorno = 1;
            }
            return retorno;
        }
        public int AgregarMemoria(int num) //Si retorna 1 muestra mensaje, sino retorna 0 y no muestra nada (validar en el Forms)
        {
            int retorno = 0;
            this.memoriaTotal += num;
            if (this.memoriaTotal > 100)
            {
                this.memoriaTotal = 100;
                retorno = 1;
            }
            return retorno;
        }
    }
}

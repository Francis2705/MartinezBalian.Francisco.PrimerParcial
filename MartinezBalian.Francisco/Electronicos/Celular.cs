using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Electronicos
{
    public sealed class Celular : ArtefactoElectronico
    {
        //Atributos
        private bool asistenteVirtual;
        private int bateria;
        private int cantidadAplicaciones;
        private int cantidadContactos;

        //Propiedades
        public bool AsistenteVirtual
        {
            get
            {
                return this.asistenteVirtual;
            }
            set
            {
                this.asistenteVirtual = value;
            }
        }
        public int Bateria
        {
            get
            {
                return this.bateria;
            }
            set
            {
                this.bateria = value;
            }
        }
        public int CantidadAplicaciones
        {
            get
            {
                return this.cantidadAplicaciones;
            }
            set
            {
                this.cantidadAplicaciones = value;
            }
        }
        public int CantidadContactos
        {
            get
            {
                return this.cantidadContactos;
            }
            set
            {
                this.cantidadContactos = value;
            }
        }
        
        //Constructores
        public Celular(double precio, double medidaAlto, string nombre, string descripcion, ETipoOrigen tipoOrigen, int bateria)
            : base(precio, medidaAlto, nombre, descripcion, tipoOrigen)
        {
            this.bateria = bateria;
            this.asistenteVirtual = false;
            this.cantidadAplicaciones = 0;
            this.cantidadContactos = 0;
        }
        //Sobrecarga (que no es sobrecarga en realidad) a eleccion ↑
        public Celular(double precio, double medidaAlto, string nombre, string descripcion, ETipoOrigen tipoOrigen, int bateria,
            int cantidadAplicaciones, int cantidadContactos) : this(precio, medidaAlto, nombre, descripcion, tipoOrigen, bateria)
        {
            this.cantidadAplicaciones = cantidadAplicaciones;
            this.cantidadContactos = cantidadContactos;
        }
        //Sobrecarga de uno menos ↑
        public Celular(double precio, double medidaAlto, string nombre, string descripcion, ETipoOrigen tipoOrigen, int bateria,
            int cantidadAplicaciones, int cantidadContactos, bool asistenteVirtual):this(precio, medidaAlto, nombre, descripcion, 
                tipoOrigen, bateria, cantidadAplicaciones, cantidadContactos)
        {
            this.asistenteVirtual = asistenteVirtual;
        }
        //Sobrecarga de todos los atributos ↑

        //Sobrescritura de metodos virtual e implementacion del abstract
        public override string MostrarDatosGenerales()
        {
            return "Esto es un celular\n" + base.ToString();
        }
        public override string MostrarCaracteristicasEspecificas()
        {
            StringBuilder sb = new StringBuilder();

            if (this.asistenteVirtual)
            {
                sb.AppendLine("Tiene asistente virtual");
            }
            else
            {
                sb.AppendLine("No tiene asistente virtual");
            }

            sb.AppendLine($"Bateria: {this.bateria}");
            sb.AppendLine($"Cantidad de aplicaciones: {this.cantidadAplicaciones}");
            sb.AppendLine($"Cantidad de contactos: {this.cantidadContactos}");

            return sb.ToString();
        }

        //Sobrecarga implicita y explicita
        public static implicit operator Celular(string nombreCelu) //De un string, creo un Celular 
        {
            return new Celular(10000, 15, nombreCelu, "Celular sin descripcion", ETipoOrigen.INTERNACIONAL, 50); //Celular celular1 = "Iphone";
        }
        public static explicit operator string(Celular nombreCelu) //De un Celular, creo un string 
        {
            return nombreCelu.nombre;
            // Celular celular1 = new Celular("paso parametros");
            // string nombre = (string)celular1;
        }

        //Sobrecarga del operador ==
        public static bool operator ==(Celular celu1, Celular celu2)
        {
            return (((ArtefactoElectronico)celu1) == celu2) && celu1.cantidadContactos == celu2.cantidadContactos;
        }
        public static bool operator !=(Celular celu1, Celular celu2)
        {
            return !(celu1 == celu2);
        }

        //Sobrescritura del Equals(), ToString() y el GetHashCode()
        public override bool Equals(object? obj)
        {
            bool retorno = false;
            if (obj is Celular)
            {
                retorno = this == (Celular)obj;
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
        public int RecargarBateria() //Si retorna 1 muestra mensaje, sino retorna 0 y no muestra nada (validar en el Forms) (Recarga rapida!)
        {
            int retorno = 0;
            this.bateria += 10;
            if (this.bateria > 100)
            {
                this.bateria = 100;
                retorno = 1;
            }
            return retorno;
        }
        public int RecargarBateria(int porcentaje) //Si retorna 1 muestra mensaje, sino retorna 0 y no muestra nada (validar en el Forms)
        {
            int retorno = 0;
            this.bateria += porcentaje;
            if (this.bateria > 100)
            {
                this.bateria = 100;
                retorno = 1;
            }
            return retorno;
        }
    }
}

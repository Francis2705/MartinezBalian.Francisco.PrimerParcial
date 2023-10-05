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
        public Celular(double precio, double medida, string nombre, string descripcion, ETipoOrigen tipoOrigen, int bateria)
            : base(precio, medida, nombre, descripcion, tipoOrigen)
        {
            this.bateria = bateria;
            this.asistenteVirtual = false;
            this.cantidadAplicaciones = 0;
            this.cantidadContactos = 0;
        }
        //Sobrecarga (que no es sobrecarga en realidad) a eleccion ↑
        public Celular(double precio, double medida, string nombre, string descripcion, ETipoOrigen tipoOrigen, int bateria,
            int cantidadAplicaciones, int cantidadContactos) : this(precio, medida, nombre, descripcion, tipoOrigen, bateria)
        {
            this.cantidadAplicaciones = cantidadAplicaciones;
            this.cantidadContactos = cantidadContactos;
        }
        //Sobrecarga de uno menos ↑
        public Celular(double precio, double medida, string nombre, string descripcion, ETipoOrigen tipoOrigen, int bateria,
            int cantidadAplicaciones, int cantidadContactos, bool asistenteVirtual):this(precio, medida, nombre, descripcion, 
                tipoOrigen, bateria, cantidadAplicaciones, cantidadContactos)
        {
            this.asistenteVirtual = asistenteVirtual;
        }
        //Sobrecarga de todos los atributos ↑

        //Sobrescritura de metodos virtual e implementacion del abstract
        public override string MostrarDatosGenerales()
        {
            string cadena = "Esto es un celular\n";
            return cadena + base.MostrarDatosGenerales();
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

        //Faltan: sobrecargar el == y el !=, hacer una sobrecarga implicita y otra explicita con el nombre, sobrescribir los metodos
        //Equals() (usar el == sobrecargado) y ToString() (ver alguna relacion con el metodo de MostrarDatosGenerales())
        //y hacer metodos normales y alguna sobrecarga (recargar bateria, aniadir memoria, etc) <- Ejemplos genericos, hacer especificos
    }
}

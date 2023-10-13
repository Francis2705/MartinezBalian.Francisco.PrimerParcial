using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Electronicos
{
    public sealed class Celular : ArtefactoElectronico
    {
        //Atributos
        private bool asistenteVirtual;
        private int bateria;
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

                if (this.bateria > 100)
                {
                    this.bateria = 100;
                }
                else if (this.bateria < 0)
                {
                    this.bateria = 0;
                }
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
                if (this.cantidadContactos > 200)
                {
                    this.cantidadContactos = 200;
                }
                else if (this.cantidadContactos < 0)
                {
                    this.cantidadContactos = 0;
                }
            }
        }

        //Constructores
        public Celular()
        {

        }
        public Celular(double precio, string nombre, string marca, ETipoOrigen tipoOrigen, int bateria)
            : base(precio, nombre, marca, tipoOrigen)
        {
            this.Bateria = bateria;
            this.asistenteVirtual = false;
            this.cantidadContactos = 0;
        }
        //Sobrecarga (que no es sobrecarga en realidad) a eleccion ↑
        public Celular(double precio, string nombre, string marca, ETipoOrigen tipoOrigen, int bateria,
            int cantidadContactos) : this(precio, nombre, marca, tipoOrigen, bateria)
        {
            this.CantidadContactos = cantidadContactos;
        }
        //Sobrecarga de uno menos ↑
        public Celular(double precio, string nombre, string marca, ETipoOrigen tipoOrigen, int bateria,
            int cantidadContactos, bool asistenteVirtual):this(precio, nombre, marca, tipoOrigen, bateria, cantidadContactos)
        {
            this.asistenteVirtual = asistenteVirtual;
        }
        //Sobrecarga de todos los atributos ↑

        //Sobrescritura de metodos virtual e implementacion del abstract
        public override string MostrarDatosGenerales()
        {
            return "Celular -> " + base.MostrarDatosGenerales();
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

            sb.AppendLine($"Bateria: {this.bateria}%");
            sb.AppendLine($"Cantidad de contactos: {this.cantidadContactos}");

            return sb.ToString();
        }

        //Sobrecarga implicita y explicita
        public static implicit operator Celular(string nombreCelu) //De un string, creo un Celular 
        {
            return new Celular(10000, nombreCelu, "Celular sin marca", ETipoOrigen.INTERNACIONAL, 50); //Celular celular1 = "Moto";
        }
        public static explicit operator string(Celular nombreCelu) //De un Celular, creo un string 
        {
            return nombreCelu.nombre;
            // Celular celular1 = new Celular("paso parametros");
            // string nombre = (string)celular1;
        }

        //Sobrecarga del operador ==
        public static bool operator ==(Celular celu1, Celular celu2) //Va al Equals() base 
        {
            return ((ArtefactoElectronico)celu1).Equals(celu2) && celu1.cantidadContactos == celu2.cantidadContactos;
            //return (((ArtefactoElectronico)celu1) == celu2) && celu1.cantidadContactos == celu2.cantidadContactos;
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
                retorno = true;
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
        public void RecargarBateria()
        {
            this.Bateria += 10;
        }
        public void RecargarBateria(int porcentaje)
        {
            this.Bateria += porcentaje;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electronicos
{
    /// <summary>
    /// Clase que representa una computadora
    /// </summary>
    public sealed class Computadora : ArtefactoElectronico
    {
        //Atributos
        private bool esTactil;
        private int cantidadNucleos;
        private double espacioDiscoSSD;

        //Propiedades
        public bool EsTactil
        {
            get
            {
                return this.esTactil;
            }
            set
            {
                this.esTactil = value;
            }
        }
        public int CantidadNucleos
        {
            get
            {
                return this.cantidadNucleos;
            }
            set
            {
                this.cantidadNucleos = value;

                if (this.cantidadNucleos > 12)
                {
                    this.cantidadNucleos = 12;
                }
                else if (this.cantidadNucleos <= 0)
                {
                    this.cantidadNucleos = 1;
                }
            }
        }
        public double EspacioDiscoSSD
        {
            get
            {
                return this.espacioDiscoSSD;
            }
            set
            {
                this.espacioDiscoSSD = value;

                if (this.espacioDiscoSSD > 2048)
                {
                    this.espacioDiscoSSD = 2048;
                }
                else if (this.espacioDiscoSSD < 32)
                {
                    this.espacioDiscoSSD = 32;
                }
            }
        }

        //Constructores
        public Computadora()
        {

        }
        public Computadora(double precio, string nombre, string marca, ETipoOrigen tipoOrigen, bool esTactil)
            : base(precio, nombre, marca, tipoOrigen)
        {
            this.esTactil = esTactil;
            this.cantidadNucleos = 2;
            this.espacioDiscoSSD = 128;
        }
        //Sobrecarga (que no es sobrecarga en realidad) a eleccion ↑
        public Computadora(double precio, string nombre, string marca, ETipoOrigen tipoOrigen, bool esTactil,
            double espacioDiscoSSD) : this(precio, nombre, marca, tipoOrigen, esTactil)
        {
            this.EspacioDiscoSSD = espacioDiscoSSD;
        }
        //Sobrecarga de uno menos ↑
        public Computadora(double precio, string nombre, string marca, ETipoOrigen tipoOrigen, bool esTactil,
            double espacioDiscoSSD, int cantidadNucleos) : this(precio, nombre, marca, tipoOrigen,
                esTactil, espacioDiscoSSD)
        {
            this.CantidadNucleos = cantidadNucleos;
        }
        //Sobrecarga de todos los atributos ↑

        //Sobrescritura de metodos virtual e implementacion del abstract
        public override string MostrarDatosGenerales()
        {
            return "Computadora -> " + base.MostrarDatosGenerales();
        }
        public override string MostrarCaracteristicasEspecificas()
        {
            StringBuilder sb = new StringBuilder();

            if (this.esTactil)
            {
                sb.AppendLine("Es tactil");
            }
            else
            {
                sb.AppendLine("No es tactil");
            }

            sb.AppendLine($"Cantidad de nucleos: {this.cantidadNucleos}");
            sb.AppendLine($"Espacio del disco SSD: {this.espacioDiscoSSD}");

            return sb.ToString();
        }

        //Sobrecarga implicita y explicita
        public static implicit operator Computadora(string nombreCompu)
        {
            return new Computadora(10000, nombreCompu, "Computadora sin marca", ETipoOrigen.INTERNACIONAL, false);
        }
        public static explicit operator string(Computadora nombreCompu)
        {
            return nombreCompu.nombre;
        }

        /// <summary>
        /// Sobrecarga del operador ==, compara por igualdad de nonmbre, precio y cantidad de nucleos
        /// </summary>
        /// <param name="art1">Representa una computadora</param>
        /// <param name="art2">Representa otra computadora</param>
        /// <returns>Retorna true si son iguales y false sino lo son</returns>
        public static bool operator ==(Computadora compu1, Computadora compu2) //Va al Equals() base
        {
            return ((ArtefactoElectronico)compu1).Equals(compu2) && compu1.cantidadNucleos == compu2.cantidadNucleos;
            //return (((ArtefactoElectronico)compu1) == compu2) && compu1.cantidadNucleos == compu2.cantidadNucleos;
        }
        public static bool operator !=(Computadora compu1, Computadora compu2)
        {
            return !(compu1 == compu2);
        }

        /// <summary>
        /// Sobrescritura del Equals()
        /// </summary>
        /// <param name="obj">Objeto de cualquier tipo</param>
        /// <returns>Retorna true si es de tipo computadora</returns>
        public override bool Equals(object? obj)
        {
            bool retorno = false;
            if (obj is Computadora)
            {
                retorno = true;
            }
            return retorno;
        }
        /// <summary>
        /// Sobrescritura del ToString()
        /// </summary>
        /// <returns>Retorna un string con lo que devuelve el metodo MostrarDatosGenerales</returns>
        public override string ToString()
        {
            return this.MostrarDatosGenerales();
        }
        /// <summary>
        /// Sobrescritura del GetHashCode()
        /// </summary>
        /// <returns>Llama al de la clase base</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        //Metodos "normales" y sobrecarga
        public void AgregarEspacioSSD()
        {
            this.EspacioDiscoSSD += 50;
        }
        public void AgregarEspacioSSD(int num)
        {
            this.espacioDiscoSSD += num;
        }
    }
}

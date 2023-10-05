using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electronicos
{
    public sealed class Computadora : ArtefactoElectronico
    {
        //Atributos
        private bool esTactil;
        private int cantidadNucleos;
        private double espacioDiscoSSD;
        private double espacioDiscoHDD;

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
            }
        }
        public double EspacioDiscoHDD
        {
            get
            {
                return this.espacioDiscoHDD;
            }
            set
            {
                this.espacioDiscoHDD = value;
            }
        }

        //Constructores
        public Computadora(double precio, double medidaAlto, string nombre, string descripcion, ETipoOrigen tipoOrigen, bool esTactil)
            : base(precio, medidaAlto, nombre, descripcion, tipoOrigen)
        {
            this.esTactil = esTactil;
            this.cantidadNucleos = 2;
            this.espacioDiscoSSD = 100;
            this.espacioDiscoHDD = 500;
        }
        //Sobrecarga (que no es sobrecarga en realidad) a eleccion ↑
        public Computadora(double precio, double medidaAlto, string nombre, string descripcion, ETipoOrigen tipoOrigen, bool esTactil,
            double espacioDiscoSSD, double espacioDiscoHDD) : this(precio, medidaAlto, nombre, descripcion, tipoOrigen, esTactil)
        {
            this.espacioDiscoSSD = espacioDiscoSSD;
            this.espacioDiscoHDD = espacioDiscoHDD;
        }
        //Sobrecarga de uno menos ↑
        public Computadora(double precio, double medidaAlto, string nombre, string descripcion, ETipoOrigen tipoOrigen, bool esTactil,
            double espacioDiscoSSD, double espacioDiscoHDD, int cantidadNucleos) : this(precio, medidaAlto, nombre, descripcion, tipoOrigen,
                esTactil, espacioDiscoSSD, espacioDiscoHDD)
        {
            this.cantidadNucleos = cantidadNucleos;
        }
        //Sobrecarga de todos los atributos ↑

        //Sobrescritura de metodos virtual e implementacion del abstract
        protected override string MostrarDatosGenerales()
        {
            return "Esto es una computadora\n" + base.ToString();
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
            sb.AppendLine($"Espacio del disco HDD: {this.espacioDiscoHDD}");

            return sb.ToString();
        }

        //Sobrecarga implicita y explicita
        public static implicit operator Computadora(string nombreCompu)
        {
            return new Computadora(10000, 15, nombreCompu, "Computadora sin descripcion", ETipoOrigen.INTERNACIONAL, false);
        }
        public static explicit operator string(Computadora nombreCompu)
        {
            return nombreCompu.nombre;
        }

        //Sobrecarga del operador ==
        public static bool operator ==(Computadora compu1, Computadora compu2)
        {
            return (((ArtefactoElectronico)compu1) == compu2) && compu1.cantidadNucleos == compu2.cantidadNucleos;
        }
        public static bool operator !=(Computadora compu1, Computadora compu2)
        {
            return !(compu1 == compu2);
        }

        //Sobrescritura del Equals(), ToString() y el GetHashCode()
        public override bool Equals(object? obj)
        {
            bool retorno = false;
            if (obj is Computadora)
            {
                retorno = this == (Computadora)obj;
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
        public int AgregarEspacioSSD() //Si retorna 1 muestra mensaje, sino retorna 0 y no muestra nada (validar en el Forms) (Agregado rapido!)
        {
            int retorno = 0;
            this.espacioDiscoSSD += 50;
            if (this.espacioDiscoSSD > 256)
            {
                this.espacioDiscoSSD = 256;
                retorno = 1;
            }
            return retorno;
        }
        public int AgregarEspacioSSD(int num) //Si retorna 1 muestra mensaje, sino retorna 0 y no muestra nada (validar en el Forms)
        {
            int retorno = 0;
            this.espacioDiscoSSD += num;
            if (this.espacioDiscoSSD > 256)
            {
                this.espacioDiscoSSD = 256;
                retorno = 1;
            }
            return retorno;
        }
    }
}

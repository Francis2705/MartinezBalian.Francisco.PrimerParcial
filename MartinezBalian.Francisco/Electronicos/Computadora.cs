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
            this.espacioDiscoHDD = 200;
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
        public override string MostrarDatosGenerales()
        {
            string cadena = "Esto es una computadora\n";
            return cadena + base.MostrarDatosGenerales();
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

        //Faltan: sobrecargar el == y el !=, hacer una sobrecarga implicita y otra explicita con el nombre, sobrescribir los metodos
        //Equals() (usar el == sobrecargado) y ToString() (ver alguna relacion con el metodo de MostrarDatosGenerales())
        //y hacer metodos normales y alguna sobrecarga (recargar bateria, aniadir memoria, etc) <- Ejemplos genericos, hacer especificos
    }
}

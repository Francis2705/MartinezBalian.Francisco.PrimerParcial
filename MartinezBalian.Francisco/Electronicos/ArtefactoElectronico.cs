using System.Text;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Electronicos
{
    [XmlInclude(typeof(Celular))]
    [XmlInclude(typeof(Consola))]
    [XmlInclude(typeof(Computadora))]
    [XmlRoot("ArtefactosElectronicos")]
    public abstract class ArtefactoElectronico
    {
        //Atributos
        protected double precio;
        protected string nombre;
        protected string marca;
        protected ETipoOrigen tipoOrigen;

        //Propiedades (publicas para la serializacion)
        public double Precio 
        {
            get
            {
                return this.precio;
            }
            set
            {
                this.precio = value;
            }
        }
        public string Nombre 
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = value;
            }
        }
        public string Marca
        {
            get
            {
                return this.marca;
            }
            set
            {
                this.marca = value;
            }
        }
        public ETipoOrigen TipoOrigen
        {
            get
            {
                return this.tipoOrigen;
            }
            set
            {
                this.tipoOrigen = value;
            }
        }

        //Constructor
        public ArtefactoElectronico()
        {

        }
        public ArtefactoElectronico(double precio, string nombre, string marca, ETipoOrigen tipoOrigen)
        {
            this.precio = precio;
            this.nombre = nombre;
            this.marca = marca;
            this.tipoOrigen = tipoOrigen;
        }

        //Metodos con virtual y abstract
        public virtual string MostrarDatosGenerales()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Precio: {this.precio} - ");
            sb.AppendLine($"Nombre: {this.nombre} - ");
            sb.AppendLine($"Marca: {this.marca} - ");
            sb.AppendLine($"Origen: {this.tipoOrigen}");
            
            return sb.ToString();
        }
        public abstract string MostrarCaracteristicasEspecificas();

        //Sobrecarga del operador ==
        public static bool operator ==(ArtefactoElectronico art1, ArtefactoElectronico art2)
        {
            return (art1.precio == art2.precio) && (art1.nombre == art2.nombre);
        }
        public static bool operator !=(ArtefactoElectronico art1, ArtefactoElectronico art2)
        {
            return !(art1 == art2);
        }

        //Sobrescritura del Equals(), ToString() y el GetHashCode()
        public override bool Equals(object? obj)
        {
            bool retorno = false;
            if (obj is ArtefactoElectronico)
            {
                retorno = this == (ArtefactoElectronico)obj;
            }
            return retorno;
        }
        public override string ToString()
        {
            return this.MostrarDatosGenerales();
        }
        public override int GetHashCode()
        {
            return (int)this.precio;
        }
    }
}
using System.Text;

namespace Electronicos
{
    public abstract class ArtefactoElectronico
    {
        //Atributos
        protected double precio;
        protected double medidaAlto;
        protected string nombre;
        protected string descripcion;
        protected ETipoOrigen tipoOrigen;

        //Propiedades
        protected double Precio
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
        protected double MedidaAlto
        {
            get
            {
                return this.medidaAlto;
            }
            set
            {
                this.medidaAlto = value;
            }
        }
        protected string Nombre
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
        protected string Descripcion
        {
            get
            {
                return this.descripcion;
            }
            set
            {
                this.descripcion = value;
            }
        }
        protected ETipoOrigen TipoOrigen
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
        public ArtefactoElectronico(double precio, double medidaAlto, string nombre, string descripcion, ETipoOrigen tipoOrigen)
        {
            this.precio = precio;
            this.medidaAlto = medidaAlto;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.tipoOrigen = tipoOrigen;
        }

        //Metodos con virtual y abstract
        public virtual string MostrarDatosGenerales()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Precio: {this.precio}");
            sb.AppendLine($"Medida: {this.medidaAlto}");
            sb.AppendLine($"Nombre: {this.nombre}");
            sb.AppendLine($"Descripcion: {this.descripcion}");
            sb.AppendLine($"Tipo: {this.tipoOrigen}");
            
            return sb.ToString();
        }
        public abstract string MostrarCaracteristicasEspecificas();

        //Sobrecarga del operador ==
        public static bool operator ==(ArtefactoElectronico art1, ArtefactoElectronico art2)
        {
            return (art1.precio == art2.precio) && (art1.nombre == art2.nombre) && (art1.medidaAlto == art2.medidaAlto);
        }
        public static bool operator !=(ArtefactoElectronico art1, ArtefactoElectronico art2)
        {
            return !(art1 == art2);
        }

        //Sobrescritura del Equals(), ToString() y el GetHashCode()
        public override bool Equals(object? obj)
        {
            return this.GetType() == obj.GetType();
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
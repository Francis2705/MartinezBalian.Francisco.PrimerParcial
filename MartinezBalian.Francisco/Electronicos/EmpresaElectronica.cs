using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Electronicos
{
    public class EmpresaElectronica
    {
        //Atributos
        private string nombre;
        private string creador;
        private List<ArtefactoElectronico> productosElectronicos;

        //Propiedades e indexador
        public string Nombre
        {
            get { return nombre; }
        }
        public string Creador
        {
            get { return creador; }
        }
        public ArtefactoElectronico this[int i] //El num que se pasa (i) ya viene validado de afuera
        {
            get
            {
                return this.productosElectronicos[i];
            }
        }

        //Constructor
        public EmpresaElectronica(string nombre, string creador)
        {
            this.productosElectronicos = new List<ArtefactoElectronico>();
            this.nombre = nombre;
            this.creador = creador;
        }

        //Sobrecarga del operador ==
        public static bool operator ==(EmpresaElectronica e, ArtefactoElectronico a)
        {
            foreach (ArtefactoElectronico artefacto in e.productosElectronicos)
            {
                if (a == artefacto)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool operator !=(EmpresaElectronica e, ArtefactoElectronico a)
        {
            return !(e == a);
        }

        //Sobrecarga del operador + y -
        public static EmpresaElectronica operator +(EmpresaElectronica e, ArtefactoElectronico a)
        {
            if (e != a)
            {
                e.productosElectronicos.Add(a);
            }
            return e;
        }
        public static EmpresaElectronica operator -(EmpresaElectronica e, ArtefactoElectronico a)
        {
            if (e == a)
            {
                e.productosElectronicos.Remove(a);
            }
            return e;
        }

        /*Agregar la posibilidad de poder ordenar los objetos de la colección con, al menos, dos criterios
        distintos de ordenamiento. Cada criterio de ordenación deberá incluir el modo ascendente y descendente.*/

        //aca no son necesarios los returns, porque ya esos valores los va a recibir el Sort, y se va a encargar de ordenar
        //segun el retorno dado (en este caso no son necesarios porque se lo paso al sort, capaz q en otro caso si es necesario)

        //lavadero.Vehiculos.Sort(LavaderoClase.OrdenarVehiculosPorPatente);
        /*public static int OrdenarVehiculosPorPatente(Vehiculo v1, Vehiculo v2)
        {
            return String.Compare(v1.Patente, v2.Patente);
            /*if (String.Compare(v1.Patente, v2.Patente) == 0)
            {
                return 0;
            }
            else if (String.Compare(v1.Patente, v2.Patente) == -1) //la primera es menor, la letra 'a' < 'b'
            {
                return -1;
            }
            else //la segunda es mayor
            {
                return 1;
            }*/
        //}
        /*public int OrdenarVehiculosPorMarca(Vehiculo v1, Vehiculo v2)
        {
            return String.Compare(v1.Marca.ToString(), v2.Marca.ToString());

            /*if (String.Compare(v1.Marca.ToString(), v2.Marca.ToString()) == 0)
            {
                return 0;
            }
            else if (String.Compare(v1.Marca.ToString(), v2.Marca.ToString()) == -1)
            {
                return -1;
            }
            else
            {
                return 1;
            }*/
        //}
    }
}

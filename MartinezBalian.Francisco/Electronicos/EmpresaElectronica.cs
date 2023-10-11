using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Electronicos
{
    public sealed class EmpresaElectronica
    {
        //Atributos
        private string nombre;
        private string creador;
        private List<ArtefactoElectronico> productosElectronicos;

        //Propiedades
        public string Nombre
        {
            get { return nombre; }
        }
        public string Creador
        {
            get { return creador; }
        }
        public List<ArtefactoElectronico> ProductosElectronicos
        {
            get { return productosElectronicos; }
            set { productosElectronicos = value;}
        }
        /*public ArtefactoElectronico this[int i] //El num que se pasa (i) ya viene validado de afuera 
        {
            get
            {
                return this.productosElectronicos[i];
            }
        }*/


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

        //Equals, GetHashCode y ToString
        public override bool Equals(object? obj)
        {
            return this == (ArtefactoElectronico)obj;
        }
        public override int GetHashCode()
        {
            return productosElectronicos.Count;
        }
        public override string ToString()
        {
            return $"Nombre: {nombre} - Creador: {creador}";
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

        //Metodos ordenamientos
        public static int OrdenarArtefactosPorNombreAscendente(ArtefactoElectronico art1, ArtefactoElectronico art2)
        {
            return String.Compare(art1.Nombre, art2.Nombre);
            /*if (ascendente)
            {
                return String.Compare(art1.Nombre, art2.Nombre);
            }*/
            /*else
            {
                return String.Compare(art2.Nombre, art1.Nombre);
            }*/
            /*if (String.Compare(art1.Nombre, art2.Nombre) == 0)
            {
                return 0;
            }
            else if (String.Compare(art1.Nombre, art2.Nombre) == -1) //el primero es menor, la letra 'a' < 'b'
            {
                return -1;
            }
            else //la segunda es mayor
            {
                return 1;
            }*/
        }
        public static int OrdenarArtefactosPorNombreDescendente(ArtefactoElectronico art1, ArtefactoElectronico art2)
        {
            return String.Compare(art2.Nombre, art1.Nombre);
        }
        public static int OrdenarArtefactosPorPrecioAscendente(ArtefactoElectronico art1, ArtefactoElectronico art2)
        {
            return art1.Precio.CompareTo(art2.Precio);
            /*if (ascendente)
            {
                return art1.Precio.CompareTo(art2.Precio);
            }
            else
            {
                return art2.Precio.CompareTo(art1.Precio);
            }*/
            /*if (art1.Precio.CompareTo(art2.Precio) < 0)
            {
                Console.WriteLine("el valor de art1.Precio es menor al de art2.Precio");
            }
            else if (art1.Precio.CompareTo(art2.Precio) == 0)
            {
                Console.WriteLine("son iguales");
            }
            else
            {
                Console.WriteLine("el valor de art1.Precio es mayor al de art2.Precio");
            }*/
        }
        public static int OrdenarArtefactosPorPrecioDescendente(ArtefactoElectronico art1, ArtefactoElectronico art2)
        {
            return art2.Precio.CompareTo(art1.Precio);
        }
    }
}

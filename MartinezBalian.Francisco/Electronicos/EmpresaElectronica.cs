using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        /*Hacer indexador de string, que se ingrese un nombre y que devuelva ese producto, sino, devuelve un string vacio o null (chequear)*/
        public string Nombre
        {
            get { return nombre; }
        }
        public string Creador
        {
            get { return creador; }
        }

        //Constructor
        public EmpresaElectronica(string nombre, string creador)
        {
            this.productosElectronicos = new List<ArtefactoElectronico>();
            this.nombre = nombre;
            this.creador = creador;
        }


        /*Para ingresar objetos a dicha colección, solo se podrá hacer mediante la sobrecarga del operador de adición (+).*/

        /*Para eliminar objetos de la colección, solo se podrá hacer mediante la sobrecarga del operador de sustracción (-).*/

        /*Sobrecargar el operador de igualdad (==) para que permita indicar si un objeto de la jerarquía
        de clases está incluido en la colección o no.*/

        /*Tanto para agregar o eliminar objetos de la colección, se deberá verificar que el mismo esté, en
        el caso de la eliminación, o no esté, para el caso de la adición. Comparando objetos, según el criterio elegido.*/

        /*Agregar la posibilidad de poder ordenar los objetos de la colección con, al menos, dos criterios
        distintos de ordenamiento. Cada criterio de ordenación deberá incluir el modo ascendente y descendente.*/
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio_clase
{
    class Creadora
    {
        private static DateTime fechaCreacionPrimerObjeto; //de clase
        private static int contadorObjetosCreados; //de clase
        private DateTime fechaCreacion; //de instancia

        /*solo en las clases o metodos que no sean estaticos puedo usar el this*/

        static Creadora () //primero se ejecuta este (solo una vez) e inicializa los atributos
        {
            fechaCreacionPrimerObjeto = DateTime.Now;
            contadorObjetosCreados = 0;
        }
        public Creadora () //despues viene este q es de instancia, y suma el contador de objetos y guarda la fecha de creacion
            //se ejecuta siempre que creo un objeto
        {
            this.fechaCreacion = DateTime.Now;
            Creadora.contadorObjetosCreados++; //contadorObjetosCreados es de clase, ahi tengo q acceder mediante la Creadora.
        }
        /*a este es al q se le puede pasar parametros para ya inicializarlos (si pong string nombre, cuando creo el objeto
          tengo que hacer: Creadora objeto1 = new Creadora("nombre inicializado en constructor");)*/
        public static int ObtenerCantidadObjetosCreados() //solamente retorna la cantidad de objetos que se crearon
        {
            return contadorObjetosCreados;
        }
        public string ObtenerDiferencia()
        {
            TimeSpan diferencia = fechaCreacion - fechaCreacionPrimerObjeto; //la resta devuelve un objeto de TimeSpan
            return diferencia.TotalMilliseconds.ToString(); //paso la diferencia a milisegundos y despues a string
        }
}
}

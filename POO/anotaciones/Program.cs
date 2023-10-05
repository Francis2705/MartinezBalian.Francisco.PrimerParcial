/*me paro sobre el proyecto principal, click derecho, voy a referencia de proyecto, y ahi puedo agregar 
 referencias de proyectos que en realidad contendrian clases, es decir, haria un proyecto que se llame clases,
y en ese proyecto haria varias clases. Ademas de eso, tendria que hacer un using con el nombre del namespace del proyecto*/
namespace anotaciones
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            ClasePrueba variablePrueba = new ClasePrueba(); //asi creo un objeto
            //ClasePrueba() -> hace referencia al constructor de esa clase
        }
    }
}
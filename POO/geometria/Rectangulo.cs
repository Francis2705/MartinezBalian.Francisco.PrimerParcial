using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geometria
{
    public class Rectangulo
    {
        private float area;
        private float perimetro;
        private Punto vertice1;
        private Punto vertice2;
        private Punto vertice3;
        private Punto vertice4;

        public Rectangulo(Punto vertice1, Punto vertice3)
        {
            this.vertice1 = vertice1;
            this.vertice3 = vertice3;
            CalcularVertices(); //calcula vertices 2 y 4 a partir del 1 y 3
        }
        private void CalcularVertices()
        {
            float basE = Math.Abs(vertice3.GetX() - vertice1.GetX());
            float altura = Math.Abs(vertice3.GetY() - vertice1.GetY());

            this.vertice2 = new Punto((int)(vertice1.GetX() + basE), vertice1.GetY());
            this.vertice4 = new Punto((int)(vertice3.GetX() - basE), vertice3.GetY());

            this.area = basE * altura;
            this.perimetro = 2 * (basE + altura);
        }
        public float GetArea()
        {
            return area;
        }
        public float GetPerimetro()
        {
            return perimetro;
        }
        public Punto GetVertice1()
        {
            return vertice1;
        }
        public Punto GetVertice2()
        {
            return vertice2;
        }
        public Punto GetVertice3()
        {
            return vertice3;
        }
        public Punto GetVertice4()
        {
            return vertice4;
        }
    }
}

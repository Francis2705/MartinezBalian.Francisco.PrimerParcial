using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio_i_04
{
    internal class Boligrafo
    {
        private const short cantidadTintaMaxima = 100;
        private ConsoleColor color;
        private short tinta;
        public Boligrafo(short tinta, ConsoleColor color)
        {
            this.color = color;
            this.tinta = tinta;
        }
        public ConsoleColor GetColor()
        {
            return color;
        }
        public short GetTinta()
        {
            return tinta;
        }
        public void Pintar(short gasto, out string dibujo)
        {
            string asterisco = "*";
            dibujo = "";

            if (this.tinta == 0)
            {
                dibujo = "";
            }
            else if (this.tinta >= gasto)
            {
                for (short j = 0; j < gasto; j++)
                {
                    dibujo += asterisco;
                }
                this.tinta -= gasto;
            }
            else if (this.tinta < gasto)
            {
                for (short i = 0; i < this.tinta; i++)
                {
                    dibujo += asterisco;
                }
                this.tinta = 0;
            }
        }
        public void Recargar()
        {
            this.tinta = cantidadTintaMaxima;
        }
        /*private void SetTinta(short tinta)
        {
            short sumaTinta = (short)(this.tinta + tinta);
            if (sumaTinta > 0 && sumaTinta < 100)
            {
                this.tinta = sumaTinta;
            }
        }*/
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace JuegoTest.Model
{
    class Juego
    {
        private Random random = new Random();
        private bool pClick = false;
        private bool sClick = false;
        private int contador;
        private int pares = 0;
        private int dificultad;

        public void primerClickFalse()
        {
            this.pClick = false;
        }
        public void segundoClickFalse()
        {
            this.sClick = false;
        }
        public void primerClick()
        {
            this.pClick = true;
        }

        public void segundoClick()
        {
            this.sClick = true;
        }

        public bool getPrimerClick()
        {
            return this.pClick;
        }
        public bool getSegundoClick()
        {
            return this.sClick;
        }
        public void setContadorFacil()
        {
            this.contador = 40;
        }
        public void setContadorNormal()
        {
            this.contador = 35;
        }
        public void setContadorDificil()
        {
            this.contador = 25;
        }
        public void IniciarContador()
        {

            this.contador = this.contador - 1;
        }
        public int GetContador()
        {
            return this.contador;
        }
        public void restartPares()
        {
            this.pares = 0;
        }
        public void addPares()
        {
            this.pares = this.pares + 1;
        }

        public int getPares()
        {
            return this.pares;
        }

        public void setDificultad(int i)
        {
            //fácil = 1, normal = 3, difícil = 5
            this.dificultad = i;
        }

        public int getDificultad()
        {
            return this.dificultad;
        }
    }
}

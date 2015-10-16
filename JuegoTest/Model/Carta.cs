using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace JuegoTest.Model
{
    class Carta
    {

        private List<string> imagenes = new List<string>();

        private int num = 0;

        public void SetNumCarta(int i)
        {
            this.num = i;
        }

        public int GetNumCarta()
        {
            return this.num;
        }

        
    }
}

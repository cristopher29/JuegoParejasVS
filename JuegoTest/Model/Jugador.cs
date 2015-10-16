using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoTest.Model
{
    class Jugador
    {
        private String nombre;
        private int puntuacion;
        
        public Jugador()
        {
            this.nombre = " ";
        }
        public void SetNombre(string nm){
            this.nombre = nm;
        }
        public string GetNombre()
        {
            return this.nombre;
        }

        public int GetPuntuacion()
        {
            return this.puntuacion;
        }

        public void AddPuntos(int punto)
        {
            this.puntuacion += punto;
        }
        public void ReiniciarPuntos()
        {
            this.puntuacion = 0;
        }

    }
}

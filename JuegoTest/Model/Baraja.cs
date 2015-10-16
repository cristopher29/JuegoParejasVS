using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoTest.Model
{
    class Baraja
    {
        private List<string> imagenes = new List<string>();

        private Random random = new Random();

        public List<E> Mezclar<E>(List<E> inputList)
        {
            List<E> randomList = new List<E>();

            int randomIndex = 0;
            while (inputList.Count > 0)
            {
                randomIndex = random.Next(0, inputList.Count); //Escoge un objeto random de la lista
                randomList.Add(inputList[randomIndex]); //Lo agrega a una nueva lista (random)
                inputList.RemoveAt(randomIndex); //Quita el objeto de la anterior lista
            }

            return randomList; //Devuelve una nueva lista (random)
        }

        public void AgregarCartas()
        {

            this.imagenes.Add("1.png");
            this.imagenes.Add("1.png");
            this.imagenes.Add("2.png");
            this.imagenes.Add("2.png");
            this.imagenes.Add("3.png");
            this.imagenes.Add("3.png");
            this.imagenes.Add("4.png");
            this.imagenes.Add("4.png");
            this.imagenes.Add("5.png");
            this.imagenes.Add("5.png");
            this.imagenes.Add("6.png");
            this.imagenes.Add("6.png");
            this.imagenes.Add("7.png");
            this.imagenes.Add("7.png");
            this.imagenes.Add("8.png");
            this.imagenes.Add("8.png");

        }

        public List<string> ListaCartas()
        {
            return this.imagenes;
        }
    }
}

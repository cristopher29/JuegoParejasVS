using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JuegoTest.Model;
using System.Media;
using System.Data.SqlClient;
using Microsoft.VisualBasic;

namespace JuegoTest
{
    public partial class Form1 : Form
    {
        //fácil = 1, normal = 3, difícil = 5

        /**SoundPlayer sndplayr = new SoundPlayer(JuegoTest.Properties.Resources.Sound);**/
        /**SoundPlayer noOne = new SoundPlayer(JuegoTest.Properties.Resources.NoOne);**/

        Juego juego = new Juego();
        Carta cartas = new Carta();
        Baraja baraja = new Baraja();
        Jugador jugador = new Jugador();
        Puntuacion puntuacion = new Puntuacion();

        List<string> random = new List<string>();

        int primero, segundo;

        List<PictureBox> pictureBox = new List<PictureBox>();
        public Form1()
        {
            InitializeComponent();

            pictureBox.Add(pictureBox1);
            pictureBox.Add(pictureBox2);
            pictureBox.Add(pictureBox3);
            pictureBox.Add(pictureBox4);
            pictureBox.Add(pictureBox5);
            pictureBox.Add(pictureBox6);
            pictureBox.Add(pictureBox7);
            pictureBox.Add(pictureBox8);
            pictureBox.Add(pictureBox9);
            pictureBox.Add(pictureBox10);
            pictureBox.Add(pictureBox11);
            pictureBox.Add(pictureBox12);
            pictureBox.Add(pictureBox13);
            pictureBox.Add(pictureBox14);
            pictureBox.Add(pictureBox15);
            pictureBox.Add(pictureBox16);

            label1.Visible = false;
            label2.Visible = false;
            button2.Visible = false;
            dataGridView1.Visible = false;
            tableLayoutPanel1.Visible = false;

            for (int x = 0; x <= 15; x++)
            {
                pictureBox[x].Visible = false;

            }


        }

        private void Contador_Tick(object sender, EventArgs e)
        {
            juego.IniciarContador();
            label1.Text = juego.GetContador().ToString();
            if (juego.GetContador() == 0)
            {
                Contador.Enabled = false;
                timer1.Enabled = false;
                for (int x = 0; x <= 15; x++)
                {
                    pictureBox[x].Image = Image.FromFile("Imagenes/" + random[x]);
                    pictureBox[x].Enabled = false;
                }
                
                MessageBox.Show("Tiempo!");
                if (juego.getDificultad() == 1)
                {
                    juego.setContadorFacil();
                }
                else if (juego.getDificultad() == 3)
                {
                    juego.setContadorNormal();
                }
                else if (juego.getDificultad() == 5)
                {
                    juego.setContadorDificil();
                }
                jugador.ReiniciarPuntos();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            if (juego.getPrimerClick() == false)
            {
                juego.primerClick();
                primero = cartas.GetNumCarta();
                pictureBox[primero].Image = Image.FromFile("Imagenes/" + random[primero]);
            }
            else if (juego.getSegundoClick() == false)
            {
                juego.segundoClick();
                segundo = cartas.GetNumCarta();
                pictureBox[segundo].Image = Image.FromFile("Imagenes/" + random[segundo]);

            }


            if (juego.getPrimerClick() == true && juego.getSegundoClick() == true && primero != segundo)
            {

                if (random[primero] == random[segundo])
                {
                    pictureBox[primero].Image = Image.FromFile("Imagenes/" + random[primero]);
                    pictureBox[segundo].Image = Image.FromFile("Imagenes/" + random[segundo]);
                    pictureBox[primero].Enabled = false;
                    pictureBox[segundo].Enabled = false;
                    juego.addPares();
                    jugador.AddPuntos(juego.getDificultad());
                    if (juego.getPares() == (random.Count+1)/2)
                    {
                        Contador.Enabled = false;
                        MessageBox.Show("Completado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        jugador.SetNombre(Interaction.InputBox("Nombre del Jugador"));

                        while(jugador.GetNombre() == ""){
                            MessageBox.Show("Ingrese un nombre");
                            jugador.SetNombre(Interaction.InputBox("Nombre del Jugador"));
                        }
                        if (jugador.GetNombre() != "")
                        {
                            puntuacion.SetPuntuacion(jugador.GetPuntuacion(), juego.GetContador());
                            puntuacion.SetNombre(jugador.GetNombre());
                            puntuacion.SetTabla();
                            this.puntuacionTableAdapter.Fill(this.puntuacionDataSet.Puntuacion);
                            this.dataGridView1.Sort(this.dataGridView1.Columns[1], ListSortDirection.Descending);
                        }
                        
                    }
                    juego.primerClickFalse();
                    juego.segundoClickFalse();
                }
                else if (pictureBox[primero].Image != pictureBox[segundo].Image)
                {
                    timer1.Interval = 800;
                    timer1.Start();
                    
                }
            }
            else if (juego.getPrimerClick() == true && juego.getSegundoClick() == true && primero == segundo)
            {
                pictureBox[primero].Image = Image.FromFile("Imagenes/" + random[primero]);
                juego.segundoClickFalse();
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            pictureBox[primero].Image = Image.FromFile("Imagenes/Default.png");
            pictureBox[segundo].Image = Image.FromFile("Imagenes/Default.png");

            juego.primerClickFalse();
            juego.segundoClickFalse();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            cartas.SetNumCarta(0);
            button1.PerformClick();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            cartas.SetNumCarta(1);
            button1.PerformClick();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            cartas.SetNumCarta(2);
            button1.PerformClick();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            cartas.SetNumCarta(3);
            button1.PerformClick();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            cartas.SetNumCarta(4);
            button1.PerformClick();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            cartas.SetNumCarta(5);
            button1.PerformClick();
        }
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            cartas.SetNumCarta(6);
            button1.PerformClick();
        }
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            cartas.SetNumCarta(7);
            button1.PerformClick();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            cartas.SetNumCarta(8);
            button1.PerformClick();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            cartas.SetNumCarta(9);
            button1.PerformClick();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            cartas.SetNumCarta(10);
            button1.PerformClick();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            cartas.SetNumCarta(11);
            button1.PerformClick();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            cartas.SetNumCarta(12);
            button1.PerformClick();
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            cartas.SetNumCarta(13);
            button1.PerformClick();
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            cartas.SetNumCarta(14);
            button1.PerformClick();
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            cartas.SetNumCarta(15);
            button1.PerformClick();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baraja.AgregarCartas();
            random = baraja.Mezclar(baraja.ListaCartas());
            for (int x = 0; x <= 15; x++)
            {
                pictureBox[x].Image = Image.FromFile("Imagenes/Default.png");
                pictureBox[x].Enabled = true;

            }
            jugador.SetNombre("");
            juego.primerClickFalse();
            juego.segundoClickFalse();
            juego.restartPares();
            if(juego.getDificultad() == 1){
                juego.setContadorFacil();
            }
            else if (juego.getDificultad() == 3)
            {
                juego.setContadorNormal();
            }
            else if (juego.getDificultad() == 5)
            {
                juego.setContadorDificil();
            }
            jugador.ReiniciarPuntos();
            Contador.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'puntuacionDataSet.Puntuacion' table. You can move, or remove it, as needed.
            this.puntuacionTableAdapter.Fill(this.puntuacionDataSet.Puntuacion);
            this.dataGridView1.Sort(this.dataGridView1.Columns[1], ListSortDirection.Descending);
        }

        private void Facil_Click(object sender, EventArgs e)
        {
            Facil.Visible = false;
            Normal.Visible = false;
            Dificil.Visible = false;

            label1.Visible = true;
            label2.Visible = true;
            button2.Visible = true;
            dataGridView1.Visible = true;
            tableLayoutPanel1.Visible = true;

            for (int x = 0; x <= 15; x++)
            {
                pictureBox[x].Visible = true;

            }

            label1.Text = juego.GetContador().ToString();

            baraja.AgregarCartas();

            random = baraja.Mezclar(baraja.ListaCartas());

            for (int x = 0; x <= 15; x++)
            {
                pictureBox[x].Image = Image.FromFile("Imagenes/Default.png");

            }

            Contador.Enabled = true;

            juego.setContadorFacil();

            juego.setDificultad(1);
        }

        private void Normal_Click(object sender, EventArgs e)
        {
            Facil.Visible = false;
            Normal.Visible = false;
            Dificil.Visible = false;

            label1.Visible = true;
            label2.Visible = true;
            button2.Visible = true;
            dataGridView1.Visible = true;
            tableLayoutPanel1.Visible = true;

            for (int x = 0; x <= 15; x++)
            {
                pictureBox[x].Visible = true;

            }

            label1.Text = juego.GetContador().ToString();

            baraja.AgregarCartas();

            random = baraja.Mezclar(baraja.ListaCartas());

            for (int x = 0; x <= 15; x++)
            {
                pictureBox[x].Image = Image.FromFile("Imagenes/Default.png");

            }

            Contador.Enabled = true;

            juego.setContadorNormal();

            juego.setDificultad(3);
        }

        private void Dificil_Click(object sender, EventArgs e)
        {
            Facil.Visible = false;
            Normal.Visible = false;
            Dificil.Visible = false;

            label1.Visible = true;
            label2.Visible = true;
            button2.Visible = true;
            dataGridView1.Visible = true;
            tableLayoutPanel1.Visible = true;

            for (int x = 0; x <= 15; x++)
            {
                pictureBox[x].Visible = true;

            }


            label1.Text = juego.GetContador().ToString();

            baraja.AgregarCartas();

            random = baraja.Mezclar(baraja.ListaCartas());

            for (int x = 0; x <= 15; x++)
            {
                pictureBox[x].Image = Image.FromFile("Imagenes/Default.png");

            }

            Contador.Enabled = true;

            juego.setContadorDificil();

            juego.setDificultad(5);
        }

        

        

        

    }
}

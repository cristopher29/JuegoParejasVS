using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;


namespace JuegoTest.Model
{
    class Puntuacion
    {
        int suma;
        String nombre;

        public void SetPuntuacion(int punt, int cont)
        {
            suma = punt + cont;
        }

        public void SetNombre(string nom)
        {
            nombre = nom;
        }
        
        public void SetTabla()
        {
            SqlConnection cn = new SqlConnection(global::JuegoTest.Properties.Settings.Default.PuntuacionConnectionString);

            try
            {
                string sql = "INSERT INTO Puntuacion (Nombre,Score) values('" + nombre + "','" + suma + "')";
                SqlCommand exesql = new SqlCommand(sql, cn);
                cn.Open();
                exesql.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally
            {
                cn.Close();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ModernGUI_V3
{
    public partial class view : Form
    {

        public int alumnoId;
       


        public view(int id)
        {
            InitializeComponent();
            alumnoId = id;
            CargarInformacionAlumno();


        }

        private void view_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void CargarInformacionAlumno()
        {
            try
            {
                MySqlConnection conexion = new MySqlConnection("datasource=localhost;port=3306;username=root;password=Jaime1902#@;database=db_school;");

                conexion.Open();

                MySqlCommand command = new MySqlCommand("SELECT * FROM alumno WHERE id = @alumnoId", conexion);

                command.Parameters.AddWithValue("@alumnoId", alumnoId);

                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    label1.Text = reader.GetString("Nombre_apellido");
                    label2.Text = reader.GetString("lugar_nacimiento");
                    label3.Text = reader.GetDateTime("fecha_nacimiento").ToString("dd/MM/yyyy");
                    label4.Text = reader.GetString("codigo_estudiante");
                    label5.Text = reader.GetString("grado");
                    label6.Text = reader.GetString("Padecimiento");
                    label7.Text = reader.GetDateTime("fecha_inscripcion").ToString("dd/MM/yyyy");
                   
                }

                reader.Close();
                conexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    
   



    }
}

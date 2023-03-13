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
    public partial class Form2 : Form
    {
       

        public Form2()
        {
            InitializeComponent();
            dataGridView1.ReadOnly = true;

            string connectionString = "datasource=localhost;port=3306;username=root;password=Jaime1902#@;database=db_school;";

            dataGridView1.Columns.Add("id", "ID");
            dataGridView1.Columns.Add("nombre_apellido", "Nombre");
            dataGridView1.Columns.Add("fecha_nacimiento", "Fecha de Nacimiento");
            dataGridView1.Columns.Add("grado", "grado");

            // Obtener los datos de los usuarios de la base de datos
            string query = "SELECT id, Nombre_apellido, fecha_nacimiento FROM alumno";
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand command = new MySqlCommand(query, connection);

            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                // Agregar cada usuario como una fila en el DataGridView
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string nombre = reader.GetString(1);
                    DateTime fechaNacimiento = reader.GetDateTime(2);
                    dataGridView1.Rows.Add(id, nombre, fechaNacimiento.ToShortDateString());
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

    

    

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
         
          
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            // Obtener el ID del usuario seleccionado
            int id = (int)dataGridView1.Rows[e.RowIndex].Cells["id"].Value;

            // Crear una instancia del formulario DetalleAlumnoForm y pasarle el ID del usuario
            view detalleAlumnoForm = new view(id);
            detalleAlumnoForm.Show();
        }
    }
}

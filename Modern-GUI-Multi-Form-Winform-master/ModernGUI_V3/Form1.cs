using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModernGUI_V3
{
    public partial class Form1 : Form
    {

        
        string connectionString = "datasource=localhost;port=3306;username=root;password=Jaime1902#@;database=db_school;";
        // Diccionario que asigna un precio a cada opción del ComboBox

        private Dictionary<string, decimal> precios = new Dictionary<string, decimal>()
        {
            {"pre-escolar", 850},
            {"Grado 1", 870},
            {"Grado 2", 770},
            {"Grado 3", 770},
            {"Grado 4", 770},
            {"Grado 5", 770},
            {"Grado 6", 770},
            {"Año 1", 850},
            {"Año 2", 850},
            {"Año 3", 850},
            {"Año 4", 850},
            {"Año 5", 850}
        };



        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

            // Ajusta el tamaño del formulario al tamaño de sus controles
            this.AutoSize = true;
            comboBox1.Items.AddRange(new string[] { "Pre-escolar","Grado 1", "Grado 2", "Grado 3", "Grado 4", "Grado 5", "Grado 6", "Año 1", "Año 2", "Año 3", "Año 4", "Año 5" });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO alumno (Nombre_apellido, lugar_nacimiento, fecha_nacimiento, codigo_estudiante, grado, Padecimiento, fecha_inscripcion, Nombre_padre, Cedula_padre, Ocupacion_padre, Nombre_Madre, cedula_Madre, ocupacion_Madre, Telefono, Direccion) " +
                                  "VALUES (@nombre_apellido, @lugar_nacimiento, @fecha_nacimiento, @codigo_estudiante, @grado, @padecimiento, @fecha_inscripcion, @nombre_padre, @cedula_padre, @ocupacion_padre, @nombre_madre, @cedula_madre, @ocupacion_madre, @telefono, @direccion)";

            command.Parameters.AddWithValue("@nombre_apellido", textBox1.Text);
            command.Parameters.AddWithValue("@lugar_nacimiento", textBox2.Text);
            command.Parameters.AddWithValue("@fecha_nacimiento", dateTimePicker1.Value);
            command.Parameters.AddWithValue("@codigo_estudiante", textBox3.Text);
            command.Parameters.AddWithValue("@grado", comboBox1.SelectedItem.ToString());
            command.Parameters.AddWithValue("@padecimiento", textBox4.Text);
            command.Parameters.AddWithValue("@fecha_inscripcion", dateTimePicker2.Value);
            command.Parameters.AddWithValue("@nombre_padre", textBox5.Text);
            command.Parameters.AddWithValue("@cedula_padre", textBox7.Text);
            command.Parameters.AddWithValue("@ocupacion_padre", textBox6.Text);
            command.Parameters.AddWithValue("@nombre_madre", textBox8.Text);
            command.Parameters.AddWithValue("@cedula_madre", textBox10.Text);
            command.Parameters.AddWithValue("@ocupacion_madre", textBox9.Text);
            command.Parameters.AddWithValue("@telefono", textBox11.Text);
            command.Parameters.AddWithValue("@direccion", textBox12.Text);

            try
            {
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Se ha insertado un nuevo usuario correctamente.");
                }
                else
                {
                    MessageBox.Show("No se ha insertado ningún usuario.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error al insertar el usuario: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }


        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

            ((DateTimePicker)sender).CustomFormat = "dd/MM/yyyy";

        }

        private void dateTimePicker1_KeyPress(object sender, KeyPressEventArgs e)
        {
          

        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {
                ((DateTimePicker)sender).CustomFormat = " ";
                ((DateTimePicker)sender).Value = DateTimePicker.MinimumDateTime;
            }

            if (e.KeyCode == Keys.Enter && dateTimePicker1.Focused)
            {
                SendKeys.Send("{TAB}");
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {



        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtiene la opción seleccionada y su precio correspondiente
            string opcionSeleccionada = comboBox1.SelectedItem.ToString();
            decimal precio = precios[opcionSeleccionada];

            // Actualiza el texto del Label con el precio correspondiente
            label1.Text = $"Precio: {precio:C}";
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

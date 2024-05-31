using EXAMEN_FINAL_PROGRA.DATA.DATA_ACCES;
using Microsoft.VisualBasic.ApplicationServices;
using MySql.Data.MySqlClient;
using System.Data;
using System.Numerics;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace EXAMEN_FINAL_PROGRA
{
    public partial class Form1 : Form

    {
        model cls = new model();
        usuarios2 usr = new usuarios2();
        
       

        public Form1()
        {
            InitializeComponent();

        }


        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void limpiar_Click(object sender, EventArgs e)
        {
            if (cls.ProbarConexion())
            {
                MessageBox.Show("Conexión exitosa puede inciar con su registro");
            }
            else
            {
                MessageBox.Show("Error en la conexión");
            }
        }

        private void buscar_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow resp = cls.LeerPorId(int.Parse(textBoxid.Text));
                if (resp != null)
                {
                    textBoxplaca.Text = resp["placa"].ToString();
                    textBoxnombre.Text = resp["nombre"].ToString();
                    textBoxmarca.Text = resp["marca"].ToString();
                    textBoxdpi.Text = resp["dpi"].ToString();
                    textBoxprecio.Text = decimal.Parse(resp["precio"].ToString()).ToString();
                    dateTimePickerfecha1.Value = (DateTime)resp["fecha1"];
                    dateTimePickerfecha2.Value = (DateTime)resp["fecha2"];
                    textBoxnumero.Text = resp["numero"].ToString();
                    textBoxdes.Text = resp["des"].ToString();
                    checkBoxsaldo.Checked = (bool)resp["saldo"];

                }
                else
                {
                    MessageBox.Show("No se encontro el registro ");
                    LimpiarControles();

                }
            }
            catch
            {


                MessageBox.Show("porfavor no deje el campo vacio o ingrese un id valido gracias :) ");
                LimpiarControles();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void insertar_Click(object sender, EventArgs e)
        {
            try
            {
                usr.placa = textBoxplaca.Text;
                usr.nombre = textBoxnombre.Text;
                usr.marca = textBoxmarca.Text;
                usr.dpi = textBoxdpi.Text;
                usr.precio = decimal.Parse(textBoxprecio.Text);
                usr.saldo = checkBoxsaldo.Checked;
                usr.numero = int.Parse(textBoxnumero.Text);
                usr.des = textBoxdes.Text;
                usr.fecha1 = dateTimePickerfecha1.Value;
                usr.fecha2 = dateTimePickerfecha2.Value;
                cls.Insertar(usr);
                LimpiarControles();
                MessageBox.Show("Cliente ingresado con exito");
            }
            catch
            {
                MessageBox.Show("no ingrese el id cuando inserte un usuario  ");
                MessageBox.Show("llene los campos para insertar y no tener porblemas");
            }
        }

        private void actualizar_Click(object sender, EventArgs e)
        {
            try
            {
                usr.id = int.Parse(textBoxid.Text);
                usr.placa = textBoxplaca.Text;
                usr.nombre = textBoxnombre.Text;
                usr.marca = textBoxmarca.Text;
                usr.dpi = textBoxdpi.Text;
                usr.precio = decimal.Parse(textBoxprecio.Text);
                usr.saldo = checkBoxsaldo.Checked;
                usr.numero = int.Parse(textBoxnumero.Text);
                usr.des = textBoxdes.Text;
                usr.fecha1 = dateTimePickerfecha1.Value;
                usr.fecha2 = dateTimePickerfecha2.Value;
                cls.Actualizar(usr);
                LimpiarControles();


            }
            catch { MessageBox.Show(" ingrese un id y llene los campos a actualizar "); }

        }

        private void buscarfh_Click(object sender, EventArgs e)
        {

            DateTime fecha1 = dateTimePickerfecha1.Value;
            dataGridView1.DataSource = cls.Buscarfecha(fecha1);

        }

       
        private void button7_Click(object sender, EventArgs e)
        {
          
        }

        private void todoslosusuario_Click(object sender, EventArgs e)
        {

            dataGridView1.DataSource = cls.LeerTodos();
        }

        private void eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int idPersonajeAEliminar = int.Parse(textBoxid.Text);

                // Llamar a la función EliminarPersonaje con el ID del personaje
                cls.EliminarPersonaje(idPersonajeAEliminar);

                // Mostrar un mensaje de éxito
                MessageBox.Show("Personaje eliminado correctamente.");

                // Limpiar los controles después de la eliminación si es necesario
                LimpiarControles();
            }
            catch (Exception ex)
            {
                // Manejar cualquier error que pueda ocurrir
                MessageBox.Show($"Error al eliminar el personaje: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LimpiarControles()
        {
            // Limpiar los controles después de la eliminación si es necesario
            textBoxid.Clear();
            textBoxplaca.Clear();
            textBoxnombre.Clear();
            textBoxmarca.Clear();
            textBoxdpi.Clear();
            textBoxprecio.Clear();
            textBoxnumero.Clear();
            textBoxdes.Clear();
            checkBoxsaldo.Checked = false;
            dateTimePickerfecha1.Value = DateTime.Now;
            dateTimePickerfecha2.Value = DateTime.Now;

            dataGridView1.DataSource = null;

        }


        private void limpiar_Click_1(object sender, EventArgs e)
        {
            LimpiarControles();
        }


        private void buscarplaca_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxplaca.Text))
            {
                string placa = textBoxplaca.Text;
                dataGridView1.DataSource = cls.Buscarplaca(placa);
                textBoxplaca.Clear();
            }
            else
            {
                MessageBox.Show("Por favor, ingresa un valor en el campo de placa");

            }
        }

        private void des_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxdes.Text))
            {
                string des = textBoxdes.Text;
                dataGridView1.DataSource = cls.Buscardes(des);
                textBoxdes.Clear();
            }
            else
            {
                MessageBox.Show("Por favor, ingresa un valor en el campo de descripcion.");

            }
        }

        private void dpi_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxdpi.Text))
            {
                string dpi = textBoxdpi.Text;
                dataGridView1.DataSource = cls.Buscardpi(dpi);
                textBoxdpi.Clear();
            }
            else
            {
                MessageBox.Show("Por favor, ingresa un valor en el campo de dpi.");

            }
        }

        private void buscarnombre_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxnombre.Text))
            {
                string nombre = textBoxnombre.Text;
                dataGridView1.DataSource = cls.Buscarnombre(nombre);
                textBoxnombre.Clear();
            }
            else
            {
                MessageBox.Show("Por favor, ingresa un valor en el campo de nombre.");

            }
        }

        private void buscarfechasalida_Click(object sender, EventArgs e)
        {
            DateTime fecha2 = dateTimePickerfecha2.Value;
            dataGridView1.DataSource = cls.Buscarfecha1(fecha2);
        }

        private void textBoxnombre_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
    


using System;
using System.Windows.Forms;

namespace Práctica_1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            // Asigna el evento KeyPress a las cajas de texto para validación
            txtNombre.KeyPress += DynamicTextKeyPress;
            txtNumero.KeyPress += DynamicTextKeyPress;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        // Evento del menú "Acerca de" para mostrar información del programa
        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Alumno: Diego Gastelum Martínez" + Environment.NewLine + "Grupo: 4SB" +
            Environment.NewLine + "No. de control: 23760352" + Environment.NewLine + Environment.NewLine + "Este programa funciona como un gestor de contactos en " +
            "el que puedes agregar, eliminar y limpiar el nombre, número de teléfono y correo de un contacto.");
        }

        // Evento para agregar un contacto a la lista
        private void bttnAgregar_Click(object sender, EventArgs e)
        {
            DynamicTextKeyPress(txtNombre, new KeyPressEventArgs((char)Keys.Enter));
            DynamicTextKeyPress(txtNumero, new KeyPressEventArgs((char)Keys.Enter));

            // Verifica que los 3 campos estén llenos 
            if (string.IsNullOrEmpty(txtCorreo.Text) || string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtNumero.Text))
            {
                MessageBox.Show("Ingresa Nombre, Correo y Teléfono", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show("¿Desea guardar este contacto?", "Guardar contacto", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                // Añade el contacto a la lista
                string contacto = $"Nombre: {txtNombre.Text} | Correo electrónico: {txtCorreo.Text} | Teléfono: {txtNumero.Text}";
                lstContactos.Items.Add(contacto);
                txtNombre.Clear();
                txtCorreo.Clear();
                txtNumero.Clear();
            }
        }

        // Evento para eliminar un contacto seleccionado de la lista
        private void bttnEliminar_Click(object sender, EventArgs e)
        {
            if (lstContactos.SelectedIndex != -1)
            {
                lstContactos.Items.RemoveAt(lstContactos.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Selecciona el contacto a eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Evento para limpiar la lista de contactos
        private void bttnLimpiar_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Desea limpiar la lista de contactos?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                lstContactos.Items.Clear();
            }
        }

        // Evento para cerrar la aplicación
        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Método para validar la entrada de las cajas de texto
        private void DynamicTextKeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                if (textBox.Name == "txtNombre") // Solo permite letras en el campo de Nombre
                {
                    if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
                    {
                        e.Handled = true;
                    }
                }
                else if (textBox.Name == "txtNumero") // Solo permite números en el campo de Teléfono
                {
                    if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                    {
                        e.Handled = true;
                    }
                }
                // No se aplica restricción a txtCorreo, ya que debe aceptar letras, números y caracteres especiales
            }
        }
    }
}

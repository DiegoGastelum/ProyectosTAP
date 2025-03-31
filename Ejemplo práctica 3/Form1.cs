using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibreríaCustom;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Práctica_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            string texto = txtBox1.Text;

            if (InputValidator.EsSoloNumeros(texto))
                MessageBox.Show("Solo números");
            else if (InputValidator.EsSoloLetras(texto))
                MessageBox.Show("Solo letras");
            else
                MessageBox.Show("Mezcla de números y letras");
        }

        private void txtBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRFC_Click(object sender, EventArgs e)
        {
            string rfc = txtBoxRFC.Text;

            if (RFCValidator.EsRFCValido(ref rfc)) 
            {
                MessageBox.Show("RFC válido: " + rfc, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("RFC inválido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            txtBoxRFC.Text = rfc; // Asegura que el RFC en el TextBox esté en mayúsculas
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

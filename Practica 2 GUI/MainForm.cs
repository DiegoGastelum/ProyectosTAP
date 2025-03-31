using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Practica_2
{
    public partial class MainForm : Form
    {
        private readonly string imageDirectory = Path.Combine(Application.StartupPath, "Imagenes");
        private readonly string[] validExtensions = { "*.jpg", "*.jpeg", "*.png", "*.bmp", "*.gif", "*.tiff", "*.webp" };
        private string lastOpenedImage = null; // Variable para almacenar la última imagen abierta

        public MainForm()
        {
            InitializeComponent();
            Directory.CreateDirectory(imageDirectory); // Crea la carpeta si no existe
            LoadThumbnails();
            this.Resize += MainForm_Resize;

            // Asigna eventos a los botones existentes en el formulario
            btnAgregar.Click += BtnAgregar_Click;
            btnEliminar.Click += BtnEliminar_Click;
            btnCarpeta.Click += BtnCarpeta_Click;
            btnAgregar.BringToFront();
            btnEliminar.BringToFront();
            btnCarpeta.BringToFront();
        }

        private void LoadThumbnails()
        {
            flowPanel.Controls.Clear();  // Limpiar los controles previos

            if (!Directory.Exists(imageDirectory))
            {
                MessageBox.Show("El directorio de imágenes no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Obtiene los archivos de imágenes válidos
            string[] files = validExtensions.SelectMany(ext => Directory.GetFiles(imageDirectory, ext)).ToArray();

            foreach (string file in files)
            {
                var picBox = new PictureBox
                {
                    Image = Image.FromFile(file),
                    Width = 100,
                    Height = 100,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Cursor = Cursors.Hand,
                    Tag = file // Guardamos la ruta completa de la imagen
                };

                // Evento para abrir la imagen al hacer clic
                picBox.Click += (sender, e) => OpenImageInNewWindow((PictureBox)sender);

                flowPanel.Controls.Add(picBox);
            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            int anchoPanel = flowPanel.Width;
            int numeroDeImagenesPorFila = anchoPanel / 220;
            if (numeroDeImagenesPorFila == 0)
            {
                numeroDeImagenesPorFila = 1;
            }
            int nuevoAncho = (anchoPanel / numeroDeImagenesPorFila) - 10;

            foreach (PictureBox pictureBox in flowPanel.Controls)
            {
                pictureBox.Width = nuevoAncho;
                pictureBox.Height = nuevoAncho;
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Imágenes|*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.tiff;*.webp",
                Multiselect = true, // Permite seleccionar varias imágenes
                Title = "Seleccionar imágenes"
            })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    foreach (string filePath in ofd.FileNames)
                    {
                        string fileName = Path.GetFileName(filePath);
                        string destFile = Path.Combine(imageDirectory, fileName);
                        int count = 1;
                        while (File.Exists(destFile))
                        {
                            string newFileName = $"{Path.GetFileNameWithoutExtension(fileName)}_{count}{Path.GetExtension(fileName)}";
                            destFile = Path.Combine(imageDirectory, newFileName);
                            count++;
                        }

                        try
                        {
                            File.Copy(filePath, destFile, true);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error al copiar {fileName}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    LoadThumbnails(); // Recargar las miniaturas después de agregar nuevas imágenes
                }
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lastOpenedImage) && File.Exists(lastOpenedImage))
            {
                try
                {
                    // Liberar los recursos de la imagen
                    foreach (PictureBox pictureBox in flowPanel.Controls)
                    {
                        if (pictureBox.Tag?.ToString() == lastOpenedImage)
                        {
                            pictureBox.Image?.Dispose();
                            pictureBox.Dispose();
                            break;
                        }
                    }

                    // Eliminar el archivo de la carpeta
                    File.Delete(lastOpenedImage);

                    // Limpiar la variable de la última imagen abierta
                    lastOpenedImage = null;

                    // Recargar las miniaturas después de eliminar
                    LoadThumbnails();

                    MessageBox.Show("La última imagen abierta ha sido eliminada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar la imagen: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No se ha abierto ninguna imagen para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnCarpeta_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", imageDirectory);
        }

        private void OpenImageInNewWindow(PictureBox clickedPictureBox)
        {
            if (clickedPictureBox.Tag is string filePath && File.Exists(filePath))
            {
                // Guarda la última imagen abierta para poder eliminarla después
                lastOpenedImage = filePath;

                string imageName = Path.GetFileNameWithoutExtension(filePath);
                ImagenForm imageForm = new ImagenForm(filePath, imageName);
                imageForm.Show();
            }
            else
            {
                MessageBox.Show("La imagen no existe o no se puede abrir.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Diego Gastelum Martínez" + "\nGrupo: 4SB" + "\nEste programa funciona como una galería de imagenes. Para" +
                " \nabrir una imagen tienes que hacer click sobre ella, para agregar una presionar el botón de Agregar y seleccionar una imagen," +
                "\npara eliminar se tiene que abrir la imagen primero, el último botón muestra la carpeta donde se guardan las imagenes.");
        }

        private void MainForm_Load_1(object sender, EventArgs e)
        {

        }
    }

    // Formulario para mostrar la imagen en tamaño completo
    public partial class ImagenForm : Form
    {
        private readonly string imagePath;
        private readonly string imageName;

        public ImagenForm(string imagePath, string imageName)
        {
            InitializeComponent();
            this.imagePath = imagePath;
            this.imageName = imageName;

            // Configurar la imagen y el título del formulario
            this.Text = imageName; // Título con el nombre de la imagen
            PictureBox pictureBox = new PictureBox
            {
                Image = Image.FromFile(imagePath),
                SizeMode = PictureBoxSizeMode.Zoom,
                Dock = DockStyle.Fill
            };
            this.Controls.Add(pictureBox);
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            // Libera los recursos de la imagen que se mostró
            foreach (Control ctrl in Controls)
            {
                if (ctrl is PictureBox pb)
                {
                    pb.Image?.Dispose();
                }
            }
        }
    }
}

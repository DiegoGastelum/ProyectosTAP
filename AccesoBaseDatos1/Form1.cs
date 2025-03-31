using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AccesoBaseDatos1
{
    public partial class Form1 : Form
    {
        private string Servidor = "DiegoPC\\SQLEXPRESS";
        private string Basedatos = "master";
        private string UsuarioId = "sa";
        private string Password = "12345";
        private string BasedatosMySQL = "localhost";
        private string UsuarioIdMySQL = "root";
        private string PasswordMySQL = "";
        private void EjecutaComando(string ConsultaSQL)
        {
            try
            {
                string strConn = $"Server={Servidor};" +
                    $"Database={Basedatos};" +
                    $"User Id={UsuarioId};" +
                    $"Password={Password}";

                if(chkSQLServer.Checked)
                {
                    SqlConnection conn = new SqlConnection(strConn);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = ConsultaSQL;
                    cmd.ExecuteNonQuery();
                }

                llenarGrid();

            }
            catch (SqlException Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error en el sistema");
            }
        }
        private void llenarGrid()
        {
            try
            {
                string strConn = $"Server={Servidor};" +
                    $"Database={Basedatos};" +
                    $"User Id={UsuarioId};" +
                    $"Password={Password}";

                if (chkSQLServer.Checked)
                {
                    SqlConnection conn = new SqlConnection(strConn);
                    conn.Open();

                    string sqlQuery = "select * from Alumnos";
                    SqlDataAdapter adp = new SqlDataAdapter(sqlQuery, conn);

                    DataSet ds = new DataSet();
                    adp.Fill(ds, "Alumnos");
                    dgvAlumnos.DataSource = ds.Tables[0];
                }

                dgvAlumnos.Refresh();
            }
            catch (SqlException Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error en el sistema");
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void btnCrearBD_Click(object sender, EventArgs e)
        {
            try
            {              
                string strConn = $"Server={Servidor};" +
                    $"Database=master;" +
                    $"User Id={UsuarioId};" +
                    $"Password={Password}";

                if (chkSQLServer.Checked)
                {
                    SqlConnection conn = new SqlConnection(strConn);
                    conn.Open();

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "CREATE DATABASE ESCOLAR";
                    cmd.ExecuteNonQuery();

                }


            }
            catch (SqlException  Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            catch (Exception Ex )
            {
                MessageBox.Show("Error en el sistema");
            }
        }

        private void btnCreaTabla_Click(object sender, EventArgs e)
        {
            EjecutaComando("CREATE TABLE " +
                    "Alumnos (NoControl varchar(10), nombre varchar(50), carrera int)");
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNoControl.Text.Trim().Length == 0 &&
                    txtNombre.Text.Trim().Length == 0 &&
                    txtCarrera.Text.Trim().Length == 0)
                {
                    string strConn = $"Server={Servidor};" +
                        $"Database={Basedatos};" +
                        $"User Id={UsuarioId};" +
                        $"Password={Password}";

                    if (chkSQLServer.Checked)
                    {
                        SqlConnection conn = new SqlConnection(strConn);
                        conn.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandText = "INSERT INTO " +
                            "Alumnos (NoControl, nombre, carrera) " +
                            "VALUES ('" + txtNoControl.Text +
                            "', '" + txtNombre.Text +
                            "', " + txtCarrera.Text + ")";
                        cmd.ExecuteNonQuery();
                    }

                    llenarGrid();
                }

            }
            catch (SqlException Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error en el sistema");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            chkSQLServer.Checked = true;
            llenarGrid();
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            llenarGrid();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNoControl.Text.Trim().Length > 0 ||
                    txtNombre.Text.Trim().Length > 0 ||
                    txtCarrera.Text.Trim().Length > 0)
                {
                    string strConn = $"Server={Servidor};" +
                        $"Database={Basedatos};" +
                        $"User Id={UsuarioId};" +
                        $"Password={Password}";

                    if (chkSQLServer.Checked)
                    {
                        SqlConnection conn = new SqlConnection(strConn);
                        conn.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandText = "UPDATE Alumnos SET nombre=@Nombre, carrera=@Carrera WHERE NoControl=@NoControl";

                        cmd.Parameters.AddWithValue("@NoControl", txtNoControl.Text);
                        cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                        cmd.Parameters.AddWithValue("@Carrera", txtCarrera.Text);

                        cmd.ExecuteNonQuery();
                        conn.Close();

                        llenarGrid(); 
                    }
                }
                else
                {
                    MessageBox.Show("Todos los campos son obligatorios.");
                }
            }
            catch (SqlException Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error en el sistema");
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNoControl.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Ingrese el NoControl del alumno a eliminar.");
                    return;
                }

                string strConn = $"Server={Servidor};" +
                    $"Database={Basedatos};" +
                    $"User Id={UsuarioId};" +
                    $"Password={Password}";

                if (chkSQLServer.Checked)
                {
                    SqlConnection conn = new SqlConnection(strConn);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "DELETE FROM Alumnos WHERE NoControl = '" + txtNoControl.Text + "'";
                    cmd.ExecuteNonQuery();
                }

                llenarGrid();
            }
            catch (SqlException Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error en el sistema");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNoControl.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Ingrese el NoControl del alumno a buscar.");
                    return;
                }

                string strConn = $"Server={Servidor};" +
                    $"Database={Basedatos};" +
                    $"User Id={UsuarioId};" +
                    $"Password={Password}";

                if (chkSQLServer.Checked)
                {
                    SqlConnection conn = new SqlConnection(strConn);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT * FROM Alumnos WHERE NoControl = '" + txtNoControl.Text + "'";

                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adp.Fill(ds, "Alumnos");

                    if (ds.Tables["Alumnos"].Rows.Count > 0)
                    {
                        DataRow row = ds.Tables["Alumnos"].Rows[0];
                        txtNombre.Text = row["nombre"].ToString();
                        txtCarrera.Text = row["carrera"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Alumno no encontrado.");
                    }
                }
            }
            catch (SqlException Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error en el sistema");
            }
        }
    }
}

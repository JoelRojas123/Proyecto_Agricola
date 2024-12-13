using Proyecto_Agricola.Clases;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Proyecto_Agricola.Formularios
{
    public partial class FrmCultivos : Form
    {
        ConexionSQL x = new ConexionSQL();
        SqlConnection con = new SqlConnection();
        public FrmCultivos()
        {
            InitializeComponent();
            con.ConnectionString = x.Conexion;
        }

        void limpiar()
        {
            txtID.Clear();
            txtNombre.Clear();
            txtTemporada.Clear();
            txtCiclo.Clear();
            Clases.Herramientas h = new Herramientas();
            txtID.Text = h.consecutivo("ID", "CULTIVOS").ToString();
            txtNombre.Focus();
            txtTemporada.Focus();
            txtCiclo.Focus();
        }

        bool encontro()
        {
            bool a = false;
            int ID = int.Parse(txtID.Text);
            string cadena = $"SELECT * FROM CULTIVOS WHERE ID = {ID}";
            con.Open();
            SqlCommand cmd = new SqlCommand(cadena, con);
            SqlDataReader lector = cmd.ExecuteReader();
            if (lector.Read())
            {
                a = true;
            }
            else
            {
                a = false;
            }
            con.Close();
            return a;
        }

        private void tsGuardar_Click(object sender, EventArgs e)
        {
            Clases.Cultivos x = new Clases.Cultivos();
            x.ID = int.Parse(txtID.Text);
            x.NOMBRE = txtNombre.Text;
            x.TEMPORADA = txtTemporada.Text;
            x.CICLO = txtCiclo.Text;
            if (encontro() == true)
            {
                MessageBox.Show(x.actualizar());
            }
            else
            {
                MessageBox.Show(x.guardar());
            }
            limpiar();

            
        }

        private void FrmCultivos_Load(object sender, EventArgs e)
        {
            Clases.Herramientas h = new Clases.Herramientas();
            txtID.Text = h.consecutivo("ID", "CULTIVOS").ToString();
        }

        private void tsBuscar_Click(object sender, EventArgs e)
        {
            Busquedas.FrmBusquedaCultivos x = new Busquedas.FrmBusquedaCultivos();
            x.ShowDialog();
            if (x.DialogResult == DialogResult.OK)
            {
                txtID.Text = x.dgCultivos.SelectedRows[0].Cells["ID"].Value.ToString();
                txtNombre.Text = x.dgCultivos.SelectedRows[0].Cells["NOMBRE"].Value.ToString();
                txtTemporada.Text = x.dgCultivos.SelectedRows[0].Cells["TEMPORADA"].Value.ToString();
                txtCiclo.Text = x.dgCultivos.SelectedRows[0].Cells["CICLO"].Value.ToString();
            }


        }
        void obtener()
        {
            string consulta = $"SELECT * FROM CULTIVOS WHERE ID = {txtID.Text}";
            con.Open();
            SqlCommand cmd = new SqlCommand(consulta, con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                txtNombre.Text = reader["NOMBRE"].ToString();
                txtTemporada.Text = reader["TEMPORADA"].ToString();
                txtCiclo.Text = reader["CICLO"].ToString();
            }

            con.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "0" || txtID.Text == "")
            {
                MessageBox.Show("ID no valido.");
            }
            else
            {
                obtener();
            }
        }

        private void tsLimpiar_Click(object sender, EventArgs e)
        {
            txtID.Clear();
            txtNombre.Clear();
            txtTemporada.Clear();
            txtCiclo.Clear();
            Clases.Herramientas H = new Herramientas();
            limpiar();
        }

        private void tsEliminar_Click(object sender, EventArgs e)
        {
            Clases.Cultivos x = new Clases.Cultivos();
            x.ID = int.Parse(txtID.Text);
            MessageBox.Show(x.eliminar());
            limpiar();
        }
    }
}

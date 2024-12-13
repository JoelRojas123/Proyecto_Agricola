using Proyecto_Agricola.Clases;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Proyecto_Agricola.Formularios
{
    public partial class FrmP_Mantenimiento : Form
    {
        ConexionSQL x = new ConexionSQL();
        SqlConnection con = new SqlConnection();
        public FrmP_Mantenimiento()
        {
            InitializeComponent();
            con.ConnectionString = x.Conexion;
        }

        private void tsGuardar_Click(object sender, EventArgs e)
        {
            Clases.Personal x = new Clases.Personal();
            x.ID = int.Parse(txtID.Text);
            x.NOMBRE = txtNombre.Text;
            x.APELLIDOS = txtApellidos.Text;
            x.CARGO = txtCargo.Text;
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

        void limpiar()
        {
            txtID.Clear();
            txtNombre.Clear();
            txtApellidos.Clear();
            txtCargo.Clear();
            Clases.Herramientas h = new Herramientas();
            txtID.Text = h.consecutivo("ID", "P_MANTENIMIENTO").ToString();
            txtNombre.Focus();
            txtApellidos.Focus();
            txtCargo.Focus();


        }

        bool encontro()
        {
            bool a = false;
            int ID = int.Parse(txtID.Text);
            string cadena = $"SELECT * FROM P_MANTENIMIENTO WHERE ID = {ID}";
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

        void obtener()
        {
            string consulta = $"SELECT * FROM P_MANTENIMIENTO WHERE ID = {txtID.Text}";
            con.Open();
            SqlCommand cmd = new SqlCommand(consulta, con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                txtNombre.Text = reader["NOMBRE"].ToString();
                txtApellidos.Text = reader["APELLIDOS"].ToString();
                txtCargo.Text = reader["CARGO"].ToString();
            }
        }

        private void tsBuscar_Click(object sender, EventArgs e)
        {
            Busquedas.FrmBusquedaP_Mantenimiento x = new Busquedas.FrmBusquedaP_Mantenimiento();
            x.ShowDialog();
            if (x.DialogResult == DialogResult.OK)
            {
                txtID.Text = x.dgP_Mantenimiento.SelectedRows[0].Cells["ID"].Value.ToString();
                txtNombre.Text = x.dgP_Mantenimiento.SelectedRows[0].Cells["NOMBRE"].Value.ToString();
                txtApellidos.Text = x.dgP_Mantenimiento.SelectedRows[0].Cells["APELLIDOS"].Value.ToString();
                txtCargo.Text = x.dgP_Mantenimiento.SelectedRows[0].Cells["CARGO"].Value.ToString();
            }
        }

        private void tsLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void tsEliminar_Click(object sender, EventArgs e)
        {
            Clases.Personal x = new Clases.Personal();
            x.ID = int.Parse(txtID.Text);
            MessageBox.Show(x.eliminar());
            limpiar();
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

        private void FrmP_Mantenimiento_Load(object sender, EventArgs e)
        {
            Clases.Herramientas h = new Clases.Herramientas();
            txtID.Text = h.consecutivo("ID", "P_MANTENIMIENTO").ToString();
        }
    }
}

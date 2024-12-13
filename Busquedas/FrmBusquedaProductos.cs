using Proyecto_Agricola.Clases;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Proyecto_Agricola.Busquedas
{
    public partial class FrmBusquedaProductos : Form
    {
        ConexionSQL x = new ConexionSQL();
        SqlConnection con = new SqlConnection();
        public FrmBusquedaProductos()
        {
            InitializeComponent();
            con.ConnectionString = x.Conexion;
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            cargardg();
        }

        private void FrmBusquedaProductos_Load(object sender, EventArgs e)
        {
            try
            {
                dgProductos.Rows[0].Selected = true;
            }
            catch
            {

            }
        }

        void cargardg()
        {
            DataTable dt = new DataTable();
            con.Open();
            SqlCommand cmd = new SqlCommand($"Select * from PRODUCTOS where FECHA_COSECHA LIKE '%{txtFiltro.Text}%'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dgProductos.DataSource = dt;
            con.Close();
        }

        private void dgProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgProductos.CurrentRow.Index;
            dgProductos.Rows[i].Selected = true;
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            cargardg();
        }
    }
}

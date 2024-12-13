using Proyecto_Agricola.Clases;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Proyecto_Agricola.Busquedas
{
    public partial class FrmBusquedaVentas : Form
    {
        ConexionSQL x = new ConexionSQL();
        SqlConnection con = new SqlConnection();
        public FrmBusquedaVentas()
        {
            InitializeComponent();
            con.ConnectionString = x.Conexion;
        }

        private void FrmBusquedaVentas_Load(object sender, EventArgs e)
        {
            try
            {
                dgVentas.Rows[0].Selected = true;
            }
            catch
            {

            }
        }

        void cargardg()
        {
            DataTable dt = new DataTable();
            con.Open();
            SqlCommand cmd = new SqlCommand($"SELECT * FROM VENTAS WHERE FECHA_VENTA LIKE '%{txtFiltro.Text}%'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dgVentas.DataSource = dt;
            con.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            cargardg();
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            cargardg();
        }

        private void dgVentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgVentas.CurrentRow.Index;
            dgVentas.Rows[i].Selected = true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}

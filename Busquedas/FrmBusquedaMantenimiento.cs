using Proyecto_Agricola.Clases;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Proyecto_Agricola.Busquedas
{
    public partial class FrmBusquedaMantenimiento : Form
    {
        ConexionSQL x = new ConexionSQL();
        SqlConnection con = new SqlConnection();
        public FrmBusquedaMantenimiento()
        {
            InitializeComponent();
            con.ConnectionString = x.Conexion;
        }

        void cargardg()
        {
            DataTable dt = new DataTable();
            con.Open();
            SqlCommand cmd = new SqlCommand($"SELECT * FROM MANTENIMIENTO_MAQUINARIA WHERE FECHA LIKE '%{txtFiltro.Text}%'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dgMantenimiento.DataSource = dt;
            con.Close();
        }



        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            cargardg();
        }

        private void FrmBusquedaMantenimiento_Load(object sender, EventArgs e)
        {
            try
            {
                dgMantenimiento.Rows[0].Selected = true;
            }
            catch
            {

            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            cargardg();
        }

        private void dgVentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgMantenimiento.CurrentRow.Index;
            dgMantenimiento.Rows[i].Selected = true;
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

using Proyecto_Agricola.Clases;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Proyecto_Agricola.Busquedas
{
    public partial class FrmBusquedaParcela : Form
    {
        ConexionSQL x = new ConexionSQL();
        SqlConnection con = new SqlConnection();
        public FrmBusquedaParcela()
        {
            InitializeComponent();
            con.ConnectionString = x.Conexion;
        }

        private void FrmBusquedaParcela_Load(object sender, EventArgs e)
        {
            try
            {
                dgParcelas.Rows[0].Selected = true;
            }
            catch
            {

            }
        }

        void cargardg()
        {
            DataTable dt = new DataTable();
            con.Open();
            SqlCommand cmd = new SqlCommand($"SELECT * FROM PARCELAS WHERE ID LIKE '%{txtFiltro.Text}%'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dgParcelas.DataSource = dt;
            con.Close();
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            cargardg();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            cargardg();
        }

        private void dgParcelas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void dgParcelas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgParcelas.CurrentRow.Index;
            dgParcelas.Rows[i].Selected = true;
        }
    }
}

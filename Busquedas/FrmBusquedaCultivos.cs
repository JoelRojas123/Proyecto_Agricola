using Proyecto_Agricola.Clases;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Proyecto_Agricola.Busquedas
{
    public partial class FrmBusquedaCultivos : Form
    {
        ConexionSQL x = new ConexionSQL();
        SqlConnection con = new SqlConnection();
        public FrmBusquedaCultivos()
        {
            InitializeComponent();
            con.ConnectionString = x.Conexion;
        }

        private void FrmBusquedaCultivos_Load(object sender, System.EventArgs e)
        {
            try
            {
                dgCultivos.Rows[0].Selected = true;
            }
            catch
            {

            }
        }

        void cargardg()
        {
            DataTable dt = new DataTable();
            con.Open();
            SqlCommand cmd = new SqlCommand($"SELECT * FROM CULTIVOS WHERE NOMBRE LIKE '%{txtFiltro.Text}%'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dgCultivos.DataSource = dt;
            con.Close();
        }

        private void txtFiltro_TextChanged(object sender, System.EventArgs e)
        {
            cargardg();
        }

        private void btnBuscar_Click(object sender, System.EventArgs e)
        {
            cargardg();
        }

        private void btnAceptar_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnBorrar_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void dgCultivos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgCultivos.CurrentRow.Index;
            dgCultivos.Rows[i].Selected = true;
        }
    }
}


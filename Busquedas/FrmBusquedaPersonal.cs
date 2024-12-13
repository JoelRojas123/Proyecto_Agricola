using Proyecto_Agricola.Clases;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Proyecto_Agricola.Busquedas
{
    public partial class FrmBusquedaPersonal : Form
    {
        ConexionSQL x = new ConexionSQL();
        SqlConnection con = new SqlConnection();
        public FrmBusquedaPersonal()
        {
            InitializeComponent();
            con.ConnectionString = x.Conexion;
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            cargardg();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cargardg();
        }

        private void FrmBusquedaPersonal_Load(object sender, EventArgs e)
        {
            try
            {
                dgPersonal.Rows[0].Selected = true;
            }
            catch
            {

            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void dgPersonal_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgPersonal.CurrentRow.Index;
            dgPersonal.Rows[i].Selected = true;
        }

        void cargardg()
        {
            DataTable dt = new DataTable();
            con.Open();
            SqlCommand cmd = new SqlCommand($"SELECT * FROM PERSONAL WHERE NOMBRE LIKE '%{txtFiltro.Text}%'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dgPersonal.DataSource = dt;
            con.Close();
        }
    }
}

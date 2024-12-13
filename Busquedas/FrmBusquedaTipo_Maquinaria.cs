using Proyecto_Agricola.Clases;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Proyecto_Agricola.Busquedas
{
    public partial class FrmBusquedaTipo_Maquinaria : Form
    {
        ConexionSQL x = new ConexionSQL();
        SqlConnection con = new SqlConnection();
        public FrmBusquedaTipo_Maquinaria()
        {
            InitializeComponent();
            con.ConnectionString = x.Conexion;
        }

        private void FrmBusquedaTipo_Maquinaria_Load(object sender, EventArgs e)
        {
            try
            {
                dgTipo_Maquinaria.Rows[0].Selected = true;
            }
            catch
            {

            }
        }

        void cargardg()
        {
            DataTable dt = new DataTable();
            con.Open();
            SqlCommand cmd = new SqlCommand($"SELECT * FROM TIPO_MAQUINARIA WHERE NOMBRE LIKE '%{txtFiltro.Text}%'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dgTipo_Maquinaria.DataSource = dt;
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

        private void dgTipo_Maquinaria_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgTipo_Maquinaria.CurrentRow.Index;
            dgTipo_Maquinaria.Rows[i].Selected = true;
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

using Proyecto_Agricola.Clases;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Proyecto_Agricola.Busquedas
{
    public partial class FrmBusquedaMaquinaria : Form
    {
        ConexionSQL x = new ConexionSQL();
        SqlConnection con = new SqlConnection();
        public FrmBusquedaMaquinaria()
        {
            InitializeComponent();
            con.ConnectionString = x.Conexion;
        }

        private void FrmBusquedaMaquinaria_Load(object sender, EventArgs e)
        {
            try
            {
                dgMaquinaria.Rows[0].Selected = true;
            }
            catch
            {

            }
        }
        void cargardg()
        {
            DataTable dt = new DataTable();
            con.Open();
            SqlCommand cmd = new SqlCommand($"SELECT * FROM MAQUINARIA WHERE TIPO LIKE '%{txtFiltro.Text}%'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dgMaquinaria.DataSource = dt;
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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void dgMaquinaria_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgMaquinaria.CurrentRow.Index;
            dgMaquinaria.Rows[i].Selected = true;
        }
    }
}

using Proyecto_Agricola.Clases;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Proyecto_Agricola.Formularios
{
    public partial class FrmParcelas : Form
    {
        ConexionSQL x = new ConexionSQL();
        SqlConnection con = new SqlConnection();
        public FrmParcelas()
        {
            InitializeComponent();
            con.ConnectionString = x.Conexion;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FrmParcelas_Load(object sender, EventArgs e)
        {
            Clases.Herramientas h = new Clases.Herramientas();
            txtID.Text = h.consecutivo("ID", "PARCELAS").ToString();
        }

        void limpiar()
        {
            txtID.Clear();
            txtSector.Clear();
            txtUbi.Clear();
            txtHec.Clear();
            txtTs.Clear();
            txtEs.Clear();
            Clases.Herramientas h = new Herramientas();
            txtID.Text = h.consecutivo("ID", "PARCELAS").ToString();
            txtSector.Focus();
            txtUbi.Focus();
            txtHec.Focus();
            txtTs.Focus();
            txtEs.Focus();
        }

        bool encontro()
        {
            bool a = false;
            int ID = int.Parse(txtID.Text);
            string cadena = $"SELECT * FROM PARCELAS WHERE ID = {ID}";
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
            string consulta = $"SELECT * FROM PARCELAS WHERE ID = {txtID.Text}";
            con.Open();
            SqlCommand cmd = new SqlCommand(consulta, con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                txtSector.Text = reader["SECTOR"].ToString();
                txtUbi.Text = reader["UBICACION"].ToString();
                txtHec.Text = reader["TAMAÑO"].ToString();
                txtTs.Text = reader["TIPOSUELO"].ToString();
                txtEs.Text = reader["ESTADO"].ToString();

            }
            con.Close();
        }

        private void tsGuardar_Click(object sender, EventArgs e)
        {
            Clases.Parcelas x = new Clases.Parcelas();
            x.ID = int.Parse(txtID.Text);
            x.SECTOR = txtSector.Text;
            x.UBICACION = txtUbi.Text;
            x.TAMAÑO = txtHec.Text;
            x.TIPOSUELO = txtTs.Text;
            x.ESTADO = txtEs.Text;
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

        private void tsBuscar_Click(object sender, EventArgs e)
        {
            Busquedas.FrmBusquedaParcela x = new Busquedas.FrmBusquedaParcela();
            x.ShowDialog();
            if (x.DialogResult == DialogResult.OK)
            {
                txtID.Text = x.dgParcelas.SelectedRows[0].Cells["ID"].Value.ToString();
                txtSector.Text = x.dgParcelas.SelectedRows[0].Cells["SECTOR"].Value.ToString();
                txtUbi.Text = x.dgParcelas.SelectedRows[0].Cells["UBICACION"].Value.ToString();
                txtHec.Text = x.dgParcelas.SelectedRows[0].Cells["TAMAÑO"].Value.ToString();
                txtTs.Text = x.dgParcelas.SelectedRows[0].Cells["TIPOSUELO"].Value.ToString();
                txtEs.Text = x.dgParcelas.SelectedRows[0].Cells["ESTADO"].Value.ToString();
            }
        }

        private void tsLimpiar_Click(object sender, EventArgs e)
        {
            txtID.Clear();
            txtSector.Clear();
            txtUbi.Clear();
            txtHec.Clear();
            txtTs.Clear();  
            txtEs.Clear();
            Clases.Herramientas h = new Herramientas();
            limpiar();
        }

        private void tsEliminar_Click(object sender, EventArgs e)
        {
            Clases.Parcelas x = new Clases.Parcelas();
            x.ID = int.Parse(txtID.Text);
            MessageBox.Show(x.eliminar());
            limpiar();
        }
    }
}

using Proyecto_Agricola.Clases;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Proyecto_Agricola.Formularios
{
    public partial class FrmProduccion : Form
    {
        ConexionSQL x = new ConexionSQL();
        SqlConnection con = new SqlConnection();
        public FrmProduccion()
        {
            InitializeComponent();
            con.ConnectionString = x.Conexion;
        }

        void limpiar()
        {
            txtID.Clear();
            txtFechaS.Clear();
            txtFechaC.Clear();
            txtCantidadP.Clear();
            txtCantidadP.Clear();
            txtEstado.Clear();
            Clases.Herramientas h = new Herramientas();
            txtID.Text = h.consecutivo("ID", "PRODUCCION").ToString();
            txtID.Focus();
            txtFechaS.Focus();
            txtFechaC.Focus();
            txtCantidadP.Focus();
            txtCantidadP.Focus();
            txtEstado.Focus();

        }

        bool encontro()
        {
            bool a = false;
            int ID = int.Parse(txtID.Text);
            string cadena = $"SELECT * FROM PRODUCCION WHERE ID = {ID}";
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
            string consulta = $"SELECT * FROM PRODUCCION WHERE ID = {txtID.Text}";
            con.Open();
            SqlCommand cmd = new SqlCommand(consulta, con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                txtFechaS.Text = reader["FECHA_SIEMBRE"].ToString();
                txtFechaC.Text = reader["FECHA_COSHECHA"].ToString();
                txtCantidadP.Text = reader["CANTIDAD_PRODUCIDA"].ToString();
                txtEstado.Text = reader["ESTADO"].ToString();
                cbParcelas.Text = reader["ID_PARCELAS"].ToString();
                cbCultivos.Text = reader["ID_CULTIVO"].ToString();


            }
            con.Close();
        }

        void cargarcb()
        {
            DataTable dt = new DataTable();
            string consulta = "Select * From PARCELAS";
            SqlDataAdapter da = new SqlDataAdapter(consulta, con);
            con.Open();
            da.Fill(dt);
            con.Close();
            cbParcelas.DisplayMember = "SECTOR";
            cbParcelas.ValueMember = "ID";
            cbParcelas.DataSource = dt;

        }

        void cargarpar()
        {
            DataTable dt = new DataTable();
            string consulta = "Select * From CULTIVOS";
            SqlDataAdapter da = new SqlDataAdapter(consulta, con);
            con.Open();
            da.Fill(dt);
            con.Close();
            cbCultivos.DisplayMember = "TEMPORADA";
            cbCultivos.ValueMember = "ID";
            cbCultivos.DataSource = dt;
        }

        private void tsGuardar_Click(object sender, EventArgs e)
        {
            Clases.Produccion x = new Clases.Produccion();
            x.ID = int.Parse(txtID.Text);
            x.ID_PARCELA = int.Parse(cbParcelas.SelectedValue.ToString());
            x.ID_CULTIVOS = int.Parse(cbCultivos.SelectedValue.ToString());
            x.FECHA_SIEMBRA = txtFechaS.Text;
            x.FECHA_COSECHA = txtFechaC.Text;
            x.CANTIDADPRO = txtCantidadP.Text;
            x.ESTADO = txtEstado.Text;
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

        private void tsBuscar_Click(object sender, EventArgs e)
        {
            Busquedas.FrmBusquedaProduccion x = new Busquedas.FrmBusquedaProduccion();
            x.ShowDialog();
            if (x.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                txtID.Text = x.dgProduccion.SelectedRows[0].Cells["ID"].Value.ToString();
                txtFechaS.Text = x.dgProduccion.SelectedRows[0].Cells["FECHA_SIEMBRE"].Value.ToString();
                txtFechaC.Text = x.dgProduccion.SelectedRows[0].Cells["FECHA_COSHECHA"].Value.ToString();
                txtCantidadP.Text = x.dgProduccion.SelectedRows[0].Cells["CANTIDAD_PRODUCIDA"].Value.ToString();
                txtEstado.Text = x.dgProduccion.SelectedRows[0].Cells["ESTADO"].Value.ToString();
                cbCultivos.Text = x.dgProduccion.SelectedRows[0].Cells["ID_CULTIVO"].Value.ToString();
                cbParcelas.Text = x.dgProduccion.SelectedRows[0].Cells["ID_PARCELAS"].Value.ToString();

            }
        }

        private void tsLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void tsEliminar_Click(object sender, EventArgs e)
        {
            Clases.Produccion x = new Clases.Produccion();
            x.ID = int.Parse(txtID.Text);
            MessageBox.Show(x.eliminar());
            limpiar();
        }

        private void FrmProduccion_Load(object sender, EventArgs e)
        {
            cargarcb();
            cargarpar();
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
    }
}

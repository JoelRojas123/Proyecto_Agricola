using Proyecto_Agricola.Clases;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Proyecto_Agricola.Formularios
{
    public partial class FrmProductos : Form
    {
        ConexionSQL x = new ConexionSQL();
        SqlConnection con = new SqlConnection();
        public FrmProductos()
        {
            InitializeComponent();
            con.ConnectionString = x.Conexion;
        }

        private void FrmProductos_Load(object sender, EventArgs e)
        {
            cargarcb();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tsGuardar_Click(object sender, EventArgs e)
        {
            Clases.Productos x = new Clases.Productos();
            x.ID = int.Parse(txtID.Text);
            x.IDCULTIVOS = int.Parse(cbCultivo.SelectedValue.ToString());
            x.FECHA_COSECHA = txtFechaCos.Text;
            x.CANTIDAD = txtCantidad.Text;
            x.PRECIO_UNI = txtPrecioUni.Text;
            x.ESTADO = txtEstado.Text;
            x.PRECIO_TOTAL = txtPrecioTotal.Text;
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


        void limpiar()
        {
            txtID.Clear();
            txtFechaCos.Clear();
            txtCantidad.Clear();
            txtPrecioUni.Clear();
            txtEstado.Clear();
            txtPrecioTotal.Clear();
            Clases.Herramientas h = new Herramientas();
            txtID.Text = h.consecutivo("ID", "PRODUCTOS").ToString();
            txtFechaCos.Focus();
            txtCantidad.Focus();
            txtPrecioUni.Focus();
            txtEstado.Focus();
            txtPrecioTotal.Focus();
        }

        bool encontro()
        {
            bool a = false;
            int ID = int.Parse(txtID.Text);
            string cadena = $"Select * from PRODUCTOS where id = {ID}";
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
        void cargarcb()
        {
            DataTable dt = new DataTable();
            string consulta = "Select * From PRODUCTOS";
            SqlDataAdapter da = new SqlDataAdapter(consulta, con);
            con.Open();
            da.Fill(dt);
            con.Close();
            cbCultivo.DisplayMember = "CANTIDAD";
            cbCultivo.ValueMember = "ID";
            cbCultivo.DataSource = dt;

        }

        private void tsBuscar_Click(object sender, EventArgs e)
        {
            Busquedas.FrmBusquedaProductos x = new Busquedas.FrmBusquedaProductos();
            x.ShowDialog();
            if (x.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                txtID.Text = x.dgProductos.SelectedRows[0].Cells["ID"].Value.ToString();
                cbCultivo.Text = x.dgProductos.SelectedRows[0].Cells["ID_CULTIVO"].Value.ToString();
                txtFechaCos.Text = x.dgProductos.SelectedRows[0].Cells["FECHA_COSECHA"].Value.ToString();
                txtCantidad.Text = x.dgProductos.SelectedRows[0].Cells["CANTIDAD"].Value.ToString();
                txtPrecioUni.Text = x.dgProductos.SelectedRows[0].Cells["PRECIO_UNI"].Value.ToString();
                txtEstado.Text = x.dgProductos.SelectedRows[0].Cells["ESTADO"].Value.ToString();
                txtPrecioTotal.Text = x.dgProductos.SelectedRows[0].Cells["PRECIO_TOTAL"].Value.ToString();
            }
        }

        private void tsLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void tsEliminar_Click(object sender, EventArgs e)
        {
            Clases.Productos x = new Clases.Productos();
            x.ID = int.Parse(txtID.Text);
            MessageBox.Show(x.eliminar());
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
        void obtener()
        {

            string consulta = $"Select * From PRODUCTOS where ID = {txtID.Text}";
            con.Open();
            SqlCommand cmd = new SqlCommand(consulta, con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                txtFechaCos.Text = reader["FECHA_COSECHA"].ToString();
                txtCantidad.Text = reader["CANTIDAD"].ToString();
                txtPrecioUni.Text = reader["PRECIO_UNI"].ToString();
                txtEstado.Text = reader["ESTADO"].ToString();
                txtPrecioTotal.Text = reader["PRECIO_TOTAL"].ToString();

            }
            else
            {
                MessageBox.Show("El ID ingresado no le corresponde a ningun estado.");

            }
            con.Close();

        }


    }
}

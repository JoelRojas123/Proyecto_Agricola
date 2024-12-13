using Proyecto_Agricola.Clases;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Proyecto_Agricola.Formularios
{
    public partial class FrmVentas : Form
    {
        ConexionSQL x = new ConexionSQL();
        SqlConnection con = new SqlConnection();
        public FrmVentas()
        {
            InitializeComponent();
            con.ConnectionString = x.Conexion;
        }

        private void FrmVentas_Load(object sender, EventArgs e)
        {
            cargarcb();
        }

        void limpiar()
        {
            txtID.Clear();
            txtFECHAVE.Clear();
            txtCantidad.Clear();
            txtPrecioTo.Clear();
            txtCliente.Clear();
            Clases.Herramientas h = new Herramientas();
            txtID.Text = h.consecutivo("ID", "VENTAS").ToString();
            txtID.Focus();
            cbID_Producto.Focus();
            txtFECHAVE.Focus();
            txtCantidad.Focus();
            txtPrecioTo.Focus();
            txtCliente.Focus();
        }

        bool encontro()
        {
            bool a = false;
            int ID = int.Parse(txtID.Text);
            string cadena = $"SELECT * FROM VENTAS WHERE ID = {ID}";
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
            string consulta = $"SELECT * FROM VENTAS WHERE ID = {txtID.Text}";
            con.Open();
            SqlCommand cmd = new SqlCommand(consulta, con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                txtFECHAVE.Text = reader["FECHA_VENTA"].ToString();
                txtCantidad.Text = reader["CANTIDAD"].ToString();
                txtPrecioTo.Text = reader["PRECIO_TOTAL"].ToString();
                txtCliente.Text = reader["CLIENTE"].ToString();

            }
            con.Close();
        }

        void cargarcb()
        {
            DataTable dt = new DataTable();
            string consulta = "Select * From PRODUCTOS";
            SqlDataAdapter da = new SqlDataAdapter(consulta, con);
            con.Open();
            da.Fill(dt);
            con.Close();
            cbID_Producto.DisplayMember = "ESTADO";
            cbID_Producto.ValueMember = "ID";
            cbID_Producto.DataSource = dt;

        }

        private void tsGuardar_Click(object sender, EventArgs e)
        {
            Clases.Ventas x = new Clases.Ventas();
            x.ID = int.Parse(txtID.Text);
            x.ID_PRODUCTO = int.Parse(cbID_Producto.SelectedValue.ToString());
            x.FECHA_VENTA = txtFECHAVE.Text;
            x.CANTIDAD = txtCantidad.Text;
            x.PRECIO_TOTAL = txtPrecioTo.Text;
            x.CLIENTE = txtCliente.Text;
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
            Busquedas.FrmBusquedaVentas x = new Busquedas.FrmBusquedaVentas();
            x.ShowDialog();
            if (x.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                txtID.Text = x.dgVentas.SelectedRows[0].Cells["ID"].Value.ToString();
                cbID_Producto.Text = x.dgVentas.SelectedRows[0].Cells["ID_PRODUCTO"].Value.ToString();
                txtFECHAVE.Text = x.dgVentas.SelectedRows[0].Cells["FECHA_VENTA"].Value.ToString();
                txtCantidad.Text = x.dgVentas.SelectedRows[0].Cells["CANTIDAD"].Value.ToString();
                txtPrecioTo.Text = x.dgVentas.SelectedRows[0].Cells["PRECIO_TOTAL"].Value.ToString();
                txtCliente.Text = x.dgVentas.SelectedRows[0].Cells["CLIENTE"].Value.ToString();
            }
        }

        private void tsLimpiar_Click(object sender, EventArgs e)
        {
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

        private void tsEliminar_Click(object sender, EventArgs e)
        {
            Clases.Ventas x = new Clases.Ventas();
            x.ID = int.Parse(txtID.Text);
            MessageBox.Show(x.eliminar());
            limpiar();
        }
    }
}

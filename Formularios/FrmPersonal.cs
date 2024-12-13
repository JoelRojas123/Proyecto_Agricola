using Proyecto_Agricola.Clases;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Proyecto_Agricola.Formularios
{
    public partial class FrmPersonal : Form
    {
        ConexionSQL x = new ConexionSQL();
        SqlConnection con = new SqlConnection();
        public FrmPersonal()
        {
            InitializeComponent();
            con.ConnectionString = x.Conexion;
        }

        private void tsGuardar_Click(object sender, EventArgs e)
        {
            Clases.Personal x = new Clases.Personal();
            x.ID = int.Parse(txtID.Text);
            x.NOMBRE = txtNombre.Text;
            x.APELLIDOS = txtApellidos.Text;
            x.CARGO = txtCargo.Text;
            x.FECHA_CONTRATACION = txtFechaCon.Text;
            x.TELEFONO = txtTelefono.Text;
            x.EMAIL = txtEmail.Text;
            x.RFC = txtRFC.Text;
            x.NSS = txtNSS.Text;
            x.DOMICILIO = txtDomicilio.Text;

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
            txtNombre.Clear();
            txtApellidos.Clear();
            txtCargo.Clear();
            txtFechaCon.Clear();
            txtFechaCon.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            txtRFC.Clear();
            txtNSS.Clear();
            txtDomicilio.Clear();
            Clases.Herramientas h = new Herramientas();
            txtID.Text = h.consecutivo("ID", "PERSONAL").ToString();
            txtNombre.Focus();
            txtApellidos.Focus();
            txtCargo.Focus();
            txtFechaCon.Focus();
            txtTelefono.Focus();
            txtEmail.Focus();
            txtRFC.Focus();
            txtNSS.Focus();
            txtDomicilio.Focus();

        }

        bool encontro()
        {
            bool a = false;
            int ID = int.Parse(txtID.Text);
            string cadena = $"SELECT * FROM PERSONAL WHERE ID = {ID}";
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
            string consulta = $"SELECT * FROM PERSONAL WHERE ID = {txtID.Text}";
            con.Open();
            SqlCommand cmd = new SqlCommand(consulta, con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                txtNombre.Text = reader["NOMBRE"].ToString();
                txtApellidos.Text = reader["APELLIDOS"].ToString();
                txtCargo.Text = reader["CARGO"].ToString();
                txtFechaCon.Text = reader["FECHA_CONTRATACION"].ToString();
                txtTelefono.Text = reader["TELEFONO"].ToString();
                txtEmail.Text = reader["EMAIL"].ToString();
                txtRFC.Text = reader["RFC"].ToString();
                txtNSS.Text = reader["NSS"].ToString();
                txtDomicilio.Text = reader["DOMICILIO"].ToString();


            }
            con.Close();
        }

        private void tsBuscar_Click(object sender, EventArgs e)
        {
            Busquedas.FrmBusquedaPersonal x = new Busquedas.FrmBusquedaPersonal();
            x.ShowDialog();
            if (x.DialogResult == DialogResult.OK)
            {
                txtID.Text = x.dgPersonal.SelectedRows[0].Cells["ID"].Value.ToString();
                txtNombre.Text = x.dgPersonal.SelectedRows[0].Cells["NOMBRE"].Value.ToString();
                txtApellidos.Text = x.dgPersonal.SelectedRows[0].Cells["APELLIDOS"].Value.ToString();
                txtCargo.Text = x.dgPersonal.SelectedRows[0].Cells["CARGO"].Value.ToString();
                txtFechaCon.Text = x.dgPersonal.SelectedRows[0].Cells["FECHA_CONTRATACION"].Value.ToString();
                txtTelefono.Text = x.dgPersonal.SelectedRows[0].Cells["TELEFONO"].Value.ToString();
                txtEmail.Text = x.dgPersonal.SelectedRows[0].Cells["EMAIL"].Value.ToString();
                txtRFC.Text = x.dgPersonal.SelectedRows[0].Cells["RFC"].Value.ToString();
                txtNSS.Text = x.dgPersonal.SelectedRows[0].Cells["NSS"].Value.ToString();
                txtDomicilio.Text = x.dgPersonal.SelectedRows[0].Cells["DOMICILIO"].Value.ToString();
            }
        }

        private void tsLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void tsEliminar_Click(object sender, EventArgs e)
        {
            Clases.Personal x = new Clases.Personal();
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

        private void FrmPersonal_Load(object sender, EventArgs e)
        {
            Clases.Herramientas h = new Clases.Herramientas();
            txtID.Text = h.consecutivo("ID", "PERSONAL").ToString();
        }
    }

}

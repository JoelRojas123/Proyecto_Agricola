using Proyecto_Agricola.Clases;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Proyecto_Agricola.Formularios
{
    public partial class FrmMantenimiento_Maquinaria : Form
    {
        ConexionSQL x = new ConexionSQL();
        SqlConnection con = new SqlConnection();
        public FrmMantenimiento_Maquinaria()
        {
            InitializeComponent();
            con.ConnectionString = x.Conexion;
        }

        private void FrmMantenimiento_Maquinaria_Load(object sender, EventArgs e)
        {
            cargarcb();
            cargarpar();
        }

        void limpiar()
        {
            txtID.Clear();
            txtFecha.Clear();
            txtDes.Clear();
            txtCosto.Clear();
            Clases.Herramientas h = new Herramientas();
            txtID.Text = h.consecutivo("ID", "MANTENIMIENTO_MAQUINARIA").ToString();
            txtID.Focus();
            txtFecha.Focus();
            txtDes.Focus();
            txtCosto.Focus();


        }

        bool encontro()
        {
            bool a = false;
            int ID = int.Parse(txtID.Text);
            string cadena = $"SELECT * FROM MANTENIMIENTO_MAQUINARIA WHERE ID = {ID}";
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
            string consulta = $"SELECT * FROM MANTENIMIENTO_MAQUINARIA WHERE ID = {txtID.Text}";
            con.Open();
            SqlCommand cmd = new SqlCommand(consulta, con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                txtFecha.Text = reader["FECHA"].ToString();
                txtDes.Text = reader["DESCRIPCION"].ToString();
                txtCosto.Text = reader["COSTO"].ToString();


            }
            con.Close();
        }

        void cargarcb()
        {
            DataTable dt = new DataTable();
            string consulta = "Select * From MAQUINARIA";
            SqlDataAdapter da = new SqlDataAdapter(consulta, con);
            con.Open();
            da.Fill(dt);
            con.Close();
            cbMaquinaria.DisplayMember = "TIPO";
            cbMaquinaria.ValueMember = "ID";
            cbMaquinaria.DataSource = dt;

        }

        void cargarpar()
        {
            DataTable dt = new DataTable();
            string consulta = "Select * From P_MANTENIMIENTO";
            SqlDataAdapter da = new SqlDataAdapter(consulta, con);
            con.Open();
            da.Fill(dt);
            con.Close();
            cbP_Maquinaria.DisplayMember = "CARGO";
            cbP_Maquinaria.ValueMember = "ID";
            cbP_Maquinaria.DataSource = dt;
        }

        private void tsGuardar_Click(object sender, EventArgs e)
        {
            Clases.Mantenimiento x = new Clases.Mantenimiento();
            x.ID = int.Parse(txtID.Text);
            x.ID_MAQUINARIA = int.Parse(cbMaquinaria.SelectedValue.ToString());
            x.FECHA = txtFecha.Text;
            x.ID_P_MAQUINARIA = int.Parse(cbP_Maquinaria.SelectedValue.ToString());
            x.DESCRIPCION = txtDes.Text;
            x.COSTO = txtCosto.Text;
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
            Busquedas.FrmBusquedaMantenimiento x = new Busquedas.FrmBusquedaMantenimiento();
            x.ShowDialog();
            if (x.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                txtID.Text = x.dgMantenimiento.SelectedRows[0].Cells["ID"].Value.ToString();
                cbMaquinaria.Text = x.dgMantenimiento.SelectedRows[0].Cells["ID_MAQUINARIA"].Value.ToString();
                txtFecha.Text = x.dgMantenimiento.SelectedRows[0].Cells["FECHA"].Value.ToString();
                cbP_Maquinaria.Text = x.dgMantenimiento.SelectedRows[0].Cells["ID_P_MANTENIMIENTO"].Value.ToString();
                txtDes.Text = x.dgMantenimiento.SelectedRows[0].Cells["DESCRIPCION"].Value.ToString();
                txtCosto.Text = x.dgMantenimiento.SelectedRows[0].Cells["COSTO"].Value.ToString();

            }
        }

        private void tsLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void tsEliminar_Click(object sender, EventArgs e)
        {

            Clases.Mantenimiento x = new Clases.Mantenimiento();
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
    }
}

using Proyecto_Agricola.Clases;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Proyecto_Agricola.Formularios
{
    public partial class FrmTareas : Form
    {
        ConexionSQL x = new ConexionSQL();
        SqlConnection con = new SqlConnection();
        public FrmTareas()
        {
            InitializeComponent();
            con.ConnectionString = x.Conexion;
        }

        void limpiar()
        {
            txtID.Clear();
            txtDescripcion.Clear();
            txtEstado.Clear();
            Clases.Herramientas h = new Herramientas();
            txtID.Text = h.consecutivo("ID", "TAREAS").ToString();
            txtID.Focus();
            txtDescripcion.Focus();
            txtEstado.Focus();

        }

        bool encontro()
        {
            bool a = false;
            int ID = int.Parse(txtID.Text);
            string cadena = $"SELECT * FROM TAREAS WHERE ID = {ID}";
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
            string consulta = $"SELECT * FROM TAREAS WHERE ID = {txtID.Text}";
            con.Open();
            SqlCommand cmd = new SqlCommand(consulta, con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                txtDescripcion.Text = reader["DESCRIPCION"].ToString();
                txtEstado.Text = reader["ESTADO"].ToString();


            }
            con.Close();
        }

        void cargarcb()
        {
            DataTable dt = new DataTable();
            string consulta = "Select * From PERSONAL";
            SqlDataAdapter da = new SqlDataAdapter(consulta, con);
            con.Open();
            da.Fill(dt);
            con.Close();
            cbPersonal.DisplayMember = "NOMBRE";
            cbPersonal.ValueMember = "ID";
            cbPersonal.DataSource = dt;

        }

        void cargarpar()
        {
            DataTable dt = new DataTable();
            string consulta = "Select * From PARCELAS";
            SqlDataAdapter da = new SqlDataAdapter(consulta, con);
            con.Open();
            da.Fill(dt);
            con.Close();
            cbParcela.DisplayMember = "SECTOR";
            cbParcela.ValueMember = "ID";
            cbParcela.DataSource = dt;
        }

        private void tsGuardar_Click(object sender, EventArgs e)
        {
            Clases.Tareas x = new Clases.Tareas();
            x.ID = int.Parse(txtID.Text);
            x.ID_PERSONAL = int.Parse(cbPersonal.SelectedValue.ToString());
            x.ID_PARCELAS = int.Parse(cbParcela.SelectedValue.ToString());
            x.DESCRIPCION = txtDescripcion.Text;
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
            Busquedas.FrmBusquedaTareas x = new Busquedas.FrmBusquedaTareas();
            x.ShowDialog();
            if (x.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                txtID.Text = x.dgVentas.SelectedRows[0].Cells["ID"].Value.ToString();
                cbPersonal.Text = x.dgVentas.SelectedRows[0].Cells["ID_PERSONAL"].Value.ToString();
                cbParcela.Text = x.dgVentas.SelectedRows[0].Cells["ID_PARCELAS"].Value.ToString();
                txtDescripcion.Text = x.dgVentas.SelectedRows[0].Cells["DESCRIPCION"].Value.ToString();
                txtEstado.Text = x.dgVentas.SelectedRows[0].Cells["ESTADO"].Value.ToString();

            }
        }

        private void tsLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void tsEliminar_Click(object sender, EventArgs e)
        {
            Clases.Tareas x = new Clases.Tareas();
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

        private void FrmTareas_Load(object sender, EventArgs e)
        {
            cargarcb();
            cargarpar();

        }
    }
}

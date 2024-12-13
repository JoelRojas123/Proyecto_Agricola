using Proyecto_Agricola.Clases;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Proyecto_Agricola.Formularios
{
    public partial class FrmMaquinaria : Form
    {
        ConexionSQL x = new ConexionSQL();
        SqlConnection con = new SqlConnection();
        public FrmMaquinaria()
        {
            InitializeComponent();
            con.ConnectionString = x.Conexion;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        void limpiar()
        {
            txtID.Clear();
            txtTipo.Clear();
            txtMarca.Clear();
            txtModelo.Clear();
            txtFechaAdd.Clear();
            txtHoras_tra.Clear();
            txtEstado.Clear();
            Clases.Herramientas h = new Herramientas();
            txtID.Text = h.consecutivo("ID", "CULTIVOS").ToString();
            txtTipo.Focus();
            txtMarca.Focus();
            txtModelo.Focus();
            txtFechaAdd.Focus();
            txtHoras_tra.Focus();
            txtEstado.Focus();
        }

        bool encontro()
        {
            bool a = false;
            int ID = int.Parse(txtID.Text);
            string cadena = $"SELECT * FROM MAQUINARIA WHERE ID = {ID}";
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
            string consulta = $"SELECT * FROM MAQUINARIA WHERE ID = {txtID.Text}";
            con.Open();
            SqlCommand cmd = new SqlCommand(consulta, con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                txtTipo.Text = reader["TIPO"].ToString();
                txtMarca.Text = reader["MARCA"].ToString();
                txtModelo.Text = reader["MODELO"].ToString();
                txtFechaAdd.Text = reader["FECHA_ADD"].ToString();
                txtHoras_tra.Text = reader["HORAS_TRABAJADAS"].ToString();
                txtEstado.Text = reader["ESTADO"].ToString();

            }
            con.Close();
        }

        private void tsGuardar_Click(object sender, EventArgs e)
        {
            Clases.Maquinaria x = new Clases.Maquinaria();
            x.ID = int.Parse(txtID.Text);
            x.TIPO = txtTipo.Text;
            x.MARCA = txtModelo.Text;
            x.MODELO = txtModelo.Text;
            x.FECHAADD = txtFechaAdd.Text;
            x.HORASTRA = txtHoras_tra.Text;
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

        private void FrmMaquinaria_Load(object sender, EventArgs e)
        {
            Clases.Herramientas h = new Clases.Herramientas();
            txtID.Text = h.consecutivo("ID", "MAQUINARIA").ToString();
        }

        private void tsBuscar_Click(object sender, EventArgs e)
        {
            Busquedas.FrmBusquedaMaquinaria x = new Busquedas.FrmBusquedaMaquinaria();
            x.ShowDialog();
            if (x.DialogResult == DialogResult.OK)
            {
                txtID.Text = x.dgMaquinaria.SelectedRows[0].Cells["ID"].Value.ToString();
                txtTipo.Text = x.dgMaquinaria.SelectedRows[0].Cells["TIPO"].Value.ToString();
                txtMarca.Text = x.dgMaquinaria.SelectedRows[0].Cells["MARCA"].Value.ToString();
                txtModelo.Text = x.dgMaquinaria.SelectedRows[0].Cells["MODELO"].Value.ToString();
                txtFechaAdd.Text = x.dgMaquinaria.SelectedRows[0].Cells["FECHA_ADD"].Value.ToString();
                txtHoras_tra.Text = x.dgMaquinaria.SelectedRows[0].Cells["HORAS_TRABAJADAS"].Value.ToString();
                txtEstado.Text = x.dgMaquinaria.SelectedRows[0].Cells["ESTADO"].Value.ToString();
            }
        }

        private void tsLimpiar_Click(object sender, EventArgs e)
        {
            txtID.Clear();
            txtTipo.Clear();
            txtMarca.Clear();
            txtModelo.Clear();
            txtHoras_tra.Clear();
            txtEstado.Clear();
            Clases.Herramientas h = new Herramientas();
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
            Clases.Maquinaria x = new Clases.Maquinaria();
            x.ID = int.Parse(txtID.Text);
            MessageBox.Show(x.eliminar());
            limpiar();
        }
    }
}

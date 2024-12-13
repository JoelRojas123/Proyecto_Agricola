using Proyecto_Agricola.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Agricola.Formularios
{
    public partial class FrmTipo_Maquinaria : Form
    {
        ConexionSQL x = new ConexionSQL();
        SqlConnection con = new SqlConnection();
        public FrmTipo_Maquinaria()
        {
            InitializeComponent();
            con.ConnectionString = x.Conexion;
        }

        private void tsGuardar_Click(object sender, EventArgs e)
        {
            Clases.Tipo_Maquinaria x = new Clases.Tipo_Maquinaria();
            x.ID = int.Parse(txtID.Text);
            x.NOMBRE = txtNombre.Text;
            x.MODELO = txtModelo.Text;

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
            txtModelo.Clear();
            Clases.Herramientas h = new Herramientas();
            txtID.Text = h.consecutivo("ID", "TIPO_MAQUINARIA").ToString();
            txtNombre.Focus();
            txtModelo.Focus();
        }

        bool encontro()
        {
            bool a = false;
            int ID = int.Parse(txtID.Text);
            string cadena = $"SELECT * FROM TIPO_MAQUINARIA WHERE ID = {ID}";
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
            string consulta = $"SELECT * FROM TIPO_MAQUINARIA WHERE ID = {txtID.Text}";
            con.Open();
            SqlCommand cmd = new SqlCommand(consulta, con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                txtNombre.Text = reader["NOMBRE"].ToString();
                txtModelo.Text = reader["MODELO"].ToString();
            }
            con.Close();
        }

        private void tsBuscar_Click(object sender, EventArgs e)
        {
            Busquedas.FrmBusquedaTipo_Maquinaria x = new Busquedas.FrmBusquedaTipo_Maquinaria();
            x.ShowDialog();
            if (x.DialogResult == DialogResult.OK)
            {
                txtID.Text = x.dgTipo_Maquinaria.SelectedRows[0].Cells["ID"].Value.ToString();
                txtNombre.Text = x.dgTipo_Maquinaria.SelectedRows[0].Cells["NOMBRE"].Value.ToString();
                txtModelo.Text = x.dgTipo_Maquinaria.SelectedRows[0].Cells["MODELO"].Value.ToString();
            }
        }

        private void tsLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void tsEliminar_Click(object sender, EventArgs e)
        {
            Clases.Tipo_Maquinaria x = new Clases.Tipo_Maquinaria();
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

        private void FrmTipo_Maquinaria_Load(object sender, EventArgs e)
        {
            Clases.Herramientas h = new Clases.Herramientas();
            txtID.Text = h.consecutivo("ID", "TIPO_MAQUINARIA").ToString();
        }
    }
}

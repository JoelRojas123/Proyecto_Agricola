using Proyecto_Agricola.Clases;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Proyecto_Agricola.Formularios
{
    public partial class FrmMaestroDe : Form
    {
        ConexionSQL x = new ConexionSQL();
        SqlConnection con = new SqlConnection();
        public FrmMaestroDe()
        {
            InitializeComponent();
            con.ConnectionString = x.Conexion;
        }

        private void FrmMaestroDe_Load(object sender, EventArgs e)
        {

        }
    }
}

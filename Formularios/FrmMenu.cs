using System;
using System.Windows.Forms;

namespace Proyecto_Agricola.Formularios
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }

        private void tsEstados_Click(object sender, EventArgs e)
        {
            Formularios.FrmMaquinaria x = new Formularios.FrmMaquinaria();
            x.ShowDialog();
        }

        private void generosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.FrmCultivos x = new Formularios.FrmCultivos();
            x.ShowDialog();
        }

        private void clasificacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.FrmParcelas x = new Formularios.FrmParcelas();
            x.ShowDialog();
        }

        private void sucursalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.FrmProductos x = new Formularios.FrmProductos();
            x.ShowDialog();
        }

        private void empleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.FrmPersonal x = new Formularios.FrmPersonal();
            x.ShowDialog();
        }

        private void tsDomicilios_Click(object sender, EventArgs e)
        {
            Formularios.FrmP_Mantenimiento X = new Formularios.FrmP_Mantenimiento();
            X.ShowDialog();
        }

        private void tipoDeMaquinariaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.FrmTipo_Maquinaria X = new Formularios.FrmTipo_Maquinaria();
            X.ShowDialog();
        }

        private void turnoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.FrmVentas X = new Formularios.FrmVentas();
            X.ShowDialog();
        }

        private void directoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTareas x = new FrmTareas();
            x.ShowDialog();
        }

        private void puestoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.FrmProduccion x = new Formularios.FrmProduccion();
            x.ShowDialog();
        }

        private void tsMunicipio_Click(object sender, EventArgs e)
        {
            Formularios.FrmMantenimiento_Maquinaria x = new Formularios.FrmMantenimiento_Maquinaria();
            x.ShowDialog();
        }
    }
}

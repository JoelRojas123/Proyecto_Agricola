namespace Proyecto_Agricola.Formularios
{
    partial class FrmMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.msMenu = new System.Windows.Forms.MenuStrip();
            this.aRTICULOSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clasificacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.directoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cATALOGOSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.puestoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.turnoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sucursalesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.empleadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dIRECCIONESToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsEstados = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMunicipio = new System.Windows.Forms.ToolStripMenuItem();
            this.tsDomicilios = new System.Windows.Forms.ToolStripMenuItem();
            this.tipoDeMaquinariaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.msMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMenu
            // 
            this.msMenu.BackColor = System.Drawing.Color.Red;
            this.msMenu.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.msMenu.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.msMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.msMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aRTICULOSToolStripMenuItem,
            this.cATALOGOSToolStripMenuItem,
            this.dIRECCIONESToolStripMenuItem});
            this.msMenu.Location = new System.Drawing.Point(0, 0);
            this.msMenu.Name = "msMenu";
            this.msMenu.Size = new System.Drawing.Size(800, 40);
            this.msMenu.TabIndex = 1;
            this.msMenu.Text = "menuStrip1";
            // 
            // aRTICULOSToolStripMenuItem
            // 
            this.aRTICULOSToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generosToolStripMenuItem,
            this.clasificacionesToolStripMenuItem,
            this.directoresToolStripMenuItem});
            this.aRTICULOSToolStripMenuItem.Name = "aRTICULOSToolStripMenuItem";
            this.aRTICULOSToolStripMenuItem.Size = new System.Drawing.Size(173, 36);
            this.aRTICULOSToolStripMenuItem.Text = "ACTIVIDADES";
            // 
            // generosToolStripMenuItem
            // 
            this.generosToolStripMenuItem.Name = "generosToolStripMenuItem";
            this.generosToolStripMenuItem.Size = new System.Drawing.Size(203, 40);
            this.generosToolStripMenuItem.Text = "Cultivos";
            this.generosToolStripMenuItem.Click += new System.EventHandler(this.generosToolStripMenuItem_Click);
            // 
            // clasificacionesToolStripMenuItem
            // 
            this.clasificacionesToolStripMenuItem.Name = "clasificacionesToolStripMenuItem";
            this.clasificacionesToolStripMenuItem.Size = new System.Drawing.Size(203, 40);
            this.clasificacionesToolStripMenuItem.Text = "Parcelas";
            this.clasificacionesToolStripMenuItem.Click += new System.EventHandler(this.clasificacionesToolStripMenuItem_Click);
            // 
            // directoresToolStripMenuItem
            // 
            this.directoresToolStripMenuItem.Name = "directoresToolStripMenuItem";
            this.directoresToolStripMenuItem.Size = new System.Drawing.Size(203, 40);
            this.directoresToolStripMenuItem.Text = "Tareas";
            this.directoresToolStripMenuItem.Click += new System.EventHandler(this.directoresToolStripMenuItem_Click);
            // 
            // cATALOGOSToolStripMenuItem
            // 
            this.cATALOGOSToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.puestoToolStripMenuItem,
            this.turnoToolStripMenuItem,
            this.sucursalesToolStripMenuItem,
            this.empleadosToolStripMenuItem});
            this.cATALOGOSToolStripMenuItem.Name = "cATALOGOSToolStripMenuItem";
            this.cATALOGOSToolStripMenuItem.Size = new System.Drawing.Size(140, 36);
            this.cATALOGOSToolStripMenuItem.Text = "AGRICOLA";
            // 
            // puestoToolStripMenuItem
            // 
            this.puestoToolStripMenuItem.Name = "puestoToolStripMenuItem";
            this.puestoToolStripMenuItem.Size = new System.Drawing.Size(237, 40);
            this.puestoToolStripMenuItem.Text = "Produccion";
            this.puestoToolStripMenuItem.Click += new System.EventHandler(this.puestoToolStripMenuItem_Click);
            // 
            // turnoToolStripMenuItem
            // 
            this.turnoToolStripMenuItem.Name = "turnoToolStripMenuItem";
            this.turnoToolStripMenuItem.Size = new System.Drawing.Size(237, 40);
            this.turnoToolStripMenuItem.Text = "Ventas";
            this.turnoToolStripMenuItem.Click += new System.EventHandler(this.turnoToolStripMenuItem_Click);
            // 
            // sucursalesToolStripMenuItem
            // 
            this.sucursalesToolStripMenuItem.Name = "sucursalesToolStripMenuItem";
            this.sucursalesToolStripMenuItem.Size = new System.Drawing.Size(237, 40);
            this.sucursalesToolStripMenuItem.Text = "Productos";
            this.sucursalesToolStripMenuItem.Click += new System.EventHandler(this.sucursalesToolStripMenuItem_Click);
            // 
            // empleadosToolStripMenuItem
            // 
            this.empleadosToolStripMenuItem.Name = "empleadosToolStripMenuItem";
            this.empleadosToolStripMenuItem.Size = new System.Drawing.Size(237, 40);
            this.empleadosToolStripMenuItem.Text = "Personal";
            this.empleadosToolStripMenuItem.Click += new System.EventHandler(this.empleadosToolStripMenuItem_Click);
            // 
            // dIRECCIONESToolStripMenuItem
            // 
            this.dIRECCIONESToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsEstados,
            this.tsMunicipio,
            this.tsDomicilios,
            this.tipoDeMaquinariaToolStripMenuItem});
            this.dIRECCIONESToolStripMenuItem.Name = "dIRECCIONESToolStripMenuItem";
            this.dIRECCIONESToolStripMenuItem.Size = new System.Drawing.Size(152, 36);
            this.dIRECCIONESToolStripMenuItem.Text = "VEHICULOS";
            // 
            // tsEstados
            // 
            this.tsEstados.Name = "tsEstados";
            this.tsEstados.Size = new System.Drawing.Size(413, 40);
            this.tsEstados.Text = "Maquinaria";
            this.tsEstados.Click += new System.EventHandler(this.tsEstados_Click);
            // 
            // tsMunicipio
            // 
            this.tsMunicipio.Name = "tsMunicipio";
            this.tsMunicipio.Size = new System.Drawing.Size(413, 40);
            this.tsMunicipio.Text = "Mantenimiento";
            this.tsMunicipio.Click += new System.EventHandler(this.tsMunicipio_Click);
            // 
            // tsDomicilios
            // 
            this.tsDomicilios.Name = "tsDomicilios";
            this.tsDomicilios.Size = new System.Drawing.Size(413, 40);
            this.tsDomicilios.Text = "Personal de Mantenimiento";
            this.tsDomicilios.Click += new System.EventHandler(this.tsDomicilios_Click);
            // 
            // tipoDeMaquinariaToolStripMenuItem
            // 
            this.tipoDeMaquinariaToolStripMenuItem.Name = "tipoDeMaquinariaToolStripMenuItem";
            this.tipoDeMaquinariaToolStripMenuItem.Size = new System.Drawing.Size(413, 40);
            this.tipoDeMaquinariaToolStripMenuItem.Text = "Tipo de Maquinaria";
            this.tipoDeMaquinariaToolStripMenuItem.Click += new System.EventHandler(this.tipoDeMaquinariaToolStripMenuItem_Click);
            // 
            // FrmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.msMenu);
            this.Name = "FrmMenu";
            this.Text = "FrmMenu";
            this.msMenu.ResumeLayout(false);
            this.msMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMenu;
        private System.Windows.Forms.ToolStripMenuItem aRTICULOSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clasificacionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem directoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cATALOGOSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem puestoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem turnoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sucursalesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem empleadosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dIRECCIONESToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsEstados;
        private System.Windows.Forms.ToolStripMenuItem tsMunicipio;
        private System.Windows.Forms.ToolStripMenuItem tsDomicilios;
        private System.Windows.Forms.ToolStripMenuItem tipoDeMaquinariaToolStripMenuItem;
    }
}
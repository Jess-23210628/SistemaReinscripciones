// ═══════════════════════════════════════════════════════
// FormAlumno.Designer.cs
// ═══════════════════════════════════════════════════════
namespace SistemaReinscripciones
{
    partial class FrmAlumno
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        // Helper used by InitializeComponent. Kept as a class method so the WinForms
        // designer can parse the generated code (local functions inside
        // InitializeComponent are not supported by the designer parser).
        private void ConfigureMenuItem(System.Windows.Forms.ToolStripMenuItem it, string txt, System.EventHandler handler)
        {
            it.Text = txt;
            it.ForeColor = System.Drawing.Color.White;
            it.BackColor = System.Drawing.Color.FromArgb(0, 109, 109);
            it.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            it.Click += handler;
        }

        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuMiHorarioAl = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMisCalifs = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHistorial = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMisPaquetes = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReporteAl = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlContenido = new System.Windows.Forms.Panel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblNombreAlumno = new System.Windows.Forms.Label();
            this.lblInfoAlumno = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tslStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslFecha = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.menuStrip1.ForeColor = System.Drawing.Color.White;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMiHorarioAl,
            this.mnuMisCalifs,
            this.mnuHistorial,
            this.mnuMisPaquetes,
            this.mnuReporteAl});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(1100, 30);
            this.menuStrip1.TabIndex = 2;
            // 
            // mnuMiHorarioAl
            // 
            this.mnuMiHorarioAl.Name = "mnuMiHorarioAl";
            this.mnuMiHorarioAl.Size = new System.Drawing.Size(14, 26);
            // 
            // mnuMisCalifs
            // 
            this.mnuMisCalifs.Name = "mnuMisCalifs";
            this.mnuMisCalifs.Size = new System.Drawing.Size(14, 26);
            // 
            // mnuHistorial
            // 
            this.mnuHistorial.Name = "mnuHistorial";
            this.mnuHistorial.Size = new System.Drawing.Size(14, 26);
            // 
            // mnuMisPaquetes
            // 
            this.mnuMisPaquetes.Name = "mnuMisPaquetes";
            this.mnuMisPaquetes.Size = new System.Drawing.Size(14, 26);
            // 
            // mnuReporteAl
            // 
            this.mnuReporteAl.Name = "mnuReporteAl";
            this.mnuReporteAl.Size = new System.Drawing.Size(14, 26);
            // 
            // pnlContenido
            // 
            this.pnlContenido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.pnlContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenido.Location = new System.Drawing.Point(0, 84);
            this.pnlContenido.Name = "pnlContenido";
            this.pnlContenido.Size = new System.Drawing.Size(1100, 570);
            this.pnlContenido.TabIndex = 0;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.pnlHeader.Controls.Add(this.lblNombreAlumno);
            this.pnlHeader.Controls.Add(this.lblInfoAlumno);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 30);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(16, 6, 16, 6);
            this.pnlHeader.Size = new System.Drawing.Size(1100, 54);
            this.pnlHeader.TabIndex = 1;
            // 
            // lblNombreAlumno
            // 
            this.lblNombreAlumno.AutoSize = true;
            this.lblNombreAlumno.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblNombreAlumno.ForeColor = System.Drawing.Color.White;
            this.lblNombreAlumno.Location = new System.Drawing.Point(16, 8);
            this.lblNombreAlumno.Name = "lblNombreAlumno";
            this.lblNombreAlumno.Size = new System.Drawing.Size(200, 30);
            this.lblNombreAlumno.TabIndex = 0;
            this.lblNombreAlumno.Text = "Portal del Alumno";
            // 
            // lblInfoAlumno
            // 
            this.lblInfoAlumno.AutoSize = true;
            this.lblInfoAlumno.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblInfoAlumno.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblInfoAlumno.Location = new System.Drawing.Point(16, 32);
            this.lblInfoAlumno.Name = "lblInfoAlumno";
            this.lblInfoAlumno.Size = new System.Drawing.Size(83, 20);
            this.lblInfoAlumno.TabIndex = 1;
            this.lblInfoAlumno.Text = "Cargando...";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslStatus,
            this.tslFecha});
            this.statusStrip1.Location = new System.Drawing.Point(0, 654);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1100, 26);
            this.statusStrip1.TabIndex = 3;
            // 
            // tslStatus
            // 
            this.tslStatus.ForeColor = System.Drawing.Color.White;
            this.tslStatus.Name = "tslStatus";
            this.tslStatus.Size = new System.Drawing.Size(40, 20);
            this.tslStatus.Text = "Listo";
            // 
            // tslFecha
            // 
            this.tslFecha.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tslFecha.ForeColor = System.Drawing.Color.White;
            this.tslFecha.Name = "tslFecha";
            this.tslFecha.Size = new System.Drawing.Size(124, 20);
            this.tslFecha.Text = "25/05/2026 19:52";
            // 
            // FrmAlumno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 680);
            this.Controls.Add(this.pnlContenido);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmAlumno";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Reinscripciones — Alumno";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuMiHorarioAl;
        private System.Windows.Forms.ToolStripMenuItem mnuMisCalifs;
        private System.Windows.Forms.ToolStripMenuItem mnuHistorial;
        private System.Windows.Forms.ToolStripMenuItem mnuMisPaquetes;
        private System.Windows.Forms.ToolStripMenuItem mnuReporteAl;
        private System.Windows.Forms.Panel pnlContenido;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblNombreAlumno;
        private System.Windows.Forms.Label lblInfoAlumno;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tslStatus;
        private System.Windows.Forms.ToolStripStatusLabel tslFecha;
    }
}
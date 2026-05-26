// ═══════════════════════════════════════════════════════
// FormMaestro.Designer.cs
// ═══════════════════════════════════════════════════════
namespace SistemaReinscripciones
{
    partial class FrmMaestro
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
            this.mnuMiHorario = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMisGrupos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCalificaciones = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReportesMaestro = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlContenido = new System.Windows.Forms.Panel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblNombreMaestro = new System.Windows.Forms.Label();
            this.lblInfoMaestro = new System.Windows.Forms.Label();
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
            this.mnuMiHorario,
            this.mnuMisGrupos,
            this.mnuCalificaciones,
            this.mnuReportesMaestro});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(1100, 24);
            this.menuStrip1.TabIndex = 2;
            // 
            // mnuMiHorario
            // 
            this.mnuMiHorario.Name = "mnuMiHorario";
            this.mnuMiHorario.Size = new System.Drawing.Size(14, 20);
            // 
            // mnuMisGrupos
            // 
            this.mnuMisGrupos.Name = "mnuMisGrupos";
            this.mnuMisGrupos.Size = new System.Drawing.Size(14, 20);
            // 
            // mnuCalificaciones
            // 
            this.mnuCalificaciones.Name = "mnuCalificaciones";
            this.mnuCalificaciones.Size = new System.Drawing.Size(14, 20);
            // 
            // mnuReportesMaestro
            // 
            this.mnuReportesMaestro.Name = "mnuReportesMaestro";
            this.mnuReportesMaestro.Size = new System.Drawing.Size(14, 20);
            // 
            // pnlContenido
            // 
            this.pnlContenido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.pnlContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenido.Location = new System.Drawing.Point(0, 78);
            this.pnlContenido.Name = "pnlContenido";
            this.pnlContenido.Size = new System.Drawing.Size(1100, 576);
            this.pnlContenido.TabIndex = 0;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.pnlHeader.Controls.Add(this.lblNombreMaestro);
            this.pnlHeader.Controls.Add(this.lblInfoMaestro);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 24);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(16, 6, 16, 6);
            this.pnlHeader.Size = new System.Drawing.Size(1100, 54);
            this.pnlHeader.TabIndex = 1;
            // 
            // lblNombreMaestro
            // 
            this.lblNombreMaestro.AutoSize = true;
            this.lblNombreMaestro.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblNombreMaestro.ForeColor = System.Drawing.Color.White;
            this.lblNombreMaestro.Location = new System.Drawing.Point(16, 8);
            this.lblNombreMaestro.Name = "lblNombreMaestro";
            this.lblNombreMaestro.Size = new System.Drawing.Size(206, 30);
            this.lblNombreMaestro.TabIndex = 0;
            this.lblNombreMaestro.Text = "Portal del Maestro";
            // 
            // lblInfoMaestro
            // 
            this.lblInfoMaestro.AutoSize = true;
            this.lblInfoMaestro.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblInfoMaestro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblInfoMaestro.Location = new System.Drawing.Point(16, 32);
            this.lblInfoMaestro.Name = "lblInfoMaestro";
            this.lblInfoMaestro.Size = new System.Drawing.Size(83, 20);
            this.lblInfoMaestro.TabIndex = 1;
            this.lblInfoMaestro.Text = "Cargando...";
            this.lblInfoMaestro.Click += new System.EventHandler(this.lblInfoMaestro_Click);
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
            this.tslFecha.Text = "25/05/2026 21:19";
            // 
            // FrmMaestro
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
            this.Name = "FrmMaestro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Reinscripciones — Maestro";
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
        private System.Windows.Forms.ToolStripMenuItem mnuMiHorario;
        private System.Windows.Forms.ToolStripMenuItem mnuMisGrupos;
        private System.Windows.Forms.ToolStripMenuItem mnuCalificaciones;
        private System.Windows.Forms.ToolStripMenuItem mnuReportesMaestro;
        private System.Windows.Forms.Panel pnlContenido;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblNombreMaestro;
        private System.Windows.Forms.Label lblInfoMaestro;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tslStatus;
        private System.Windows.Forms.ToolStripStatusLabel tslFecha;
    }
}
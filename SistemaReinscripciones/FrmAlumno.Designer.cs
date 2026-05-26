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
            this.SuspendLayout();

            // ── menuStrip ─────────────────────────────────────────────────────
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(0, 109, 109);
            this.menuStrip1.ForeColor = System.Drawing.Color.White;
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9.5f, System.Drawing.FontStyle.Bold);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.mnuMiHorarioAl, this.mnuMisCalifs,
                this.mnuHistorial, this.mnuMisPaquetes, this.mnuReporteAl });
            this.menuStrip1.Size = new System.Drawing.Size(1100, 28);

            // Configure menu items
            ConfigureMenuItem(mnuMiHorarioAl, "MI HORARIO", mnuMiHorarioAl_Click);
            ConfigureMenuItem(mnuMisCalifs, "CALIFICACIONES", mnuMisCalifs_Click);
            ConfigureMenuItem(mnuHistorial, "HISTORIAL", mnuHistorial_Click);
            ConfigureMenuItem(mnuMisPaquetes, "MIS PAQUETES", mnuMisPaquetes_Click);
            ConfigureMenuItem(mnuReporteAl, "REPORTE PDF", mnuReporteAl_Click);

            // ── pnlHeader ─────────────────────────────────────────────────────
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 54;
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(0, 90, 90);
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(16, 6, 16, 6);

            this.lblNombreAlumno.AutoSize = true;
            this.lblNombreAlumno.Font = new System.Drawing.Font("Segoe UI", 13f, System.Drawing.FontStyle.Bold);
            this.lblNombreAlumno.ForeColor = System.Drawing.Color.White;
            this.lblNombreAlumno.Location = new System.Drawing.Point(16, 8);
            this.lblNombreAlumno.Text = "Portal del Alumno";

            this.lblInfoAlumno.AutoSize = true;
            this.lblInfoAlumno.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblInfoAlumno.ForeColor = System.Drawing.Color.FromArgb(180, 230, 230);
            this.lblInfoAlumno.Location = new System.Drawing.Point(16, 32);
            this.lblInfoAlumno.Text = "Cargando...";

            this.pnlHeader.Controls.Add(this.lblNombreAlumno);
            this.pnlHeader.Controls.Add(this.lblInfoAlumno);

            // ── pnlContenido ──────────────────────────────────────────────────
            this.pnlContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenido.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);

            // ── statusStrip ───────────────────────────────────────────────────
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(0, 109, 109);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.tslStatus, this.tslFecha });
            this.tslStatus.ForeColor = System.Drawing.Color.White;
            this.tslStatus.Text = "Listo";
            this.tslFecha.ForeColor = System.Drawing.Color.White;
            this.tslFecha.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tslFecha.Text = System.DateTime.Now.ToString("dd/MM/yyyy HH:mm");

            // ── Form ──────────────────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(7f, 15f);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 680);
            this.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormAlumno";
            this.Text = "Sistema de Reinscripciones — Alumno";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

            this.Controls.Add(this.pnlContenido);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);

            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
namespace SistemaReinscripciones
{
    partial class FormAdmin
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.alumnosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mATERIASToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hORARIOSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rEINSCRIPCIONToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mAESTROSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rEPORTESToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aDMINToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlContenido = new System.Windows.Forms.Panel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblBienvenido = new System.Windows.Forms.Label();
            this.lblRolAdmin = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tslStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslFecha = new System.Windows.Forms.ToolStripStatusLabel();

            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();

            // ── menuStrip1 ────────────────────────────────────────────────────
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(0, 109, 109);
            this.menuStrip1.ForeColor = System.Drawing.Color.White;
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.alumnosToolStripMenuItem,
                this.mATERIASToolStripMenuItem,
                this.hORARIOSToolStripMenuItem,
                this.rEINSCRIPCIONToolStripMenuItem,
                this.mAESTROSToolStripMenuItem,
                this.rEPORTESToolStripMenuItem,
                this.aDMINToolStripMenuItem });
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1100, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9.5f, System.Drawing.FontStyle.Bold);

            // ── Items del menú ────────────────────────────────────────────────
            void EstiloItem(System.Windows.Forms.ToolStripMenuItem item, string texto)
            {
                item.Text = texto;
                item.ForeColor = System.Drawing.Color.White;
                item.BackColor = System.Drawing.Color.FromArgb(0, 109, 109);
                item.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            }

            EstiloItem(alumnosToolStripMenuItem, "ALUMNOS");
            EstiloItem(mATERIASToolStripMenuItem, "MATERIAS");
            EstiloItem(hORARIOSToolStripMenuItem, "HORARIOS");
            EstiloItem(rEINSCRIPCIONToolStripMenuItem, "REINSCRIPCIÓN");
            EstiloItem(mAESTROSToolStripMenuItem, "MAESTROS");
            EstiloItem(rEPORTESToolStripMenuItem, "REPORTES");
            EstiloItem(aDMINToolStripMenuItem, "ADMIN");

            this.alumnosToolStripMenuItem.Click += alumnosToolStripMenuItem_Click;
            this.mATERIASToolStripMenuItem.Click += mATERIASToolStripMenuItem_Click;
            this.hORARIOSToolStripMenuItem.Click += hORARIOSToolStripMenuItem_Click;
            this.rEINSCRIPCIONToolStripMenuItem.Click += rEINSCRIPCIONToolStripMenuItem_Click;
            this.mAESTROSToolStripMenuItem.Click += mAESTROSToolStripMenuItem_Click;
            this.rEPORTESToolStripMenuItem.Click += rEPORTESToolStripMenuItem_Click;
            this.aDMINToolStripMenuItem.Click += aDMINToolStripMenuItem_Click;

            // ── pnlHeader ─────────────────────────────────────────────────────
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 54;
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(0, 90, 90);
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(16, 6, 16, 6);

            this.lblBienvenido.AutoSize = true;
            this.lblBienvenido.Font = new System.Drawing.Font("Segoe UI", 13f, System.Drawing.FontStyle.Bold);
            this.lblBienvenido.ForeColor = System.Drawing.Color.White;
            this.lblBienvenido.Location = new System.Drawing.Point(16, 8);
            this.lblBienvenido.Text = "Panel de Administración";

            this.lblRolAdmin.AutoSize = true;
            this.lblRolAdmin.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblRolAdmin.ForeColor = System.Drawing.Color.FromArgb(180, 230, 230);
            this.lblRolAdmin.Location = new System.Drawing.Point(16, 32);
            this.lblRolAdmin.Text = "Administrador del sistema";

            this.pnlHeader.Controls.Add(this.lblBienvenido);
            this.pnlHeader.Controls.Add(this.lblRolAdmin);

            // ── pnlContenido ──────────────────────────────────────────────────
            this.pnlContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenido.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.pnlContenido.Name = "pnlContenido";

            // ── statusStrip ───────────────────────────────────────────────────
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(0, 109, 109);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.tslStatus, this.tslFecha });

            this.tslStatus.ForeColor = System.Drawing.Color.White;
            this.tslStatus.Text = "Listo";

            this.tslFecha.ForeColor = System.Drawing.Color.White;
            this.tslFecha.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tslFecha.Text = System.DateTime.Now.ToString("dd/MM/yyyy HH:mm");

            // ── FormAdmin ─────────────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(7f, 15f);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 680);
            this.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormAdmin";
            this.Text = "Sistema de Reinscripciones — Administrador";
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

        // Controles
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem alumnosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mATERIASToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hORARIOSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rEINSCRIPCIONToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mAESTROSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rEPORTESToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aDMINToolStripMenuItem;
        private System.Windows.Forms.Panel pnlContenido;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblBienvenido;
        private System.Windows.Forms.Label lblRolAdmin;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tslStatus;
        private System.Windows.Forms.ToolStripStatusLabel tslFecha;
    }
}
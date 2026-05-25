using System.Drawing;
using System.Windows.Forms;

namespace SistemaReinscripciones
{
    partial class Form2
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlCard = new System.Windows.Forms.Panel();
            this.lblIcono = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.pnlLinea = new System.Windows.Forms.Panel();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblPasswL = new System.Windows.Forms.Label();
            this.txtPassw = new System.Windows.Forms.TextBox();
            this.lblRolL = new System.Windows.Forms.Label();
            this.cmbRol = new System.Windows.Forms.ComboBox();
            this.lblError = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lblAyuda = new System.Windows.Forms.Label();
            this.pnlSombra = new System.Windows.Forms.Panel();
            this.pnlCard.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCard
            // 
            this.pnlCard.BackColor = System.Drawing.Color.White;
            this.pnlCard.Controls.Add(this.lblIcono);
            this.pnlCard.Controls.Add(this.lblTitulo);
            this.pnlCard.Controls.Add(this.lblSubtitulo);
            this.pnlCard.Controls.Add(this.pnlLinea);
            this.pnlCard.Controls.Add(this.lblUsuario);
            this.pnlCard.Controls.Add(this.txtUsuario);
            this.pnlCard.Controls.Add(this.lblPasswL);
            this.pnlCard.Controls.Add(this.txtPassw);
            this.pnlCard.Controls.Add(this.lblRolL);
            this.pnlCard.Controls.Add(this.cmbRol);
            this.pnlCard.Controls.Add(this.lblError);
            this.pnlCard.Controls.Add(this.button1);
            this.pnlCard.Controls.Add(this.lblAyuda);
            this.pnlCard.Location = new System.Drawing.Point(40, 40);
            this.pnlCard.Name = "pnlCard";
            this.pnlCard.Padding = new System.Windows.Forms.Padding(30, 20, 30, 20);
            this.pnlCard.Size = new System.Drawing.Size(360, 460);
            this.pnlCard.TabIndex = 0;
            // 
            // lblIcono
            // 
            this.lblIcono.Font = new System.Drawing.Font("Segoe UI Emoji", 32F);
            this.lblIcono.Location = new System.Drawing.Point(30, 18);
            this.lblIcono.Name = "lblIcono";
            this.lblIcono.Size = new System.Drawing.Size(300, 54);
            this.lblIcono.TabIndex = 0;
            this.lblIcono.Text = "🎓";
            this.lblIcono.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.lblTitulo.Location = new System.Drawing.Point(30, 78);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(300, 26);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Sistema de Reinscripciones";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.Gray;
            this.lblSubtitulo.Location = new System.Drawing.Point(30, 106);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(300, 18);
            this.lblSubtitulo.TabIndex = 2;
            this.lblSubtitulo.Text = "Ing. en Sistemas Computacionales";
            this.lblSubtitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlLinea
            // 
            this.pnlLinea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(242)))), ((int)(((byte)(241)))));
            this.pnlLinea.Location = new System.Drawing.Point(30, 132);
            this.pnlLinea.Name = "pnlLinea";
            this.pnlLinea.Size = new System.Drawing.Size(300, 1);
            this.pnlLinea.TabIndex = 3;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblUsuario.Location = new System.Drawing.Point(30, 148);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(112, 15);
            this.lblUsuario.TabIndex = 4;
            this.lblUsuario.Text = "Usuario / Matrícula";
            // 
            // txtUsuario
            // 
            this.txtUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsuario.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtUsuario.Location = new System.Drawing.Point(30, 168);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(300, 26);
            this.txtUsuario.TabIndex = 5;
            this.txtUsuario.Text = "ej. 21sc0001";
            // 
            // lblPasswL
            // 
            this.lblPasswL.AutoSize = true;
            this.lblPasswL.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblPasswL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblPasswL.Location = new System.Drawing.Point(30, 212);
            this.lblPasswL.Name = "lblPasswL";
            this.lblPasswL.Size = new System.Drawing.Size(69, 15);
            this.lblPasswL.TabIndex = 6;
            this.lblPasswL.Text = "Contraseña";
            // 
            // txtPassw
            // 
            this.txtPassw.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.txtPassw.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassw.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtPassw.Location = new System.Drawing.Point(30, 232);
            this.txtPassw.Name = "txtPassw";
            this.txtPassw.Size = new System.Drawing.Size(300, 26);
            this.txtPassw.TabIndex = 7;
            this.txtPassw.Text = "••••••••";
            this.txtPassw.UseSystemPasswordChar = true;
            // 
            // lblRolL
            // 
            this.lblRolL.AutoSize = true;
            this.lblRolL.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblRolL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblRolL.Location = new System.Drawing.Point(30, 278);
            this.lblRolL.Name = "lblRolL";
            this.lblRolL.Size = new System.Drawing.Size(87, 15);
            this.lblRolL.TabIndex = 8;
            this.lblRolL.Text = "Acceder como";
            // 
            // cmbRol
            // 
            this.cmbRol.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.cmbRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbRol.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.cmbRol.Location = new System.Drawing.Point(30, 298);
            this.cmbRol.Name = "cmbRol";
            this.cmbRol.Size = new System.Drawing.Size(300, 27);
            this.cmbRol.TabIndex = 9;
            // 
            // lblError
            // 
            this.lblError.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.lblError.Location = new System.Drawing.Point(30, 340);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(300, 18);
            this.lblError.TabIndex = 10;
            this.lblError.Visible = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(30, 366);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(300, 40);
            this.button1.TabIndex = 11;
            this.button1.Text = "Iniciar sesión";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // lblAyuda
            // 
            this.lblAyuda.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblAyuda.ForeColor = System.Drawing.Color.Gray;
            this.lblAyuda.Location = new System.Drawing.Point(30, 420);
            this.lblAyuda.Name = "lblAyuda";
            this.lblAyuda.Size = new System.Drawing.Size(300, 16);
            this.lblAyuda.TabIndex = 12;
            this.lblAyuda.Text = "¿Problemas para acceder? Contacta a Control Escolar";
            this.lblAyuda.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlSombra
            // 
            this.pnlSombra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            this.pnlSombra.Location = new System.Drawing.Point(42, 42);
            this.pnlSombra.Name = "pnlSombra";
            this.pnlSombra.Size = new System.Drawing.Size(364, 464);
            this.pnlSombra.TabIndex = 1;
            // 
            // Form2
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(440, 540);
            this.Controls.Add(this.pnlCard);
            this.Controls.Add(this.pnlSombra);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ITSC — Iniciar sesión";
            this.pnlCard.ResumeLayout(false);
            this.pnlCard.PerformLayout();
            this.ResumeLayout(false);

        }

        // ── Controles declarados ──────────────────────────────────────────────
        private Panel pnlCard;
        private Panel pnlLinea;
        private Label lblIcono;
        private Label lblTitulo;
        private Label lblSubtitulo;
        private Label lblUsuario;
        private TextBox txtUsuario;
        private Label lblPasswL;
        private TextBox txtPassw;
        private Label lblRolL;
        private ComboBox cmbRol;
        private Label lblError;
        private Button button1;
        private Label lblAyuda;
        private Panel pnlSombra;
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace SistemaReinscripciones
{
    // ═══════════════════════════════════════════════════════════════════════
    // UcBase — clase base para todos los UserControls del sistema.
    // Cada UC hereda de aquí y sobreescribe Inicializar() y BuildUI().
    // ═══════════════════════════════════════════════════════════════════════
    public partial class UcBase : UserControl
    {
        // Propiedades que inyecta el Form padre
        public string Conn { get; set; }
        public string NumControl { get; set; }   // para alumnos
        public string NumEmpleado { get; set; }   // para maestros
        public string Username { get; set; }

        // Controles compartidos de layout
        protected Panel pnlTop;     // barra superior con título y botones
        protected Panel pnlBody;    // área de contenido principal
        protected Label lblTitulo;

        public UcBase()
        {
            this.BackColor = Color.FromArgb(245, 247, 250);
            this.Dock = DockStyle.Fill;
            ConstruirLayoutBase();
        }

        private void ConstruirLayoutBase()
        {
            // Barra superior teal
            pnlTop = new Panel();
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Height = 48;
            pnlTop.BackColor = Color.FromArgb(0, 128, 128);
            pnlTop.Padding = new Padding(14, 0, 14, 0);

            lblTitulo = new Label();
            lblTitulo.Dock = DockStyle.Left;
            lblTitulo.Font = new Font("Segoe UI", 12f, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.TextAlign = ContentAlignment.MiddleLeft;
            lblTitulo.AutoSize = false;
            lblTitulo.Width = 400;
            pnlTop.Controls.Add(lblTitulo);

            // Área de contenido
            pnlBody = new Panel();
            pnlBody.Dock = DockStyle.Fill;
            pnlBody.BackColor = Color.FromArgb(245, 247, 250);
            pnlBody.Padding = new Padding(12);

            this.Controls.Add(pnlBody);
            this.Controls.Add(pnlTop);
        }

        // Sobreescribir en cada UC
        public virtual void Inicializar() { }

        // ── Helpers de estilo compartidos ────────────────────────────────────
        protected Button CrearBoton(string texto, bool peligro = false)
        {
            var btn = new Button();
            btn.Text = texto;
            btn.Height = 30;
            btn.AutoSize = true;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Segoe UI", 9f);
            btn.ForeColor = Color.White;
            btn.Cursor = Cursors.Hand;
            btn.Padding = new Padding(8, 0, 8, 0);
            btn.BackColor = peligro
                ? Color.FromArgb(198, 58, 58)
                : Color.FromArgb(0, 128, 128);
            btn.FlatAppearance.MouseOverBackColor = peligro
                ? Color.FromArgb(160, 40, 40)
                : Color.FromArgb(0, 90, 90);
            return btn;
        }

        protected DataGridView CrearGrid()
        {
            var dgv = new DataGridView();
            dgv.Dock = DockStyle.Fill;
            dgv.ReadOnly = true;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.BackgroundColor = Color.White;
            dgv.GridColor = Color.FromArgb(200, 200, 200);
            dgv.BorderStyle = BorderStyle.None;
            dgv.Font = new Font("Segoe UI", 9f);
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(224, 242, 241);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(0, 77, 77);
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            dgv.EnableHeadersVisualStyles = false;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 248, 248);
            dgv.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 128, 128);
            dgv.RowsDefaultCellStyle.SelectionForeColor = Color.White;
            dgv.RowTemplate.Height = 26;
            return dgv;
        }

        protected TextBox CrearBuscador(string placeholder = "Buscar...")
        {
            var txt = new TextBox();
            txt.Font = new Font("Segoe UI", 9.5f);
            txt.SetPlaceholder(placeholder);
            txt.Height = 28;
            txt.Width = 220;
            txt.BorderStyle = BorderStyle.FixedSingle;
            txt.BackColor = Color.FromArgb(248, 250, 250);
            return txt;
        }

        protected Label CrearMetrica(string titulo, string valor)
        {
            var pnl = new Panel();
            pnl.Width = 130;
            pnl.Height = 56;
            pnl.BackColor = Color.White;
            pnl.Padding = new Padding(10, 6, 10, 6);

            var lv = new Label();
            lv.Text = valor;
            lv.Font = new Font("Segoe UI", 16f, FontStyle.Bold);
            lv.ForeColor = Color.FromArgb(0, 128, 128);
            lv.AutoSize = true;
            lv.Location = new Point(10, 6);

            var lt = new Label();
            lt.Text = titulo;
            lt.Font = new Font("Segoe UI", 7.5f);
            lt.ForeColor = Color.Gray;
            lt.AutoSize = true;
            lt.Location = new Point(10, 34);

            pnl.Controls.AddRange(new Control[] { lv, lt });
            return lv; // retorna el label valor para actualizarlo
        }
    }

    static class TextBoxExtensions
    {
        private const int EM_SETCUEBANNER = 0x1501;

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, string lParam);

        public static void SetPlaceholder(this TextBox tb, string text)
        {
            if (tb.IsHandleCreated)
            {
                SendMessage(tb.Handle, EM_SETCUEBANNER, (IntPtr)1, text);
            }
            else
            {
                tb.HandleCreated += (s, e) => SendMessage(tb.Handle, EM_SETCUEBANNER, (IntPtr)1, text);
            }
        }
    }
}

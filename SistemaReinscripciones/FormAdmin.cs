using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaReinscripciones
{
    public partial class FormAdmin : Form
    {

        private readonly string _conn;
        private readonly string _username;

        // UserControls cargados una sola vez (lazy)
        private UcAlumnos _ucAlumnos;
        private UcMaterias _ucMaterias;
        private UcHorarios _ucHorarios;
        private UcReinscripcion _ucReinscripcion;
        private UcMaestros _ucMaestros;
        private UcReportes _ucReportes;
        private UcAdminUsuarios _ucAdmin;

        public FormAdmin(string conn, string username)
        {
            InitializeComponent();
            _conn = conn;
            _username = username;
            this.Load += FormAdmin_Load;
        }

        private void FormAdmin_Load(object sender, EventArgs e)
        {
            lblBienvenido.Text = $"Panel de Administración";
            lblRolAdmin.Text = $"Administrador: {_username}  |  {DateTime.Now:dddd dd/MM/yyyy}";
            tslFecha.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");

            // Mostrar alumnos al arrancar
            CargarControl(ObtenerUc<UcAlumnos>(ref _ucAlumnos));
        }

        // ── Menú handlers ─────────────────────────────────────────────────────
        private void alumnosToolStripMenuItem_Click(object sender, EventArgs e)
            => CargarControl(ObtenerUc<UcAlumnos>(ref _ucAlumnos));

        private void mATERIASToolStripMenuItem_Click(object sender, EventArgs e)
            => CargarControl(ObtenerUc<UcMaterias>(ref _ucMaterias));

        private void hORARIOSToolStripMenuItem_Click(object sender, EventArgs e)
            => CargarControl(ObtenerUc<UcHorarios>(ref _ucHorarios));

        private void rEINSCRIPCIONToolStripMenuItem_Click(object sender, EventArgs e)
            => CargarControl(ObtenerUc<UcReinscripcion>(ref _ucReinscripcion));

        private void mAESTROSToolStripMenuItem_Click(object sender, EventArgs e)
            => CargarControl(ObtenerUc<UcMaestros>(ref _ucMaestros));

        private void rEPORTESToolStripMenuItem_Click(object sender, EventArgs e)
            => CargarControl(ObtenerUc<UcReportes>(ref _ucReportes));

        private void aDMINToolStripMenuItem_Click(object sender, EventArgs e)
            => CargarControl(ObtenerUc<UcAdminUsuarios>(ref _ucAdmin));

        // ── Carga el UserControl en pnlContenido ──────────────────────────────
        private void CargarControl(UserControl uc)
        {
            pnlContenido.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            pnlContenido.Controls.Add(uc);
            tslStatus.Text = uc.Tag?.ToString() ?? "Listo";
        }

        // ── Lazy init: crea el UC solo la primera vez ─────────────────────────
        private T ObtenerUc<T>(ref T campo) where T : UserControl, new()
        {
            if (campo == null)
            {
                campo = new T();

                // Inyectar conn y username si el UC lo expone
                var tipo = typeof(T);
                tipo.GetProperty("Conn")?.SetValue(campo, _conn);
                tipo.GetProperty("Username")?.SetValue(campo, _username);

                // Llamar Inicializar() si existe
                tipo.GetMethod("Inicializar")?.Invoke(campo, null);
            }
            return campo;
        }
    }
}

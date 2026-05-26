using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaReinscripciones
{
    public partial class FrmMaestro : Form
    {
        private readonly string _conn;
        private readonly string _username;
        private readonly string _numEmpleado;

        private UcMiHorarioMaestro _ucHorario;
        private UcMisGrupos _ucGrupos;
        private UcCapturaCalifsM _ucCalifs;
        private UcReportesMaestro _ucReportes;

        public FrmMaestro(string conn, string username, string numEmpleado)
        {
            InitializeComponent();
            _conn = conn;
            _username = username;
            _numEmpleado = numEmpleado;
            this.Load += FormMaestro_Load;
        }

        private void FormMaestro_Load(object sender, EventArgs e)
        {
            CargarNombreMaestro();
            tslFecha.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            CargarControl(ObtenerUc<UcMiHorarioMaestro>(ref _ucHorario));
        }

        // ── Nombre del maestro desde BD ───────────────────────────────────────
        private void CargarNombreMaestro()
        {
            try
            {
                using (var cn = new SqlConnection(_conn))
                {
                    var cmd = new SqlCommand(
                        "SELECT Nombre + ' ' + Apellido_Paterno FROM maestros WHERE Num_empleado=@e", cn);
                    cmd.Parameters.AddWithValue("@e", _numEmpleado);
                    cn.Open();
                    object res = cmd.ExecuteScalar();
                    if (res != null)
                    {
                        lblNombreMaestro.Text = "Bienvenido, Dr(a). " + res.ToString().Trim();
                        lblInfoMaestro.Text = $"Empleado: {_numEmpleado}  |  {DateTime.Now:dddd dd/MM/yyyy}";
                    }
                }
            }
            catch { lblInfoMaestro.Text = _username; }
        }

        // ── Menú handlers ─────────────────────────────────────────────────────
        private void mnuMiHorario_Click(object sender, EventArgs e)
            => CargarControl(ObtenerUc<UcMiHorarioMaestro>(ref _ucHorario));

        private void mnuMisGrupos_Click(object sender, EventArgs e)
            => CargarControl(ObtenerUc<UcMisGrupos>(ref _ucGrupos));

        private void mnuCalificaciones_Click(object sender, EventArgs e)
            => CargarControl(ObtenerUc<UcCapturaCalifsM>(ref _ucCalifs));

        private void mnuReportesMaestro_Click(object sender, EventArgs e)
            => CargarControl(ObtenerUc<UcReportesMaestro>(ref _ucReportes));

        // ── Helpers ───────────────────────────────────────────────────────────
        private void CargarControl(UserControl uc)
        {
            pnlContenido.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            pnlContenido.Controls.Add(uc);
            tslStatus.Text = uc.Tag?.ToString() ?? "Listo";
        }

        private T ObtenerUc<T>(ref T campo) where T : UserControl, new()
        {
            if (campo == null)
            {
                campo = new T();
                var tipo = typeof(T);
                tipo.GetProperty("Conn")?.SetValue(campo, _conn);
                tipo.GetProperty("NumEmpleado")?.SetValue(campo, _numEmpleado);
                tipo.GetProperty("Username")?.SetValue(campo, _username);
                tipo.GetMethod("Inicializar")?.Invoke(campo, null);
            }
            return campo;
        }

        private void lblInfoMaestro_Click(object sender, EventArgs e)
        {

        }
    }
}

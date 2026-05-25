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
    public partial class FrmAlumno : Form
    {

        private readonly string _conn;
        private readonly string _username;
        private readonly string _numControl;

        private UcMiHorarioAlumno _ucHorario;
        private UcMisCalifs _ucCalifs;
        private UcHistorial _ucHistorial;
        private UcMisPaquetes _ucPaquetes;
        private UcReporteAlumno _ucReporte;

        public FrmAlumno(string conn, string username, string numControl)
        {
            InitializeComponent();
            _conn = conn;
            _username = username;
            _numControl = numControl;
            this.Load += FormAlumno_Load;
        }

        private void FormAlumno_Load(object sender, EventArgs e)
        {
            CargarNombreAlumno();
            tslFecha.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            CargarControl(ObtenerUc<UcMiHorarioAlumno>(ref _ucHorario));
        }

        private void CargarNombreAlumno()
        {
            try
            {
                using (var cn = new SqlConnection(_conn))
                {
                    var cmd = new SqlCommand(
                        @"SELECT Nombre + ' ' + Apellido_Paterno, Semestre, Carrera
                          FROM alumnos WHERE Num_control = @n", cn);
                    cmd.Parameters.AddWithValue("@n", _numControl);
                    cn.Open();
                    var dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        lblNombreAlumno.Text = "Bienvenido, " + dr[0].ToString().Trim();
                        lblInfoAlumno.Text =
                            $"Matrícula: {_numControl}  |  " +
                            $"Semestre: {dr[1]}°  |  {dr[2]}  |  " +
                            $"{DateTime.Now:dddd dd/MM/yyyy}";
                    }
                    dr.Close();
                }
            }
            catch { lblInfoAlumno.Text = _numControl; }
        }

        // ── Menú handlers ─────────────────────────────────────────────────────
        private void mnuMiHorarioAl_Click(object sender, EventArgs e)
            => CargarControl(ObtenerUc<UcMiHorarioAlumno>(ref _ucHorario));

        private void mnuMisCalifs_Click(object sender, EventArgs e)
            => CargarControl(ObtenerUc<UcMisCalifs>(ref _ucCalifs));

        private void mnuHistorial_Click(object sender, EventArgs e)
            => CargarControl(ObtenerUc<UcHistorial>(ref _ucHistorial));

        private void mnuMisPaquetes_Click(object sender, EventArgs e)
            => CargarControl(ObtenerUc<UcMisPaquetes>(ref _ucPaquetes));

        private void mnuReporteAl_Click(object sender, EventArgs e)
            => CargarControl(ObtenerUc<UcReporteAlumno>(ref _ucReporte));

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
                tipo.GetProperty("NumControl")?.SetValue(campo, _numControl);
                tipo.GetProperty("Username")?.SetValue(campo, _username);
                tipo.GetMethod("Inicializar")?.Invoke(campo, null);
            }
            return campo;
        }
    }
}

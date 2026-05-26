using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
namespace SistemaReinscripciones
{
    public partial class Form2 : Form
    {
        // ── Cadena de conexión centralizada ──────────────────────────────────
        private readonly string _conn =
            "Server=100.88.175.118;Database=Proyecto_Final_Horarios;" +
            "User Id=sa;Password=MyP@ssw0rd2026!;";

        // Usuario especial admin local
        private const string ADMIN_ESPECIAL_USUARIO = "Jessi";
        private const string ADMIN_ESPECIAL_PASSWORD = "3058";

        public Form2()
        {
            InitializeComponent();
            this.Load += Form2_Load;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // Llenar el combo de roles
            cmbRol.Items.Clear();
            cmbRol.Items.AddRange(new[] { "Alumno", "Maestro", "Admin" });
            cmbRol.SelectedIndex = 0;

            // Permitir Enter en el campo contraseña
            txtPassw.KeyDown += (s, ke) =>
            {
                if (ke.KeyCode == Keys.Enter) button1_Click_1(s, ke);
            };

            // Ocultar label de error al inicio
            lblError.Visible = false;

            AplicarEstilo();
        }

        // ── Botón Iniciar sesión ──────────────────────────────────────────────
        private void button1_Click_1(object sender, EventArgs e)
        {
           
            // Limpiar error anterior
            lblError.Visible = false;

            string user = txtUsuario.Text.Trim();
            string pass = txtPassw.Text;
            string rol = cmbRol.SelectedItem?.ToString() ?? "";

            // ── Validaciones básicas ──────────────────────────────────────
            if (string.IsNullOrEmpty(user))
            {
                MostrarError("Ingresa tu usuario o matrícula.");
                txtUsuario.Focus();
                return;
            }
            if (string.IsNullOrEmpty(pass))
            {
                MostrarError("Ingresa tu contraseña.");
                txtPassw.Focus();
                return;
            }

            // ═══════════════════════════════════════════════════════════════
            //  VERIFICAR USUARIO ADMIN ESPECIAL (Jessi)
            // ═══════════════════════════════════════════════════════════════
            if (user.Equals(ADMIN_ESPECIAL_USUARIO, StringComparison.OrdinalIgnoreCase) &&
                pass == ADMIN_ESPECIAL_PASSWORD)
            {
                // Login como admin especial
                RegistrarBitacoraLocal("Jessi", "Admin", "Login exitoso (Admin especial local)");

                // Abrir FormAdmin con nombre de usuario especial
                Form frmAdmin = new FormAdmin(_conn, "Jessi (Admin Local)");
                frmAdmin.Show();
                this.Hide();

                frmAdmin.FormClosed += (s, ex) =>
                {
                    RegistrarBitacoraLocal("Jessi", "Admin", "Logout");
                    Application.Exit();
                };
                return;
            }

            // ── CONSULTA SIN HASH ───────────────────
            try
            {
                using (SqlConnection cn = new SqlConnection(_conn))
                {
                    // MODIFICADO: Eliminé el hash y la condición Activo
                    SqlCommand cmd = new SqlCommand(
                        @"SELECT Rol, Id_referencia
                  FROM usuarios
                  WHERE Username = @u
                    AND Password_hash = @p
                    AND Rol = @r", cn);  // Eliminado "AND Activo = 1"

                    cmd.Parameters.AddWithValue("@u", user);
                    cmd.Parameters.AddWithValue("@p", pass);  // Compara texto plano
                    cmd.Parameters.AddWithValue("@r", rol);

                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        string rolDB = dr["Rol"].ToString();
                        string idRef = dr["Id_referencia"].ToString();
                        dr.Close();

                        // Registrar último acceso y bitácora
                        ActualizarUltimoAcceso(cn, user);
                        RegistrarBitacora(cn, user, rolDB, "Login exitoso");

                        // Abrir el Form correspondiente al rol
                        AbrirFormulario(rolDB, idRef, user);
                    }
                    else
                    {
                        dr.Close();
                        RegistrarBitacoraFallido(user, rol);
                        MostrarError("Usuario, contraseña o rol incorrecto.");
                        txtPassw.Clear();
                        txtPassw.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error de conexión:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }

        // ── Abrir el Form según el rol ────────────────────────────────────────
        private void AbrirFormulario(string rol, string idRef, string username)
        {
            Form frm;

            switch (rol)
            {
                case "Admin":
                    frm = new FormAdmin(_conn, username);
                    break;
                case "Maestro":
                    frm = new FrmMaestro(_conn, username, idRef);
                    break;
                case "Alumno":
                    frm = new FrmAlumno(_conn, username, idRef);
                    break;
                default:
                    MessageBox.Show("Rol no reconocido.");
                    return;
            }

            frm.Show();
            this.Hide();

            frm.FormClosed += (s, e) =>
            {
                RegistrarBitacoraFallido(username, rol);
                Application.Exit();
            };
        }

        // ── Combo de rol ──────────
        private void cmbRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Cambiar el placeholder del usuario según el rol seleccionado
            switch (cmbRol.SelectedItem?.ToString())
            {
                case "Alumno":
                    SetCueBanner(txtUsuario, "ej. 21sc0001");
                    break;
                case "Maestro":
                    SetCueBanner(txtUsuario, "ej. doc.hernandez");
                    break;
                case "Admin":
                    SetCueBanner(txtUsuario, "ej. admin");
                    break;
            }
        }

        // P/Invoke para establecer texto de placeholder (cue banner) en TextBox en .NET Framework
        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, string lParam);

        private const int EM_SETCUEBANNER = 0x1501;

        private void SetCueBanner(TextBox tb, string text)
        {
            if (tb == null) return;
            SendMessage(tb.Handle, EM_SETCUEBANNER, (IntPtr)1, text);
        }

        // ══════════════════════════════════════════════════════════════════════
        //  MÉTODOS AUXILIARES
        // ══════════════════════════════════════════════════════════════════════

        // Hash SHA-256 (mismo algoritmo que usa FrmAdmin al crear usuarios)
        private string HashSHA256(string texto)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(texto));
                StringBuilder sb = new StringBuilder();
                foreach (byte b in bytes)
                    sb.Append(b.ToString("X2"));
                return sb.ToString();
            }
        }

        private void ActualizarUltimoAcceso(SqlConnection cn, string user)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(
                    "UPDATE usuarios SET Ultimo_acceso = GETDATE() WHERE Username = @u", cn);
                cmd.Parameters.AddWithValue("@u", user);
                cmd.ExecuteNonQuery();
            }
            catch { }
        }

        private void RegistrarBitacora(SqlConnection cn, string user, string rol, string accion)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(
                    @"INSERT INTO bitacora_accesos (Username, Rol, Accion, IP_equipo)
                      VALUES (@u, @r, @a, @ip)", cn);
                cmd.Parameters.AddWithValue("@u", user);
                cmd.Parameters.AddWithValue("@r", rol);
                cmd.Parameters.AddWithValue("@a", accion);
                cmd.Parameters.AddWithValue("@ip", ObtenerIP());
                cmd.ExecuteNonQuery();
            }
            catch { }
        }

        private void RegistrarBitacoraLocal(string user, string rol, string accion)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(_conn))
                {
                    cn.Open();
                    RegistrarBitacora(cn, user, rol, accion);
                }
            }
            catch { }
        }

        private void RegistrarBitacoraFallido(string user, string rol)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(_conn))
                {
                    cn.Open();
                    RegistrarBitacora(cn, user, rol, "Login fallido");
                }
            }
            catch { }
        }

        private string ObtenerIP()
        {
            try { return System.Net.Dns.GetHostEntry("").AddressList[0].ToString(); }
            catch { return "Desconocida"; }
        }

        private void MostrarError(string mensaje)
        {
            lblError.Text = "⚠  " + mensaje;
            lblError.Visible = true;
        }

        // ── Estilo visual ─────────────────────────────────────────────────────
        private void AplicarEstilo()
        {
            // Form
            this.BackColor = Color.FromArgb(245, 247, 250);

            // Panel blanco central
            pnlCard.BackColor = Color.White;

            // Título
            lblTitulo.ForeColor = Color.FromArgb(0, 109, 109);

            // Subtítulo
            lblSubtitulo.ForeColor = Color.Gray;

            // Botón
            button1.BackColor = Color.FromArgb(0, 128, 128);
            button1.ForeColor = Color.White;
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 90, 90);
            button1.Cursor = Cursors.Hand;

            // Error
            lblError.ForeColor = Color.FromArgb(162, 45, 45);
        }
    }
}
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SistemaReinscripciones
{
    public partial class FrmPrincipal : Form
    {
        // Cambia la cadena de conexión según tu servidor y credenciales
        private string cadenaConexion = "Server=192.168.0.78;Database=Proyecto_Final_Horarios;User Id=sa;Password=MyP@ssw0rd2026!;";

        public FrmPrincipal()
        {
            InitializeComponent();
            // Suscripción manual de eventos por si el diseñador no los enlaza
            this.Load += FrmPrincipal_Load;

            // Inicializar combos
            InicializarCombos();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            CargarAlumnos();
            CargarMaterias();
            CargarHorarios();
            CargarCombosAlumnos();
            CargarCombosMaterias();
            CargarCombosPaquete();
            OcultarTodosPaneles();
            MostrarPanel(pnlAlumnos);
            tslInfo.Text = "Listo";

            dgvAlumnos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvMaterias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvHorarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvPaqRein.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvMatPaqRein.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvPaqLista.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvMatPaqDet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvHistCalif.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvResultCon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        // ==================== MÉTODOS AUXILIARES ====================
        private void OcultarTodosPaneles()
        {
            pnlAlumnos.Visible = false;
            pnlMaterias.Visible = false;
            pnlHorarios.Visible = false;
            pnlReinscripcion.Visible = false;
            pnlCalificaciones.Visible = false;
            pnlConsultas.Visible = false;
            pnlPaquetes.Visible = false;
            pnlEditAlumno.Visible = false;
        }

        private void MostrarPanel(Panel panel)
        {
            OcultarTodosPaneles();
            panel.Visible = true;
            panel.BringToFront();
            panel.Dock = DockStyle.Fill;
        }

        private void InicializarCombos()
        {
            if (cmbTipoCalif != null)
            {
                cmbTipoCalif.Items.Clear();
                cmbTipoCalif.Items.Add("No cursado (1)");
                cmbTipoCalif.Items.Add("Reprobado (2)");
                cmbTipoCalif.Items.Add("Aprobado (3)");
                cmbTipoCalif.SelectedIndex = 0;
            }
            if (cboConsultaTipo != null)
            {
                cboConsultaTipo.Items.Clear();
                cboConsultaTipo.Items.Add("Materias con prioridad 1");
                cboConsultaTipo.Items.Add("Horario del paquete A001-P01 (ejemplo)");
                cboConsultaTipo.Items.Add("Materias pendientes del alumno");
                cboConsultaTipo.Items.Add("Paquetes del alumno");
                cboConsultaTipo.SelectedIndex = 0;
            }
        }

        // ==================== CARGA DE DATOS ====================
        private void CargarAlumnos(string filtro = "")
        {
            string query = "SELECT Num_control, Nombre, Apellido_Paterno, Apellido_Materno, Carrera, Semestre, Curp, Clave_Paquete FROM alumnos";
            if (!string.IsNullOrWhiteSpace(filtro))
                query += " WHERE Nombre LIKE @filtro OR Num_control LIKE @filtro";
            using (SqlConnection cn = new SqlConnection(cadenaConexion))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, cn);
                if (!string.IsNullOrWhiteSpace(filtro))
                    da.SelectCommand.Parameters.AddWithValue("@filtro", "%" + filtro + "%");
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvAlumnos.DataSource = dt;
            }
        }

        private void CargarMaterias(string filtro = "")
        {
            string query = "SELECT Clave_Materia, Nombre, Creditos, Prioridad, Prerequisito FROM materias";
            if (!string.IsNullOrWhiteSpace(filtro))
                query += " WHERE Nombre LIKE @filtro OR Clave_Materia LIKE @filtro";
            using (SqlConnection cn = new SqlConnection(cadenaConexion))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, cn);
                if (!string.IsNullOrWhiteSpace(filtro))
                    da.SelectCommand.Parameters.AddWithValue("@filtro", "%" + filtro + "%");
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvMaterias.DataSource = dt;
            }
        }

        private void CargarHorarios(string filtro = "")
        {
            string query = @"SELECT h.Clave_Horario, h.Clave_Materia, m.Nombre AS Materia,
                            h.Hor_lun, h.Hor_mar, h.Hor_mie, h.Hor_jue, h.Hor_vie
                            FROM horaMaterias h
                            JOIN materias m ON h.Clave_Materia = m.Clave_Materia";
            if (!string.IsNullOrWhiteSpace(filtro))
                query += " WHERE m.Nombre LIKE @filtro OR h.Clave_Horario LIKE @filtro";
            using (SqlConnection cn = new SqlConnection(cadenaConexion))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, cn);
                if (!string.IsNullOrWhiteSpace(filtro))
                    da.SelectCommand.Parameters.AddWithValue("@filtro", "%" + filtro + "%");
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvHorarios.DataSource = dt;
            }
        }

        private void CargarCombosAlumnos()
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(cadenaConexion))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT Num_control, Nombre + ' ' + Apellido_Paterno AS NombreCompleto FROM alumnos", cn);
                da.Fill(dt);
            }
            if (cmbAlumRein != null) { cmbAlumRein.DataSource = dt.Copy(); cmbAlumRein.DisplayMember = "NombreCompleto"; cmbAlumRein.ValueMember = "Num_control"; }
            if (cmbAlumCalif != null) { cmbAlumCalif.DataSource = dt.Copy(); cmbAlumCalif.DisplayMember = "NombreCompleto"; cmbAlumCalif.ValueMember = "Num_control"; }
            if (cmbAlumPaq != null) { cmbAlumPaq.DataSource = dt.Copy(); cmbAlumPaq.DisplayMember = "NombreCompleto"; cmbAlumPaq.ValueMember = "Num_control"; }
        }

        private void CargarCombosMaterias()
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(cadenaConexion))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT Clave_Materia, Nombre FROM materias", cn);
                da.Fill(dt);
            }
            if (cmbMatCalif != null) { cmbMatCalif.DataSource = dt; cmbMatCalif.DisplayMember = "Nombre"; cmbMatCalif.ValueMember = "Clave_Materia"; }
        }

        private void CargarCombosPaquete()
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(cadenaConexion))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT Clave_Paquete FROM paquetes", cn);
                da.Fill(dt);
            }
            if (cboPaqueteAl != null) { cboPaqueteAl.DataSource = dt; cboPaqueteAl.DisplayMember = "Clave_Paquete"; cboPaqueteAl.ValueMember = "Clave_Paquete"; }
        }

        // ==================== ALUMNOS CRUD ====================
        private void btnBuscarAl_Click(object sender, EventArgs e) { CargarAlumnos(txtBuscarAl.Text); pnlEditAlumno.Visible = false; }
        private void btnAgregarAl_Click(object sender, EventArgs e) { LimpiarCamposAlumno(); pnlEditAlumno.Visible = true; pnlEditAlumno.BringToFront(); txtNumCtrlAl.ReadOnly = false; txtNumCtrlAl.Focus(); }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvAlumnos.CurrentRow == null) return;
            DataRowView row = (DataRowView)dgvAlumnos.CurrentRow.DataBoundItem;
            txtNumCtrlAl.Text = row["Num_control"].ToString();
            txtNombreAl.Text = row["Nombre"].ToString();
            txtApPatAl.Text = row["Apellido_Paterno"].ToString();
            txtApMatAl.Text = row["Apellido_Materno"].ToString();
            txtCarreraAl.Text = row["Carrera"].ToString();
            txtSemestreAl.Text = row["Semestre"].ToString();
            txtCurpAl.Text = row["Curp"].ToString();
            if (row["Clave_Paquete"] != DBNull.Value) cboPaqueteAl.SelectedValue = row["Clave_Paquete"].ToString();
            else cboPaqueteAl.SelectedIndex = -1;
            txtNumCtrlAl.ReadOnly = true;
            pnlEditAlumno.Visible = true; pnlEditAlumno.BringToFront();
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvAlumnos.CurrentRow == null) return;
            string numCtrl = dgvAlumnos.CurrentRow.Cells["Num_control"].Value.ToString();
            if (MessageBox.Show("¿Eliminar alumno " + numCtrl + "?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (SqlConnection cn = new SqlConnection(cadenaConexion))
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM alumnos WHERE Num_control = @num", cn);
                    cmd.Parameters.AddWithValue("@num", numCtrl);
                    cn.Open(); cmd.ExecuteNonQuery();
                }
                CargarAlumnos(); pnlEditAlumno.Visible = false;
            }
        }
        private void btnGuardarAl_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNumCtrlAl.Text) || string.IsNullOrWhiteSpace(txtNombreAl.Text))
            { MessageBox.Show("Número de control y nombre son obligatorios."); return; }
            using (SqlConnection cn = new SqlConnection(cadenaConexion))
            {
                cn.Open();
                SqlCommand cmd;
                if (txtNumCtrlAl.ReadOnly)
                {
                    cmd = new SqlCommand(@"UPDATE alumnos SET Nombre=@nom, Apellido_Paterno=@apPat, Apellido_Materno=@apMat,
                                        Carrera=@car, Semestre=@sem, Curp=@curp, Clave_Paquete=@paq
                                        WHERE Num_control=@num", cn);
                    cmd.Parameters.AddWithValue("@num", txtNumCtrlAl.Text);
                }
                else
                {
                    cmd = new SqlCommand(@"INSERT INTO alumnos (Num_control, Nombre, Apellido_Paterno, Apellido_Materno,
                                        Carrera, Semestre, Curp, Clave_Paquete)
                                        VALUES (@num, @nom, @apPat, @apMat, @car, @sem, @curp, @paq)", cn);
                    cmd.Parameters.AddWithValue("@num", txtNumCtrlAl.Text);
                }
                cmd.Parameters.AddWithValue("@nom", txtNombreAl.Text);
                cmd.Parameters.AddWithValue("@apPat", txtApPatAl.Text);
                cmd.Parameters.AddWithValue("@apMat", txtApMatAl.Text);
                cmd.Parameters.AddWithValue("@car", txtCarreraAl.Text);
                cmd.Parameters.AddWithValue("@sem", int.Parse(txtSemestreAl.Text));
                cmd.Parameters.AddWithValue("@curp", txtCurpAl.Text);
                cmd.Parameters.AddWithValue("@paq", cboPaqueteAl.SelectedValue == null ? DBNull.Value : cboPaqueteAl.SelectedValue);
                cmd.ExecuteNonQuery();
            }
            CargarAlumnos(); pnlEditAlumno.Visible = false;
        }
        private void btnCancelarAl_Click(object sender, EventArgs e) { pnlEditAlumno.Visible = false; }
        private void LimpiarCamposAlumno()
        {
            txtNumCtrlAl.Text = ""; txtNombreAl.Text = ""; txtApPatAl.Text = ""; txtApMatAl.Text = "";
            txtCarreraAl.Text = ""; txtSemestreAl.Text = ""; txtCurpAl.Text = ""; cboPaqueteAl.SelectedIndex = -1;
        }

        // ==================== MATERIAS ====================
        private void btnBuscarMat_Click(object sender, EventArgs e) => CargarMaterias(txtBuscarMat.Text);
        private void btnAgregarMat_Click(object sender, EventArgs e) { MessageBox.Show("Función en desarrollo"); }
        private void btnEditarMat_Click(object sender, EventArgs e) { MessageBox.Show("Función en desarrollo"); }
        private void btnEliminarMat_Click(object sender, EventArgs e) { MessageBox.Show("Función en desarrollo"); }

        // ==================== HORARIOS ====================
        private void btnBuscarHor_Click(object sender, EventArgs e) => CargarHorarios(txtBuscarHor.Text);
        private void btnAgregarHor_Click(object sender, EventArgs e) { MessageBox.Show("Función en desarrollo"); }
        private void btnEditarHor_Click(object sender, EventArgs e) { MessageBox.Show("Función en desarrollo"); }
        private void btnEliminarHor_Click(object sender, EventArgs e) { MessageBox.Show("Función en desarrollo"); }

        // ==================== REINSCRIPCIÓN ====================
        private void mnuReinscripcion_Click(object sender, EventArgs e)
        {
            MostrarPanel(pnlReinscripcion);
            CargarCombosAlumnos();
            dgvPaqRein.DataSource = null;
            dgvMatPaqRein.DataSource = null;
        }

        private void CargarPaquetesAlumno(string numCtrl)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(cadenaConexion))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT Clave_Paquete FROM paquetes WHERE Clave_Paquete LIKE '" + numCtrl + "%'", cn);
                da.Fill(dt);
            }
            dgvPaqRein.DataSource = dt;
        }
        private void dgvPaqRein_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPaqRein.CurrentRow == null) return;
            string paquete = dgvPaqRein.CurrentRow.Cells["Clave_Paquete"].Value.ToString();
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(cadenaConexion))
            {
                string sql = @"SELECT m.Nombre, h.Hor_lun, h.Hor_mar, h.Hor_mie, h.Hor_jue, h.Hor_vie
                               FROM materia_paquete mp
                               JOIN horaMaterias h ON mp.Clave_Horario = h.Clave_Horario
                               JOIN materias m ON h.Clave_Materia = m.Clave_Materia
                               WHERE mp.Clave_Paquete = @paq";
                SqlDataAdapter da = new SqlDataAdapter(sql, cn);
                da.SelectCommand.Parameters.AddWithValue("@paq", paquete);
                da.Fill(dt);
            }
            dgvMatPaqRein.DataSource = dt;
        }
        private void btnAsignarPaq_Click(object sender, EventArgs e)
        {
            if (dgvPaqRein.CurrentRow == null || cmbAlumRein.SelectedValue == null)
            { MessageBox.Show("Seleccione un paquete y un alumno"); return; }
            string paquete = dgvPaqRein.CurrentRow.Cells["Clave_Paquete"].Value.ToString();
            string numCtrl = cmbAlumRein.SelectedValue.ToString();
            using (SqlConnection cn = new SqlConnection(cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("UPDATE alumnos SET Clave_Paquete = @paq WHERE Num_control = @num", cn);
                cmd.Parameters.AddWithValue("@paq", paquete);
                cmd.Parameters.AddWithValue("@num", numCtrl);
                cn.Open(); cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Paquete asignado al alumno");
            CargarAlumnos();
        }

        // ==================== CALIFICACIONES ====================
        private void mnuCalificacion_Click(object sender, EventArgs e)
        {
            MostrarPanel(pnlCalificaciones);
            CargarCombosAlumnos();
            CargarCombosMaterias();
            cmbAlumCalif_SelectedIndexChanged(null, null);
        }
        private void cmbAlumCalif_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAlumCalif.SelectedValue == null) return;
            string numCtrl = cmbAlumCalif.SelectedValue.ToString();
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(cadenaConexion))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT rc.Clave_materia, m.Nombre, rc.Calificacion, rc.Tipo_acred FROM registro_calificaciones rc JOIN materias m ON rc.Clave_materia = m.Clave_Materia WHERE rc.Num_control = @num", cn);
                da.SelectCommand.Parameters.AddWithValue("@num", numCtrl);
                da.Fill(dt);
            }
            dgvHistCalif.DataSource = dt;
        }
        private void btnGuardarCalif_Click(object sender, EventArgs e)
        {
            if (cmbAlumCalif.SelectedValue == null || cmbMatCalif.SelectedValue == null)
            { MessageBox.Show("Seleccione alumno y materia"); return; }
            string numCtrl = cmbAlumCalif.SelectedValue.ToString();
            string claveMat = cmbMatCalif.SelectedValue.ToString();
            if (!int.TryParse(txtCalif.Text, out int calif)) { MessageBox.Show("Calificación inválida"); return; }
            int tipo = cmbTipoCalif.SelectedIndex + 1;
            using (SqlConnection cn = new SqlConnection(cadenaConexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(@"IF EXISTS (SELECT 1 FROM registro_calificaciones WHERE Num_control=@num AND Clave_materia=@cla) 
                                                  UPDATE registro_calificaciones SET Calificacion=@cal, Tipo_acred=@tip WHERE Num_control=@num AND Clave_materia=@cla 
                                                  ELSE 
                                                  INSERT INTO registro_calificaciones (Num_control, Clave_materia, Calificacion, Tipo_acred) VALUES (@num, @cla, @cal, @tip)", cn);
                cmd.Parameters.AddWithValue("@num", numCtrl);
                cmd.Parameters.AddWithValue("@cla", claveMat);
                cmd.Parameters.AddWithValue("@cal", calif);
                cmd.Parameters.AddWithValue("@tip", tipo);
                cmd.ExecuteNonQuery();
            }
            cmbAlumCalif_SelectedIndexChanged(null, null);
            MessageBox.Show("Calificación guardada");
        }

        // ==================== CONSULTAS ====================
        private void mnuConsulta_Click(object sender, EventArgs e)
        {
            MostrarPanel(pnlConsultas);
            if (cboConsultaTipo.Items.Count == 0) InicializarCombos();
        }
        private void btnEjecutarCon_Click(object sender, EventArgs e)
        {
            if (cboConsultaTipo.SelectedIndex == -1) return;
            DataTable dt = new DataTable();
            string consulta = "";
            switch (cboConsultaTipo.SelectedIndex)
            {
                case 0: consulta = "SELECT Clave_Materia, Nombre, Creditos FROM materias WHERE Prioridad = 1 ORDER BY Creditos DESC"; break;
                case 1: consulta = "SELECT p.Clave_Paquete, m.Nombre, h.Hor_lun, h.Hor_mar, h.Hor_mie, h.Hor_jue, h.Hor_vie FROM paquetes p JOIN materia_paquete mp ON p.Clave_Paquete = mp.Clave_Paquete JOIN horaMaterias h ON mp.Clave_Horario = h.Clave_Horario JOIN materias m ON h.Clave_Materia = m.Clave_Materia WHERE p.Clave_Paquete = 'A001-P01'"; break;
                case 2:
                    if (cmbAlumPaq.SelectedValue != null)
                        consulta = "SELECT m.Nombre FROM registro_calificaciones rc RIGHT JOIN materias m ON rc.Clave_materia = m.Clave_Materia AND rc.Num_control = '" + cmbAlumPaq.SelectedValue.ToString() + "' WHERE rc.Tipo_acred IS NULL OR rc.Tipo_acred = 2";
                    else consulta = "SELECT 'Seleccione un alumno en el panel de Paquetes' AS Mensaje";
                    break;
                case 3:
                    if (cmbAlumPaq.SelectedValue != null)
                        consulta = "SELECT Clave_Paquete FROM paquetes WHERE Clave_Paquete LIKE '" + cmbAlumPaq.SelectedValue.ToString() + "%'";
                    else consulta = "SELECT 'Seleccione un alumno en el panel de Paquetes' AS Mensaje";
                    break;
            }
            if (!string.IsNullOrEmpty(consulta))
            {
                using (SqlConnection cn = new SqlConnection(cadenaConexion))
                {
                    SqlDataAdapter da = new SqlDataAdapter(consulta, cn);
                    da.Fill(dt);
                }
                dgvResultCon.DataSource = dt;
            }
        }

        // ==================== PAQUETES (CONSULTA) ====================
        private void mnuPaquetes_Click(object sender, EventArgs e)
        {
            MostrarPanel(pnlPaquetes);
            CargarCombosAlumnos();
            if (cmbAlumPaq.Items.Count > 0) cmbAlumPaq.SelectedIndex = -1;
            dgvPaqLista.DataSource = null;
            dgvMatPaqDet.DataSource = null;
        }
        private void cmbAlumPaq_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAlumPaq.SelectedValue == null) return;
            string num = cmbAlumPaq.SelectedValue.ToString();
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(cadenaConexion))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT Clave_Paquete FROM paquetes WHERE Clave_Paquete LIKE '" + num + "%'", cn);
                da.Fill(dt);
            }
            dgvPaqLista.DataSource = dt;
        }
        private void dgvPaqLista_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPaqLista.CurrentRow == null) return;
            string paq = dgvPaqLista.CurrentRow.Cells["Clave_Paquete"].Value.ToString();
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(cadenaConexion))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT m.Nombre FROM materia_paquete mp JOIN horaMaterias h ON mp.Clave_Horario = h.Clave_Horario JOIN materias m ON h.Clave_Materia = m.Clave_Materia WHERE mp.Clave_Paquete = @paq", cn);
                da.SelectCommand.Parameters.AddWithValue("@paq", paq);
                da.Fill(dt);
            }
            dgvMatPaqDet.DataSource = dt;
        }

        // ==================== MENÚS ====================
        private void mnuAlumnos_Click(object sender, EventArgs e) => MostrarPanel(pnlAlumnos);
        private void mnuMaterias_Click(object sender, EventArgs e) => MostrarPanel(pnlMaterias);
        private void mnuHorarios_Click(object sender, EventArgs e) => MostrarPanel(pnlHorarios);
        private void mnuSalir_Click(object sender, EventArgs e) => Application.Exit();

        private void btnGenPaq_Click(object sender, EventArgs e)
        {
            if (cmbAlumRein.SelectedValue == null) { MessageBox.Show("Seleccione un alumno"); return; }
            string numCtrl = cmbAlumRein.SelectedValue.ToString();

            // Eliminar paquetes anteriores de este alumno
            using (SqlConnection cn = new SqlConnection(cadenaConexion))
            {
                cn.Open();
                // Eliminar primero las relaciones en materia_paquete
                SqlCommand cmdDeleteRel = new SqlCommand(
                    "DELETE mp FROM materia_paquete mp INNER JOIN paquetes p ON mp.Clave_Paquete = p.Clave_Paquete WHERE p.Clave_Paquete LIKE @prefijo", cn);
                cmdDeleteRel.Parameters.AddWithValue("@prefijo", numCtrl + "%");
                cmdDeleteRel.ExecuteNonQuery();

                // Eliminar los paquetes
                SqlCommand cmdDeletePaq = new SqlCommand("DELETE FROM paquetes WHERE Clave_Paquete LIKE @prefijo", cn);
                cmdDeletePaq.Parameters.AddWithValue("@prefijo", numCtrl + "%");
                cmdDeletePaq.ExecuteNonQuery();
            }

            // Luego generar nuevos paquetes
            using (SqlConnection cn = new SqlConnection(cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("dbo.GenerarPaquetesAlumno", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Num_control", numCtrl);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
            CargarPaquetesAlumno(numCtrl);
            MessageBox.Show("Paquetes generados correctamente");
        }
    }
}
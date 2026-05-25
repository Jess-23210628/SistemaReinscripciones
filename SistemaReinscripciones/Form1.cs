using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaReinscripciones
{
    public partial class FrmPrincipal : Form
    {
        // Cambia la cadena de conexión según tu servidor y credenciales
        private string cadenaConexion = "Server=100.88.175.118;Database=Proyecto_Final_Horarios;" +
            "User Id=sa;Password=MyP@ssw0rd2026!;";

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
            AplicarEstiloTeal();

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

        // ==================== CARGA DE DATOS ====================//
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

        // ==================== ALUMNOS EDITAR ====================//
        private void btnAgregarAl_Click(object sender, EventArgs e)
        {
            if (dgvAlumnos.CurrentRow == null) return;
            DataRowView row = (DataRowView)dgvAlumnos.CurrentRow.DataBoundItem;
            txtNumCtrlA.Text = row["Num_control"].ToString();
            txtNombreA.Text = row["Nombre"].ToString();
            txtApPatA.Text = row["Apellido_Paterno"].ToString();
            txtApMatA.Text = row["Apellido_Materno"].ToString();
            txtCarreraA.Text = row["Carrera"].ToString();
            txtSemestreA.Text = row["Semestre"].ToString();
            txtCurpA.Text = row["Curp"].ToString();
            if (row["Clave_Paquete"] != DBNull.Value) cboPaqueteAl.SelectedValue = row["Clave_Paquete"].ToString();
            else cboPaqueteAl.SelectedIndex = -1;
            txtNumCtrlA.ReadOnly = true;

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
                if (control is TextBox)
                {
                    control.Text = "";
                }
        }





        // ==================== ALUMNOS CRUD ====================
        private void btnAgregarAl_Click_1(object sender, EventArgs e)
        {
            LimpiarCamposAlumno(); pnlEditAlumno.Visible = true; pnlEditAlumno.BringToFront();
            txtNumCtrlA.ReadOnly = false; txtNumCtrlA.Focus();
        }

        //=========Editar Alumno=============//

        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            pnlEditAlumno.Visible = true; pnlEditAlumno.BringToFront();


        }

        private void btnBuscarAl_Click_1(object sender, EventArgs e)
        {
            CargarAlumnos(txtBuscarAl.Text); pnlEditAlumno.Visible = false;
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
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

        // ==================== MATERIAS (CRUD completo) ====================
        private void btnBuscarMat_Click(object sender, EventArgs e)
        {
            if (dgvMaterias.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una materia para editar.");
                return;
            }
            string clave = dgvMaterias.CurrentRow.Cells["Clave_Materia"].Value.ToString();
            MostrarDialogoMateria(clave);
        }

        private void btnAgregarMat_Click_1(object sender, EventArgs e)
        {
            MostrarDialogoMateria(null);
        }

        private void btnEliminarMat_Click_1(object sender, EventArgs e)
        {
            if (dgvMaterias.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una materia para eliminar.");
                return;
            }
            string clave = dgvMaterias.CurrentRow.Cells["Clave_Materia"].Value.ToString();
            if (MessageBox.Show($"¿Eliminar materia {clave}?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (SqlConnection cn = new SqlConnection(cadenaConexion))
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM materias WHERE Clave_Materia = @cla", cn);
                    cmd.Parameters.AddWithValue("@cla", clave);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
                CargarMaterias(); // Refrescar
            }
        }

        private void MostrarDialogoMateria(string claveExistente)
        {
            // Crear un formulario temporal
            Form frm = new Form();
            frm.Text = claveExistente == null ? "Nueva Materia" : "Editar Materia";
            frm.Size = new System.Drawing.Size(400, 350);
            frm.StartPosition = FormStartPosition.CenterParent;

            // Controles
            Label lblClave = new Label() { Text = "Clave (5 caracteres):", Location = new System.Drawing.Point(20, 20), AutoSize = true };
            TextBox txtClave = new TextBox() { Location = new System.Drawing.Point(180, 17), Width = 100 };
            Label lblNombre = new Label() { Text = "Nombre:", Location = new System.Drawing.Point(20, 60), AutoSize = true };
            TextBox txtNombre = new TextBox() { Location = new System.Drawing.Point(180, 57), Width = 180 };
            Label lblCreditos = new Label() { Text = "Créditos:", Location = new System.Drawing.Point(20, 100), AutoSize = true };
            NumericUpDown nudCreditos = new NumericUpDown() { Location = new System.Drawing.Point(180, 97), Width = 80, Minimum = 1, Maximum = 10 };
            Label lblPrioridad = new Label() { Text = "Prioridad (1-3):", Location = new System.Drawing.Point(20, 140), AutoSize = true };
            NumericUpDown nudPrioridad = new NumericUpDown() { Location = new System.Drawing.Point(180, 137), Width = 80, Minimum = 1, Maximum = 3 };
            Label lblPrereq = new Label() { Text = "Prerequisito:", Location = new System.Drawing.Point(20, 180), AutoSize = true };
            ComboBox cboPrereq = new ComboBox() { Location = new System.Drawing.Point(180, 177), Width = 180, DropDownStyle = ComboBoxStyle.DropDownList };

            // Cargar combo de prerequisitos
            DataTable dtMaterias = new DataTable();
            using (SqlConnection cn = new SqlConnection(cadenaConexion))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT Clave_Materia, Nombre FROM materias", cn);
                da.Fill(dtMaterias);
            }
            DataRow row = dtMaterias.NewRow();
            row["Clave_Materia"] = DBNull.Value;
            row["Nombre"] = "(Ninguno)";
            dtMaterias.Rows.InsertAt(row, 0);
            cboPrereq.DataSource = dtMaterias;
            cboPrereq.DisplayMember = "Nombre";
            cboPrereq.ValueMember = "Clave_Materia";

            Button btnGuardar = new Button() { Text = "Guardar", Location = new System.Drawing.Point(100, 240), Size = new System.Drawing.Size(80, 30) };
            Button btnCancelar = new Button() { Text = "Cancelar", Location = new System.Drawing.Point(200, 240), Size = new System.Drawing.Size(80, 30) };
            btnCancelar.Click += (s, ev) => frm.Close();

            // Si estamos editando, cargar datos
            if (claveExistente != null)
            {
                using (SqlConnection cn = new SqlConnection(cadenaConexion))
                {
                    SqlCommand cmd = new SqlCommand("SELECT Nombre, Creditos, Prioridad, Prerequisito FROM materias WHERE Clave_Materia = @cla", cn);
                    cmd.Parameters.AddWithValue("@cla", claveExistente);
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        txtClave.Text = claveExistente;
                        txtClave.ReadOnly = true;
                        txtNombre.Text = dr["Nombre"].ToString();
                        nudCreditos.Value = Convert.ToDecimal(dr["Creditos"]);
                        nudPrioridad.Value = Convert.ToDecimal(dr["Prioridad"]);
                        object prereq = dr["Prerequisito"];
                        if (prereq != DBNull.Value)
                            cboPrereq.SelectedValue = prereq.ToString();
                        else
                            cboPrereq.SelectedIndex = 0;
                    }
                    dr.Close();
                }
            }
            else
            {
                txtClave.ReadOnly = false;
            }

            btnGuardar.Click += (s, ev) =>
            {
                if (string.IsNullOrWhiteSpace(txtClave.Text) || string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    MessageBox.Show("Clave y nombre son obligatorios.");
                    return;
                }
                if (txtClave.Text.Length != 5)
                {
                    MessageBox.Show("La clave debe tener exactamente 5 caracteres.");
                    return;
                }
                using (SqlConnection cn = new SqlConnection(cadenaConexion))
                {
                    cn.Open();
                    SqlCommand cmd;
                    if (claveExistente != null)
                    {
                        cmd = new SqlCommand("UPDATE materias SET Nombre=@nom, Creditos=@cred, Prioridad=@pri, Prerequisito=@pre WHERE Clave_Materia=@cla", cn);
                        cmd.Parameters.AddWithValue("@cla", claveExistente);
                    }
                    else
                    {
                        cmd = new SqlCommand("INSERT INTO materias (Clave_Materia, Nombre, Creditos, Prioridad, Prerequisito) VALUES (@cla, @nom, @cred, @pri, @pre)", cn);
                        cmd.Parameters.AddWithValue("@cla", txtClave.Text);
                    }
                    cmd.Parameters.AddWithValue("@nom", txtNombre.Text);
                    cmd.Parameters.AddWithValue("@cred", (int)nudCreditos.Value);
                    cmd.Parameters.AddWithValue("@pri", (int)nudPrioridad.Value);
                    object prereqVal = cboPrereq.SelectedValue;
                    cmd.Parameters.AddWithValue("@pre", (prereqVal == DBNull.Value || prereqVal == null) ? DBNull.Value : prereqVal);
                    cmd.ExecuteNonQuery();
                }
                CargarMaterias();
                frm.Close();
            };

            frm.Controls.AddRange(new Control[] { lblClave, txtClave, lblNombre, txtNombre, lblCreditos, nudCreditos,
                                          lblPrioridad, nudPrioridad, lblPrereq, cboPrereq, btnGuardar, btnCancelar });
            frm.ShowDialog(this);
        }
        // ==================== HORARIOS (CRUD completo) ====================
        private void btnBuscarHor_Click(object sender, EventArgs e)
        {
            CargarHorarios(txtBuscarHor.Text);
        }

        private void btnAgregarHor_Click_1(object sender, EventArgs e)
        {
            MostrarDialogoHorario(null);
        }

        private void btnEditarHor_Click_1(object sender, EventArgs e)
        {
            if (dgvHorarios.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un horario para editar.");
                return;
            }
            string claveHor = dgvHorarios.CurrentRow.Cells["Clave_Horario"].Value.ToString();
            MostrarDialogoHorario(claveHor);
        }

        private void btnEliminarHor_Click_1(object sender, EventArgs e)
        {
            if (dgvHorarios.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un horario para eliminar.");
                return;
            }
            string claveHor = dgvHorarios.CurrentRow.Cells["Clave_Horario"].Value.ToString();
            if (MessageBox.Show($"¿Eliminar horario {claveHor}?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (SqlConnection cn = new SqlConnection(cadenaConexion))
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM horaMaterias WHERE Clave_Horario = @cla", cn);
                    cmd.Parameters.AddWithValue("@cla", claveHor);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
                CargarHorarios();
            }
        }


        private void MostrarDialogoHorario(string claveExistente)
        {
            Form frm = new Form();
            frm.Text = claveExistente == null ? "Nuevo Horario" : "Editar Horario";
            frm.Size = new System.Drawing.Size(500, 400);
            frm.StartPosition = FormStartPosition.CenterParent;

            Label lblClave = new Label() { Text = "Clave Horario (5 chars):", Location = new System.Drawing.Point(20, 20), AutoSize = true };
            TextBox txtClave = new TextBox() { Location = new System.Drawing.Point(200, 17), Width = 100 };
            Label lblMateria = new Label() { Text = "Materia:", Location = new System.Drawing.Point(20, 60), AutoSize = true };
            ComboBox cboMateria = new ComboBox() { Location = new System.Drawing.Point(200, 57), Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };

            // Cargar materias
            DataTable dtMaterias = new DataTable();
            using (SqlConnection cn = new SqlConnection(cadenaConexion))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT Clave_Materia, Nombre FROM materias", cn);
                da.Fill(dtMaterias);
            }
            cboMateria.DataSource = dtMaterias;
            cboMateria.DisplayMember = "Nombre";
            cboMateria.ValueMember = "Clave_Materia";

            // Días de la semana
            CheckBox[] chkDias = new CheckBox[5];
            DateTimePicker[] dtpDias = new DateTimePicker[5];
            string[] dias = { "Lunes", "Martes", "Miércoles", "Jueves", "Viernes" };
            int y = 110;
            for (int i = 0; i < 5; i++)
            {
                chkDias[i] = new CheckBox() { Text = dias[i], Location = new System.Drawing.Point(20, y), AutoSize = true };
                dtpDias[i] = new DateTimePicker() { Location = new System.Drawing.Point(150, y - 3), Format = DateTimePickerFormat.Time, ShowUpDown = true, Width = 100, Enabled = false };
                int idx = i; // variable local para el evento
                chkDias[i].CheckedChanged += (s, ev) => dtpDias[idx].Enabled = chkDias[idx].Checked;
                frm.Controls.Add(chkDias[i]);
                frm.Controls.Add(dtpDias[i]);
                y += 40;
            }

            Button btnGuardar = new Button() { Text = "Guardar", Location = new System.Drawing.Point(120, 310), Size = new System.Drawing.Size(80, 30) };
            Button btnCancelar = new Button() { Text = "Cancelar", Location = new System.Drawing.Point(230, 310), Size = new System.Drawing.Size(80, 30) };
            btnCancelar.Click += (s, ev) => frm.Close();

            // Si es edición, cargar datos
            if (claveExistente != null)
            {
                using (SqlConnection cn = new SqlConnection(cadenaConexion))
                {
                    SqlCommand cmd = new SqlCommand("SELECT Clave_Materia, Hor_lun, Hor_mar, Hor_mie, Hor_jue, Hor_vie FROM horaMaterias WHERE Clave_Horario = @cla", cn);
                    cmd.Parameters.AddWithValue("@cla", claveExistente);
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        txtClave.Text = claveExistente;
                        txtClave.ReadOnly = true;
                        cboMateria.SelectedValue = dr["Clave_Materia"].ToString();
                        // Horas
                        TimeSpan?[] horas = new TimeSpan?[5];
                        horas[0] = dr["Hor_lun"] as TimeSpan?;
                        horas[1] = dr["Hor_mar"] as TimeSpan?;
                        horas[2] = dr["Hor_mie"] as TimeSpan?;
                        horas[3] = dr["Hor_jue"] as TimeSpan?;
                        horas[4] = dr["Hor_vie"] as TimeSpan?;
                        for (int i = 0; i < 5; i++)
                        {
                            if (horas[i].HasValue)
                            {
                                chkDias[i].Checked = true;
                                dtpDias[i].Value = DateTime.Today.Add(horas[i].Value);
                            }
                            else
                            {
                                chkDias[i].Checked = false;
                            }
                        }
                    }
                    dr.Close();
                }
            }
            else
            {
                txtClave.ReadOnly = false;
            }

            btnGuardar.Click += (s, ev) =>
            {
                if (string.IsNullOrWhiteSpace(txtClave.Text) || txtClave.Text.Length != 5)
                {
                    MessageBox.Show("La clave debe tener 5 caracteres.");
                    return;
                }
                if (cboMateria.SelectedValue == null)
                {
                    MessageBox.Show("Seleccione una materia.");
                    return;
                }
                using (SqlConnection cn = new SqlConnection(cadenaConexion))
                {
                    cn.Open();
                    SqlCommand cmd;
                    if (claveExistente != null)
                        cmd = new SqlCommand("UPDATE horaMaterias SET Clave_Materia=@mat, Hor_lun=@lun, Hor_mar=@mar, Hor_mie=@mie, Hor_jue=@jue, Hor_vie=@vie WHERE Clave_Horario=@cla", cn);
                    else
                        cmd = new SqlCommand("INSERT INTO horaMaterias (Clave_Horario, Clave_Materia, Hor_lun, Hor_mar, Hor_mie, Hor_jue, Hor_vie) VALUES (@cla, @mat, @lun, @mar, @mie, @jue, @vie)", cn);

                    cmd.Parameters.AddWithValue("@cla", txtClave.Text);
                    cmd.Parameters.AddWithValue("@mat", cboMateria.SelectedValue);
                    cmd.Parameters.AddWithValue("@lun", chkDias[0].Checked ? (object)dtpDias[0].Value.TimeOfDay : DBNull.Value);
                    cmd.Parameters.AddWithValue("@mar", chkDias[1].Checked ? (object)dtpDias[1].Value.TimeOfDay : DBNull.Value);
                    cmd.Parameters.AddWithValue("@mie", chkDias[2].Checked ? (object)dtpDias[2].Value.TimeOfDay : DBNull.Value);
                    cmd.Parameters.AddWithValue("@jue", chkDias[3].Checked ? (object)dtpDias[3].Value.TimeOfDay : DBNull.Value);
                    cmd.Parameters.AddWithValue("@vie", chkDias[4].Checked ? (object)dtpDias[4].Value.TimeOfDay : DBNull.Value);
                    cmd.ExecuteNonQuery();
                }
                CargarHorarios();
                frm.Close();
            };

            frm.Controls.AddRange(new Control[] { lblClave, txtClave, lblMateria, cboMateria, btnGuardar, btnCancelar });
            frm.ShowDialog(this);
        }
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

        // ==================== CALIFICACIONES ====================//
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
        private void btnGuardarCalif_Click_1(object sender, EventArgs e)
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

        // ==================== CONSULTAS ====================//

        private void mnuConsulta_Click(object sender, EventArgs e)
        {
            MostrarPanel(pnlConsultas);
            if (cboConsultaTipo.Items.Count == 0) InicializarCombos();
        }
        private void btnEjecutarCon_Click_1(object sender, EventArgs e)
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



        // ==================== PAQUETES (CONSULTA) ====================//


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

        // ==================== MENÚS ====================//
        private void mnuAlumnos_Click(object sender, EventArgs e) => MostrarPanel(pnlAlumnos);
        private void mnuMaterias_Click(object sender, EventArgs e) => MostrarPanel(pnlMaterias);
        private void mnuHorarios_Click(object sender, EventArgs e) => MostrarPanel(pnlHorarios);
        private void mnuSalir_Click(object sender, EventArgs e) => Application.Exit();

        //=================REINSCRIPCIÓN - GENERAR PAQUETES============//

        private void btnAsignarPaq_Click_1(object sender, EventArgs e)
        {

        }
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




        // ============= DISEÑO ======================//

        private void AplicarEstiloTeal()
        {
            // MenuStrip
            mnuPrincipal.BackColor = Color.FromArgb(0, 109, 109); // #006D6D
            mnuPrincipal.ForeColor = Color.White;
            foreach (ToolStripMenuItem item in mnuPrincipal.Items)
            {
                item.BackColor = Color.FromArgb(0, 109, 109);
                item.ForeColor = Color.White;
            }

            // Paneles de contenido (todos)
            Panel[] paneles = { pnlAlumnos, pnlMaterias, pnlHorarios, pnlReinscripcion,
                        pnlPaquetes, pnlCalificaciones, pnlConsultas, pnlEditAlumno,};
            foreach (Panel p in paneles)
            {
                if (p != null) p.BackColor = Color.FromArgb(245, 247, 250); // #F5F7FA
            }

            // Botones (estilo plano)
            Button[] botones = { btnBuscarAl, btnAgregarAl, btnEditar, btnEliminar,
                         btnBuscarMat, btnAgregarMat, btnEditarMat, btnEliminarMat,
                         btnBuscarHor, btnAgregarHor, btnEditarHor, btnEliminarHor,
                         btnGenPaq, btnAsignarPaq, btnGuardarCalif, btnEjecutarCon,btnGuardarAl};
            foreach (Button btn in botones)
            {
                if (btn != null)
                {
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.BackColor = Color.FromArgb(0, 128, 128); // Teal
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 90, 90);
                    // Para botones de cancelar/eliminar (si quieres excepción)
                    if (btn.Text == "Eliminar" || btn.Text == "Cancelar")
                    {
                        btn.BackColor = Color.FromArgb(117, 117, 117); // Gris
                        btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(97, 97, 97);
                    }
                }
            }

            // DataGridView
            foreach (DataGridView dgv in new DataGridView[] { dgvAlumnos, dgvMaterias, dgvHorarios,
                                                      dgvPaqRein, dgvMatPaqRein, dgvPaqLista,
                                                      dgvMatPaqDet, dgvHistCalif, dgvResultCon })
            {
                if (dgv != null)
                {
                    dgv.BackgroundColor = Color.White;
                    dgv.GridColor = Color.FromArgb(200, 200, 200);
                    dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(224, 242, 241);
                    dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(0, 77, 77);
                    dgv.EnableHeadersVisualStyles = false;
                    dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 244, 248);
                    dgv.RowsDefaultCellStyle.BackColor = Color.White;
                    dgv.RowsDefaultCellStyle.ForeColor = Color.Black;
                    dgv.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 128, 128);
                    dgv.RowsDefaultCellStyle.SelectionForeColor = Color.White;
                    dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
            }

            // StatusStrip
            statusStrip1.BackColor = Color.FromArgb(0, 109, 109);
            statusStrip1.ForeColor = Color.White;
            tslInfo.ForeColor = Color.White;
        }

        private void btnEditarMat_Click(object sender, EventArgs e)
        {

        }
    }
}
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
    // ═══════════════════════════════════════════════════════════════════════════
    //  ADMIN — UcAlumnos
    // ═══════════════════════════════════════════════════════════════════════════
    public class UcAlumnos : UcBase
    {
        private DataGridView dgv;
        private TextBox txtBuscar;
        private Button btnBuscar, btnNuevo, btnEditar, btnEliminar;

        public override void Inicializar()
        {
            this.Tag = "Gestión de alumnos";
            lblTitulo.Text = "👨‍🎓  Alumnos";

            // Barra de herramientas en pnlTop
            btnNuevo = CrearBoton("+ Nuevo");
            btnEditar = CrearBoton("Editar");
            btnEliminar = CrearBoton("Eliminar", peligro: true);
            txtBuscar = CrearBuscador("Buscar nombre o matrícula...");
            btnBuscar = CrearBoton("🔍");

            var flow = new FlowLayoutPanel
            {
                Dock = DockStyle.Right,
                AutoSize = true,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,
                Padding = new Padding(0, 9, 8, 0)
            };
            flow.Controls.AddRange(new Control[]
                { txtBuscar, btnBuscar, btnNuevo, btnEditar, btnEliminar });
            pnlTop.Controls.Add(flow);

            // Grid
            dgv = CrearGrid();
            pnlBody.Controls.Add(dgv);

            // Eventos
            btnBuscar.Click += (s, e) => Cargar(txtBuscar.Text);
            txtBuscar.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) Cargar(txtBuscar.Text); };
            btnNuevo.Click += (s, e) => MessageBox.Show("Abrir formulario Nuevo Alumno");
            btnEditar.Click += (s, e) => MessageBox.Show("Abrir formulario Editar Alumno");
            btnEliminar.Click += (s, e) => EliminarAlumno();

            Cargar();
        }

        private void Cargar(string filtro = "")
        {
            string sql = @"SELECT Num_control AS Matrícula,
                                  Nombre, Apellido_Paterno AS [Ap. Paterno],
                                  Apellido_Materno AS [Ap. Materno],
                                  Semestre, Carrera, Clave_Paquete AS Paquete
                           FROM alumnos";
            if (!string.IsNullOrWhiteSpace(filtro))
                sql += " WHERE Nombre LIKE @f OR Num_control LIKE @f";
            sql += " ORDER BY Apellido_Paterno";

            using (var cn = new SqlConnection(Conn))
            {
                var da = new SqlDataAdapter(sql, cn);
                if (!string.IsNullOrWhiteSpace(filtro))
                    da.SelectCommand.Parameters.AddWithValue("@f", "%" + filtro + "%");
                var dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;
            }
        }

        private void EliminarAlumno()
        {
            if (dgv.CurrentRow == null) return;
            string num = dgv.CurrentRow.Cells["Matrícula"].Value.ToString();
            if (MessageBox.Show($"¿Eliminar al alumno {num}?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                using (var cn = new SqlConnection(Conn))
                {
                    cn.Open();
                    new SqlCommand($"DELETE FROM alumnos WHERE Num_control='{num}'", cn).ExecuteNonQuery();
                }
                Cargar();
            }
        }
    }

    // ═══════════════════════════════════════════════════════════════════════════
    //  ADMIN — UcMaterias
    // ═══════════════════════════════════════════════════════════════════════════
    public class UcMaterias : UcBase
    {
        private DataGridView dgv;
        private TextBox txtBuscar;
        private Button btnBuscar, btnNuevo, btnEditar, btnEliminar;

        public override void Inicializar()
        {
            this.Tag = "Gestión de materias";
            lblTitulo.Text = "📚  Materias";

            btnNuevo = CrearBoton("+ Nueva");
            btnEditar = CrearBoton("Editar");
            btnEliminar = CrearBoton("Eliminar", peligro: true);
            txtBuscar = CrearBuscador("Buscar materia o clave...");
            btnBuscar = CrearBoton("🔍");

            var flow = new FlowLayoutPanel
            {
                Dock = DockStyle.Right,
                AutoSize = true,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,
                Padding = new Padding(0, 9, 8, 0)
            };
            flow.Controls.AddRange(new Control[]
                { txtBuscar, btnBuscar, btnNuevo, btnEditar, btnEliminar });
            pnlTop.Controls.Add(flow);

            dgv = CrearGrid();
            pnlBody.Controls.Add(dgv);

            btnBuscar.Click += (s, e) => Cargar(txtBuscar.Text);
            txtBuscar.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) Cargar(txtBuscar.Text); };

            Cargar();
        }

        private void Cargar(string f = "")
        {
            string sql = @"SELECT Clave_Materia AS Clave, Nombre, Creditos AS Créditos,
                                  Prioridad, Prerequisito
                           FROM materias";
            if (!string.IsNullOrWhiteSpace(f))
                sql += " WHERE Nombre LIKE @f OR Clave_Materia LIKE @f";
            sql += " ORDER BY Prioridad, Nombre";

            using (var cn = new SqlConnection(Conn))
            {
                var da = new SqlDataAdapter(sql, cn);
                if (!string.IsNullOrWhiteSpace(f))
                    da.SelectCommand.Parameters.AddWithValue("@f", "%" + f + "%");
                var dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;
            }
        }
    }

    // ═══════════════════════════════════════════════════════════════════════════
    //  ADMIN — UcHorarios
    // ═══════════════════════════════════════════════════════════════════════════
    public class UcHorarios : UcBase
    {
        private DataGridView dgv;

        public override void Inicializar()
        {
            this.Tag = "Gestión de horarios";
            lblTitulo.Text = "🕐  Horarios";

            var btnNuevo = CrearBoton("+ Nuevo");
            var btnEditar = CrearBoton("Editar");
            var btnElim = CrearBoton("Eliminar", peligro: true);
            var flow = new FlowLayoutPanel
            {
                Dock = DockStyle.Right,
                AutoSize = true,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,
                Padding = new Padding(0, 9, 8, 0)
            };
            flow.Controls.AddRange(new Control[] { btnNuevo, btnEditar, btnElim });
            pnlTop.Controls.Add(flow);

            dgv = CrearGrid();
            pnlBody.Controls.Add(dgv);
            Cargar();
        }

        private void Cargar()
        {
            string sql = @"SELECT h.Clave_Horario, m.Nombre AS Materia,
                                  ISNULL(CONVERT(VARCHAR,h.Hor_lun,108),'—') AS Lunes,
                                  ISNULL(CONVERT(VARCHAR,h.Hor_mar,108),'—') AS Martes,
                                  ISNULL(CONVERT(VARCHAR,h.Hor_mie,108),'—') AS Miércoles,
                                  ISNULL(CONVERT(VARCHAR,h.Hor_jue,108),'—') AS Jueves,
                                  ISNULL(CONVERT(VARCHAR,h.Hor_vie,108),'—') AS Viernes
                           FROM horaMaterias h
                           JOIN materias m ON h.Clave_Materia = m.Clave_Materia
                           ORDER BY m.Nombre";
            using (var cn = new SqlConnection(Conn))
            {
                var da = new SqlDataAdapter(sql, cn);
                var dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;
            }
        }
    }

    // ═══════════════════════════════════════════════════════════════════════════
    //  ADMIN — UcReinscripcion
    // ═══════════════════════════════════════════════════════════════════════════
    public class UcReinscripcion : UcBase
    {
        private ComboBox cboAlumno;
        private DataGridView dgvPaquetes, dgvMaterias;
        private Button btnGenerar, btnAsignar;

        public override void Inicializar()
        {
            this.Tag = "Reinscripción de alumnos";
            lblTitulo.Text = "🔄  Reinscripción";

            // Combo alumno en top
            var lblAl = new Label
            {
                Text = "Alumno:",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9f),
                AutoSize = true,
                Dock = DockStyle.Left,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(0, 0, 4, 0)
            };
            cboAlumno = new ComboBox
            {
                Width = 260,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 9.5f)
            };
            btnGenerar = CrearBoton("Generar paquetes");
            btnAsignar = CrearBoton("Asignar paquete");

            var flow = new FlowLayoutPanel
            {
                Dock = DockStyle.Right,
                AutoSize = true,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,
                Padding = new Padding(0, 10, 8, 0)
            };
            flow.Controls.AddRange(new Control[]
                { lblAl, cboAlumno, btnGenerar, btnAsignar });
            pnlTop.Controls.Add(flow);

            // Split horizontal
            var split = new SplitContainer { Dock = DockStyle.Fill, SplitterDistance = 280 };
            dgvPaquetes = CrearGrid();
            dgvMaterias = CrearGrid();
            split.Panel1.Controls.Add(dgvPaquetes);
            split.Panel2.Controls.Add(dgvMaterias);
            pnlBody.Controls.Add(split);

            CargarAlumnos();
            cboAlumno.SelectedIndexChanged += (s, e) => CargarPaquetes();
            dgvPaquetes.SelectionChanged += (s, e) => CargarMaterias();
            btnGenerar.Click += (s, e) => GenerarPaquetes();
            btnAsignar.Click += (s, e) => AsignarPaquete();
        }

        private void CargarAlumnos()
        {
            using (var cn = new SqlConnection(Conn))
            {
                var da = new SqlDataAdapter(
                    "SELECT Num_control, Nombre+' '+Apellido_Paterno AS Nombre FROM alumnos ORDER BY Apellido_Paterno", cn);
                var dt = new DataTable();
                da.Fill(dt);
                cboAlumno.DataSource = dt;
                cboAlumno.DisplayMember = "Nombre";
                cboAlumno.ValueMember = "Num_control";
            }
        }

        private void CargarPaquetes()
        {
            if (cboAlumno.SelectedValue == null) return;
            string num = cboAlumno.SelectedValue.ToString();
            using (var cn = new SqlConnection(Conn))
            {
                var da = new SqlDataAdapter(
                    "SELECT Clave_Paquete FROM paquetes WHERE Clave_Paquete LIKE @p", cn);
                da.SelectCommand.Parameters.AddWithValue("@p", num + "%");
                var dt = new DataTable();
                da.Fill(dt);
                dgvPaquetes.DataSource = dt;
            }
        }

        private void CargarMaterias()
        {
            if (dgvPaquetes.CurrentRow == null) return;
            string paq = dgvPaquetes.CurrentRow.Cells["Clave_Paquete"].Value.ToString();
            using (var cn = new SqlConnection(Conn))
            {
                var da = new SqlDataAdapter(
                    @"SELECT m.Nombre AS Materia,
                             ISNULL(CONVERT(VARCHAR,h.Hor_lun,108),'—') AS Lunes,
                             ISNULL(CONVERT(VARCHAR,h.Hor_mar,108),'—') AS Martes,
                             ISNULL(CONVERT(VARCHAR,h.Hor_mie,108),'—') AS Miércoles,
                             ISNULL(CONVERT(VARCHAR,h.Hor_jue,108),'—') AS Jueves,
                             ISNULL(CONVERT(VARCHAR,h.Hor_vie,108),'—') AS Viernes
                      FROM materia_paquete mp
                      JOIN horaMaterias h ON mp.Clave_Horario = h.Clave_Horario
                      JOIN materias m     ON h.Clave_Materia  = m.Clave_Materia
                      WHERE mp.Clave_Paquete = @paq", cn);
                da.SelectCommand.Parameters.AddWithValue("@paq", paq);
                var dt = new DataTable();
                da.Fill(dt);
                dgvMaterias.DataSource = dt;
            }
        }

        private void GenerarPaquetes()
        {
            if (cboAlumno.SelectedValue == null) return;
            string num = cboAlumno.SelectedValue.ToString();
            using (var cn = new SqlConnection(Conn))
            {
                cn.Open();
                var cmd = new SqlCommand("dbo.GenerarPaquetesAlumno", cn)
                { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@Num_control", num);
                cmd.ExecuteNonQuery();
            }
            CargarPaquetes();
            MessageBox.Show("Paquetes generados.", "Éxito",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void AsignarPaquete()
        {
            if (dgvPaquetes.CurrentRow == null || cboAlumno.SelectedValue == null) return;
            string paq = dgvPaquetes.CurrentRow.Cells["Clave_Paquete"].Value.ToString();
            string num = cboAlumno.SelectedValue.ToString();
            using (var cn = new SqlConnection(Conn))
            {
                cn.Open();
                var cmd = new SqlCommand(
                    "UPDATE alumnos SET Clave_Paquete=@paq WHERE Num_control=@num", cn);
                cmd.Parameters.AddWithValue("@paq", paq);
                cmd.Parameters.AddWithValue("@num", num);
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Paquete asignado.", "Éxito",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    // ═══════════════════════════════════════════════════════════════════════════
    //  ADMIN — UcMaestros
    // ═══════════════════════════════════════════════════════════════════════════
    public class UcMaestros : UcBase
    {
        private DataGridView dgv;

        public override void Inicializar()
        {
            this.Tag = "Gestión de maestros";
            lblTitulo.Text = "🏫  Maestros";

            var btnNuevo = CrearBoton("+ Nuevo");
            var btnEditar = CrearBoton("Editar");
            var btnBaja = CrearBoton("Dar de baja", peligro: true);
            var flow = new FlowLayoutPanel
            {
                Dock = DockStyle.Right,
                AutoSize = true,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,
                Padding = new Padding(0, 9, 8, 0)
            };
            flow.Controls.AddRange(new Control[] { btnNuevo, btnEditar, btnBaja });
            pnlTop.Controls.Add(flow);

            dgv = CrearGrid();
            pnlBody.Controls.Add(dgv);
            Cargar();
        }

        private void Cargar()
        {
            string sql = @"SELECT Num_empleado AS [Num. Empleado], Nombre,
                                  Apellido_Paterno AS [Ap. Paterno],
                                  Email, Especialidad,
                                  CASE Activo WHEN 1 THEN 'Activo' ELSE 'Inactivo' END AS Estado
                           FROM maestros ORDER BY Apellido_Paterno";
            using (var cn = new SqlConnection(Conn))
            {
                var da = new SqlDataAdapter(sql, cn);
                var dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;
            }
        }
    }

    // ═══════════════════════════════════════════════════════════════════════════
    //  ADMIN — UcReportes
    // ═══════════════════════════════════════════════════════════════════════════
    public class UcReportes : UcBase
    {
        private DataGridView dgv;
        private ComboBox cboTipo;
        private Button btnEjecutar;

        public override void Inicializar()
        {
            this.Tag = "Consultas y reportes";
            lblTitulo.Text = "📊  Reportes y consultas";

            cboTipo = new ComboBox
            {
                Width = 260,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 9.5f)
            };
            cboTipo.Items.AddRange(new[]
            {
                "Materias con prioridad 1",
                "Alumnos inscritos por semestre",
                "Materias sin prerequisito",
                "Alumnos sin paquete asignado",
                "Maestros activos"
            });
            cboTipo.SelectedIndex = 0;
            btnEjecutar = CrearBoton("▶ Ejecutar");

            var flow = new FlowLayoutPanel
            {
                Dock = DockStyle.Right,
                AutoSize = true,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,
                Padding = new Padding(0, 10, 8, 0)
            };
            flow.Controls.AddRange(new Control[] { cboTipo, btnEjecutar });
            pnlTop.Controls.Add(flow);

            dgv = CrearGrid();
            pnlBody.Controls.Add(dgv);
            btnEjecutar.Click += (s, e) => EjecutarConsulta();
        }

        private void EjecutarConsulta()
        {
            string[] sqls =
            {
                "SELECT Clave_Materia,Nombre,Creditos FROM materias WHERE Prioridad=1 ORDER BY Creditos DESC",
                "SELECT Semestre, COUNT(*) AS Total FROM alumnos GROUP BY Semestre ORDER BY Semestre",
                "SELECT Clave_Materia,Nombre,Creditos FROM materias WHERE Prerequisito IS NULL",
                "SELECT Num_control,Nombre,Apellido_Paterno,Semestre FROM alumnos WHERE Clave_Paquete IS NULL",
                "SELECT Num_empleado,Nombre,Apellido_Paterno,Email,Especialidad FROM maestros WHERE Activo=1"
            };
            string sql = sqls[cboTipo.SelectedIndex];
            using (var cn = new SqlConnection(Conn))
            {
                var da = new SqlDataAdapter(sql, cn);
                var dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;
            }
        }
    }

    // ═══════════════════════════════════════════════════════════════════════════
    //  ADMIN — UcAdminUsuarios
    // ═══════════════════════════════════════════════════════════════════════════
    public class UcAdminUsuarios : UcBase
    {
        private DataGridView dgv;
        private ComboBox cboRolFiltro;

        public override void Inicializar()
        {
            this.Tag = "Administración de usuarios";
            lblTitulo.Text = "🔐  Usuarios y accesos";

            var lblF = new Label
            {
                Text = "Filtrar:",
                ForeColor = Color.White,
                AutoSize = true,
                Font = new Font("Segoe UI", 9f),
                Dock = DockStyle.Left,
                TextAlign = ContentAlignment.MiddleLeft
            };
            cboRolFiltro = new ComboBox
            {
                Width = 120,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 9.5f)
            };
            cboRolFiltro.Items.AddRange(new[] { "Todos", "Admin", "Maestro", "Alumno" });
            cboRolFiltro.SelectedIndex = 0;

            var btnBloquear = CrearBoton("Bloquear/Activar");
            var flow = new FlowLayoutPanel
            {
                Dock = DockStyle.Right,
                AutoSize = true,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,
                Padding = new Padding(0, 10, 8, 0)
            };
            flow.Controls.AddRange(new Control[] { lblF, cboRolFiltro, btnBloquear });
            pnlTop.Controls.Add(flow);

            dgv = CrearGrid();
            pnlBody.Controls.Add(dgv);

            cboRolFiltro.SelectedIndexChanged += (s, e) => Cargar();
            btnBloquear.Click += (s, e) => ToggleActivo();
            Cargar();
        }

        private void Cargar()
        {
            string sql = @"SELECT Username, Rol, Id_referencia,
                                  CASE Activo WHEN 1 THEN 'Activo' ELSE 'Bloqueado' END AS Estado,
                                  Ultimo_acceso AS [Último acceso]
                           FROM usuarios";
            string rol = cboRolFiltro.SelectedItem?.ToString() ?? "Todos";
            if (rol != "Todos") sql += " WHERE Rol = @r";
            sql += " ORDER BY Rol, Username";

            using (var cn = new SqlConnection(Conn))
            {
                var da = new SqlDataAdapter(sql, cn);
                if (rol != "Todos") da.SelectCommand.Parameters.AddWithValue("@r", rol);
                var dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;
            }
        }

        private void ToggleActivo()
        {
            if (dgv.CurrentRow == null) return;
            string user = dgv.CurrentRow.Cells["Username"].Value.ToString();
            string estado = dgv.CurrentRow.Cells["Estado"].Value.ToString();
            int nuevo = estado == "Activo" ? 0 : 1;
            using (var cn = new SqlConnection(Conn))
            {
                cn.Open();
                var cmd = new SqlCommand(
                    "UPDATE usuarios SET Activo=@a WHERE Username=@u", cn);
                cmd.Parameters.AddWithValue("@a", nuevo);
                cmd.Parameters.AddWithValue("@u", user);
                cmd.ExecuteNonQuery();
            }
            Cargar();
        }
    }

    // ═══════════════════════════════════════════════════════════════════════════
    //  MAESTRO — UcMiHorarioMaestro
    // ═══════════════════════════════════════════════════════════════════════════
    public class UcMiHorarioMaestro : UcBase
    {
        private DataGridView dgv;

        public override void Inicializar()
        {
            this.Tag = "Mi horario de clases";
            lblTitulo.Text = "📅  Mi horario de clases";
            dgv = CrearGrid();
            pnlBody.Controls.Add(dgv);
            Cargar();
        }

        private void Cargar()
        {
            string sql = @"SELECT mat.Nombre AS Materia,
                                  ISNULL(CONVERT(VARCHAR,h.Hor_lun,108),'—') AS Lunes,
                                  ISNULL(CONVERT(VARCHAR,h.Hor_mar,108),'—') AS Martes,
                                  ISNULL(CONVERT(VARCHAR,h.Hor_mie,108),'—') AS Miércoles,
                                  ISNULL(CONVERT(VARCHAR,h.Hor_jue,108),'—') AS Jueves,
                                  ISNULL(CONVERT(VARCHAR,h.Hor_vie,108),'—') AS Viernes,
                                  mh.Periodo, mh.Anio
                           FROM maestro_horario mh
                           JOIN horaMaterias h ON mh.Clave_Horario = h.Clave_Horario
                           JOIN materias mat   ON h.Clave_Materia  = mat.Clave_Materia
                           WHERE mh.Num_empleado = @e
                           ORDER BY mat.Nombre";
            using (var cn = new SqlConnection(Conn))
            {
                var da = new SqlDataAdapter(sql, cn);
                da.SelectCommand.Parameters.AddWithValue("@e", NumEmpleado ?? "");
                var dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;
            }
        }
    }

    // ═══════════════════════════════════════════════════════════════════════════
    //  MAESTRO — UcMisGrupos
    // ═══════════════════════════════════════════════════════════════════════════
    public class UcMisGrupos : UcBase
    {
        private DataGridView dgvGrupos, dgvAlumnos;

        public override void Inicializar()
        {
            this.Tag = "Mis grupos";
            lblTitulo.Text = "👥  Mis grupos";

            var split = new SplitContainer { Dock = DockStyle.Fill, SplitterDistance = 320 };
            dgvGrupos = CrearGrid();
            dgvAlumnos = CrearGrid();
            split.Panel1.Controls.Add(dgvGrupos);
            split.Panel2.Controls.Add(dgvAlumnos);
            pnlBody.Controls.Add(split);

            dgvGrupos.SelectionChanged += (s, e) => CargarAlumnos();
            CargarGrupos();
        }

        private void CargarGrupos()
        {
            string sql = @"SELECT DISTINCT mat.Nombre AS Materia, h.Clave_Horario AS Grupo,
                                  mh.Periodo, mh.Anio
                           FROM maestro_horario mh
                           JOIN horaMaterias h ON mh.Clave_Horario = h.Clave_Horario
                           JOIN materias mat   ON h.Clave_Materia  = mat.Clave_Materia
                           WHERE mh.Num_empleado = @e
                           ORDER BY mat.Nombre";
            using (var cn = new SqlConnection(Conn))
            {
                var da = new SqlDataAdapter(sql, cn);
                da.SelectCommand.Parameters.AddWithValue("@e", NumEmpleado ?? "");
                var dt = new DataTable();
                da.Fill(dt);
                dgvGrupos.DataSource = dt;
            }
        }

        private void CargarAlumnos()
        {
            if (dgvGrupos.CurrentRow == null) return;
            string grupo = dgvGrupos.CurrentRow.Cells["Grupo"].Value.ToString();
            string sql = @"SELECT DISTINCT a.Num_control AS Matrícula,
                                  a.Nombre, a.Apellido_Paterno AS [Ap. Paterno],
                                  a.Semestre
                           FROM alumnos a
                           JOIN paquetes p      ON a.Clave_Paquete  = p.Clave_Paquete
                           JOIN materia_paquete mp ON p.Clave_Paquete = mp.Clave_Paquete
                           WHERE mp.Clave_Horario = @g
                           ORDER BY a.Apellido_Paterno";
            using (var cn = new SqlConnection(Conn))
            {
                var da = new SqlDataAdapter(sql, cn);
                da.SelectCommand.Parameters.AddWithValue("@g", grupo);
                var dt = new DataTable();
                da.Fill(dt);
                dgvAlumnos.DataSource = dt;
            }
        }
    }

    // ═══════════════════════════════════════════════════════════════════════════
    //  MAESTRO — UcCapturaCalifsM
    // ═══════════════════════════════════════════════════════════════════════════
    public class UcCapturaCalifsM : UcBase
    {
        private DataGridView dgv;
        private ComboBox cboGrupo, cboParcial;
        private Button btnCargar, btnGuardar;

        public override void Inicializar()
        {
            this.Tag = "Captura de calificaciones";
            lblTitulo.Text = "✏️  Captura de calificaciones";

            cboGrupo = new ComboBox
            {
                Width = 200,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 9.5f)
            };
            cboParcial = new ComboBox
            {
                Width = 130,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 9.5f)
            };
            cboParcial.Items.AddRange(new[] { "Primer parcial", "Segundo parcial", "Final" });
            cboParcial.SelectedIndex = 0;
            btnCargar = CrearBoton("Cargar");
            btnGuardar = CrearBoton("💾 Guardar todo");

            var flow = new FlowLayoutPanel
            {
                Dock = DockStyle.Right,
                AutoSize = true,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,
                Padding = new Padding(0, 10, 8, 0)
            };
            flow.Controls.AddRange(new Control[]
                { cboGrupo, cboParcial, btnCargar, btnGuardar });
            pnlTop.Controls.Add(flow);

            // Grid editable
            dgv = CrearGrid();
            dgv.ReadOnly = false;
            dgv.EditMode = DataGridViewEditMode.EditOnEnter;
            pnlBody.Controls.Add(dgv);

            CargarGrupos();
            btnCargar.Click += (s, e) => CargarAlumnos();
            btnGuardar.Click += (s, e) => GuardarCalifs();
        }

        private void CargarGrupos()
        {
            string sql = @"SELECT DISTINCT h.Clave_Horario AS Grupo, mat.Nombre AS Materia
                           FROM maestro_horario mh
                           JOIN horaMaterias h ON mh.Clave_Horario = h.Clave_Horario
                           JOIN materias mat   ON h.Clave_Materia  = mat.Clave_Materia
                           WHERE mh.Num_empleado = @e";
            using (var cn = new SqlConnection(Conn))
            {
                var da = new SqlDataAdapter(sql, cn);
                da.SelectCommand.Parameters.AddWithValue("@e", NumEmpleado ?? "");
                var dt = new DataTable();
                da.Fill(dt);
                cboGrupo.DataSource = dt;
                cboGrupo.DisplayMember = "Materia";
                cboGrupo.ValueMember = "Grupo";
            }
        }

        private void CargarAlumnos()
        {
            if (cboGrupo.SelectedValue == null) return;
            string grupo = cboGrupo.SelectedValue.ToString();
            string sql = @"SELECT a.Num_control AS Matrícula,
                                  a.Nombre + ' ' + a.Apellido_Paterno AS Alumno,
                                  ISNULL(rc.Calificacion, 0) AS Calificación
                           FROM alumnos a
                           JOIN paquetes p      ON a.Clave_Paquete = p.Clave_Paquete
                           JOIN materia_paquete mp ON p.Clave_Paquete = mp.Clave_Paquete
                           JOIN horaMaterias h  ON mp.Clave_Horario = h.Clave_Horario
                           LEFT JOIN registro_calificaciones rc
                               ON rc.Num_control = a.Num_control
                              AND rc.Clave_materia = h.Clave_Materia
                           WHERE mp.Clave_Horario = @g
                           ORDER BY a.Apellido_Paterno";
            using (var cn = new SqlConnection(Conn))
            {
                var da = new SqlDataAdapter(sql, cn);
                da.SelectCommand.Parameters.AddWithValue("@g", grupo);
                var dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;
                if (dgv.Columns.Contains("Matrícula")) dgv.Columns["Matrícula"].ReadOnly = true;
                if (dgv.Columns.Contains("Alumno")) dgv.Columns["Alumno"].ReadOnly = true;
            }
        }

        private void GuardarCalifs()
        {
            if (cboGrupo.SelectedValue == null) return;
            string grupo = cboGrupo.SelectedValue.ToString();
            // Obtener clave de materia del horario
            string claveMat = "";
            using (var cn = new SqlConnection(Conn))
            {
                cn.Open();
                var cmd = new SqlCommand(
                    "SELECT Clave_Materia FROM horaMaterias WHERE Clave_Horario=@g", cn);
                cmd.Parameters.AddWithValue("@g", grupo);
                claveMat = cmd.ExecuteScalar()?.ToString() ?? "";
            }
            if (string.IsNullOrEmpty(claveMat)) return;

            using (var cn = new SqlConnection(Conn))
            {
                cn.Open();
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.IsNewRow) continue;
                    string num = row.Cells["Matrícula"].Value.ToString();
                    if (!int.TryParse(row.Cells["Calificación"].Value?.ToString(), out int cal)) continue;

                    var cmd = new SqlCommand(
                        @"IF EXISTS (SELECT 1 FROM registro_calificaciones
                                    WHERE Num_control=@n AND Clave_materia=@m)
                              UPDATE registro_calificaciones
                                 SET Calificacion=@c, Tipo_acred=CASE WHEN @c>=60 THEN 3 ELSE 2 END
                               WHERE Num_control=@n AND Clave_materia=@m
                          ELSE
                              INSERT INTO registro_calificaciones
                                (Num_control, Clave_materia, Calificacion, Tipo_acred)
                              VALUES (@n, @m, @c, CASE WHEN @c>=60 THEN 3 ELSE 2 END)", cn);
                    cmd.Parameters.AddWithValue("@n", num);
                    cmd.Parameters.AddWithValue("@m", claveMat);
                    cmd.Parameters.AddWithValue("@c", cal);
                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Calificaciones guardadas.", "Éxito",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    // ═══════════════════════════════════════════════════════════════════════════
    //  MAESTRO — UcReportesMaestro
    // ═══════════════════════════════════════════════════════════════════════════
    public class UcReportesMaestro : UcBase
    {
        private DataGridView dgv;
        public override void Inicializar()
        {
            this.Tag = "Reportes del grupo";
            lblTitulo.Text = "📊  Reportes del grupo";
            dgv = CrearGrid();
            pnlBody.Controls.Add(dgv);

            string sql = @"SELECT a.Num_control, a.Nombre+' '+a.Apellido_Paterno AS Alumno,
                                  AVG(CAST(rc.Calificacion AS FLOAT)) AS Promedio,
                                  COUNT(rc.Clave_materia) AS [Materias calificadas]
                           FROM alumnos a
                           LEFT JOIN registro_calificaciones rc ON rc.Num_control = a.Num_control
                           GROUP BY a.Num_control, a.Nombre, a.Apellido_Paterno
                           ORDER BY Promedio DESC";
            using (var cn = new SqlConnection(Conn))
            {
                var da = new SqlDataAdapter(sql, cn);
                var dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;
            }
        }
    }

    // ═══════════════════════════════════════════════════════════════════════════
    //  ALUMNO — UcMiHorarioAlumno
    // ═══════════════════════════════════════════════════════════════════════════
    public class UcMiHorarioAlumno : UcBase
    {
        private DataGridView dgv;
        public override void Inicializar()
        {
            this.Tag = "Mi horario";
            lblTitulo.Text = "📅  Mi horario del semestre";
            dgv = CrearGrid();
            pnlBody.Controls.Add(dgv);
            Cargar();
        }

        private void Cargar()
        {
            string sql = @"SELECT mat.Nombre AS Materia,
                                  ISNULL(CONVERT(VARCHAR,h.Hor_lun,108),'—') AS Lunes,
                                  ISNULL(CONVERT(VARCHAR,h.Hor_mar,108),'—') AS Martes,
                                  ISNULL(CONVERT(VARCHAR,h.Hor_mie,108),'—') AS Miércoles,
                                  ISNULL(CONVERT(VARCHAR,h.Hor_jue,108),'—') AS Jueves,
                                  ISNULL(CONVERT(VARCHAR,h.Hor_vie,108),'—') AS Viernes,
                                  mat.Creditos AS Créditos
                           FROM alumnos a
                           JOIN paquetes p        ON a.Clave_Paquete  = p.Clave_Paquete
                           JOIN materia_paquete mp ON p.Clave_Paquete = mp.Clave_Paquete
                           JOIN horaMaterias h     ON mp.Clave_Horario = h.Clave_Horario
                           JOIN materias mat       ON h.Clave_Materia  = mat.Clave_Materia
                           WHERE a.Num_control = @n
                           ORDER BY mat.Nombre";
            using (var cn = new SqlConnection(Conn))
            {
                var da = new SqlDataAdapter(sql, cn);
                da.SelectCommand.Parameters.AddWithValue("@n", NumControl ?? "");
                var dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;
            }
        }
    }

    // ═══════════════════════════════════════════════════════════════════════════
    //  ALUMNO — UcMisCalifs
    // ═══════════════════════════════════════════════════════════════════════════
    public class UcMisCalifs : UcBase
    {
        private DataGridView dgv;
        private Label lblPromedio;

        public override void Inicializar()
        {
            this.Tag = "Mis calificaciones";
            lblTitulo.Text = "📋  Mis calificaciones del semestre";

            lblPromedio = new Label
            {
                Dock = DockStyle.Right,
                AutoSize = true,
                Font = new Font("Segoe UI", 10f, FontStyle.Bold),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleRight,
                Padding = new Padding(0, 0, 16, 0)
            };
            pnlTop.Controls.Add(lblPromedio);

            dgv = CrearGrid();
            pnlBody.Controls.Add(dgv);
            Cargar();
        }

        private void Cargar()
        {
            string sql = @"SELECT mat.Nombre AS Materia,
                                  rc.Calificacion AS Calificación,
                                  CASE rc.Tipo_acred
                                      WHEN 3 THEN 'Aprobada'
                                      WHEN 2 THEN 'Reprobada'
                                      ELSE 'Pendiente'
                                  END AS Estado
                           FROM alumnos a
                           JOIN paquetes p        ON a.Clave_Paquete  = p.Clave_Paquete
                           JOIN materia_paquete mp ON p.Clave_Paquete = mp.Clave_Paquete
                           JOIN horaMaterias h     ON mp.Clave_Horario = h.Clave_Horario
                           JOIN materias mat       ON h.Clave_Materia  = mat.Clave_Materia
                           LEFT JOIN registro_calificaciones rc
                               ON rc.Num_control = a.Num_control
                              AND rc.Clave_materia = mat.Clave_Materia
                           WHERE a.Num_control = @n
                           ORDER BY mat.Nombre";
            using (var cn = new SqlConnection(Conn))
            {
                var da = new SqlDataAdapter(sql, cn);
                da.SelectCommand.Parameters.AddWithValue("@n", NumControl ?? "");
                var dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;

                // Calcular promedio
                double suma = 0; int count = 0;
                foreach (DataRow row in dt.Rows)
                    if (row["Calificación"] != DBNull.Value)
                    { suma += Convert.ToDouble(row["Calificación"]); count++; }
                lblPromedio.Text = count > 0
                    ? $"Promedio: {suma / count:F1}"
                    : "Sin calificaciones";
            }
        }
    }

    // ═══════════════════════════════════════════════════════════════════════════
    //  ALUMNO — UcHistorial
    // ═══════════════════════════════════════════════════════════════════════════
    public class UcHistorial : UcBase
    {
        private DataGridView dgv;
        public override void Inicializar()
        {
            this.Tag = "Historial académico";
            lblTitulo.Text = "📁  Historial académico";
            dgv = CrearGrid();
            pnlBody.Controls.Add(dgv);
            Cargar();
        }

        private void Cargar()
        {
            string sql = @"SELECT mat.Nombre AS Materia, mat.Creditos AS Créditos,
                                  rc.Calificacion AS Calificación,
                                  CASE rc.Tipo_acred
                                      WHEN 3 THEN 'Aprobada'
                                      WHEN 2 THEN 'Reprobada'
                                      WHEN 1 THEN 'No cursada'
                                      ELSE '—'
                                  END AS Estado
                           FROM registro_calificaciones rc
                           JOIN materias mat ON rc.Clave_materia = mat.Clave_Materia
                           WHERE rc.Num_control = @n
                           ORDER BY mat.Nombre";
            using (var cn = new SqlConnection(Conn))
            {
                var da = new SqlDataAdapter(sql, cn);
                da.SelectCommand.Parameters.AddWithValue("@n", NumControl ?? "");
                var dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;
            }
        }
    }

    // ═══════════════════════════════════════════════════════════════════════════
    //  ALUMNO — UcMisPaquetes
    // ═══════════════════════════════════════════════════════════════════════════
    public class UcMisPaquetes : UcBase
    {
        private DataGridView dgvPaq, dgvMat;
        public override void Inicializar()
        {
            this.Tag = "Mis paquetes disponibles";
            lblTitulo.Text = "📦  Mis paquetes";

            var split = new SplitContainer
            { Dock = DockStyle.Fill, SplitterDistance = 220 };
            dgvPaq = CrearGrid();
            dgvMat = CrearGrid();
            split.Panel1.Controls.Add(dgvPaq);
            split.Panel2.Controls.Add(dgvMat);
            pnlBody.Controls.Add(split);

            dgvPaq.SelectionChanged += (s, e) => CargarMaterias();
            CargarPaquetes();
        }

        private void CargarPaquetes()
        {
            using (var cn = new SqlConnection(Conn))
            {
                var da = new SqlDataAdapter(
                    "SELECT Clave_Paquete FROM paquetes WHERE Clave_Paquete LIKE @n", cn);
                da.SelectCommand.Parameters.AddWithValue("@n", (NumControl ?? "") + "%");
                var dt = new DataTable();
                da.Fill(dt);
                dgvPaq.DataSource = dt;
            }
        }

        private void CargarMaterias()
        {
            if (dgvPaq.CurrentRow == null) return;
            string paq = dgvPaq.CurrentRow.Cells["Clave_Paquete"].Value.ToString();
            using (var cn = new SqlConnection(Conn))
            {
                var da = new SqlDataAdapter(
                    @"SELECT mat.Nombre AS Materia,
                             ISNULL(CONVERT(VARCHAR,h.Hor_lun,108),'—') AS Lunes,
                             ISNULL(CONVERT(VARCHAR,h.Hor_mar,108),'—') AS Martes,
                             ISNULL(CONVERT(VARCHAR,h.Hor_mie,108),'—') AS Miércoles,
                             ISNULL(CONVERT(VARCHAR,h.Hor_jue,108),'—') AS Jueves,
                             ISNULL(CONVERT(VARCHAR,h.Hor_vie,108),'—') AS Viernes
                      FROM materia_paquete mp
                      JOIN horaMaterias h ON mp.Clave_Horario = h.Clave_Horario
                      JOIN materias mat   ON h.Clave_Materia  = mat.Clave_Materia
                      WHERE mp.Clave_Paquete = @paq", cn);
                da.SelectCommand.Parameters.AddWithValue("@paq", paq);
                var dt = new DataTable();
                da.Fill(dt);
                dgvMat.DataSource = dt;
            }
        }
    }

    // ═══════════════════════════════════════════════════════════════════════════
    //  ALUMNO — UcReporteAlumno
    // ═══════════════════════════════════════════════════════════════════════════
    public class UcReporteAlumno : UcBase
    {
        private DataGridView dgv;
        private Button btnImprimir;

        public override void Inicializar()
        {
            this.Tag = "Reporte de calificaciones";
            lblTitulo.Text = "🖨️  Reporte de calificaciones";

            btnImprimir = CrearBoton("🖨️ Imprimir / PDF");
            var flow = new FlowLayoutPanel
            {
                Dock = DockStyle.Right,
                AutoSize = true,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,
                Padding = new Padding(0, 9, 8, 0)
            };
            flow.Controls.Add(btnImprimir);
            pnlTop.Controls.Add(flow);

            dgv = CrearGrid();
            pnlBody.Controls.Add(dgv);
            Cargar();
            btnImprimir.Click += (s, e) => Imprimir();
        }

        private void Cargar()
        {
            string sql = @"SELECT mat.Clave_Materia AS Clave, mat.Nombre AS Materia,
                                  mat.Creditos AS Créditos,
                                  rc.Calificacion AS Calificación,
                                  CASE rc.Tipo_acred
                                      WHEN 3 THEN 'Aprobada'
                                      WHEN 2 THEN 'Reprobada'
                                      ELSE 'Pendiente'
                                  END AS Estado
                           FROM registro_calificaciones rc
                           JOIN materias mat ON rc.Clave_materia = mat.Clave_Materia
                           WHERE rc.Num_control = @n
                           ORDER BY mat.Nombre";
            using (var cn = new SqlConnection(Conn))
            {
                var da = new SqlDataAdapter(sql, cn);
                da.SelectCommand.Parameters.AddWithValue("@n", NumControl ?? "");
                var dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;
            }
        }

        private void Imprimir()
        {
            var pd = new System.Drawing.Printing.PrintDocument();
            pd.PrintPage += (s, ev) =>
            {
                var g = ev.Graphics;
                int x = 30, y = 40;
                g.DrawString("Reporte de Calificaciones",
                    new Font("Segoe UI", 14f, FontStyle.Bold),
                    new SolidBrush(Color.FromArgb(0, 109, 109)), x, y);
                y += 30;
                g.DrawString($"Matrícula: {NumControl}   Fecha: {DateTime.Now:dd/MM/yyyy}",
                    new Font("Segoe UI", 9f), Brushes.Gray, x, y);
                y += 20;
                g.DrawLine(Pens.Teal, x, y, 750, y);
                y += 10;

                string[] cols = { "Clave", "Materia", "Créditos", "Calificación", "Estado" };
                int[] widths = { 60, 220, 70, 90, 90 };
                int cx = x;
                foreach (var (col, w) in System.Linq.Enumerable.Zip(cols, widths, (a, b) => (a, b)))
                {
                    g.FillRectangle(new SolidBrush(Color.FromArgb(224, 242, 241)), cx, y, w, 18);
                    g.DrawString(col, new Font("Segoe UI", 8f, FontStyle.Bold),
                        new SolidBrush(Color.FromArgb(0, 77, 77)), cx + 2, y + 2);
                    cx += w;
                }
                y += 20;

                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.IsNewRow) continue;
                    cx = x;
                    object[] vals = { row.Cells[0].Value, row.Cells[1].Value,
                                      row.Cells[2].Value, row.Cells[3].Value, row.Cells[4].Value };
                    foreach (var (v, w) in System.Linq.Enumerable.Zip(vals, widths, (a, b) => (a, b)))
                    {
                        g.DrawString(v?.ToString() ?? "",
                            new Font("Segoe UI", 8f), Brushes.Black, cx + 2, y + 1);
                        cx += w;
                    }
                    y += 16;
                }
            };
            new System.Windows.Forms.PrintPreviewDialog { Document = pd }.ShowDialog();
        }
    }
}

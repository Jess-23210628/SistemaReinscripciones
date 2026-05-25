namespace SistemaReinscripciones
{
    partial class FrmPrincipal
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.mnuPrincipal = new System.Windows.Forms.MenuStrip();
            this.mnuAlumnos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMaterias = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHorarios = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReinscripcion = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCalificacion = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuConsulta = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPaquetes = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlContenedor = new System.Windows.Forms.Panel();
            this.pnlMaterias = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBuscarMat = new System.Windows.Forms.TextBox();
            this.btnBuscarMat = new System.Windows.Forms.Button();
            this.btnAgregarMat = new System.Windows.Forms.Button();
            this.btnEditarMat = new System.Windows.Forms.Button();
            this.btnEliminarMat = new System.Windows.Forms.Button();
            this.dgvMaterias = new System.Windows.Forms.DataGridView();
            this.pnlHorarios = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBuscarHor = new System.Windows.Forms.TextBox();
            this.btnBuscarHor = new System.Windows.Forms.Button();
            this.btnAgregarHor = new System.Windows.Forms.Button();
            this.btnEditarHor = new System.Windows.Forms.Button();
            this.btnEliminarHor = new System.Windows.Forms.Button();
            this.dgvHorarios = new System.Windows.Forms.DataGridView();
            this.pnlAlumnos = new System.Windows.Forms.Panel();
            this.lblTituloAl = new System.Windows.Forms.Label();
            this.txtBuscarAl = new System.Windows.Forms.TextBox();
            this.btnBuscarAl = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.dgvAlumnos = new System.Windows.Forms.DataGridView();
            this.pnlEditAlumno = new System.Windows.Forms.Panel();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnAgregarAl = new System.Windows.Forms.Button();
            this.txtNumCtrlA = new System.Windows.Forms.TextBox();
            this.txtCurpA = new System.Windows.Forms.TextBox();
            this.txtSemestreA = new System.Windows.Forms.TextBox();
            this.txtCarreraA = new System.Windows.Forms.TextBox();
            this.txtApMatA = new System.Windows.Forms.TextBox();
            this.txtApPatA = new System.Windows.Forms.TextBox();
            this.txtNombreA = new System.Windows.Forms.TextBox();
            this.lblClave = new System.Windows.Forms.Label();
            this.lblCurp = new System.Windows.Forms.Label();
            this.lblSemestre = new System.Windows.Forms.Label();
            this.lblCarreras = new System.Windows.Forms.Label();
            this.lblApellidoM = new System.Windows.Forms.Label();
            this.lblApellidoP = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlReinscripcion = new System.Windows.Forms.Panel();
            this.lblReinscripcion = new System.Windows.Forms.Label();
            this.cmbAlumRein = new System.Windows.Forms.ComboBox();
            this.btnGenPaq = new System.Windows.Forms.Button();
            this.btnAsignarPaq = new System.Windows.Forms.Button();
            this.dgvPaqRein = new System.Windows.Forms.DataGridView();
            this.dgvMatPaqRein = new System.Windows.Forms.DataGridView();
            this.pnlPaquetes = new System.Windows.Forms.Panel();
            this.lblPaquetes = new System.Windows.Forms.Label();
            this.cmbAlumPaq = new System.Windows.Forms.ComboBox();
            this.dgvPaqLista = new System.Windows.Forms.DataGridView();
            this.dgvMatPaqDet = new System.Windows.Forms.DataGridView();
            this.pnlCalificaciones = new System.Windows.Forms.Panel();
            this.lblCalif = new System.Windows.Forms.Label();
            this.cmbAlumCalif = new System.Windows.Forms.ComboBox();
            this.cmbMatCalif = new System.Windows.Forms.ComboBox();
            this.txtCalif = new System.Windows.Forms.TextBox();
            this.cmbTipoCalif = new System.Windows.Forms.ComboBox();
            this.btnGuardarCalif = new System.Windows.Forms.Button();
            this.dgvHistCalif = new System.Windows.Forms.DataGridView();
            this.pnlConsultas = new System.Windows.Forms.Panel();
            this.lblConsultas = new System.Windows.Forms.Label();
            this.cboConsultaTipo = new System.Windows.Forms.ComboBox();
            this.btnEjecutarCon = new System.Windows.Forms.Button();
            this.dgvResultCon = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tslInfo = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnCancelarAl = new System.Windows.Forms.Button();
            this.btnGuardarAl = new System.Windows.Forms.Button();
            this.cboPaqueteAl = new System.Windows.Forms.ComboBox();
            this.lblPaquete = new System.Windows.Forms.Label();
            this.txtSemestreAl = new System.Windows.Forms.TextBox();
            this.lblSemestreAl = new System.Windows.Forms.Label();
            this.txtCarreraAl = new System.Windows.Forms.TextBox();
            this.lblCarrera = new System.Windows.Forms.Label();
            this.txtCurpAl = new System.Windows.Forms.TextBox();
            this.lblCurpAl = new System.Windows.Forms.Label();
            this.txtApMatAl = new System.Windows.Forms.TextBox();
            this.lblMatAl = new System.Windows.Forms.Label();
            this.txtApPatAl = new System.Windows.Forms.TextBox();
            this.lblApPatAl = new System.Windows.Forms.Label();
            this.txtNombreAl = new System.Windows.Forms.TextBox();
            this.lblNombreAl = new System.Windows.Forms.Label();
            this.txtNumCtrlAl = new System.Windows.Forms.TextBox();
            this.lblNumcontrol = new System.Windows.Forms.Label();
            this.mnuPrincipal.SuspendLayout();
            this.pnlContenedor.SuspendLayout();
            this.pnlMaterias.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterias)).BeginInit();
            this.pnlHorarios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHorarios)).BeginInit();
            this.pnlAlumnos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlumnos)).BeginInit();
            this.pnlEditAlumno.SuspendLayout();
            this.pnlReinscripcion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaqRein)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatPaqRein)).BeginInit();
            this.pnlPaquetes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaqLista)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatPaqDet)).BeginInit();
            this.pnlCalificaciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistCalif)).BeginInit();
            this.pnlConsultas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultCon)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuPrincipal
            // 
            this.mnuPrincipal.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAlumnos,
            this.mnuMaterias,
            this.mnuHorarios,
            this.mnuReinscripcion,
            this.mnuCalificacion,
            this.mnuConsulta,
            this.mnuPaquetes,
            this.mnuSalir});
            this.mnuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.mnuPrincipal.Name = "mnuPrincipal";
            this.mnuPrincipal.Size = new System.Drawing.Size(1037, 24);
            this.mnuPrincipal.TabIndex = 0;
            this.mnuPrincipal.Text = "menuStrip1";
            // 
            // mnuAlumnos
            // 
            this.mnuAlumnos.Name = "mnuAlumnos";
            this.mnuAlumnos.Size = new System.Drawing.Size(67, 20);
            this.mnuAlumnos.Text = "Alumnos";
            this.mnuAlumnos.Click += new System.EventHandler(this.mnuAlumnos_Click);
            // 
            // mnuMaterias
            // 
            this.mnuMaterias.Name = "mnuMaterias";
            this.mnuMaterias.Size = new System.Drawing.Size(64, 20);
            this.mnuMaterias.Text = "Materias";
            this.mnuMaterias.Click += new System.EventHandler(this.mnuMaterias_Click);
            // 
            // mnuHorarios
            // 
            this.mnuHorarios.Name = "mnuHorarios";
            this.mnuHorarios.Size = new System.Drawing.Size(64, 20);
            this.mnuHorarios.Text = "Horarios";
            this.mnuHorarios.Click += new System.EventHandler(this.mnuHorarios_Click);
            // 
            // mnuReinscripcion
            // 
            this.mnuReinscripcion.Name = "mnuReinscripcion";
            this.mnuReinscripcion.Size = new System.Drawing.Size(90, 20);
            this.mnuReinscripcion.Text = "Reinscripcion";
            this.mnuReinscripcion.Click += new System.EventHandler(this.mnuReinscripcion_Click);
            // 
            // mnuCalificacion
            // 
            this.mnuCalificacion.Name = "mnuCalificacion";
            this.mnuCalificacion.Size = new System.Drawing.Size(92, 20);
            this.mnuCalificacion.Text = "Calificaciones";
            this.mnuCalificacion.Click += new System.EventHandler(this.mnuCalificacion_Click);
            // 
            // mnuConsulta
            // 
            this.mnuConsulta.Name = "mnuConsulta";
            this.mnuConsulta.Size = new System.Drawing.Size(71, 20);
            this.mnuConsulta.Text = "Consultas";
            this.mnuConsulta.Click += new System.EventHandler(this.mnuConsulta_Click);
            // 
            // mnuPaquetes
            // 
            this.mnuPaquetes.Name = "mnuPaquetes";
            this.mnuPaquetes.Size = new System.Drawing.Size(67, 20);
            this.mnuPaquetes.Text = "Paquetes";
            this.mnuPaquetes.Click += new System.EventHandler(this.mnuPaquetes_Click);
            // 
            // mnuSalir
            // 
            this.mnuSalir.Name = "mnuSalir";
            this.mnuSalir.Size = new System.Drawing.Size(41, 20);
            this.mnuSalir.Text = "Salir";
            this.mnuSalir.Click += new System.EventHandler(this.mnuSalir_Click);
            // 
            // pnlContenedor
            // 
            this.pnlContenedor.Controls.Add(this.pnlAlumnos);
            this.pnlContenedor.Controls.Add(this.pnlMaterias);
            this.pnlContenedor.Controls.Add(this.pnlHorarios);
            this.pnlContenedor.Controls.Add(this.pnlEditAlumno);
            this.pnlContenedor.Controls.Add(this.pnlReinscripcion);
            this.pnlContenedor.Controls.Add(this.pnlPaquetes);
            this.pnlContenedor.Controls.Add(this.pnlCalificaciones);
            this.pnlContenedor.Controls.Add(this.pnlConsultas);
            this.pnlContenedor.Controls.Add(this.statusStrip1);
            this.pnlContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenedor.Location = new System.Drawing.Point(0, 24);
            this.pnlContenedor.Name = "pnlContenedor";
            this.pnlContenedor.Size = new System.Drawing.Size(1037, 612);
            this.pnlContenedor.TabIndex = 1;
            // 
            // pnlMaterias
            // 
            this.pnlMaterias.Controls.Add(this.label1);
            this.pnlMaterias.Controls.Add(this.txtBuscarMat);
            this.pnlMaterias.Controls.Add(this.btnBuscarMat);
            this.pnlMaterias.Controls.Add(this.btnAgregarMat);
            this.pnlMaterias.Controls.Add(this.btnEditarMat);
            this.pnlMaterias.Controls.Add(this.btnEliminarMat);
            this.pnlMaterias.Controls.Add(this.dgvMaterias);
            this.pnlMaterias.Location = new System.Drawing.Point(315, 468);
            this.pnlMaterias.Name = "pnlMaterias";
            this.pnlMaterias.Size = new System.Drawing.Size(290, 126);
            this.pnlMaterias.TabIndex = 2;
            this.pnlMaterias.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Catálogo de Materias";
            // 
            // txtBuscarMat
            // 
            this.txtBuscarMat.Location = new System.Drawing.Point(12, 40);
            this.txtBuscarMat.Name = "txtBuscarMat";
            this.txtBuscarMat.Size = new System.Drawing.Size(300, 25);
            this.txtBuscarMat.TabIndex = 1;
            // 
            // btnBuscarMat
            // 
            this.btnBuscarMat.Location = new System.Drawing.Point(320, 38);
            this.btnBuscarMat.Name = "btnBuscarMat";
            this.btnBuscarMat.Size = new System.Drawing.Size(90, 30);
            this.btnBuscarMat.TabIndex = 2;
            this.btnBuscarMat.Text = "Buscar";
            this.btnBuscarMat.Click += new System.EventHandler(this.btnBuscarMat_Click);
            // 
            // btnAgregarMat
            // 
            this.btnAgregarMat.Location = new System.Drawing.Point(420, 38);
            this.btnAgregarMat.Name = "btnAgregarMat";
            this.btnAgregarMat.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarMat.TabIndex = 3;
            this.btnAgregarMat.Text = "Agregar";
            this.btnAgregarMat.Click += new System.EventHandler(this.btnAgregarMat_Click_1);
            // 
            // btnEditarMat
            // 
            this.btnEditarMat.Location = new System.Drawing.Point(520, 38);
            this.btnEditarMat.Name = "btnEditarMat";
            this.btnEditarMat.Size = new System.Drawing.Size(75, 23);
            this.btnEditarMat.TabIndex = 4;
            this.btnEditarMat.Text = "Editar";
            this.btnEditarMat.Click += new System.EventHandler(this.btnEditarMat_Click);
            // 
            // btnEliminarMat
            // 
            this.btnEliminarMat.Location = new System.Drawing.Point(620, 38);
            this.btnEliminarMat.Name = "btnEliminarMat";
            this.btnEliminarMat.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarMat.TabIndex = 5;
            this.btnEliminarMat.Text = "Eliminar";
            this.btnEliminarMat.Click += new System.EventHandler(this.btnEliminarMat_Click_1);
            // 
            // dgvMaterias
            // 
            this.dgvMaterias.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMaterias.ColumnHeadersHeight = 29;
            this.dgvMaterias.Location = new System.Drawing.Point(12, 80);
            this.dgvMaterias.Name = "dgvMaterias";
            this.dgvMaterias.RowHeadersWidth = 51;
            this.dgvMaterias.Size = new System.Drawing.Size(1100, 526);
            this.dgvMaterias.TabIndex = 12;
            // 
            // pnlHorarios
            // 
            this.pnlHorarios.Controls.Add(this.label2);
            this.pnlHorarios.Controls.Add(this.txtBuscarHor);
            this.pnlHorarios.Controls.Add(this.btnBuscarHor);
            this.pnlHorarios.Controls.Add(this.btnAgregarHor);
            this.pnlHorarios.Controls.Add(this.btnEditarHor);
            this.pnlHorarios.Controls.Add(this.btnEliminarHor);
            this.pnlHorarios.Controls.Add(this.dgvHorarios);
            this.pnlHorarios.Location = new System.Drawing.Point(315, 310);
            this.pnlHorarios.Name = "pnlHorarios";
            this.pnlHorarios.Size = new System.Drawing.Size(246, 135);
            this.pnlHorarios.TabIndex = 3;
            this.pnlHorarios.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Catálogo de Horarios";
            // 
            // txtBuscarHor
            // 
            this.txtBuscarHor.Location = new System.Drawing.Point(12, 40);
            this.txtBuscarHor.Name = "txtBuscarHor";
            this.txtBuscarHor.Size = new System.Drawing.Size(300, 25);
            this.txtBuscarHor.TabIndex = 1;
            // 
            // btnBuscarHor
            // 
            this.btnBuscarHor.Location = new System.Drawing.Point(320, 38);
            this.btnBuscarHor.Name = "btnBuscarHor";
            this.btnBuscarHor.Size = new System.Drawing.Size(90, 30);
            this.btnBuscarHor.TabIndex = 2;
            this.btnBuscarHor.Text = "Buscar";
            this.btnBuscarHor.Click += new System.EventHandler(this.btnBuscarHor_Click);
            // 
            // btnAgregarHor
            // 
            this.btnAgregarHor.Location = new System.Drawing.Point(420, 38);
            this.btnAgregarHor.Name = "btnAgregarHor";
            this.btnAgregarHor.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarHor.TabIndex = 3;
            this.btnAgregarHor.Text = "Agregar";
            this.btnAgregarHor.Click += new System.EventHandler(this.btnAgregarHor_Click_1);
            // 
            // btnEditarHor
            // 
            this.btnEditarHor.Location = new System.Drawing.Point(520, 38);
            this.btnEditarHor.Name = "btnEditarHor";
            this.btnEditarHor.Size = new System.Drawing.Size(75, 23);
            this.btnEditarHor.TabIndex = 4;
            this.btnEditarHor.Text = "Editar";
            this.btnEditarHor.Click += new System.EventHandler(this.btnEditarHor_Click_1);
            // 
            // btnEliminarHor
            // 
            this.btnEliminarHor.Location = new System.Drawing.Point(620, 38);
            this.btnEliminarHor.Name = "btnEliminarHor";
            this.btnEliminarHor.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarHor.TabIndex = 5;
            this.btnEliminarHor.Text = "Eliminar";
            this.btnEliminarHor.Click += new System.EventHandler(this.btnEliminarHor_Click_1);
            // 
            // dgvHorarios
            // 
            this.dgvHorarios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHorarios.ColumnHeadersHeight = 29;
            this.dgvHorarios.Location = new System.Drawing.Point(12, 80);
            this.dgvHorarios.Name = "dgvHorarios";
            this.dgvHorarios.RowHeadersWidth = 51;
            this.dgvHorarios.Size = new System.Drawing.Size(1056, 535);
            this.dgvHorarios.TabIndex = 19;
            // 
            // pnlAlumnos
            // 
            this.pnlAlumnos.Controls.Add(this.lblTituloAl);
            this.pnlAlumnos.Controls.Add(this.txtBuscarAl);
            this.pnlAlumnos.Controls.Add(this.btnBuscarAl);
            this.pnlAlumnos.Controls.Add(this.btnEditar);
            this.pnlAlumnos.Controls.Add(this.btnEliminar);
            this.pnlAlumnos.Controls.Add(this.dgvAlumnos);
            this.pnlAlumnos.Location = new System.Drawing.Point(315, 190);
            this.pnlAlumnos.Name = "pnlAlumnos";
            this.pnlAlumnos.Size = new System.Drawing.Size(262, 82);
            this.pnlAlumnos.TabIndex = 1;
            this.pnlAlumnos.Visible = false;
            // 
            // lblTituloAl
            // 
            this.lblTituloAl.AutoSize = true;
            this.lblTituloAl.Location = new System.Drawing.Point(22, 9);
            this.lblTituloAl.Name = "lblTituloAl";
            this.lblTituloAl.Size = new System.Drawing.Size(159, 19);
            this.lblTituloAl.TabIndex = 0;
            this.lblTituloAl.Text = "Catálogo de Alumnos";
            // 
            // txtBuscarAl
            // 
            this.txtBuscarAl.Location = new System.Drawing.Point(12, 40);
            this.txtBuscarAl.Name = "txtBuscarAl";
            this.txtBuscarAl.Size = new System.Drawing.Size(300, 25);
            this.txtBuscarAl.TabIndex = 1;
            // 
            // btnBuscarAl
            // 
            this.btnBuscarAl.Location = new System.Drawing.Point(320, 38);
            this.btnBuscarAl.Name = "btnBuscarAl";
            this.btnBuscarAl.Size = new System.Drawing.Size(90, 30);
            this.btnBuscarAl.TabIndex = 2;
            this.btnBuscarAl.Text = "Buscar";
            this.btnBuscarAl.Click += new System.EventHandler(this.btnBuscarAl_Click_1);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(542, 38);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(104, 32);
            this.btnEditar.TabIndex = 4;
            this.btnEditar.Text = "Editar";
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click_1);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(422, 39);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(101, 32);
            this.btnEliminar.TabIndex = 5;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click_1);
            // 
            // dgvAlumnos
            // 
            this.dgvAlumnos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAlumnos.ColumnHeadersHeight = 29;
            this.dgvAlumnos.Location = new System.Drawing.Point(12, 80);
            this.dgvAlumnos.Name = "dgvAlumnos";
            this.dgvAlumnos.RowHeadersWidth = 51;
            this.dgvAlumnos.Size = new System.Drawing.Size(1072, 382);
            this.dgvAlumnos.TabIndex = 6;
            // 
            // pnlEditAlumno
            // 
            this.pnlEditAlumno.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlEditAlumno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlEditAlumno.Controls.Add(this.btnLimpiar);
            this.pnlEditAlumno.Controls.Add(this.btnAgregarAl);
            this.pnlEditAlumno.Controls.Add(this.txtNumCtrlA);
            this.pnlEditAlumno.Controls.Add(this.txtCurpA);
            this.pnlEditAlumno.Controls.Add(this.txtSemestreA);
            this.pnlEditAlumno.Controls.Add(this.txtCarreraA);
            this.pnlEditAlumno.Controls.Add(this.txtApMatA);
            this.pnlEditAlumno.Controls.Add(this.txtApPatA);
            this.pnlEditAlumno.Controls.Add(this.txtNombreA);
            this.pnlEditAlumno.Controls.Add(this.lblClave);
            this.pnlEditAlumno.Controls.Add(this.lblCurp);
            this.pnlEditAlumno.Controls.Add(this.lblSemestre);
            this.pnlEditAlumno.Controls.Add(this.lblCarreras);
            this.pnlEditAlumno.Controls.Add(this.lblApellidoM);
            this.pnlEditAlumno.Controls.Add(this.lblApellidoP);
            this.pnlEditAlumno.Controls.Add(this.lblNombre);
            this.pnlEditAlumno.Controls.Add(this.label4);
            this.pnlEditAlumno.Location = new System.Drawing.Point(315, 34);
            this.pnlEditAlumno.Name = "pnlEditAlumno";
            this.pnlEditAlumno.Size = new System.Drawing.Size(297, 109);
            this.pnlEditAlumno.TabIndex = 7;
            this.pnlEditAlumno.Visible = false;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(333, 501);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(94, 32);
            this.btnLimpiar.TabIndex = 31;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnAgregarAl
            // 
            this.btnAgregarAl.Location = new System.Drawing.Point(453, 500);
            this.btnAgregarAl.Name = "btnAgregarAl";
            this.btnAgregarAl.Size = new System.Drawing.Size(94, 32);
            this.btnAgregarAl.TabIndex = 30;
            this.btnAgregarAl.Text = "Agregar";
            this.btnAgregarAl.Click += new System.EventHandler(this.btnAgregarAl_Click);
            // 
            // txtNumCtrlA
            // 
            this.txtNumCtrlA.Location = new System.Drawing.Point(232, 93);
            this.txtNumCtrlA.Name = "txtNumCtrlA";
            this.txtNumCtrlA.Size = new System.Drawing.Size(315, 25);
            this.txtNumCtrlA.TabIndex = 29;
            // 
            // txtCurpA
            // 
            this.txtCurpA.Location = new System.Drawing.Point(232, 414);
            this.txtCurpA.Name = "txtCurpA";
            this.txtCurpA.Size = new System.Drawing.Size(315, 25);
            this.txtCurpA.TabIndex = 28;
            // 
            // txtSemestreA
            // 
            this.txtSemestreA.Location = new System.Drawing.Point(232, 353);
            this.txtSemestreA.Name = "txtSemestreA";
            this.txtSemestreA.Size = new System.Drawing.Size(315, 25);
            this.txtSemestreA.TabIndex = 27;
            // 
            // txtCarreraA
            // 
            this.txtCarreraA.Location = new System.Drawing.Point(232, 309);
            this.txtCarreraA.Name = "txtCarreraA";
            this.txtCarreraA.Size = new System.Drawing.Size(315, 25);
            this.txtCarreraA.TabIndex = 26;
            // 
            // txtApMatA
            // 
            this.txtApMatA.Location = new System.Drawing.Point(232, 254);
            this.txtApMatA.Name = "txtApMatA";
            this.txtApMatA.Size = new System.Drawing.Size(315, 25);
            this.txtApMatA.TabIndex = 25;
            // 
            // txtApPatA
            // 
            this.txtApPatA.Location = new System.Drawing.Point(232, 200);
            this.txtApPatA.Name = "txtApPatA";
            this.txtApPatA.Size = new System.Drawing.Size(315, 25);
            this.txtApPatA.TabIndex = 24;
            // 
            // txtNombreA
            // 
            this.txtNombreA.Location = new System.Drawing.Point(232, 148);
            this.txtNombreA.Name = "txtNombreA";
            this.txtNombreA.Size = new System.Drawing.Size(315, 25);
            this.txtNombreA.TabIndex = 23;
            // 
            // lblClave
            // 
            this.lblClave.AutoSize = true;
            this.lblClave.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClave.Location = new System.Drawing.Point(32, 93);
            this.lblClave.Name = "lblClave";
            this.lblClave.Size = new System.Drawing.Size(99, 20);
            this.lblClave.TabIndex = 22;
            this.lblClave.Text = "Num. Control";
            // 
            // lblCurp
            // 
            this.lblCurp.AutoSize = true;
            this.lblCurp.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurp.Location = new System.Drawing.Point(32, 414);
            this.lblCurp.Name = "lblCurp";
            this.lblCurp.Size = new System.Drawing.Size(46, 20);
            this.lblCurp.TabIndex = 21;
            this.lblCurp.Text = "CURP";
            // 
            // lblSemestre
            // 
            this.lblSemestre.AutoSize = true;
            this.lblSemestre.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSemestre.Location = new System.Drawing.Point(32, 352);
            this.lblSemestre.Name = "lblSemestre";
            this.lblSemestre.Size = new System.Drawing.Size(70, 20);
            this.lblSemestre.TabIndex = 20;
            this.lblSemestre.Text = "Semestre";
            // 
            // lblCarreras
            // 
            this.lblCarreras.AutoSize = true;
            this.lblCarreras.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCarreras.Location = new System.Drawing.Point(32, 316);
            this.lblCarreras.Name = "lblCarreras";
            this.lblCarreras.Size = new System.Drawing.Size(57, 20);
            this.lblCarreras.TabIndex = 19;
            this.lblCarreras.Text = "Carrera";
            // 
            // lblApellidoM
            // 
            this.lblApellidoM.AutoSize = true;
            this.lblApellidoM.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApellidoM.Location = new System.Drawing.Point(32, 254);
            this.lblApellidoM.Name = "lblApellidoM";
            this.lblApellidoM.Size = new System.Drawing.Size(128, 20);
            this.lblApellidoM.TabIndex = 18;
            this.lblApellidoM.Text = "Apellido Materno";
            // 
            // lblApellidoP
            // 
            this.lblApellidoP.AutoSize = true;
            this.lblApellidoP.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApellidoP.Location = new System.Drawing.Point(32, 207);
            this.lblApellidoP.Name = "lblApellidoP";
            this.lblApellidoP.Size = new System.Drawing.Size(123, 20);
            this.lblApellidoP.TabIndex = 17;
            this.lblApellidoP.Text = "Apellido Paterno";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(32, 151);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(64, 20);
            this.lblNombre.TabIndex = 16;
            this.lblNombre.Text = "Nombre";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 19);
            this.label4.TabIndex = 11;
            this.label4.Text = "Editar Alumnos";
            // 
            // pnlReinscripcion
            // 
            this.pnlReinscripcion.Controls.Add(this.lblReinscripcion);
            this.pnlReinscripcion.Controls.Add(this.cmbAlumRein);
            this.pnlReinscripcion.Controls.Add(this.btnGenPaq);
            this.pnlReinscripcion.Controls.Add(this.btnAsignarPaq);
            this.pnlReinscripcion.Controls.Add(this.dgvPaqRein);
            this.pnlReinscripcion.Controls.Add(this.dgvMatPaqRein);
            this.pnlReinscripcion.Location = new System.Drawing.Point(28, 460);
            this.pnlReinscripcion.Name = "pnlReinscripcion";
            this.pnlReinscripcion.Size = new System.Drawing.Size(232, 109);
            this.pnlReinscripcion.TabIndex = 4;
            this.pnlReinscripcion.Visible = false;
            // 
            // lblReinscripcion
            // 
            this.lblReinscripcion.AutoSize = true;
            this.lblReinscripcion.Location = new System.Drawing.Point(12, 9);
            this.lblReinscripcion.Name = "lblReinscripcion";
            this.lblReinscripcion.Size = new System.Drawing.Size(307, 19);
            this.lblReinscripcion.TabIndex = 0;
            this.lblReinscripcion.Text = "Reinscripción - Generar y asignar paquetes";
            // 
            // cmbAlumRein
            // 
            this.cmbAlumRein.Location = new System.Drawing.Point(12, 40);
            this.cmbAlumRein.Name = "cmbAlumRein";
            this.cmbAlumRein.Size = new System.Drawing.Size(300, 27);
            this.cmbAlumRein.TabIndex = 1;
            // 
            // btnGenPaq
            // 
            this.btnGenPaq.Location = new System.Drawing.Point(320, 38);
            this.btnGenPaq.Name = "btnGenPaq";
            this.btnGenPaq.Size = new System.Drawing.Size(120, 30);
            this.btnGenPaq.TabIndex = 2;
            this.btnGenPaq.Text = "Generar Paquetes";
            this.btnGenPaq.Click += new System.EventHandler(this.btnGenPaq_Click);
            // 
            // btnAsignarPaq
            // 
            this.btnAsignarPaq.Location = new System.Drawing.Point(450, 38);
            this.btnAsignarPaq.Name = "btnAsignarPaq";
            this.btnAsignarPaq.Size = new System.Drawing.Size(120, 30);
            this.btnAsignarPaq.TabIndex = 3;
            this.btnAsignarPaq.Text = "Asignar Paquete";
            this.btnAsignarPaq.Click += new System.EventHandler(this.btnAsignarPaq_Click_1);
            // 
            // dgvPaqRein
            // 
            this.dgvPaqRein.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPaqRein.ColumnHeadersHeight = 29;
            this.dgvPaqRein.Location = new System.Drawing.Point(12, 80);
            this.dgvPaqRein.Name = "dgvPaqRein";
            this.dgvPaqRein.RowHeadersWidth = 51;
            this.dgvPaqRein.Size = new System.Drawing.Size(1042, 200);
            this.dgvPaqRein.TabIndex = 0;
            this.dgvPaqRein.SelectionChanged += new System.EventHandler(this.dgvPaqRein_SelectionChanged);
            // 
            // dgvMatPaqRein
            // 
            this.dgvMatPaqRein.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMatPaqRein.ColumnHeadersHeight = 29;
            this.dgvMatPaqRein.Location = new System.Drawing.Point(12, 290);
            this.dgvMatPaqRein.Name = "dgvMatPaqRein";
            this.dgvMatPaqRein.RowHeadersWidth = 51;
            this.dgvMatPaqRein.Size = new System.Drawing.Size(1042, 299);
            this.dgvMatPaqRein.TabIndex = 1;
            // 
            // pnlPaquetes
            // 
            this.pnlPaquetes.Controls.Add(this.lblPaquetes);
            this.pnlPaquetes.Controls.Add(this.cmbAlumPaq);
            this.pnlPaquetes.Controls.Add(this.dgvPaqLista);
            this.pnlPaquetes.Controls.Add(this.dgvMatPaqDet);
            this.pnlPaquetes.Location = new System.Drawing.Point(28, 339);
            this.pnlPaquetes.Name = "pnlPaquetes";
            this.pnlPaquetes.Size = new System.Drawing.Size(232, 106);
            this.pnlPaquetes.TabIndex = 5;
            this.pnlPaquetes.Visible = false;
            // 
            // lblPaquetes
            // 
            this.lblPaquetes.AutoSize = true;
            this.lblPaquetes.Location = new System.Drawing.Point(12, 9);
            this.lblPaquetes.Name = "lblPaquetes";
            this.lblPaquetes.Size = new System.Drawing.Size(229, 19);
            this.lblPaquetes.TabIndex = 0;
            this.lblPaquetes.Text = "Consultar paquetes por alumno";
            // 
            // cmbAlumPaq
            // 
            this.cmbAlumPaq.Location = new System.Drawing.Point(12, 40);
            this.cmbAlumPaq.Name = "cmbAlumPaq";
            this.cmbAlumPaq.Size = new System.Drawing.Size(300, 27);
            this.cmbAlumPaq.TabIndex = 1;
            this.cmbAlumPaq.SelectedIndexChanged += new System.EventHandler(this.cmbAlumPaq_SelectedIndexChanged);
            // 
            // dgvPaqLista
            // 
            this.dgvPaqLista.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPaqLista.ColumnHeadersHeight = 29;
            this.dgvPaqLista.Location = new System.Drawing.Point(12, 80);
            this.dgvPaqLista.Name = "dgvPaqLista";
            this.dgvPaqLista.RowHeadersWidth = 51;
            this.dgvPaqLista.Size = new System.Drawing.Size(1042, 200);
            this.dgvPaqLista.TabIndex = 0;
            this.dgvPaqLista.SelectionChanged += new System.EventHandler(this.dgvPaqLista_SelectionChanged);
            // 
            // dgvMatPaqDet
            // 
            this.dgvMatPaqDet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMatPaqDet.ColumnHeadersHeight = 29;
            this.dgvMatPaqDet.Location = new System.Drawing.Point(12, 290);
            this.dgvMatPaqDet.Name = "dgvMatPaqDet";
            this.dgvMatPaqDet.RowHeadersWidth = 51;
            this.dgvMatPaqDet.Size = new System.Drawing.Size(1042, 296);
            this.dgvMatPaqDet.TabIndex = 1;
            // 
            // pnlCalificaciones
            // 
            this.pnlCalificaciones.Controls.Add(this.lblCalif);
            this.pnlCalificaciones.Controls.Add(this.cmbAlumCalif);
            this.pnlCalificaciones.Controls.Add(this.cmbMatCalif);
            this.pnlCalificaciones.Controls.Add(this.txtCalif);
            this.pnlCalificaciones.Controls.Add(this.cmbTipoCalif);
            this.pnlCalificaciones.Controls.Add(this.btnGuardarCalif);
            this.pnlCalificaciones.Controls.Add(this.dgvHistCalif);
            this.pnlCalificaciones.Location = new System.Drawing.Point(28, 181);
            this.pnlCalificaciones.Name = "pnlCalificaciones";
            this.pnlCalificaciones.Size = new System.Drawing.Size(232, 107);
            this.pnlCalificaciones.TabIndex = 6;
            this.pnlCalificaciones.Visible = false;
            // 
            // lblCalif
            // 
            this.lblCalif.AutoSize = true;
            this.lblCalif.Location = new System.Drawing.Point(12, 9);
            this.lblCalif.Name = "lblCalif";
            this.lblCalif.Size = new System.Drawing.Size(187, 19);
            this.lblCalif.TabIndex = 0;
            this.lblCalif.Text = "Registro de Calificaciones";
            // 
            // cmbAlumCalif
            // 
            this.cmbAlumCalif.Location = new System.Drawing.Point(12, 40);
            this.cmbAlumCalif.Name = "cmbAlumCalif";
            this.cmbAlumCalif.Size = new System.Drawing.Size(300, 27);
            this.cmbAlumCalif.TabIndex = 1;
            // 
            // cmbMatCalif
            // 
            this.cmbMatCalif.Location = new System.Drawing.Point(320, 40);
            this.cmbMatCalif.Name = "cmbMatCalif";
            this.cmbMatCalif.Size = new System.Drawing.Size(250, 27);
            this.cmbMatCalif.TabIndex = 2;
            // 
            // txtCalif
            // 
            this.txtCalif.Location = new System.Drawing.Point(580, 40);
            this.txtCalif.Name = "txtCalif";
            this.txtCalif.Size = new System.Drawing.Size(80, 25);
            this.txtCalif.TabIndex = 3;
            this.txtCalif.Text = "0";
            // 
            // cmbTipoCalif
            // 
            this.cmbTipoCalif.Location = new System.Drawing.Point(670, 40);
            this.cmbTipoCalif.Name = "cmbTipoCalif";
            this.cmbTipoCalif.Size = new System.Drawing.Size(180, 27);
            this.cmbTipoCalif.TabIndex = 4;
            // 
            // btnGuardarCalif
            // 
            this.btnGuardarCalif.Location = new System.Drawing.Point(860, 38);
            this.btnGuardarCalif.Name = "btnGuardarCalif";
            this.btnGuardarCalif.Size = new System.Drawing.Size(100, 30);
            this.btnGuardarCalif.TabIndex = 5;
            this.btnGuardarCalif.Text = "Guardar";
            this.btnGuardarCalif.Click += new System.EventHandler(this.btnGuardarCalif_Click_1);
            // 
            // dgvHistCalif
            // 
            this.dgvHistCalif.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHistCalif.ColumnHeadersHeight = 29;
            this.dgvHistCalif.Location = new System.Drawing.Point(12, 80);
            this.dgvHistCalif.Name = "dgvHistCalif";
            this.dgvHistCalif.RowHeadersWidth = 51;
            this.dgvHistCalif.Size = new System.Drawing.Size(1042, 507);
            this.dgvHistCalif.TabIndex = 6;
            // 
            // pnlConsultas
            // 
            this.pnlConsultas.Controls.Add(this.lblConsultas);
            this.pnlConsultas.Controls.Add(this.cboConsultaTipo);
            this.pnlConsultas.Controls.Add(this.btnEjecutarCon);
            this.pnlConsultas.Controls.Add(this.dgvResultCon);
            this.pnlConsultas.Location = new System.Drawing.Point(0, 0);
            this.pnlConsultas.Name = "pnlConsultas";
            this.pnlConsultas.Size = new System.Drawing.Size(278, 143);
            this.pnlConsultas.TabIndex = 7;
            this.pnlConsultas.Visible = false;
            // 
            // lblConsultas
            // 
            this.lblConsultas.AutoSize = true;
            this.lblConsultas.Location = new System.Drawing.Point(12, 9);
            this.lblConsultas.Name = "lblConsultas";
            this.lblConsultas.Size = new System.Drawing.Size(168, 19);
            this.lblConsultas.TabIndex = 0;
            this.lblConsultas.Text = "Consultas predefinidas";
            // 
            // cboConsultaTipo
            // 
            this.cboConsultaTipo.Location = new System.Drawing.Point(12, 40);
            this.cboConsultaTipo.Name = "cboConsultaTipo";
            this.cboConsultaTipo.Size = new System.Drawing.Size(300, 27);
            this.cboConsultaTipo.TabIndex = 1;
            // 
            // btnEjecutarCon
            // 
            this.btnEjecutarCon.Location = new System.Drawing.Point(320, 38);
            this.btnEjecutarCon.Name = "btnEjecutarCon";
            this.btnEjecutarCon.Size = new System.Drawing.Size(100, 30);
            this.btnEjecutarCon.TabIndex = 2;
            this.btnEjecutarCon.Text = "Ejecutar";
            this.btnEjecutarCon.Click += new System.EventHandler(this.btnEjecutarCon_Click_1);
            // 
            // dgvResultCon
            // 
            this.dgvResultCon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvResultCon.ColumnHeadersHeight = 29;
            this.dgvResultCon.Location = new System.Drawing.Point(12, 80);
            this.dgvResultCon.Name = "dgvResultCon";
            this.dgvResultCon.RowHeadersWidth = 51;
            this.dgvResultCon.Size = new System.Drawing.Size(1088, 543);
            this.dgvResultCon.TabIndex = 8;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslInfo,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 590);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1037, 22);
            this.statusStrip1.TabIndex = 8;
            // 
            // tslInfo
            // 
            this.tslInfo.Name = "tslInfo";
            this.tslInfo.Size = new System.Drawing.Size(100, 16);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // btnCancelarAl
            // 
            this.btnCancelarAl.Location = new System.Drawing.Point(0, 0);
            this.btnCancelarAl.Name = "btnCancelarAl";
            this.btnCancelarAl.Size = new System.Drawing.Size(75, 23);
            this.btnCancelarAl.TabIndex = 0;
            // 
            // btnGuardarAl
            // 
            this.btnGuardarAl.Location = new System.Drawing.Point(0, 0);
            this.btnGuardarAl.Name = "btnGuardarAl";
            this.btnGuardarAl.Size = new System.Drawing.Size(75, 23);
            this.btnGuardarAl.TabIndex = 0;
            // 
            // cboPaqueteAl
            // 
            this.cboPaqueteAl.Location = new System.Drawing.Point(0, 0);
            this.cboPaqueteAl.Name = "cboPaqueteAl";
            this.cboPaqueteAl.Size = new System.Drawing.Size(121, 21);
            this.cboPaqueteAl.TabIndex = 0;
            // 
            // lblPaquete
            // 
            this.lblPaquete.Location = new System.Drawing.Point(0, 0);
            this.lblPaquete.Name = "lblPaquete";
            this.lblPaquete.Size = new System.Drawing.Size(100, 23);
            this.lblPaquete.TabIndex = 0;
            // 
            // txtSemestreAl
            // 
            this.txtSemestreAl.Location = new System.Drawing.Point(0, 0);
            this.txtSemestreAl.Name = "txtSemestreAl";
            this.txtSemestreAl.Size = new System.Drawing.Size(100, 20);
            this.txtSemestreAl.TabIndex = 0;
            // 
            // lblSemestreAl
            // 
            this.lblSemestreAl.Location = new System.Drawing.Point(0, 0);
            this.lblSemestreAl.Name = "lblSemestreAl";
            this.lblSemestreAl.Size = new System.Drawing.Size(100, 23);
            this.lblSemestreAl.TabIndex = 0;
            // 
            // txtCarreraAl
            // 
            this.txtCarreraAl.Location = new System.Drawing.Point(0, 0);
            this.txtCarreraAl.Name = "txtCarreraAl";
            this.txtCarreraAl.Size = new System.Drawing.Size(100, 20);
            this.txtCarreraAl.TabIndex = 0;
            // 
            // lblCarrera
            // 
            this.lblCarrera.Location = new System.Drawing.Point(0, 0);
            this.lblCarrera.Name = "lblCarrera";
            this.lblCarrera.Size = new System.Drawing.Size(100, 23);
            this.lblCarrera.TabIndex = 0;
            // 
            // txtCurpAl
            // 
            this.txtCurpAl.Location = new System.Drawing.Point(0, 0);
            this.txtCurpAl.Name = "txtCurpAl";
            this.txtCurpAl.Size = new System.Drawing.Size(100, 20);
            this.txtCurpAl.TabIndex = 0;
            // 
            // lblCurpAl
            // 
            this.lblCurpAl.Location = new System.Drawing.Point(0, 0);
            this.lblCurpAl.Name = "lblCurpAl";
            this.lblCurpAl.Size = new System.Drawing.Size(100, 23);
            this.lblCurpAl.TabIndex = 0;
            // 
            // txtApMatAl
            // 
            this.txtApMatAl.Location = new System.Drawing.Point(0, 0);
            this.txtApMatAl.Name = "txtApMatAl";
            this.txtApMatAl.Size = new System.Drawing.Size(100, 20);
            this.txtApMatAl.TabIndex = 0;
            // 
            // lblMatAl
            // 
            this.lblMatAl.Location = new System.Drawing.Point(0, 0);
            this.lblMatAl.Name = "lblMatAl";
            this.lblMatAl.Size = new System.Drawing.Size(100, 23);
            this.lblMatAl.TabIndex = 0;
            // 
            // txtApPatAl
            // 
            this.txtApPatAl.Location = new System.Drawing.Point(0, 0);
            this.txtApPatAl.Name = "txtApPatAl";
            this.txtApPatAl.Size = new System.Drawing.Size(100, 20);
            this.txtApPatAl.TabIndex = 0;
            // 
            // lblApPatAl
            // 
            this.lblApPatAl.Location = new System.Drawing.Point(0, 0);
            this.lblApPatAl.Name = "lblApPatAl";
            this.lblApPatAl.Size = new System.Drawing.Size(100, 23);
            this.lblApPatAl.TabIndex = 0;
            // 
            // txtNombreAl
            // 
            this.txtNombreAl.Location = new System.Drawing.Point(0, 0);
            this.txtNombreAl.Name = "txtNombreAl";
            this.txtNombreAl.Size = new System.Drawing.Size(100, 20);
            this.txtNombreAl.TabIndex = 0;
            // 
            // lblNombreAl
            // 
            this.lblNombreAl.Location = new System.Drawing.Point(0, 0);
            this.lblNombreAl.Name = "lblNombreAl";
            this.lblNombreAl.Size = new System.Drawing.Size(100, 23);
            this.lblNombreAl.TabIndex = 0;
            // 
            // txtNumCtrlAl
            // 
            this.txtNumCtrlAl.Location = new System.Drawing.Point(0, 0);
            this.txtNumCtrlAl.Name = "txtNumCtrlAl";
            this.txtNumCtrlAl.Size = new System.Drawing.Size(100, 20);
            this.txtNumCtrlAl.TabIndex = 0;
            // 
            // lblNumcontrol
            // 
            this.lblNumcontrol.Location = new System.Drawing.Point(0, 0);
            this.lblNumcontrol.Name = "lblNumcontrol";
            this.lblNumcontrol.Size = new System.Drawing.Size(100, 23);
            this.lblNumcontrol.TabIndex = 0;
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1037, 636);
            this.Controls.Add(this.pnlContenedor);
            this.Controls.Add(this.mnuPrincipal);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Bold);
            this.MainMenuStrip = this.mnuPrincipal;
            this.Name = "FrmPrincipal";
            this.Text = "Sistema de Reinscripción";
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.mnuPrincipal.ResumeLayout(false);
            this.mnuPrincipal.PerformLayout();
            this.pnlContenedor.ResumeLayout(false);
            this.pnlContenedor.PerformLayout();
            this.pnlMaterias.ResumeLayout(false);
            this.pnlMaterias.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterias)).EndInit();
            this.pnlHorarios.ResumeLayout(false);
            this.pnlHorarios.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHorarios)).EndInit();
            this.pnlAlumnos.ResumeLayout(false);
            this.pnlAlumnos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlumnos)).EndInit();
            this.pnlEditAlumno.ResumeLayout(false);
            this.pnlEditAlumno.PerformLayout();
            this.pnlReinscripcion.ResumeLayout(false);
            this.pnlReinscripcion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaqRein)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatPaqRein)).EndInit();
            this.pnlPaquetes.ResumeLayout(false);
            this.pnlPaquetes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaqLista)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatPaqDet)).EndInit();
            this.pnlCalificaciones.ResumeLayout(false);
            this.pnlCalificaciones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistCalif)).EndInit();
            this.pnlConsultas.ResumeLayout(false);
            this.pnlConsultas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultCon)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        // Declaración de todos los controles (para que el diseñador los reconozca)
        private System.Windows.Forms.MenuStrip mnuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem mnuAlumnos, mnuMaterias, mnuHorarios, mnuReinscripcion, mnuCalificacion, mnuConsulta, mnuPaquetes, mnuSalir;
        private System.Windows.Forms.Panel pnlContenedor;

        private System.Windows.Forms.Panel pnlAlumnos, pnlMaterias, pnlHorarios, pnlReinscripcion, pnlPaquetes, pnlCalificaciones, pnlConsultas;

        // Alumnos
        private System.Windows.Forms.DataGridView dgvAlumnos;
        private System.Windows.Forms.TextBox txtBuscarAl;
        private System.Windows.Forms.Button btnBuscarAl, btnEditar, btnEliminar;
        private System.Windows.Forms.Label lblTituloAl;
        private System.Windows.Forms.Panel pnlEditAlumno;
        private System.Windows.Forms.Button btnCancelarAl, btnGuardarAl;
        private System.Windows.Forms.ComboBox cboPaqueteAl;
        private System.Windows.Forms.Label lblPaquete, lblSemestreAl, lblCarrera, lblCurpAl, lblMatAl, lblApPatAl, lblNombreAl, lblNumcontrol;
        private System.Windows.Forms.TextBox txtSemestreAl, txtCarreraAl, txtCurpAl, txtApMatAl, txtApPatAl, txtNombreAl, txtNumCtrlAl;

        // Materias
        private System.Windows.Forms.DataGridView dgvMaterias;
        private System.Windows.Forms.TextBox txtBuscarMat;
        private System.Windows.Forms.Button btnBuscarMat, btnAgregarMat, btnEditarMat, btnEliminarMat;
        private System.Windows.Forms.Label label1;

        // Horarios
        private System.Windows.Forms.DataGridView dgvHorarios;
        private System.Windows.Forms.TextBox txtBuscarHor;
        private System.Windows.Forms.Button btnBuscarHor, btnAgregarHor, btnEditarHor, btnEliminarHor;
        private System.Windows.Forms.Label label2;

        // Reinscripción
        private System.Windows.Forms.Label lblReinscripcion;
        private System.Windows.Forms.ComboBox cmbAlumRein;
        private System.Windows.Forms.Button btnGenPaq, btnAsignarPaq;
        private System.Windows.Forms.DataGridView dgvPaqRein, dgvMatPaqRein;

        // Paquetes (consulta)
        private System.Windows.Forms.Label lblPaquetes;
        private System.Windows.Forms.ComboBox cmbAlumPaq;
        private System.Windows.Forms.DataGridView dgvPaqLista, dgvMatPaqDet;

        // Calificaciones
        private System.Windows.Forms.Label lblCalif;
        private System.Windows.Forms.ComboBox cmbAlumCalif, cmbMatCalif, cmbTipoCalif;
        private System.Windows.Forms.TextBox txtCalif;
        private System.Windows.Forms.Button btnGuardarCalif;
        private System.Windows.Forms.DataGridView dgvHistCalif;

        // Consultas
        private System.Windows.Forms.Label lblConsultas;
        private System.Windows.Forms.ComboBox cboConsultaTipo;
        private System.Windows.Forms.Button btnEjecutarCon;
        private System.Windows.Forms.DataGridView dgvResultCon;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblApellidoM;
        private System.Windows.Forms.Label lblApellidoP;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblSemestre;
        private System.Windows.Forms.Label lblCarreras;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnAgregarAl;
        private System.Windows.Forms.TextBox txtNumCtrlA;
        private System.Windows.Forms.TextBox txtCurpA;
        private System.Windows.Forms.TextBox txtSemestreA;
        private System.Windows.Forms.TextBox txtCarreraA;
        private System.Windows.Forms.TextBox txtApMatA;
        private System.Windows.Forms.TextBox txtApPatA;
        private System.Windows.Forms.TextBox txtNombreA;
        private System.Windows.Forms.Label lblClave;
        private System.Windows.Forms.Label lblCurp;
        private System.Windows.Forms.ToolStripProgressBar tslInfo;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
    }
}
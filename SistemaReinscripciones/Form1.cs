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
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void OcultarTodosPaneles()
        {
            pnlAlumnos.Visible = false;
            pnlMaterias.Visible = false;
            pnlEditAlumno.Visible = false;
            pnlHorarios.Visible = false;
            pnlConsulta.Visible = false;

        }

        // Muestra un panel específico (primero oculta todos)
        private void MostrarPanel(Panel panelMostrar)
        {
            OcultarTodosPaneles();
            panelMostrar.Visible = true;
            panelMostrar.BringToFront();
        }

        // Evento del menú Alumnos
        private void mnuAlumnos_Click(object sender, EventArgs e)
        {
            MostrarPanel(pnlAlumnos);
            tslInfo.Text = "Módulo: Alumnos";
        }

        // Evento del menú Materias
         private void mnuMaterias_Click(object sender, EventArgs e)
        {

            OcultarTodosPaneles();
            // Muestra el panel de materias
            pnlMaterias.Visible = true;
            pnlMaterias.BringToFront();
            tslInfo.Text = "Módulo: Materias";
        }
        private void mnuHorarios_Click(object sender, EventArgs e)
        {
            MostrarPanel(pnlHorarios);
            tslInfo.Text = "Módulo: Alumnos";
        }  
        private void mnuReinscripcion_Click(object sender, EventArgs e)
        {

        } 
        private void mnuCalificacion_Click(object sender, EventArgs e)
        {

        }

        private void mnuConsulta_Click(object sender, EventArgs e)
        {
            MostrarPanel(pnlConsulta);
            tslInfo.Text = "Módulo: Alumnos";
        }

        private void mnuPaquetes_Click(object sender, EventArgs e)
        {

        }

        private void mnuSalir_Click(object sender, EventArgs e)
        {

        }

        
        private void btnEditar_Click(object sender, EventArgs e)
        {
            // Opción A: Mostrar solo el panel de edición encima de lo que haya
            pnlEditAlumno.Visible = true;
            pnlEditAlumno.BringToFront();
            
          
        }

        // Botón Buscar - ejemplo: oculta el panel de edición si está visible
        private void btnBuscarAl_Click(object sender, EventArgs e)
        {
            pnlEditAlumno.Visible = false;
            // Aquí iría la lógica de búsqueda
        }

        // Botón Agregar - similar
        private void btnAgregarAl_Click(object sender, EventArgs e)
        {
            pnlEditAlumno.Visible = false;
            // Lógica para agregar nuevo alumno
        }

        // Botón Eliminar - oculta panel de edición
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            pnlEditAlumno.Visible = false;
            // Lógica para eliminar
        }

        // Mantén los demás eventos (Load, Paint, etc.) si son necesarios
        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            // Opcional: mostrar un panel por defecto al cargar el formulario
            //MostrarPanel(pnlAlumnos);
            tslInfo.Text = "Módulo: Alumnos";
        }


    }
}
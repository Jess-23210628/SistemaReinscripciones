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
    public partial class ucAlumnos : UserControl
    {
        private string _conn;
        private string _usuarioAdmin;

        public ucAlumnos()
        {
            InitializeComponent();
        }

        // Constructor adicional para aceptar cadena de conexión y usuario
        public ucAlumnos(string connectionString, string username)
        {
            _conn = connectionString;
            _usuarioAdmin = username;
            InitializeComponent();
        }

        private void ucAlumnoscs_Load(object sender, EventArgs e)
        {

        }
    }
}

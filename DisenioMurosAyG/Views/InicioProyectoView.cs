using DisenioMurosAyG.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DisenioMurosAyG.Views
{
    public partial class InicioProyectoView : Form
    {
        public InicioProyectoView()
        {

            InitializeComponent();

            ContextController _context = new ContextController(this);
        }

        private void InicioProyectoView_Load(object sender, EventArgs e)
        {

        }
    }
}

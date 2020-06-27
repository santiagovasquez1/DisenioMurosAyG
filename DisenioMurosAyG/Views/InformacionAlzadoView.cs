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
    public partial class InformacionAlzadoView : Form
    {
        public InformacionAlzadoView()
        {
            InitializeComponent();
            AlzadoController alzadoController = new AlzadoController(this);
        }
    }
}

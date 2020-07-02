using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace DisenioMurosAyG.Views
{
    public partial class DespieceView : Telerik.WinControls.UI.RadForm
    {
        public DespieceView()
        {
            InitializeComponent();
            SetTheme();
        }

        private void SetTheme()
        {
           this.gvDespieceMuro.ThemeName="Prueba1";
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace DisenioMurosAyG.Views
{
    public partial class InformacionAlzadoView1 : Telerik.WinControls.UI.RadForm
    {
        public InformacionAlzadoView1()        {
 
            InitializeComponent();
            SetTheme();
            //SetContextMenu();
        }

        private void SetContextMenu()
        {
            //var contextMenu = this.dgAlzado.ContextMenu ;
            //if (contextMenu != null)
            //{
            //    var items = contextMenu.MenuItems;

            //    RadMenuItem menuItem = new RadMenuItem();
            //    menuItem.Text = "Copiar";
            //}

        }

        private void SetTheme()
        {
            this.dgAlzado.ThemeName = "Prueba1";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DisenioMurosAyG.ClasesEstaticas
{
   public static class  Cargar_Formularios
    {
        public static void Open_From_Panel(Telerik.WinControls.UI.RadPanel Formulario_Madre, Telerik.WinControls.UI.RadForm Formulario)
        {
            Telerik.WinControls.UI.RadPanel FM = Formulario_Madre;
            Telerik.WinControls.UI.RadForm FH = Formulario;

            if (FM.Controls.Count > 0)
            {
                FM.Controls.Clear();
            }

            FH.TopLevel = false;
            FH.FormBorderStyle = FormBorderStyle.None;
            FH.Dock = DockStyle.Fill;

            FM.Controls.Add(FH);
            FM.Tag = FH;
            FH.Show();
        }

    }
}

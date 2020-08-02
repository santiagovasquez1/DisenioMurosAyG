using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace DisenioMurosAyG.ClasesEstaticas
{
   public static class  Cargar_Formularios
    {
        public static void Open_From_Panel(RadPageViewPage Formulario_Madre, Telerik.WinControls.UI.RadForm Formulario)
        {
            RadPageViewPage FM = Formulario_Madre;
            RadForm FH = Formulario;

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

        public static void Open_From_Panel(SplitPanel Formulario_Madre, Telerik.WinControls.UI.RadForm Formulario)
        {
            SplitPanel FM = Formulario_Madre;
            RadForm FH = Formulario;

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

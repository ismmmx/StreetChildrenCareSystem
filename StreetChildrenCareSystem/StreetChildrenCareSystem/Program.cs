using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StreetChildrenCareSystem
{
    static class Program
    {
        // This function tells Windows: "Don't auto-scale this app"
        // Without this, on 200% DPI screens, forms appear DOUBLE the size
        [DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();

        [STAThread]
        static void Main()
        {
            // Fix the "form too big" problem on high-DPI / 200% scaled monitors
            SetProcessDPIAware();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogin());

           
        }
    }
}

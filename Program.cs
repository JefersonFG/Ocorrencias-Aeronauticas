using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ocorrências_Aeronáuticas
{
    /// <summary>
    /// Classe de programa
    /// </summary>
    static class Program
    {
        /// <summary>
        /// Função Main do programa
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoadForm());
        }
    }
}

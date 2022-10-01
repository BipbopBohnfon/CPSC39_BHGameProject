using System;
using System.Drawing;
using System.Windows.Forms;

namespace RhythmGame
{
    /// <summary>
    /// Not much to see here, just launches the Windows Forms application
    /// </summary>
    class MainClass
    {
        [STAThread]
        static public void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Canvas());
        }
    }
}

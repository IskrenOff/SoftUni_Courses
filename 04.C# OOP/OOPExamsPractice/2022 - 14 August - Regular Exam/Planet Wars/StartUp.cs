using PlanetWars.Core;
using System;
using System.Windows.Forms;

namespace PlanetWars
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //Don't forget to comment out the commented code lines in the Engine class!
            //var engine = new Engine();

            //engine.Run();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}

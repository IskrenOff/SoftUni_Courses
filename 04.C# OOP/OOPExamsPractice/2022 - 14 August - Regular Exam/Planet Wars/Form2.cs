using PlanetWars.Core;
using PlanetWars.Core.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PlanetWars
{
    public partial class Form2 : Form
    {

        Form opener;

        public Form2(Form parentForm)
        {
            InitializeComponent();
            opener = parentForm;
        }

        private void fileSystemWatcher1_Changed(object sender, System.IO.FileSystemEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            var objectForm1 = new Form1();
            objectForm1.PassingPlanetInfo();
            listBox1.Text = objectForm1.PassingPlanetInfo();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}

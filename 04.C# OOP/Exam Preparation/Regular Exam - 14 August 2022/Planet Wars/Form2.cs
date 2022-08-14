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
            richTextBox1.Multiline = true;
            richTextBox1.Text = objectForm1.PassingPlanetInfo();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}

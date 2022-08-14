using PlanetWars.Core;
using PlanetWars.Core.Contracts;
using PlanetWars.Models.Planets;
using PlanetWars.Models.Planets.Contracts;
using System;
using System.Text;
using System.Windows.Forms;

namespace PlanetWars
{
    internal class Form1 : Form
    {
        private TextBox PlanetNameField;
        private TextBox InfoField;
        private Button AddButton;
        private Button Play;
        private TextBox BudgetField;
        private Label Cnt;
        private Button ShowPlanetInfo;
        private IController controller;
        private IPlanet planet;

        private void InitializeComponent()
        {
            this.PlanetNameField = new System.Windows.Forms.TextBox();
            this.Play = new System.Windows.Forms.Button();
            this.InfoField = new System.Windows.Forms.TextBox();
            this.AddButton = new System.Windows.Forms.Button();
            this.BudgetField = new System.Windows.Forms.TextBox();
            this.Cnt = new System.Windows.Forms.Label();
            this.ShowPlanetInfo = new System.Windows.Forms.Button();           
            this.SuspendLayout();
            // 
            // PlanetNameField
            // 
            this.PlanetNameField.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PlanetNameField.Location = new System.Drawing.Point(241, 145);
            this.PlanetNameField.Name = "PlanetNameField";
            this.PlanetNameField.Size = new System.Drawing.Size(300, 23);
            this.PlanetNameField.TabIndex = 0;
            // 
            // Play
            // 
            this.Play.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Play.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Play.Location = new System.Drawing.Point(0, 358);
            this.Play.Name = "Play";
            this.Play.Size = new System.Drawing.Size(788, 93);
            this.Play.TabIndex = 1;
            this.Play.Text = "Play";
            this.Play.UseVisualStyleBackColor = true;
            // 
            // InfoField
            // 
            this.InfoField.Location = new System.Drawing.Point(241, 84);
            this.InfoField.Name = "InfoField";
            this.InfoField.Size = new System.Drawing.Size(300, 23);
            this.InfoField.TabIndex = 2;
            this.InfoField.Visible = false;
            // 
            // AddButton
            // 
            this.AddButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.AddButton.Location = new System.Drawing.Point(0, 268);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(788, 90);
            this.AddButton.TabIndex = 3;
            this.AddButton.Text = "Add Planet";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // BudgetField
            // 
            this.BudgetField.Location = new System.Drawing.Point(241, 206);
            this.BudgetField.Name = "BudgetField";
            this.BudgetField.Size = new System.Drawing.Size(300, 23);
            this.BudgetField.TabIndex = 4;
            // 
            // Cnt
            // 
            this.Cnt.Font = new System.Drawing.Font("Segoe UI", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Cnt.Location = new System.Drawing.Point(70, 84);
            this.Cnt.Name = "Cnt";
            this.Cnt.Size = new System.Drawing.Size(97, 145);
            this.Cnt.TabIndex = 0;
            this.Cnt.Text = "0";
            // 
            // ShowPlanetInfo
            // 
            this.ShowPlanetInfo.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ShowPlanetInfo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ShowPlanetInfo.Location = new System.Drawing.Point(596, 193);
            this.ShowPlanetInfo.Name = "ShowPlanetInfo";
            this.ShowPlanetInfo.Size = new System.Drawing.Size(160, 43);
            this.ShowPlanetInfo.TabIndex = 5;
            this.ShowPlanetInfo.Text = "Show Planet Info";
            this.ShowPlanetInfo.UseVisualStyleBackColor = false;
            this.ShowPlanetInfo.Click += new System.EventHandler(this.ShowPlanetInfo_Click);
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(788, 451);
            this.Controls.Add(this.ShowPlanetInfo);
            this.Controls.Add(this.Cnt);
            this.Controls.Add(this.BudgetField);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.InfoField);
            this.Controls.Add(this.Play);
            this.Controls.Add(this.PlanetNameField);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

            controller = new Controller();
            
            
        }
        
        private void AddButton_Click(object sender, EventArgs e)
        {
            string inputText = PlanetNameField.Text;
            try
            {               
                var budged = double.Parse(BudgetField.Text);               
                InfoField.Text = controller.CreatePlanet(inputText, budged);
                InfoField.Visible = true;
                Cnt.Text = controller.GetPlanetCount();
            }
            catch (Exception error)
            {
                InfoField.Text = error.Message;
                InfoField.Visible = true;

            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        public void ShowPlanetInfo_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(this);
            form2.Show();
        }

        public string PassingPlanetInfo()
        {         
            return controller.ForcesReport();
        }
    }
}
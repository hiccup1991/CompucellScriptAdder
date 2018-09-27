using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompucellScriptAdder
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Simulation Project";
            theDialog.Filter = "CC3D files|*.cc3d";
            theDialog.InitialDirectory = @"C:\";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = theDialog.FileName;
                MessageBox.Show(fileName);
            }
        }

        private void btnTemperaturePanelScript_Click(object sender, EventArgs e)
        {

        }
    }
}

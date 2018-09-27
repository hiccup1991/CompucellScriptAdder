using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace CompucellScriptAdder
{
    public partial class Form : System.Windows.Forms.Form
    {
        private string xmlScriptFilePath = "";
        private string resourceFilePath = "";
        private string pythonScriptFilePath = "";

        public Form()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Simulation Project";
            theDialog.Filter = "CC3D files|*.cc3d";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = theDialog.FileName;
                tbxProjectPath.Text = fileName;
                // Create an XML reader for this file.
                using (XmlReader reader = XmlReader.Create(fileName))
                {
                    while (reader.Read())
                    {
                        // Only detect start elements.
                        if (reader.IsStartElement())
                        {
                            // Get element name and switch on it.
                            switch (reader.Name)
                            {
                                case "XMLScript":
                                    if (reader.Read())
                                    {
                                        resourceFilePath = Path.GetDirectoryName(fileName) + "/" + reader.Value;
                                        //MessageBox.Show(resourceFilePath);
                                    }
                                    break;
                                case "PythonScript":
                                    if (reader.Read())
                                    {
                                        pythonScriptFilePath = Path.GetDirectoryName(fileName) + "/" + reader.Value;
                                        //MessageBox.Show(pythonScriptFilePath);
                                    }
                                    break;
                                case "Resource":
                                    if (reader.GetAttribute("Type") != "Python") break;
                                    if (reader.Read())
                                    {
                                        resourceFilePath = Path.GetDirectoryName(fileName) + "/" + reader.Value;
                                        //MessageBox.Show(resourceFilePath);
                                    }
                                    break;
                            }
                        }
                    }
                }
            }
        }

        private void btnTemperaturePanelScript_Click(object sender, EventArgs e)
        {
            string pythonScript = "\r\nfrom " + Path.GetFileNameWithoutExtension(resourceFilePath) + " import TemperatureSteeringSteppable\r\n\r\n" +
                "temperatureSteeringSteppable = TemperatureSteeringSteppable(_simulator = sim, _frequency = 1)\r\n" +
                "steppableRegistry.registerSteppable(temperatureSteeringSteppable)\r\n\r\n";
            addResource();
            addPythonScript(pythonScript);
        }

        private void addPythonScript(String pythonScript)
        {
            if (pythonScriptFilePath == "") return;

            var text = new StringBuilder();

            foreach (string s in File.ReadAllLines(pythonScriptFilePath))
            {
                text.AppendLine(s.Replace("CompuCellSetup.mainLoop(", pythonScript + "CompuCellSetup.mainLoop("));
            }

            using (var file = new StreamWriter(File.Create(pythonScriptFilePath)))
            {
                file.Write(text.ToString());
            }
        }

        private void addResource()
        {
            if (resourceFilePath == "") return;
            string fileName = "temperaturepanel.dll";
            try
            {
                FileStream stream = new FileStream(fileName, FileMode.Open);

                DESCryptoServiceProvider cryptic = new DESCryptoServiceProvider();

                cryptic.Key = ASCIIEncoding.ASCII.GetBytes("hiccup19");
                cryptic.IV = ASCIIEncoding.ASCII.GetBytes("hiccup19");

                CryptoStream crStream = new CryptoStream(stream, cryptic.CreateDecryptor(), CryptoStreamMode.Read);

                StreamReader reader = new StreamReader(crStream);

                string data = reader.ReadToEnd();
                reader.Close();
                stream.Close();

                File.AppendAllText(resourceFilePath, data);
                MessageBox.Show("Successfully added.");
            }
            catch(Exception ex)
            {
                //MessageBox.Show(ex.ToString());
                MessageBox.Show("Error in adding script.");
            }
        }

        private void btnEncrpyt_Click(object sender, EventArgs e)
        {
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Simulation Project";
            theDialog.Filter = "All files|*.*";
            theDialog.InitialDirectory = "E:/mytask/Compucell/CompucellScriptAdder";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = theDialog.FileName;
                try
                {
                    DESCryptoServiceProvider cryptic = new DESCryptoServiceProvider();

                    cryptic.Key = ASCIIEncoding.ASCII.GetBytes("hiccup19");
                    cryptic.IV = ASCIIEncoding.ASCII.GetBytes("hiccup19");

                    string cryptFile = Path.GetDirectoryName(fileName) + "/" + Path.GetFileNameWithoutExtension(fileName) + ".dll";
                    FileStream fsCrypt = new FileStream(cryptFile, FileMode.Create);

                    CryptoStream cs = new CryptoStream(fsCrypt, cryptic.CreateEncryptor(), CryptoStreamMode.Write);

                    FileStream fsIn = new FileStream(fileName, FileMode.Open);

                    int data;
                    while ((data = fsIn.ReadByte()) != -1)
                        cs.WriteByte((byte)data);

                    fsIn.Close();
                    cs.Close();
                    fsCrypt.Close();
                }
                catch(Exception ex)
                {
                    //MessageBox.Show(ex.ToString());
                    MessageBox.Show("Error in encryption.");
                }
            }
        }
    }
}


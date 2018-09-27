namespace CompucellScriptAdder
{
    partial class Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOpen = new System.Windows.Forms.Button();
            this.lblProjectPath = new System.Windows.Forms.Label();
            this.tbxProjectPath = new System.Windows.Forms.TextBox();
            this.btnTemperaturePanelScript = new System.Windows.Forms.Button();
            this.btnEncrpyt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(423, 68);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 0;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // lblProjectPath
            // 
            this.lblProjectPath.AutoSize = true;
            this.lblProjectPath.Location = new System.Drawing.Point(28, 73);
            this.lblProjectPath.Name = "lblProjectPath";
            this.lblProjectPath.Size = new System.Drawing.Size(62, 13);
            this.lblProjectPath.TabIndex = 1;
            this.lblProjectPath.Text = "ProjectPath";
            // 
            // tbxProjectPath
            // 
            this.tbxProjectPath.Location = new System.Drawing.Point(96, 70);
            this.tbxProjectPath.Name = "tbxProjectPath";
            this.tbxProjectPath.Size = new System.Drawing.Size(321, 20);
            this.tbxProjectPath.TabIndex = 2;
            // 
            // btnTemperaturePanelScript
            // 
            this.btnTemperaturePanelScript.Location = new System.Drawing.Point(187, 163);
            this.btnTemperaturePanelScript.Name = "btnTemperaturePanelScript";
            this.btnTemperaturePanelScript.Size = new System.Drawing.Size(117, 23);
            this.btnTemperaturePanelScript.TabIndex = 3;
            this.btnTemperaturePanelScript.Text = "Temperature Panel";
            this.btnTemperaturePanelScript.UseVisualStyleBackColor = true;
            this.btnTemperaturePanelScript.Click += new System.EventHandler(this.btnTemperaturePanelScript_Click);
            // 
            // btnEncrpyt
            // 
            this.btnEncrpyt.Location = new System.Drawing.Point(31, 12);
            this.btnEncrpyt.Name = "btnEncrpyt";
            this.btnEncrpyt.Size = new System.Drawing.Size(76, 23);
            this.btnEncrpyt.TabIndex = 4;
            this.btnEncrpyt.Text = "Encrypt";
            this.btnEncrpyt.UseVisualStyleBackColor = true;
            this.btnEncrpyt.Visible = false;
            this.btnEncrpyt.Click += new System.EventHandler(this.btnEncrpyt_Click);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 241);
            this.Controls.Add(this.btnEncrpyt);
            this.Controls.Add(this.btnTemperaturePanelScript);
            this.Controls.Add(this.tbxProjectPath);
            this.Controls.Add(this.lblProjectPath);
            this.Controls.Add(this.btnOpen);
            this.Name = "Form";
            this.Text = "CompucellScriptAdder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Label lblProjectPath;
        private System.Windows.Forms.TextBox tbxProjectPath;
        private System.Windows.Forms.Button btnTemperaturePanelScript;
        private System.Windows.Forms.Button btnEncrpyt;
    }
}


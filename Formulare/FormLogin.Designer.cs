
namespace MaschinenVerwaltung
{
    partial class FormLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.maskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.labelPasswort = new System.Windows.Forms.Label();
            this.checkBoxPasswortSpeichern = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // maskedTextBox
            // 
            this.maskedTextBox.Location = new System.Drawing.Point(15, 25);
            this.maskedTextBox.Name = "maskedTextBox";
            this.maskedTextBox.PasswordChar = '●';
            this.maskedTextBox.Size = new System.Drawing.Size(213, 20);
            this.maskedTextBox.TabIndex = 1;
            // 
            // buttonLogin
            // 
            this.buttonLogin.Location = new System.Drawing.Point(150, 51);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(78, 25);
            this.buttonLogin.TabIndex = 2;
            this.buttonLogin.Text = "OK";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // labelPasswort
            // 
            this.labelPasswort.AutoSize = true;
            this.labelPasswort.Location = new System.Drawing.Point(12, 9);
            this.labelPasswort.Name = "labelPasswort";
            this.labelPasswort.Size = new System.Drawing.Size(53, 13);
            this.labelPasswort.TabIndex = 3;
            this.labelPasswort.Text = "Passwort:";
            // 
            // checkBoxPasswortSpeichern
            // 
            this.checkBoxPasswortSpeichern.AutoSize = true;
            this.checkBoxPasswortSpeichern.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxPasswortSpeichern.Location = new System.Drawing.Point(15, 56);
            this.checkBoxPasswortSpeichern.Name = "checkBoxPasswortSpeichern";
            this.checkBoxPasswortSpeichern.Size = new System.Drawing.Size(136, 17);
            this.checkBoxPasswortSpeichern.TabIndex = 4;
            this.checkBoxPasswortSpeichern.Text = "Passwort speichern";
            this.checkBoxPasswortSpeichern.UseVisualStyleBackColor = true;
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 83);
            this.Controls.Add(this.checkBoxPasswortSpeichern);
            this.Controls.Add(this.labelPasswort);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.maskedTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox maskedTextBox;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Label labelPasswort;
        private System.Windows.Forms.CheckBox checkBoxPasswortSpeichern;
    }
}

namespace SuperheroMemoryGame_1_
{
    partial class mainMenu
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
            this.buttonMediumLevel = new System.Windows.Forms.Button();
            this.buttonHardLevel = new System.Windows.Forms.Button();
            this.buttonEasyLevel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonMediumLevel
            // 
            this.buttonMediumLevel.Location = new System.Drawing.Point(352, 156);
            this.buttonMediumLevel.Name = "buttonMediumLevel";
            this.buttonMediumLevel.Size = new System.Drawing.Size(96, 34);
            this.buttonMediumLevel.TabIndex = 1;
            this.buttonMediumLevel.Text = "Medium";
            this.buttonMediumLevel.UseVisualStyleBackColor = true;
            this.buttonMediumLevel.Click += new System.EventHandler(this.buttonMediumLevel_Click);
            // 
            // buttonHardLevel
            // 
            this.buttonHardLevel.Location = new System.Drawing.Point(352, 208);
            this.buttonHardLevel.Name = "buttonHardLevel";
            this.buttonHardLevel.Size = new System.Drawing.Size(96, 34);
            this.buttonHardLevel.TabIndex = 2;
            this.buttonHardLevel.Text = "Hard";
            this.buttonHardLevel.UseVisualStyleBackColor = true;
            this.buttonHardLevel.Click += new System.EventHandler(this.buttonHardLevel_Click);
            // 
            // buttonEasyLevel
            // 
            this.buttonEasyLevel.Location = new System.Drawing.Point(352, 102);
            this.buttonEasyLevel.Name = "buttonEasyLevel";
            this.buttonEasyLevel.Size = new System.Drawing.Size(96, 34);
            this.buttonEasyLevel.TabIndex = 0;
            this.buttonEasyLevel.Text = "Easy";
            this.buttonEasyLevel.UseVisualStyleBackColor = true;
            this.buttonEasyLevel.Click += new System.EventHandler(this.buttonEasyLevel_Click);
            // 
            // mainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonEasyLevel);
            this.Controls.Add(this.buttonHardLevel);
            this.Controls.Add(this.buttonMediumLevel);
            this.Name = "mainMenu";
            this.Text = "Main Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonMediumLevel;
        private System.Windows.Forms.Button buttonHardLevel;
        private System.Windows.Forms.Button buttonEasyLevel;
    }
}
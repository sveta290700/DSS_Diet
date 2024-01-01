
namespace DietProject
{
    partial class DietResult
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DietResult));
            this.LabelText = new System.Windows.Forms.Label();
            this.DRPrintButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LabelText
            // 
            resources.ApplyResources(this.LabelText, "LabelText");
            this.LabelText.Name = "LabelText";
            // 
            // DRPrintButton
            // 
            resources.ApplyResources(this.DRPrintButton, "DRPrintButton");
            this.DRPrintButton.BackColor = System.Drawing.Color.PaleGreen;
            this.DRPrintButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.DRPrintButton.Name = "DRPrintButton";
            this.DRPrintButton.TabStop = false;
            this.DRPrintButton.UseVisualStyleBackColor = false;
            this.DRPrintButton.Click += new System.EventHandler(this.DRPrintButton_Click);
            // 
            // DietResult
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.DRPrintButton);
            this.Controls.Add(this.LabelText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DietResult";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label LabelText;
        private System.Windows.Forms.Button DRPrintButton;
    }
}
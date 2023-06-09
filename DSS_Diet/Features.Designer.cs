
namespace DietProject
{
    partial class Features
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Features));
            this.FeatureTextBox = new DietProject.WaterMarkTextBox();
            this.FDeleteButton = new System.Windows.Forms.Button();
            this.FAddButton = new System.Windows.Forms.Button();
            this.FeaturesLabel = new System.Windows.Forms.Label();
            this.FFeaturesListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // FeatureTextBox
            // 
            resources.ApplyResources(this.FeatureTextBox, "FeatureTextBox");
            this.FeatureTextBox.Name = "FeatureTextBox";
            this.FeatureTextBox.TabStop = false;
            this.FeatureTextBox.WaterMarkColor = System.Drawing.Color.Gray;
            this.FeatureTextBox.WaterMarkText = "Введите признак продукта";
            // 
            // FDeleteButton
            // 
            resources.ApplyResources(this.FDeleteButton, "FDeleteButton");
            this.FDeleteButton.BackColor = System.Drawing.Color.PaleGreen;
            this.FDeleteButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.FDeleteButton.Name = "FDeleteButton";
            this.FDeleteButton.TabStop = false;
            this.FDeleteButton.UseVisualStyleBackColor = false;
            this.FDeleteButton.Click += new System.EventHandler(this.FDeleteButton_Click);
            // 
            // FAddButton
            // 
            resources.ApplyResources(this.FAddButton, "FAddButton");
            this.FAddButton.BackColor = System.Drawing.Color.PaleGreen;
            this.FAddButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.FAddButton.Name = "FAddButton";
            this.FAddButton.TabStop = false;
            this.FAddButton.UseVisualStyleBackColor = false;
            this.FAddButton.Click += new System.EventHandler(this.FAddButton_Click);
            // 
            // FeaturesLabel
            // 
            resources.ApplyResources(this.FeaturesLabel, "FeaturesLabel");
            this.FeaturesLabel.BackColor = System.Drawing.Color.LightGreen;
            this.FeaturesLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FeaturesLabel.Name = "FeaturesLabel";
            // 
            // FFeaturesListBox
            // 
            resources.ApplyResources(this.FFeaturesListBox, "FFeaturesListBox");
            this.FFeaturesListBox.FormattingEnabled = true;
            this.FFeaturesListBox.Name = "FFeaturesListBox";
            this.FFeaturesListBox.TabStop = false;
            // 
            // Features
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.FeatureTextBox);
            this.Controls.Add(this.FDeleteButton);
            this.Controls.Add(this.FAddButton);
            this.Controls.Add(this.FeaturesLabel);
            this.Controls.Add(this.FFeaturesListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Features";
            this.Load += new System.EventHandler(this.Features_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WaterMarkTextBox FeatureTextBox;
        private System.Windows.Forms.Button FDeleteButton;
        private System.Windows.Forms.Button FAddButton;
        private System.Windows.Forms.Label FeaturesLabel;
        private System.Windows.Forms.ListBox FFeaturesListBox;
    }
}
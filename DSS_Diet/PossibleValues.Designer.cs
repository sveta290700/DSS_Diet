
namespace DietProject
{
    partial class PossibleValues
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PossibleValues));
            this.PVSaveButton = new System.Windows.Forms.Button();
            this.PVFeaturesLabel = new System.Windows.Forms.Label();
            this.PVFeaturesListBox = new System.Windows.Forms.ListBox();
            this.PVValuesLabel = new System.Windows.Forms.Label();
            this.PVFromLabel = new System.Windows.Forms.Label();
            this.PVToLabel = new System.Windows.Forms.Label();
            this.PVFromCheckbox = new System.Windows.Forms.CheckBox();
            this.PVToCheckbox = new System.Windows.Forms.CheckBox();
            this.PVFromNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.PVToNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.PVBorderPanel = new System.Windows.Forms.Panel();
            this.PVSizeToLabel = new System.Windows.Forms.Label();
            this.PVSizeFromLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PVFromNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PVToNumericUpDown)).BeginInit();
            this.PVBorderPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // PVSaveButton
            // 
            resources.ApplyResources(this.PVSaveButton, "PVSaveButton");
            this.PVSaveButton.BackColor = System.Drawing.Color.PaleGreen;
            this.PVSaveButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.PVSaveButton.Name = "PVSaveButton";
            this.PVSaveButton.TabStop = false;
            this.PVSaveButton.UseVisualStyleBackColor = false;
            this.PVSaveButton.Click += new System.EventHandler(this.PVSaveButton_Click);
            // 
            // PVFeaturesLabel
            // 
            resources.ApplyResources(this.PVFeaturesLabel, "PVFeaturesLabel");
            this.PVFeaturesLabel.BackColor = System.Drawing.Color.LightGreen;
            this.PVFeaturesLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PVFeaturesLabel.Name = "PVFeaturesLabel";
            // 
            // PVFeaturesListBox
            // 
            resources.ApplyResources(this.PVFeaturesListBox, "PVFeaturesListBox");
            this.PVFeaturesListBox.FormattingEnabled = true;
            this.PVFeaturesListBox.Name = "PVFeaturesListBox";
            this.PVFeaturesListBox.TabStop = false;
            this.PVFeaturesListBox.SelectedIndexChanged += new System.EventHandler(this.PVFeaturesListBox_SelectedIndexChanged);
            // 
            // PVValuesLabel
            // 
            resources.ApplyResources(this.PVValuesLabel, "PVValuesLabel");
            this.PVValuesLabel.BackColor = System.Drawing.Color.LightGreen;
            this.PVValuesLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PVValuesLabel.Name = "PVValuesLabel";
            // 
            // PVFromLabel
            // 
            resources.ApplyResources(this.PVFromLabel, "PVFromLabel");
            this.PVFromLabel.Name = "PVFromLabel";
            // 
            // PVToLabel
            // 
            resources.ApplyResources(this.PVToLabel, "PVToLabel");
            this.PVToLabel.Name = "PVToLabel";
            // 
            // PVFromCheckbox
            // 
            resources.ApplyResources(this.PVFromCheckbox, "PVFromCheckbox");
            this.PVFromCheckbox.Checked = true;
            this.PVFromCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.PVFromCheckbox.Name = "PVFromCheckbox";
            this.PVFromCheckbox.TabStop = false;
            this.PVFromCheckbox.UseVisualStyleBackColor = true;
            // 
            // PVToCheckbox
            // 
            resources.ApplyResources(this.PVToCheckbox, "PVToCheckbox");
            this.PVToCheckbox.Checked = true;
            this.PVToCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.PVToCheckbox.Name = "PVToCheckbox";
            this.PVToCheckbox.TabStop = false;
            this.PVToCheckbox.UseVisualStyleBackColor = true;
            // 
            // PVFromNumericUpDown
            // 
            resources.ApplyResources(this.PVFromNumericUpDown, "PVFromNumericUpDown");
            this.PVFromNumericUpDown.DecimalPlaces = 5;
            this.PVFromNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            327680});
            this.PVFromNumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.PVFromNumericUpDown.Name = "PVFromNumericUpDown";
            this.PVFromNumericUpDown.TabStop = false;
            // 
            // PVToNumericUpDown
            // 
            resources.ApplyResources(this.PVToNumericUpDown, "PVToNumericUpDown");
            this.PVToNumericUpDown.DecimalPlaces = 5;
            this.PVToNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            327680});
            this.PVToNumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.PVToNumericUpDown.Name = "PVToNumericUpDown";
            this.PVToNumericUpDown.TabStop = false;
            // 
            // PVBorderPanel
            // 
            resources.ApplyResources(this.PVBorderPanel, "PVBorderPanel");
            this.PVBorderPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PVBorderPanel.Controls.Add(this.PVSizeToLabel);
            this.PVBorderPanel.Controls.Add(this.PVSizeFromLabel);
            this.PVBorderPanel.Controls.Add(this.PVToNumericUpDown);
            this.PVBorderPanel.Controls.Add(this.PVToLabel);
            this.PVBorderPanel.Controls.Add(this.PVFromNumericUpDown);
            this.PVBorderPanel.Controls.Add(this.PVFromCheckbox);
            this.PVBorderPanel.Controls.Add(this.PVFromLabel);
            this.PVBorderPanel.Controls.Add(this.PVToCheckbox);
            this.PVBorderPanel.Name = "PVBorderPanel";
            // 
            // PVSizeToLabel
            // 
            resources.ApplyResources(this.PVSizeToLabel, "PVSizeToLabel");
            this.PVSizeToLabel.Name = "PVSizeToLabel";
            // 
            // PVSizeFromLabel
            // 
            resources.ApplyResources(this.PVSizeFromLabel, "PVSizeFromLabel");
            this.PVSizeFromLabel.Name = "PVSizeFromLabel";
            // 
            // PossibleValues
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.PVValuesLabel);
            this.Controls.Add(this.PVSaveButton);
            this.Controls.Add(this.PVFeaturesLabel);
            this.Controls.Add(this.PVFeaturesListBox);
            this.Controls.Add(this.PVBorderPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PossibleValues";
            this.Load += new System.EventHandler(this.PossibleValues_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PVFromNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PVToNumericUpDown)).EndInit();
            this.PVBorderPanel.ResumeLayout(false);
            this.PVBorderPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button PVSaveButton;
        private System.Windows.Forms.Label PVFeaturesLabel;
        private System.Windows.Forms.ListBox PVFeaturesListBox;
        private System.Windows.Forms.Label PVValuesLabel;
        private System.Windows.Forms.Label PVFromLabel;
        private System.Windows.Forms.Label PVToLabel;
        private System.Windows.Forms.CheckBox PVFromCheckbox;
        private System.Windows.Forms.CheckBox PVToCheckbox;
        private System.Windows.Forms.NumericUpDown PVFromNumericUpDown;
        private System.Windows.Forms.NumericUpDown PVToNumericUpDown;
        private System.Windows.Forms.Panel PVBorderPanel;
        private System.Windows.Forms.Label PVSizeToLabel;
        private System.Windows.Forms.Label PVSizeFromLabel;
    }
}
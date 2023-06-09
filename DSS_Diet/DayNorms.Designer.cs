
namespace DietProject
{
    partial class DayNorms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DayNorms));
            this.DNNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.DNSubstanceComboBox = new System.Windows.Forms.ComboBox();
            this.DNAddButton = new System.Windows.Forms.Button();
            this.DNSubstanceChoiceLabel = new System.Windows.Forms.Label();
            this.DNSizeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DNNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // DNNumericUpDown
            // 
            resources.ApplyResources(this.DNNumericUpDown, "DNNumericUpDown");
            this.DNNumericUpDown.DecimalPlaces = 7;
            this.DNNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            458752});
            this.DNNumericUpDown.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.DNNumericUpDown.Name = "DNNumericUpDown";
            this.DNNumericUpDown.TabStop = false;
            // 
            // DNSubstanceComboBox
            // 
            resources.ApplyResources(this.DNSubstanceComboBox, "DNSubstanceComboBox");
            this.DNSubstanceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DNSubstanceComboBox.FormattingEnabled = true;
            this.DNSubstanceComboBox.Name = "DNSubstanceComboBox";
            this.DNSubstanceComboBox.TabStop = false;
            this.DNSubstanceComboBox.SelectedIndexChanged += new System.EventHandler(this.DNSubstanceComboBox_SelectedIndexChanged);
            // 
            // DNAddButton
            // 
            resources.ApplyResources(this.DNAddButton, "DNAddButton");
            this.DNAddButton.BackColor = System.Drawing.Color.PaleGreen;
            this.DNAddButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.DNAddButton.Name = "DNAddButton";
            this.DNAddButton.TabStop = false;
            this.DNAddButton.UseVisualStyleBackColor = false;
            this.DNAddButton.Click += new System.EventHandler(this.DNAddButton_Click);
            // 
            // DNSubstanceChoiceLabel
            // 
            resources.ApplyResources(this.DNSubstanceChoiceLabel, "DNSubstanceChoiceLabel");
            this.DNSubstanceChoiceLabel.Name = "DNSubstanceChoiceLabel";
            // 
            // DNSizeLabel
            // 
            resources.ApplyResources(this.DNSizeLabel, "DNSizeLabel");
            this.DNSizeLabel.Name = "DNSizeLabel";
            // 
            // DayNorms
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.DNSizeLabel);
            this.Controls.Add(this.DNNumericUpDown);
            this.Controls.Add(this.DNSubstanceComboBox);
            this.Controls.Add(this.DNAddButton);
            this.Controls.Add(this.DNSubstanceChoiceLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DayNorms";
            ((System.ComponentModel.ISupportInitialize)(this.DNNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown DNNumericUpDown;
        private System.Windows.Forms.ComboBox DNSubstanceComboBox;
        private System.Windows.Forms.Button DNAddButton;
        private System.Windows.Forms.Label DNSubstanceChoiceLabel;
        private System.Windows.Forms.Label DNSizeLabel;
    }
}
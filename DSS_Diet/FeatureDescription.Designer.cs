
namespace DietProject
{
    partial class FeatureDescription
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FeatureDescription));
            this.FDUnselectButton = new System.Windows.Forms.Button();
            this.FDSelectButton = new System.Windows.Forms.Button();
            this.FDProductsComboBox = new System.Windows.Forms.ComboBox();
            this.FDSaveButton = new System.Windows.Forms.Button();
            this.FDChoiceLabel = new System.Windows.Forms.Label();
            this.SelectedFeaturesLabel = new System.Windows.Forms.Label();
            this.FDSelectedFeaturesListBox = new System.Windows.Forms.ListBox();
            this.FDFeaturesLabel = new System.Windows.Forms.Label();
            this.FDFeaturesListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // FDUnselectButton
            // 
            resources.ApplyResources(this.FDUnselectButton, "FDUnselectButton");
            this.FDUnselectButton.BackColor = System.Drawing.SystemColors.Window;
            this.FDUnselectButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.FDUnselectButton.Name = "FDUnselectButton";
            this.FDUnselectButton.TabStop = false;
            this.FDUnselectButton.UseVisualStyleBackColor = false;
            this.FDUnselectButton.Click += new System.EventHandler(this.FDUnselectButton_Click);
            // 
            // FDSelectButton
            // 
            resources.ApplyResources(this.FDSelectButton, "FDSelectButton");
            this.FDSelectButton.BackColor = System.Drawing.SystemColors.Window;
            this.FDSelectButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.FDSelectButton.Name = "FDSelectButton";
            this.FDSelectButton.TabStop = false;
            this.FDSelectButton.UseVisualStyleBackColor = false;
            this.FDSelectButton.Click += new System.EventHandler(this.FDSelectButton_Click);
            // 
            // FDProductsComboBox
            // 
            resources.ApplyResources(this.FDProductsComboBox, "FDProductsComboBox");
            this.FDProductsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FDProductsComboBox.FormattingEnabled = true;
            this.FDProductsComboBox.Name = "FDProductsComboBox";
            this.FDProductsComboBox.TabStop = false;
            this.FDProductsComboBox.SelectedIndexChanged += new System.EventHandler(this.FDProductsComboBox_SelectedIndexChanged);
            // 
            // FDSaveButton
            // 
            resources.ApplyResources(this.FDSaveButton, "FDSaveButton");
            this.FDSaveButton.BackColor = System.Drawing.Color.PaleGreen;
            this.FDSaveButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.FDSaveButton.Name = "FDSaveButton";
            this.FDSaveButton.TabStop = false;
            this.FDSaveButton.UseVisualStyleBackColor = false;
            this.FDSaveButton.Click += new System.EventHandler(this.FDSaveButton_Click);
            // 
            // FDChoiceLabel
            // 
            resources.ApplyResources(this.FDChoiceLabel, "FDChoiceLabel");
            this.FDChoiceLabel.Name = "FDChoiceLabel";
            // 
            // SelectedFeaturesLabel
            // 
            resources.ApplyResources(this.SelectedFeaturesLabel, "SelectedFeaturesLabel");
            this.SelectedFeaturesLabel.BackColor = System.Drawing.Color.LightGreen;
            this.SelectedFeaturesLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SelectedFeaturesLabel.Name = "SelectedFeaturesLabel";
            // 
            // FDSelectedFeaturesListBox
            // 
            resources.ApplyResources(this.FDSelectedFeaturesListBox, "FDSelectedFeaturesListBox");
            this.FDSelectedFeaturesListBox.FormattingEnabled = true;
            this.FDSelectedFeaturesListBox.Name = "FDSelectedFeaturesListBox";
            this.FDSelectedFeaturesListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.FDSelectedFeaturesListBox.TabStop = false;
            // 
            // FDFeaturesLabel
            // 
            resources.ApplyResources(this.FDFeaturesLabel, "FDFeaturesLabel");
            this.FDFeaturesLabel.BackColor = System.Drawing.Color.LightGreen;
            this.FDFeaturesLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FDFeaturesLabel.Name = "FDFeaturesLabel";
            // 
            // FDFeaturesListBox
            // 
            resources.ApplyResources(this.FDFeaturesListBox, "FDFeaturesListBox");
            this.FDFeaturesListBox.FormattingEnabled = true;
            this.FDFeaturesListBox.Name = "FDFeaturesListBox";
            this.FDFeaturesListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.FDFeaturesListBox.TabStop = false;
            // 
            // FeatureDescription
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.FDUnselectButton);
            this.Controls.Add(this.FDSelectButton);
            this.Controls.Add(this.FDProductsComboBox);
            this.Controls.Add(this.FDSaveButton);
            this.Controls.Add(this.FDChoiceLabel);
            this.Controls.Add(this.SelectedFeaturesLabel);
            this.Controls.Add(this.FDSelectedFeaturesListBox);
            this.Controls.Add(this.FDFeaturesLabel);
            this.Controls.Add(this.FDFeaturesListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FeatureDescription";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button FDUnselectButton;
        private System.Windows.Forms.Button FDSelectButton;
        private System.Windows.Forms.ComboBox FDProductsComboBox;
        private System.Windows.Forms.Button FDSaveButton;
        private System.Windows.Forms.Label FDChoiceLabel;
        private System.Windows.Forms.Label SelectedFeaturesLabel;
        private System.Windows.Forms.ListBox FDSelectedFeaturesListBox;
        private System.Windows.Forms.Label FDFeaturesLabel;
        private System.Windows.Forms.ListBox FDFeaturesListBox;
    }
}
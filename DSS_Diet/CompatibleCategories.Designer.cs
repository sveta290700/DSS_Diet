
namespace DietProject
{
    partial class CompatibleCategories
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompatibleCategories));
            this.CCUnselectButton = new System.Windows.Forms.Button();
            this.CCSelectButton = new System.Windows.Forms.Button();
            this.CCCategoriesComboBox = new System.Windows.Forms.ComboBox();
            this.CCSaveButton = new System.Windows.Forms.Button();
            this.CCChoiceLabel = new System.Windows.Forms.Label();
            this.CompatibleCategoriesLabel = new System.Windows.Forms.Label();
            this.CCCompatibleCategoriesListBox = new System.Windows.Forms.ListBox();
            this.CCCategoriesLabel = new System.Windows.Forms.Label();
            this.CCCategoriesListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // CCUnselectButton
            // 
            resources.ApplyResources(this.CCUnselectButton, "CCUnselectButton");
            this.CCUnselectButton.BackColor = System.Drawing.SystemColors.Window;
            this.CCUnselectButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.CCUnselectButton.Name = "CCUnselectButton";
            this.CCUnselectButton.TabStop = false;
            this.CCUnselectButton.UseVisualStyleBackColor = false;
            this.CCUnselectButton.Click += new System.EventHandler(this.CCUnselectButton_Click);
            // 
            // CCSelectButton
            // 
            resources.ApplyResources(this.CCSelectButton, "CCSelectButton");
            this.CCSelectButton.BackColor = System.Drawing.SystemColors.Window;
            this.CCSelectButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.CCSelectButton.Name = "CCSelectButton";
            this.CCSelectButton.TabStop = false;
            this.CCSelectButton.UseVisualStyleBackColor = false;
            this.CCSelectButton.Click += new System.EventHandler(this.CCSelectButton_Click);
            // 
            // CCCategoriesComboBox
            // 
            resources.ApplyResources(this.CCCategoriesComboBox, "CCCategoriesComboBox");
            this.CCCategoriesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CCCategoriesComboBox.FormattingEnabled = true;
            this.CCCategoriesComboBox.Name = "CCCategoriesComboBox";
            this.CCCategoriesComboBox.TabStop = false;
            this.CCCategoriesComboBox.SelectedIndexChanged += new System.EventHandler(this.CCCategoriesComboBox_SelectedIndexChanged);
            // 
            // CCSaveButton
            // 
            resources.ApplyResources(this.CCSaveButton, "CCSaveButton");
            this.CCSaveButton.BackColor = System.Drawing.Color.PaleGreen;
            this.CCSaveButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.CCSaveButton.Name = "CCSaveButton";
            this.CCSaveButton.TabStop = false;
            this.CCSaveButton.UseVisualStyleBackColor = false;
            this.CCSaveButton.Click += new System.EventHandler(this.CCSaveButton_Click);
            // 
            // CCChoiceLabel
            // 
            resources.ApplyResources(this.CCChoiceLabel, "CCChoiceLabel");
            this.CCChoiceLabel.Name = "CCChoiceLabel";
            // 
            // CompatibleCategoriesLabel
            // 
            resources.ApplyResources(this.CompatibleCategoriesLabel, "CompatibleCategoriesLabel");
            this.CompatibleCategoriesLabel.BackColor = System.Drawing.Color.LightGreen;
            this.CompatibleCategoriesLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CompatibleCategoriesLabel.Name = "CompatibleCategoriesLabel";
            // 
            // CCCompatibleCategoriesListBox
            // 
            resources.ApplyResources(this.CCCompatibleCategoriesListBox, "CCCompatibleCategoriesListBox");
            this.CCCompatibleCategoriesListBox.FormattingEnabled = true;
            this.CCCompatibleCategoriesListBox.Name = "CCCompatibleCategoriesListBox";
            this.CCCompatibleCategoriesListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.CCCompatibleCategoriesListBox.TabStop = false;
            // 
            // CCCategoriesLabel
            // 
            resources.ApplyResources(this.CCCategoriesLabel, "CCCategoriesLabel");
            this.CCCategoriesLabel.BackColor = System.Drawing.Color.LightGreen;
            this.CCCategoriesLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CCCategoriesLabel.Name = "CCCategoriesLabel";
            // 
            // CCCategoriesListBox
            // 
            resources.ApplyResources(this.CCCategoriesListBox, "CCCategoriesListBox");
            this.CCCategoriesListBox.FormattingEnabled = true;
            this.CCCategoriesListBox.Name = "CCCategoriesListBox";
            this.CCCategoriesListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.CCCategoriesListBox.TabStop = false;
            // 
            // CompatibleCategories
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.CCUnselectButton);
            this.Controls.Add(this.CCSelectButton);
            this.Controls.Add(this.CCCategoriesComboBox);
            this.Controls.Add(this.CCSaveButton);
            this.Controls.Add(this.CCChoiceLabel);
            this.Controls.Add(this.CompatibleCategoriesLabel);
            this.Controls.Add(this.CCCompatibleCategoriesListBox);
            this.Controls.Add(this.CCCategoriesLabel);
            this.Controls.Add(this.CCCategoriesListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CompatibleCategories";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CCUnselectButton;
        private System.Windows.Forms.Button CCSelectButton;
        private System.Windows.Forms.ComboBox CCCategoriesComboBox;
        private System.Windows.Forms.Button CCSaveButton;
        private System.Windows.Forms.Label CCChoiceLabel;
        private System.Windows.Forms.Label CompatibleCategoriesLabel;
        private System.Windows.Forms.ListBox CCCompatibleCategoriesListBox;
        private System.Windows.Forms.Label CCCategoriesLabel;
        private System.Windows.Forms.ListBox CCCategoriesListBox;
    }
}
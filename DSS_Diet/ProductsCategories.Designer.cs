
namespace DietProject
{
    partial class ProductsCategories
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductsCategories));
            this.PCProductsNamesLabel = new System.Windows.Forms.Label();
            this.PCProductsNamesListBox = new System.Windows.Forms.ListBox();
            this.ProductsCategoryLabel = new System.Windows.Forms.Label();
            this.PCProductsCategoryListBox = new System.Windows.Forms.ListBox();
            this.PCSaveButton = new System.Windows.Forms.Button();
            this.PCChoiceLabel = new System.Windows.Forms.Label();
            this.PCCategoriesComboBox = new System.Windows.Forms.ComboBox();
            this.PCSelectButton = new System.Windows.Forms.Button();
            this.PCUnselectButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PCProductsNamesLabel
            // 
            resources.ApplyResources(this.PCProductsNamesLabel, "PCProductsNamesLabel");
            this.PCProductsNamesLabel.BackColor = System.Drawing.Color.LightGreen;
            this.PCProductsNamesLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PCProductsNamesLabel.Name = "PCProductsNamesLabel";
            // 
            // PCProductsNamesListBox
            // 
            resources.ApplyResources(this.PCProductsNamesListBox, "PCProductsNamesListBox");
            this.PCProductsNamesListBox.FormattingEnabled = true;
            this.PCProductsNamesListBox.Name = "PCProductsNamesListBox";
            this.PCProductsNamesListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.PCProductsNamesListBox.TabStop = false;
            // 
            // ProductsCategoryLabel
            // 
            resources.ApplyResources(this.ProductsCategoryLabel, "ProductsCategoryLabel");
            this.ProductsCategoryLabel.BackColor = System.Drawing.Color.LightGreen;
            this.ProductsCategoryLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ProductsCategoryLabel.Name = "ProductsCategoryLabel";
            // 
            // PCProductsCategoryListBox
            // 
            resources.ApplyResources(this.PCProductsCategoryListBox, "PCProductsCategoryListBox");
            this.PCProductsCategoryListBox.FormattingEnabled = true;
            this.PCProductsCategoryListBox.Name = "PCProductsCategoryListBox";
            this.PCProductsCategoryListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.PCProductsCategoryListBox.TabStop = false;
            // 
            // PCSaveButton
            // 
            resources.ApplyResources(this.PCSaveButton, "PCSaveButton");
            this.PCSaveButton.BackColor = System.Drawing.Color.PaleGreen;
            this.PCSaveButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.PCSaveButton.Name = "PCSaveButton";
            this.PCSaveButton.TabStop = false;
            this.PCSaveButton.UseVisualStyleBackColor = false;
            this.PCSaveButton.Click += new System.EventHandler(this.PCSaveButton_Click);
            // 
            // PCChoiceLabel
            // 
            resources.ApplyResources(this.PCChoiceLabel, "PCChoiceLabel");
            this.PCChoiceLabel.Name = "PCChoiceLabel";
            // 
            // PCCategoriesComboBox
            // 
            resources.ApplyResources(this.PCCategoriesComboBox, "PCCategoriesComboBox");
            this.PCCategoriesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PCCategoriesComboBox.FormattingEnabled = true;
            this.PCCategoriesComboBox.Name = "PCCategoriesComboBox";
            this.PCCategoriesComboBox.TabStop = false;
            this.PCCategoriesComboBox.SelectedIndexChanged += new System.EventHandler(this.PCCategoriesComboBox_SelectedIndexChanged);
            // 
            // PCSelectButton
            // 
            resources.ApplyResources(this.PCSelectButton, "PCSelectButton");
            this.PCSelectButton.BackColor = System.Drawing.SystemColors.Window;
            this.PCSelectButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.PCSelectButton.Name = "PCSelectButton";
            this.PCSelectButton.TabStop = false;
            this.PCSelectButton.UseVisualStyleBackColor = false;
            this.PCSelectButton.Click += new System.EventHandler(this.PCSelectButton_Click);
            // 
            // PCUnselectButton
            // 
            resources.ApplyResources(this.PCUnselectButton, "PCUnselectButton");
            this.PCUnselectButton.BackColor = System.Drawing.SystemColors.Window;
            this.PCUnselectButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.PCUnselectButton.Name = "PCUnselectButton";
            this.PCUnselectButton.TabStop = false;
            this.PCUnselectButton.UseVisualStyleBackColor = false;
            this.PCUnselectButton.Click += new System.EventHandler(this.PCUnselectButton_Click);
            // 
            // ProductsCategories
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.PCUnselectButton);
            this.Controls.Add(this.PCSelectButton);
            this.Controls.Add(this.PCCategoriesComboBox);
            this.Controls.Add(this.PCSaveButton);
            this.Controls.Add(this.PCChoiceLabel);
            this.Controls.Add(this.ProductsCategoryLabel);
            this.Controls.Add(this.PCProductsCategoryListBox);
            this.Controls.Add(this.PCProductsNamesLabel);
            this.Controls.Add(this.PCProductsNamesListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProductsCategories";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label PCProductsNamesLabel;
        private System.Windows.Forms.ListBox PCProductsNamesListBox;
        private System.Windows.Forms.Label ProductsCategoryLabel;
        private System.Windows.Forms.ListBox PCProductsCategoryListBox;
        private System.Windows.Forms.Button PCSaveButton;
        private System.Windows.Forms.Label PCChoiceLabel;
        private System.Windows.Forms.ComboBox PCCategoriesComboBox;
        private System.Windows.Forms.Button PCSelectButton;
        private System.Windows.Forms.Button PCUnselectButton;
    }
}
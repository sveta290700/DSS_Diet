
namespace DietProject
{
    partial class Categories
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Categories));
            this.CategoryTextBox = new DietProject.WaterMarkTextBox();
            this.CDeleteButton = new System.Windows.Forms.Button();
            this.CAddButton = new System.Windows.Forms.Button();
            this.CategoriesLabel = new System.Windows.Forms.Label();
            this.CCategoriesListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // CategoryTextBox
            // 
            resources.ApplyResources(this.CategoryTextBox, "CategoryTextBox");
            this.CategoryTextBox.Name = "CategoryTextBox";
            this.CategoryTextBox.TabStop = false;
            this.CategoryTextBox.WaterMarkColor = System.Drawing.Color.Gray;
            this.CategoryTextBox.WaterMarkText = "Введите название категории";
            // 
            // CDeleteButton
            // 
            resources.ApplyResources(this.CDeleteButton, "CDeleteButton");
            this.CDeleteButton.BackColor = System.Drawing.Color.PaleGreen;
            this.CDeleteButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.CDeleteButton.Name = "CDeleteButton";
            this.CDeleteButton.TabStop = false;
            this.CDeleteButton.UseVisualStyleBackColor = false;
            this.CDeleteButton.Click += new System.EventHandler(this.CDeleteButton_Click);
            // 
            // CAddButton
            // 
            resources.ApplyResources(this.CAddButton, "CAddButton");
            this.CAddButton.BackColor = System.Drawing.Color.PaleGreen;
            this.CAddButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.CAddButton.Name = "CAddButton";
            this.CAddButton.TabStop = false;
            this.CAddButton.UseVisualStyleBackColor = false;
            this.CAddButton.Click += new System.EventHandler(this.CAddButton_Click);
            // 
            // CategoriesLabel
            // 
            resources.ApplyResources(this.CategoriesLabel, "CategoriesLabel");
            this.CategoriesLabel.BackColor = System.Drawing.Color.LightGreen;
            this.CategoriesLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CategoriesLabel.Name = "CategoriesLabel";
            // 
            // CCategoriesListBox
            // 
            resources.ApplyResources(this.CCategoriesListBox, "CCategoriesListBox");
            this.CCategoriesListBox.FormattingEnabled = true;
            this.CCategoriesListBox.Name = "CCategoriesListBox";
            this.CCategoriesListBox.TabStop = false;
            // 
            // Categories
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.CategoryTextBox);
            this.Controls.Add(this.CDeleteButton);
            this.Controls.Add(this.CAddButton);
            this.Controls.Add(this.CategoriesLabel);
            this.Controls.Add(this.CCategoriesListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Categories";
            this.Load += new System.EventHandler(this.Categories_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WaterMarkTextBox CategoryTextBox;
        private System.Windows.Forms.Button CDeleteButton;
        private System.Windows.Forms.Button CAddButton;
        private System.Windows.Forms.Label CategoriesLabel;
        private System.Windows.Forms.ListBox CCategoriesListBox;
    }
}
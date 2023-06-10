
namespace DietProject
{
    partial class Products
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Products));
            this.ProductsLabel = new System.Windows.Forms.Label();
            this.PProductsListBox = new System.Windows.Forms.ListBox();
            this.PAddButton = new System.Windows.Forms.Button();
            this.PDeleteButton = new System.Windows.Forms.Button();
            this.ProductTextBox = new DietProject.WaterMarkTextBox();
            this.SuspendLayout();
            // 
            // ProductsLabel
            // 
            resources.ApplyResources(this.ProductsLabel, "ProductsLabel");
            this.ProductsLabel.BackColor = System.Drawing.Color.LightGreen;
            this.ProductsLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ProductsLabel.Name = "ProductsLabel";
            // 
            // PProductsListBox
            // 
            resources.ApplyResources(this.PProductsListBox, "PProductsListBox");
            this.PProductsListBox.FormattingEnabled = true;
            this.PProductsListBox.Name = "PProductsListBox";
            this.PProductsListBox.TabStop = false;
            // 
            // PAddButton
            // 
            resources.ApplyResources(this.PAddButton, "PAddButton");
            this.PAddButton.BackColor = System.Drawing.Color.PaleGreen;
            this.PAddButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.PAddButton.Name = "PAddButton";
            this.PAddButton.TabStop = false;
            this.PAddButton.UseVisualStyleBackColor = false;
            this.PAddButton.Click += new System.EventHandler(this.PAddButton_Click);
            // 
            // PDeleteButton
            // 
            resources.ApplyResources(this.PDeleteButton, "PDeleteButton");
            this.PDeleteButton.BackColor = System.Drawing.Color.PaleGreen;
            this.PDeleteButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.PDeleteButton.Name = "PDeleteButton";
            this.PDeleteButton.TabStop = false;
            this.PDeleteButton.UseVisualStyleBackColor = false;
            this.PDeleteButton.Click += new System.EventHandler(this.PDeleteButton_Click);
            // 
            // ProductTextBox
            // 
            resources.ApplyResources(this.ProductTextBox, "ProductTextBox");
            this.ProductTextBox.Name = "ProductTextBox";
            this.ProductTextBox.TabStop = false;
            this.ProductTextBox.WaterMarkColor = System.Drawing.Color.Gray;
            this.ProductTextBox.WaterMarkText = "Введите название продукта";
            // 
            // Products
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.ProductTextBox);
            this.Controls.Add(this.PDeleteButton);
            this.Controls.Add(this.PAddButton);
            this.Controls.Add(this.ProductsLabel);
            this.Controls.Add(this.PProductsListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Products";
            this.Load += new System.EventHandler(this.Products_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ProductsLabel;
        private System.Windows.Forms.ListBox PProductsListBox;
        private System.Windows.Forms.Button PAddButton;
        private System.Windows.Forms.Button PDeleteButton;
        private WaterMarkTextBox ProductTextBox;
    }
}
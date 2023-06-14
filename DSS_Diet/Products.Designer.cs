
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
            this.CEditButton = new System.Windows.Forms.Button();
            this.PSubstanceFeaturesLabel = new System.Windows.Forms.Label();
            this.PProteinsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.PProteinsLabel = new System.Windows.Forms.Label();
            this.PFatsLabel = new System.Windows.Forms.Label();
            this.PFatsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.PCarhydLabel = new System.Windows.Forms.Label();
            this.PCarhydNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.PVitB1Label = new System.Windows.Forms.Label();
            this.PVitB1NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.PVitALabel = new System.Windows.Forms.Label();
            this.PVitANumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.PCellLabel = new System.Windows.Forms.Label();
            this.PCellNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.PVitCLabel = new System.Windows.Forms.Label();
            this.PVitCNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.PCategoriesComboBox = new System.Windows.Forms.ComboBox();
            this.PChoiceLabel = new System.Windows.Forms.Label();
            this.PEnergyLabel = new System.Windows.Forms.Label();
            this.PEnergyNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.PPriceLabel = new System.Windows.Forms.Label();
            this.PPriceNumericUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.PProteinsNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PFatsNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PCarhydNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PVitB1NumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PVitANumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PCellNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PVitCNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PEnergyNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PPriceNumericUpDown)).BeginInit();
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
            this.PProductsListBox.SelectedIndexChanged += new System.EventHandler(this.PProductsListBox_SelectedIndexChanged);
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
            this.ProductTextBox.WaterMarkText = "Название продукта";
            // 
            // CEditButton
            // 
            resources.ApplyResources(this.CEditButton, "CEditButton");
            this.CEditButton.BackColor = System.Drawing.Color.PaleGreen;
            this.CEditButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.CEditButton.Name = "CEditButton";
            this.CEditButton.TabStop = false;
            this.CEditButton.UseVisualStyleBackColor = false;
            this.CEditButton.Click += new System.EventHandler(this.CEditButton_Click);
            // 
            // PSubstanceFeaturesLabel
            // 
            resources.ApplyResources(this.PSubstanceFeaturesLabel, "PSubstanceFeaturesLabel");
            this.PSubstanceFeaturesLabel.Name = "PSubstanceFeaturesLabel";
            // 
            // PProteinsNumericUpDown
            // 
            resources.ApplyResources(this.PProteinsNumericUpDown, "PProteinsNumericUpDown");
            this.PProteinsNumericUpDown.DecimalPlaces = 3;
            this.PProteinsNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.PProteinsNumericUpDown.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.PProteinsNumericUpDown.Name = "PProteinsNumericUpDown";
            this.PProteinsNumericUpDown.TabStop = false;
            // 
            // PProteinsLabel
            // 
            resources.ApplyResources(this.PProteinsLabel, "PProteinsLabel");
            this.PProteinsLabel.Name = "PProteinsLabel";
            // 
            // PFatsLabel
            // 
            resources.ApplyResources(this.PFatsLabel, "PFatsLabel");
            this.PFatsLabel.Name = "PFatsLabel";
            // 
            // PFatsNumericUpDown
            // 
            resources.ApplyResources(this.PFatsNumericUpDown, "PFatsNumericUpDown");
            this.PFatsNumericUpDown.DecimalPlaces = 3;
            this.PFatsNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.PFatsNumericUpDown.Name = "PFatsNumericUpDown";
            this.PFatsNumericUpDown.TabStop = false;
            // 
            // PCarhydLabel
            // 
            resources.ApplyResources(this.PCarhydLabel, "PCarhydLabel");
            this.PCarhydLabel.Name = "PCarhydLabel";
            // 
            // PCarhydNumericUpDown
            // 
            resources.ApplyResources(this.PCarhydNumericUpDown, "PCarhydNumericUpDown");
            this.PCarhydNumericUpDown.DecimalPlaces = 3;
            this.PCarhydNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.PCarhydNumericUpDown.Name = "PCarhydNumericUpDown";
            this.PCarhydNumericUpDown.TabStop = false;
            // 
            // PVitB1Label
            // 
            resources.ApplyResources(this.PVitB1Label, "PVitB1Label");
            this.PVitB1Label.Name = "PVitB1Label";
            // 
            // PVitB1NumericUpDown
            // 
            resources.ApplyResources(this.PVitB1NumericUpDown, "PVitB1NumericUpDown");
            this.PVitB1NumericUpDown.DecimalPlaces = 3;
            this.PVitB1NumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.PVitB1NumericUpDown.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.PVitB1NumericUpDown.Name = "PVitB1NumericUpDown";
            this.PVitB1NumericUpDown.TabStop = false;
            // 
            // PVitALabel
            // 
            resources.ApplyResources(this.PVitALabel, "PVitALabel");
            this.PVitALabel.Name = "PVitALabel";
            // 
            // PVitANumericUpDown
            // 
            resources.ApplyResources(this.PVitANumericUpDown, "PVitANumericUpDown");
            this.PVitANumericUpDown.DecimalPlaces = 3;
            this.PVitANumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.PVitANumericUpDown.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.PVitANumericUpDown.Name = "PVitANumericUpDown";
            this.PVitANumericUpDown.TabStop = false;
            // 
            // PCellLabel
            // 
            resources.ApplyResources(this.PCellLabel, "PCellLabel");
            this.PCellLabel.Name = "PCellLabel";
            // 
            // PCellNumericUpDown
            // 
            resources.ApplyResources(this.PCellNumericUpDown, "PCellNumericUpDown");
            this.PCellNumericUpDown.DecimalPlaces = 3;
            this.PCellNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.PCellNumericUpDown.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.PCellNumericUpDown.Name = "PCellNumericUpDown";
            this.PCellNumericUpDown.TabStop = false;
            // 
            // PVitCLabel
            // 
            resources.ApplyResources(this.PVitCLabel, "PVitCLabel");
            this.PVitCLabel.Name = "PVitCLabel";
            // 
            // PVitCNumericUpDown
            // 
            resources.ApplyResources(this.PVitCNumericUpDown, "PVitCNumericUpDown");
            this.PVitCNumericUpDown.DecimalPlaces = 3;
            this.PVitCNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.PVitCNumericUpDown.Maximum = new decimal(new int[] {
            700,
            0,
            0,
            0});
            this.PVitCNumericUpDown.Name = "PVitCNumericUpDown";
            this.PVitCNumericUpDown.TabStop = false;
            // 
            // PCategoriesComboBox
            // 
            resources.ApplyResources(this.PCategoriesComboBox, "PCategoriesComboBox");
            this.PCategoriesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PCategoriesComboBox.FormattingEnabled = true;
            this.PCategoriesComboBox.Name = "PCategoriesComboBox";
            this.PCategoriesComboBox.TabStop = false;
            // 
            // PChoiceLabel
            // 
            resources.ApplyResources(this.PChoiceLabel, "PChoiceLabel");
            this.PChoiceLabel.Name = "PChoiceLabel";
            // 
            // PEnergyLabel
            // 
            resources.ApplyResources(this.PEnergyLabel, "PEnergyLabel");
            this.PEnergyLabel.Name = "PEnergyLabel";
            // 
            // PEnergyNumericUpDown
            // 
            resources.ApplyResources(this.PEnergyNumericUpDown, "PEnergyNumericUpDown");
            this.PEnergyNumericUpDown.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.PEnergyNumericUpDown.Name = "PEnergyNumericUpDown";
            this.PEnergyNumericUpDown.TabStop = false;
            // 
            // PPriceLabel
            // 
            resources.ApplyResources(this.PPriceLabel, "PPriceLabel");
            this.PPriceLabel.Name = "PPriceLabel";
            // 
            // PPriceNumericUpDown
            // 
            resources.ApplyResources(this.PPriceNumericUpDown, "PPriceNumericUpDown");
            this.PPriceNumericUpDown.DecimalPlaces = 2;
            this.PPriceNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.PPriceNumericUpDown.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.PPriceNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.PPriceNumericUpDown.Name = "PPriceNumericUpDown";
            this.PPriceNumericUpDown.TabStop = false;
            this.PPriceNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // Products
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.PPriceNumericUpDown);
            this.Controls.Add(this.PPriceLabel);
            this.Controls.Add(this.PEnergyLabel);
            this.Controls.Add(this.PEnergyNumericUpDown);
            this.Controls.Add(this.PCategoriesComboBox);
            this.Controls.Add(this.PChoiceLabel);
            this.Controls.Add(this.PCellLabel);
            this.Controls.Add(this.PCellNumericUpDown);
            this.Controls.Add(this.PVitCLabel);
            this.Controls.Add(this.PVitCNumericUpDown);
            this.Controls.Add(this.PVitB1Label);
            this.Controls.Add(this.PVitB1NumericUpDown);
            this.Controls.Add(this.PVitALabel);
            this.Controls.Add(this.PVitANumericUpDown);
            this.Controls.Add(this.PCarhydLabel);
            this.Controls.Add(this.PCarhydNumericUpDown);
            this.Controls.Add(this.PFatsLabel);
            this.Controls.Add(this.PFatsNumericUpDown);
            this.Controls.Add(this.PProteinsLabel);
            this.Controls.Add(this.PProteinsNumericUpDown);
            this.Controls.Add(this.PSubstanceFeaturesLabel);
            this.Controls.Add(this.CEditButton);
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
            ((System.ComponentModel.ISupportInitialize)(this.PProteinsNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PFatsNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PCarhydNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PVitB1NumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PVitANumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PCellNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PVitCNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PEnergyNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PPriceNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ProductsLabel;
        private System.Windows.Forms.ListBox PProductsListBox;
        private System.Windows.Forms.Button PAddButton;
        private System.Windows.Forms.Button PDeleteButton;
        private WaterMarkTextBox ProductTextBox;
        private System.Windows.Forms.Button CEditButton;
        private System.Windows.Forms.Label PSubstanceFeaturesLabel;
        private System.Windows.Forms.NumericUpDown PProteinsNumericUpDown;
        private System.Windows.Forms.Label PProteinsLabel;
        private System.Windows.Forms.Label PFatsLabel;
        private System.Windows.Forms.NumericUpDown PFatsNumericUpDown;
        private System.Windows.Forms.Label PCarhydLabel;
        private System.Windows.Forms.NumericUpDown PCarhydNumericUpDown;
        private System.Windows.Forms.Label PVitB1Label;
        private System.Windows.Forms.NumericUpDown PVitB1NumericUpDown;
        private System.Windows.Forms.Label PVitALabel;
        private System.Windows.Forms.NumericUpDown PVitANumericUpDown;
        private System.Windows.Forms.Label PCellLabel;
        private System.Windows.Forms.NumericUpDown PCellNumericUpDown;
        private System.Windows.Forms.Label PVitCLabel;
        private System.Windows.Forms.NumericUpDown PVitCNumericUpDown;
        private System.Windows.Forms.ComboBox PCategoriesComboBox;
        private System.Windows.Forms.Label PChoiceLabel;
        private System.Windows.Forms.Label PEnergyLabel;
        private System.Windows.Forms.NumericUpDown PEnergyNumericUpDown;
        private System.Windows.Forms.Label PPriceLabel;
        private System.Windows.Forms.NumericUpDown PPriceNumericUpDown;
    }
}
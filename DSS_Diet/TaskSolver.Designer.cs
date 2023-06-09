
namespace DietProject
{
    partial class TaskSolver
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaskSolver));
            this.DTUnselectButton = new System.Windows.Forms.Button();
            this.DTSelectButton = new System.Windows.Forms.Button();
            this.TDSolveButton = new System.Windows.Forms.Button();
            this.DietProductsLabel = new System.Windows.Forms.Label();
            this.DietProductsListBox = new System.Windows.Forms.ListBox();
            this.DTProductsNamesLabel = new System.Windows.Forms.Label();
            this.DTProductsNamesListBox = new System.Windows.Forms.ListBox();
            this.PVFromNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.TDLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PVFromNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // DTUnselectButton
            // 
            resources.ApplyResources(this.DTUnselectButton, "DTUnselectButton");
            this.DTUnselectButton.BackColor = System.Drawing.SystemColors.Window;
            this.DTUnselectButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.DTUnselectButton.Name = "DTUnselectButton";
            this.DTUnselectButton.TabStop = false;
            this.DTUnselectButton.UseVisualStyleBackColor = false;
            this.DTUnselectButton.Click += new System.EventHandler(this.DTUnselectButton_Click);
            // 
            // DTSelectButton
            // 
            resources.ApplyResources(this.DTSelectButton, "DTSelectButton");
            this.DTSelectButton.BackColor = System.Drawing.SystemColors.Window;
            this.DTSelectButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.DTSelectButton.Name = "DTSelectButton";
            this.DTSelectButton.TabStop = false;
            this.DTSelectButton.UseVisualStyleBackColor = false;
            this.DTSelectButton.Click += new System.EventHandler(this.DTSelectButton_Click);
            // 
            // TDSolveButton
            // 
            resources.ApplyResources(this.TDSolveButton, "TDSolveButton");
            this.TDSolveButton.BackColor = System.Drawing.Color.PaleGreen;
            this.TDSolveButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.TDSolveButton.Name = "TDSolveButton";
            this.TDSolveButton.TabStop = false;
            this.TDSolveButton.UseVisualStyleBackColor = false;
            this.TDSolveButton.Click += new System.EventHandler(this.TDSolveButton_Click);
            // 
            // DietProductsLabel
            // 
            resources.ApplyResources(this.DietProductsLabel, "DietProductsLabel");
            this.DietProductsLabel.BackColor = System.Drawing.Color.LightGreen;
            this.DietProductsLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DietProductsLabel.Name = "DietProductsLabel";
            // 
            // DietProductsListBox
            // 
            resources.ApplyResources(this.DietProductsListBox, "DietProductsListBox");
            this.DietProductsListBox.FormattingEnabled = true;
            this.DietProductsListBox.Name = "DietProductsListBox";
            this.DietProductsListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.DietProductsListBox.TabStop = false;
            // 
            // DTProductsNamesLabel
            // 
            resources.ApplyResources(this.DTProductsNamesLabel, "DTProductsNamesLabel");
            this.DTProductsNamesLabel.BackColor = System.Drawing.Color.LightGreen;
            this.DTProductsNamesLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DTProductsNamesLabel.Name = "DTProductsNamesLabel";
            // 
            // DTProductsNamesListBox
            // 
            resources.ApplyResources(this.DTProductsNamesListBox, "DTProductsNamesListBox");
            this.DTProductsNamesListBox.FormattingEnabled = true;
            this.DTProductsNamesListBox.Name = "DTProductsNamesListBox";
            this.DTProductsNamesListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.DTProductsNamesListBox.TabStop = false;
            // 
            // PVFromNumericUpDown
            // 
            resources.ApplyResources(this.PVFromNumericUpDown, "PVFromNumericUpDown");
            this.PVFromNumericUpDown.Maximum = new decimal(new int[] {
            1500,
            0,
            0,
            0});
            this.PVFromNumericUpDown.Minimum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.PVFromNumericUpDown.Name = "PVFromNumericUpDown";
            this.PVFromNumericUpDown.TabStop = false;
            this.PVFromNumericUpDown.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // TDLabel
            // 
            resources.ApplyResources(this.TDLabel, "TDLabel");
            this.TDLabel.Name = "TDLabel";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // TaskSolver
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PVFromNumericUpDown);
            this.Controls.Add(this.TDLabel);
            this.Controls.Add(this.DTUnselectButton);
            this.Controls.Add(this.DTSelectButton);
            this.Controls.Add(this.TDSolveButton);
            this.Controls.Add(this.DietProductsLabel);
            this.Controls.Add(this.DietProductsListBox);
            this.Controls.Add(this.DTProductsNamesLabel);
            this.Controls.Add(this.DTProductsNamesListBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TaskSolver";
            this.Load += new System.EventHandler(this.TaskDataInput_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PVFromNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button DTUnselectButton;
        private System.Windows.Forms.Button DTSelectButton;
        private System.Windows.Forms.Button TDSolveButton;
        private System.Windows.Forms.Label DietProductsLabel;
        private System.Windows.Forms.ListBox DietProductsListBox;
        private System.Windows.Forms.Label DTProductsNamesLabel;
        private System.Windows.Forms.ListBox DTProductsNamesListBox;
        private System.Windows.Forms.NumericUpDown PVFromNumericUpDown;
        private System.Windows.Forms.Label TDLabel;
        private System.Windows.Forms.Label label1;
    }
}
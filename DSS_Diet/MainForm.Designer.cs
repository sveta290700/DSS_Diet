
namespace DietProject
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ButtonToDE = new System.Windows.Forms.Button();
            this.ButtonToTS = new System.Windows.Forms.Button();
            this.ButtonToDDB = new System.Windows.Forms.Button();
            this.DietImagePictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.DietImagePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ButtonToDE
            // 
            resources.ApplyResources(this.ButtonToDE, "ButtonToDE");
            this.ButtonToDE.BackColor = System.Drawing.Color.PaleGreen;
            this.ButtonToDE.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.ButtonToDE.Name = "ButtonToDE";
            this.ButtonToDE.TabStop = false;
            this.ButtonToDE.UseVisualStyleBackColor = false;
            this.ButtonToDE.Click += new System.EventHandler(this.ButtonToDE_Click);
            // 
            // ButtonToTS
            // 
            resources.ApplyResources(this.ButtonToTS, "ButtonToTS");
            this.ButtonToTS.BackColor = System.Drawing.Color.PaleGreen;
            this.ButtonToTS.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.ButtonToTS.Name = "ButtonToTS";
            this.ButtonToTS.TabStop = false;
            this.ButtonToTS.UseVisualStyleBackColor = false;
            this.ButtonToTS.Click += new System.EventHandler(this.ButtonToTS_Click);
            // 
            // ButtonToDDB
            // 
            resources.ApplyResources(this.ButtonToDDB, "ButtonToDDB");
            this.ButtonToDDB.BackColor = System.Drawing.Color.PaleGreen;
            this.ButtonToDDB.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.ButtonToDDB.Name = "ButtonToDDB";
            this.ButtonToDDB.TabStop = false;
            this.ButtonToDDB.UseVisualStyleBackColor = false;
            this.ButtonToDDB.Click += new System.EventHandler(this.ButtonToDDB_Click);
            // 
            // DietImagePictureBox
            // 
            resources.ApplyResources(this.DietImagePictureBox, "DietImagePictureBox");
            this.DietImagePictureBox.Image = global::DSS_Diet.Properties.Resources.StartImage;
            this.DietImagePictureBox.Name = "DietImagePictureBox";
            this.DietImagePictureBox.TabStop = false;
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.DietImagePictureBox);
            this.Controls.Add(this.ButtonToDDB);
            this.Controls.Add(this.ButtonToTS);
            this.Controls.Add(this.ButtonToDE);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.DietImagePictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ButtonToDE;
        private System.Windows.Forms.Button ButtonToTS;
        private System.Windows.Forms.Button ButtonToDDB;
        private System.Windows.Forms.PictureBox DietImagePictureBox;
    }
}


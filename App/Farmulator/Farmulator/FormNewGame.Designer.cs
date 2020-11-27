namespace Farmulator
{
    partial class FormNewGame
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
            this.Map = new System.Windows.Forms.Label();
            this.picture_map = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picture_map)).BeginInit();
            this.SuspendLayout();
            // 
            // Map
            // 
            this.Map.AutoSize = true;
            this.Map.Location = new System.Drawing.Point(12, 9);
            this.Map.Name = "Map";
            this.Map.Size = new System.Drawing.Size(0, 13);
            this.Map.TabIndex = 0;
            // 
            // picture_map
            // 
            this.picture_map.Location = new System.Drawing.Point(135, 12);
            this.picture_map.Name = "picture_map";
            this.picture_map.Size = new System.Drawing.Size(557, 492);
            this.picture_map.TabIndex = 1;
            this.picture_map.TabStop = false;
            // 
            // FormNewGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 681);
            this.Controls.Add(this.picture_map);
            this.Controls.Add(this.Map);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormNewGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FARMULATOR : THE GAME";
            ((System.ComponentModel.ISupportInitialize)(this.picture_map)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Map;
        private System.Windows.Forms.PictureBox picture_map;
    }
}
namespace Farmulator
{
    partial class FormMain
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
            this.btn_newgame = new System.Windows.Forms.Button();
            this.panel_startmenu = new System.Windows.Forms.Panel();
            this.btn_loadgame = new System.Windows.Forms.Button();
            this.panel_startmenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_newgame
            // 
            this.btn_newgame.Location = new System.Drawing.Point(575, 470);
            this.btn_newgame.Name = "btn_newgame";
            this.btn_newgame.Size = new System.Drawing.Size(102, 23);
            this.btn_newgame.TabIndex = 0;
            this.btn_newgame.Text = "Juego Nuevo";
            this.btn_newgame.UseVisualStyleBackColor = true;
            this.btn_newgame.Click += new System.EventHandler(this.btn_newgame_Click);
            // 
            // panel_startmenu
            // 
            this.panel_startmenu.BackColor = System.Drawing.Color.Transparent;
            this.panel_startmenu.Controls.Add(this.btn_loadgame);
            this.panel_startmenu.Controls.Add(this.btn_newgame);
            this.panel_startmenu.Location = new System.Drawing.Point(12, 12);
            this.panel_startmenu.Name = "panel_startmenu";
            this.panel_startmenu.Size = new System.Drawing.Size(680, 587);
            this.panel_startmenu.TabIndex = 1;
            // 
            // btn_loadgame
            // 
            this.btn_loadgame.Location = new System.Drawing.Point(575, 500);
            this.btn_loadgame.Name = "btn_loadgame";
            this.btn_loadgame.Size = new System.Drawing.Size(102, 23);
            this.btn_loadgame.TabIndex = 1;
            this.btn_loadgame.Text = "Cargar Juego";
            this.btn_loadgame.UseVisualStyleBackColor = true;
            this.btn_loadgame.Click += new System.EventHandler(this.btn_loadgame_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.BackgroundImage = global::Farmulator.Properties.Resources.back_start_menu;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(704, 611);
            this.Controls.Add(this.panel_startmenu);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormMain";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FARMULATOR";
            this.panel_startmenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_newgame;
        private System.Windows.Forms.Panel panel_startmenu;
        private System.Windows.Forms.Button btn_loadgame;
    }
}
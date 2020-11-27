namespace Farmulator
{
    partial class FormLoad
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
            this.lbox_savedgames = new System.Windows.Forms.ListBox();
            this.btn_load = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.lb_status = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbox_savedgames
            // 
            this.lbox_savedgames.FormattingEnabled = true;
            this.lbox_savedgames.Location = new System.Drawing.Point(12, 12);
            this.lbox_savedgames.Name = "lbox_savedgames";
            this.lbox_savedgames.Size = new System.Drawing.Size(120, 225);
            this.lbox_savedgames.TabIndex = 0;
            // 
            // btn_load
            // 
            this.btn_load.Location = new System.Drawing.Point(159, 41);
            this.btn_load.Name = "btn_load";
            this.btn_load.Size = new System.Drawing.Size(100, 50);
            this.btn_load.TabIndex = 1;
            this.btn_load.Text = "CARGAR";
            this.btn_load.UseVisualStyleBackColor = true;
            this.btn_load.Click += new System.EventHandler(this.btn_load_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(159, 131);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(100, 30);
            this.btn_cancel.TabIndex = 2;
            this.btn_cancel.Text = "CANCELAR";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // lb_status
            // 
            this.lb_status.Location = new System.Drawing.Point(159, 182);
            this.lb_status.Name = "lb_status";
            this.lb_status.Size = new System.Drawing.Size(100, 55);
            this.lb_status.TabIndex = 3;
            this.lb_status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 246);
            this.Controls.Add(this.lb_status);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_load);
            this.Controls.Add(this.lbox_savedgames);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormLoad";
            this.Text = "FARMULATOR";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbox_savedgames;
        private System.Windows.Forms.Button btn_load;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Label lb_status;
    }
}
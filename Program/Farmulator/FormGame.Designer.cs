namespace Farmulator
{
    partial class FormGame
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
            this.components = new System.ComponentModel.Container();
            this.panel_tools = new System.Windows.Forms.Panel();
            this.btn_nexturn = new System.Windows.Forms.Button();
            this.vsb_map = new System.Windows.Forms.VScrollBar();
            this.hsb_map = new System.Windows.Forms.HScrollBar();
            this.lb_money = new System.Windows.Forms.Label();
            this.panel_stats = new System.Windows.Forms.Panel();
            this.lb_numbermoney = new System.Windows.Forms.Label();
            this.lb_numberturn = new System.Windows.Forms.Label();
            this.lb_turn = new System.Windows.Forms.Label();
            this.btn_market = new System.Windows.Forms.Button();
            this.pb_map = new System.Windows.Forms.PictureBox();
            this.tooltip_plant = new System.Windows.Forms.ToolTip(this.components);
            this.btn_save = new System.Windows.Forms.Button();
            this.panel_tools.SuspendLayout();
            this.panel_stats.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_map)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_tools
            // 
            this.panel_tools.Controls.Add(this.btn_save);
            this.panel_tools.Controls.Add(this.btn_nexturn);
            this.panel_tools.Location = new System.Drawing.Point(0, 60);
            this.panel_tools.Name = "panel_tools";
            this.panel_tools.Size = new System.Drawing.Size(80, 708);
            this.panel_tools.TabIndex = 1;
            // 
            // btn_nexturn
            // 
            this.btn_nexturn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_nexturn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_nexturn.Location = new System.Drawing.Point(2, 2);
            this.btn_nexturn.Name = "btn_nexturn";
            this.btn_nexturn.Size = new System.Drawing.Size(75, 45);
            this.btn_nexturn.TabIndex = 0;
            this.btn_nexturn.Text = "Sig. Turno";
            this.btn_nexturn.UseVisualStyleBackColor = true;
            this.btn_nexturn.Click += new System.EventHandler(this.btn_nexturn_Click);
            // 
            // vsb_map
            // 
            this.vsb_map.Location = new System.Drawing.Point(788, 60);
            this.vsb_map.Maximum = 50;
            this.vsb_map.Name = "vsb_map";
            this.vsb_map.Size = new System.Drawing.Size(17, 708);
            this.vsb_map.TabIndex = 2;
            this.vsb_map.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vsb_map_Scroll);
            // 
            // hsb_map
            // 
            this.hsb_map.Location = new System.Drawing.Point(0, 768);
            this.hsb_map.Name = "hsb_map";
            this.hsb_map.Size = new System.Drawing.Size(788, 17);
            this.hsb_map.TabIndex = 3;
            this.hsb_map.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hsb_map_Scroll);
            // 
            // lb_money
            // 
            this.lb_money.AutoSize = true;
            this.lb_money.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_money.Location = new System.Drawing.Point(44, 34);
            this.lb_money.Name = "lb_money";
            this.lb_money.Size = new System.Drawing.Size(54, 16);
            this.lb_money.TabIndex = 4;
            this.lb_money.Text = "Dinero";
            // 
            // panel_stats
            // 
            this.panel_stats.Controls.Add(this.lb_numbermoney);
            this.panel_stats.Controls.Add(this.lb_numberturn);
            this.panel_stats.Controls.Add(this.lb_turn);
            this.panel_stats.Controls.Add(this.lb_money);
            this.panel_stats.Location = new System.Drawing.Point(505, 0);
            this.panel_stats.Name = "panel_stats";
            this.panel_stats.Size = new System.Drawing.Size(300, 60);
            this.panel_stats.TabIndex = 5;
            // 
            // lb_numbermoney
            // 
            this.lb_numbermoney.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lb_numbermoney.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_numbermoney.Location = new System.Drawing.Point(100, 34);
            this.lb_numbermoney.Name = "lb_numbermoney";
            this.lb_numbermoney.Size = new System.Drawing.Size(150, 20);
            this.lb_numbermoney.TabIndex = 7;
            this.lb_numbermoney.Text = "50000";
            this.lb_numbermoney.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_numberturn
            // 
            this.lb_numberturn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lb_numberturn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_numberturn.Location = new System.Drawing.Point(100, 6);
            this.lb_numberturn.Name = "lb_numberturn";
            this.lb_numberturn.Size = new System.Drawing.Size(150, 20);
            this.lb_numberturn.TabIndex = 6;
            this.lb_numberturn.Text = "1";
            this.lb_numberturn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_turn
            // 
            this.lb_turn.AutoSize = true;
            this.lb_turn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_turn.Location = new System.Drawing.Point(48, 9);
            this.lb_turn.Name = "lb_turn";
            this.lb_turn.Size = new System.Drawing.Size(48, 16);
            this.lb_turn.TabIndex = 5;
            this.lb_turn.Text = "Turno";
            // 
            // btn_market
            // 
            this.btn_market.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_market.Location = new System.Drawing.Point(2, 2);
            this.btn_market.Name = "btn_market";
            this.btn_market.Size = new System.Drawing.Size(75, 56);
            this.btn_market.TabIndex = 6;
            this.btn_market.Text = "Comprar";
            this.btn_market.UseVisualStyleBackColor = true;
            this.btn_market.Click += new System.EventHandler(this.btn_market_Click);
            // 
            // pb_map
            // 
            this.pb_map.Location = new System.Drawing.Point(80, 60);
            this.pb_map.Name = "pb_map";
            this.pb_map.Size = new System.Drawing.Size(708, 708);
            this.pb_map.TabIndex = 0;
            this.pb_map.TabStop = false;
            // 
            // tooltip_plant
            // 
            this.tooltip_plant.IsBalloon = true;
            // 
            // btn_save
            // 
            this.btn_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.Location = new System.Drawing.Point(2, 50);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 45);
            this.btn_save.TabIndex = 7;
            this.btn_save.Text = "Guardar";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // FormGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 786);
            this.Controls.Add(this.btn_market);
            this.Controls.Add(this.panel_stats);
            this.Controls.Add(this.hsb_map);
            this.Controls.Add(this.vsb_map);
            this.Controls.Add(this.panel_tools);
            this.Controls.Add(this.pb_map);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FARMULATOR";
            this.Load += new System.EventHandler(this.FormGame_Load);
            this.panel_tools.ResumeLayout(false);
            this.panel_stats.ResumeLayout(false);
            this.panel_stats.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_map)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_map;
        private System.Windows.Forms.Panel panel_tools;
        private System.Windows.Forms.VScrollBar vsb_map;
        private System.Windows.Forms.HScrollBar hsb_map;
        private System.Windows.Forms.Label lb_money;
        private System.Windows.Forms.Panel panel_stats;
        private System.Windows.Forms.Label lb_numbermoney;
        private System.Windows.Forms.Label lb_numberturn;
        private System.Windows.Forms.Label lb_turn;
        private System.Windows.Forms.Button btn_nexturn;
        private System.Windows.Forms.Button btn_market;
        private System.Windows.Forms.ToolTip tooltip_plant;
        private System.Windows.Forms.Button btn_save;
    }
}
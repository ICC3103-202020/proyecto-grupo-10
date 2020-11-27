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
            this.pb_map = new System.Windows.Forms.PictureBox();
            this.check_river = new System.Windows.Forms.CheckBox();
            this.check_lake = new System.Windows.Forms.CheckBox();
            this.btn_generateworld = new System.Windows.Forms.Button();
            this.lb_titlenewgame = new System.Windows.Forms.Label();
            this.pb_temperature = new System.Windows.Forms.ProgressBar();
            this.btn_uptemperature = new System.Windows.Forms.Button();
            this.btn_downtemperature = new System.Windows.Forms.Button();
            this.lb_temperature = new System.Windows.Forms.Label();
            this.pb_rainfall = new System.Windows.Forms.ProgressBar();
            this.btn_uprainfall = new System.Windows.Forms.Button();
            this.btn_downrainfall = new System.Windows.Forms.Button();
            this.lb_rainfall = new System.Windows.Forms.Label();
            this.panel_temperature = new System.Windows.Forms.Panel();
            this.panel_rainfall = new System.Windows.Forms.Panel();
            this.panel_lakeriver = new System.Windows.Forms.Panel();
            this.btn_play = new System.Windows.Forms.Button();
            this.panel_buttons = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pb_map)).BeginInit();
            this.panel_temperature.SuspendLayout();
            this.panel_rainfall.SuspendLayout();
            this.panel_lakeriver.SuspendLayout();
            this.panel_buttons.SuspendLayout();
            this.SuspendLayout();
            // 
            // pb_map
            // 
            this.pb_map.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pb_map.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pb_map.Cursor = System.Windows.Forms.Cursors.Default;
            this.pb_map.Location = new System.Drawing.Point(320, 70);
            this.pb_map.Name = "pb_map";
            this.pb_map.Size = new System.Drawing.Size(500, 500);
            this.pb_map.TabIndex = 0;
            this.pb_map.TabStop = false;
            // 
            // check_river
            // 
            this.check_river.AutoSize = true;
            this.check_river.Cursor = System.Windows.Forms.Cursors.Default;
            this.check_river.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.check_river.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check_river.Location = new System.Drawing.Point(113, 59);
            this.check_river.Name = "check_river";
            this.check_river.Size = new System.Drawing.Size(79, 21);
            this.check_river.TabIndex = 3;
            this.check_river.Text = "RIVER";
            this.check_river.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.check_river.UseVisualStyleBackColor = true;
            // 
            // check_lake
            // 
            this.check_lake.AutoSize = true;
            this.check_lake.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.check_lake.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check_lake.Location = new System.Drawing.Point(113, 19);
            this.check_lake.Name = "check_lake";
            this.check_lake.Size = new System.Drawing.Size(73, 21);
            this.check_lake.TabIndex = 4;
            this.check_lake.Text = "LAGO";
            this.check_lake.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.check_lake.UseVisualStyleBackColor = true;
            // 
            // btn_generateworld
            // 
            this.btn_generateworld.BackColor = System.Drawing.Color.Transparent;
            this.btn_generateworld.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_generateworld.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_generateworld.FlatAppearance.BorderSize = 2;
            this.btn_generateworld.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_generateworld.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_generateworld.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_generateworld.Location = new System.Drawing.Point(20, 24);
            this.btn_generateworld.Name = "btn_generateworld";
            this.btn_generateworld.Size = new System.Drawing.Size(260, 30);
            this.btn_generateworld.TabIndex = 5;
            this.btn_generateworld.Text = "GENERAR MUNDO";
            this.btn_generateworld.UseVisualStyleBackColor = false;
            this.btn_generateworld.Click += new System.EventHandler(this.btn_generateworld_Click);
            // 
            // lb_titlenewgame
            // 
            this.lb_titlenewgame.AutoSize = true;
            this.lb_titlenewgame.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_titlenewgame.Location = new System.Drawing.Point(227, 20);
            this.lb_titlenewgame.Name = "lb_titlenewgame";
            this.lb_titlenewgame.Size = new System.Drawing.Size(285, 31);
            this.lb_titlenewgame.TabIndex = 6;
            this.lb_titlenewgame.Text = "DISEÑA TU MUNDO";
            // 
            // pb_temperature
            // 
            this.pb_temperature.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.pb_temperature.Location = new System.Drawing.Point(50, 55);
            this.pb_temperature.Name = "pb_temperature";
            this.pb_temperature.Size = new System.Drawing.Size(200, 20);
            this.pb_temperature.Step = 5;
            this.pb_temperature.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pb_temperature.TabIndex = 7;
            this.pb_temperature.Value = 20;
            // 
            // btn_uptemperature
            // 
            this.btn_uptemperature.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_uptemperature.Location = new System.Drawing.Point(260, 55);
            this.btn_uptemperature.Name = "btn_uptemperature";
            this.btn_uptemperature.Size = new System.Drawing.Size(20, 20);
            this.btn_uptemperature.TabIndex = 8;
            this.btn_uptemperature.Text = "▲";
            this.btn_uptemperature.UseVisualStyleBackColor = true;
            this.btn_uptemperature.Click += new System.EventHandler(this.btn_uptemperature_Click);
            // 
            // btn_downtemperature
            // 
            this.btn_downtemperature.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_downtemperature.Location = new System.Drawing.Point(20, 55);
            this.btn_downtemperature.Name = "btn_downtemperature";
            this.btn_downtemperature.Size = new System.Drawing.Size(20, 20);
            this.btn_downtemperature.TabIndex = 9;
            this.btn_downtemperature.Text = "▼";
            this.btn_downtemperature.UseVisualStyleBackColor = true;
            this.btn_downtemperature.Click += new System.EventHandler(this.btn_downtemperature_Click);
            // 
            // lb_temperature
            // 
            this.lb_temperature.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_temperature.Location = new System.Drawing.Point(50, 15);
            this.lb_temperature.Name = "lb_temperature";
            this.lb_temperature.Size = new System.Drawing.Size(200, 20);
            this.lb_temperature.TabIndex = 10;
            this.lb_temperature.Text = "TEMPERATURA";
            this.lb_temperature.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pb_rainfall
            // 
            this.pb_rainfall.Location = new System.Drawing.Point(50, 55);
            this.pb_rainfall.Name = "pb_rainfall";
            this.pb_rainfall.Size = new System.Drawing.Size(200, 20);
            this.pb_rainfall.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pb_rainfall.TabIndex = 11;
            this.pb_rainfall.Value = 20;
            // 
            // btn_uprainfall
            // 
            this.btn_uprainfall.Location = new System.Drawing.Point(260, 55);
            this.btn_uprainfall.Name = "btn_uprainfall";
            this.btn_uprainfall.Size = new System.Drawing.Size(20, 20);
            this.btn_uprainfall.TabIndex = 12;
            this.btn_uprainfall.Text = "▲";
            this.btn_uprainfall.UseVisualStyleBackColor = true;
            this.btn_uprainfall.Click += new System.EventHandler(this.btn_uprainfall_Click);
            // 
            // btn_downrainfall
            // 
            this.btn_downrainfall.Location = new System.Drawing.Point(20, 55);
            this.btn_downrainfall.Name = "btn_downrainfall";
            this.btn_downrainfall.Size = new System.Drawing.Size(20, 20);
            this.btn_downrainfall.TabIndex = 13;
            this.btn_downrainfall.Text = "▼";
            this.btn_downrainfall.UseVisualStyleBackColor = true;
            this.btn_downrainfall.Click += new System.EventHandler(this.btn_downrainfall_Click);
            // 
            // lb_rainfall
            // 
            this.lb_rainfall.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_rainfall.Location = new System.Drawing.Point(50, 15);
            this.lb_rainfall.Name = "lb_rainfall";
            this.lb_rainfall.Size = new System.Drawing.Size(200, 20);
            this.lb_rainfall.TabIndex = 14;
            this.lb_rainfall.Text = "LLUVIA";
            this.lb_rainfall.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel_temperature
            // 
            this.panel_temperature.Controls.Add(this.pb_temperature);
            this.panel_temperature.Controls.Add(this.btn_downtemperature);
            this.panel_temperature.Controls.Add(this.btn_uptemperature);
            this.panel_temperature.Controls.Add(this.lb_temperature);
            this.panel_temperature.Location = new System.Drawing.Point(10, 70);
            this.panel_temperature.Name = "panel_temperature";
            this.panel_temperature.Size = new System.Drawing.Size(300, 100);
            this.panel_temperature.TabIndex = 15;
            // 
            // panel_rainfall
            // 
            this.panel_rainfall.Controls.Add(this.pb_rainfall);
            this.panel_rainfall.Controls.Add(this.btn_uprainfall);
            this.panel_rainfall.Controls.Add(this.lb_rainfall);
            this.panel_rainfall.Controls.Add(this.btn_downrainfall);
            this.panel_rainfall.Location = new System.Drawing.Point(10, 175);
            this.panel_rainfall.Name = "panel_rainfall";
            this.panel_rainfall.Size = new System.Drawing.Size(300, 100);
            this.panel_rainfall.TabIndex = 16;
            // 
            // panel_lakeriver
            // 
            this.panel_lakeriver.Controls.Add(this.check_river);
            this.panel_lakeriver.Controls.Add(this.check_lake);
            this.panel_lakeriver.Location = new System.Drawing.Point(10, 280);
            this.panel_lakeriver.Name = "panel_lakeriver";
            this.panel_lakeriver.Size = new System.Drawing.Size(300, 100);
            this.panel_lakeriver.TabIndex = 17;
            // 
            // btn_play
            // 
            this.btn_play.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_play.Location = new System.Drawing.Point(112, 77);
            this.btn_play.Name = "btn_play";
            this.btn_play.Size = new System.Drawing.Size(75, 50);
            this.btn_play.TabIndex = 18;
            this.btn_play.Text = "JUGAR";
            this.btn_play.UseVisualStyleBackColor = true;
            this.btn_play.Click += new System.EventHandler(this.btn_play_Click);
            // 
            // panel_buttons
            // 
            this.panel_buttons.Controls.Add(this.btn_play);
            this.panel_buttons.Controls.Add(this.btn_generateworld);
            this.panel_buttons.Location = new System.Drawing.Point(10, 385);
            this.panel_buttons.Name = "panel_buttons";
            this.panel_buttons.Size = new System.Drawing.Size(300, 150);
            this.panel_buttons.TabIndex = 19;
            // 
            // FormNewGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 580);
            this.Controls.Add(this.panel_buttons);
            this.Controls.Add(this.panel_lakeriver);
            this.Controls.Add(this.panel_rainfall);
            this.Controls.Add(this.panel_temperature);
            this.Controls.Add(this.lb_titlenewgame);
            this.Controls.Add(this.pb_map);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormNewGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FARMULATOR";
            this.Load += new System.EventHandler(this.FormNewGame_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb_map)).EndInit();
            this.panel_temperature.ResumeLayout(false);
            this.panel_rainfall.ResumeLayout(false);
            this.panel_lakeriver.ResumeLayout(false);
            this.panel_lakeriver.PerformLayout();
            this.panel_buttons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_map;
        private System.Windows.Forms.CheckBox check_river;
        private System.Windows.Forms.CheckBox check_lake;
        private System.Windows.Forms.Button btn_generateworld;
        private System.Windows.Forms.Label lb_titlenewgame;
        private System.Windows.Forms.ProgressBar pb_temperature;
        private System.Windows.Forms.Button btn_uptemperature;
        private System.Windows.Forms.Button btn_downtemperature;
        private System.Windows.Forms.Label lb_temperature;
        private System.Windows.Forms.ProgressBar pb_rainfall;
        private System.Windows.Forms.Button btn_uprainfall;
        private System.Windows.Forms.Button btn_downrainfall;
        private System.Windows.Forms.Label lb_rainfall;
        private System.Windows.Forms.Panel panel_temperature;
        private System.Windows.Forms.Panel panel_rainfall;
        private System.Windows.Forms.Panel panel_lakeriver;
        private System.Windows.Forms.Button btn_play;
        private System.Windows.Forms.Panel panel_buttons;
    }
}
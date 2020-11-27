namespace Farmulator
{
    partial class FormBuy
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
            this.panel_categories = new System.Windows.Forms.Panel();
            this.btn_terrain = new System.Windows.Forms.Button();
            this.btn_consumables = new System.Windows.Forms.Button();
            this.btn_storage = new System.Windows.Forms.Button();
            this.btn_ranch = new System.Windows.Forms.Button();
            this.btn_land = new System.Windows.Forms.Button();
            this.pb_product = new System.Windows.Forms.PictureBox();
            this.panel_description = new System.Windows.Forms.Panel();
            this.btn_subtractconsumable = new System.Windows.Forms.Button();
            this.btn_addconsumable = new System.Windows.Forms.Button();
            this.lb_quantityconsumable = new System.Windows.Forms.Label();
            this.lbox_products = new System.Windows.Forms.ListBox();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_buy = new System.Windows.Forms.Button();
            this.lb_description = new System.Windows.Forms.Label();
            this.btn_down = new System.Windows.Forms.Button();
            this.btn_up = new System.Windows.Forms.Button();
            this.lb_numberown = new System.Windows.Forms.Label();
            this.lb_own = new System.Windows.Forms.Label();
            this.lb_price = new System.Windows.Forms.Label();
            this.lb_nameproduct = new System.Windows.Forms.Label();
            this.lb_numberprice = new System.Windows.Forms.Label();
            this.panel_categories.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_product)).BeginInit();
            this.panel_description.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_categories
            // 
            this.panel_categories.Controls.Add(this.btn_terrain);
            this.panel_categories.Controls.Add(this.btn_consumables);
            this.panel_categories.Controls.Add(this.btn_storage);
            this.panel_categories.Controls.Add(this.btn_ranch);
            this.panel_categories.Controls.Add(this.btn_land);
            this.panel_categories.Location = new System.Drawing.Point(10, 10);
            this.panel_categories.Name = "panel_categories";
            this.panel_categories.Padding = new System.Windows.Forms.Padding(2);
            this.panel_categories.Size = new System.Drawing.Size(50, 330);
            this.panel_categories.TabIndex = 1;
            // 
            // btn_terrain
            // 
            this.btn_terrain.BackgroundImage = global::Farmulator.Properties.Resources.sprayer;
            this.btn_terrain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_terrain.Location = new System.Drawing.Point(2, 186);
            this.btn_terrain.Name = "btn_terrain";
            this.btn_terrain.Size = new System.Drawing.Size(46, 36);
            this.btn_terrain.TabIndex = 4;
            this.btn_terrain.UseVisualStyleBackColor = true;
            this.btn_terrain.Click += new System.EventHandler(this.btn_terrain_Click);
            // 
            // btn_consumables
            // 
            this.btn_consumables.BackgroundImage = global::Farmulator.Properties.Resources.pesticide;
            this.btn_consumables.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_consumables.Location = new System.Drawing.Point(2, 140);
            this.btn_consumables.Name = "btn_consumables";
            this.btn_consumables.Size = new System.Drawing.Size(46, 36);
            this.btn_consumables.TabIndex = 3;
            this.btn_consumables.UseVisualStyleBackColor = true;
            this.btn_consumables.Click += new System.EventHandler(this.btn_consumables_Click);
            // 
            // btn_storage
            // 
            this.btn_storage.BackgroundImage = global::Farmulator.Properties.Resources.storage;
            this.btn_storage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_storage.Location = new System.Drawing.Point(2, 94);
            this.btn_storage.Name = "btn_storage";
            this.btn_storage.Size = new System.Drawing.Size(46, 36);
            this.btn_storage.TabIndex = 2;
            this.btn_storage.UseVisualStyleBackColor = true;
            this.btn_storage.Click += new System.EventHandler(this.btn_storage_Click);
            // 
            // btn_ranch
            // 
            this.btn_ranch.BackgroundImage = global::Farmulator.Properties.Resources.animal;
            this.btn_ranch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_ranch.Location = new System.Drawing.Point(2, 48);
            this.btn_ranch.Name = "btn_ranch";
            this.btn_ranch.Size = new System.Drawing.Size(46, 36);
            this.btn_ranch.TabIndex = 1;
            this.btn_ranch.UseVisualStyleBackColor = true;
            this.btn_ranch.Click += new System.EventHandler(this.btn_ranch_Click);
            // 
            // btn_land
            // 
            this.btn_land.BackgroundImage = global::Farmulator.Properties.Resources.planter;
            this.btn_land.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_land.Location = new System.Drawing.Point(2, 2);
            this.btn_land.Name = "btn_land";
            this.btn_land.Size = new System.Drawing.Size(46, 36);
            this.btn_land.TabIndex = 0;
            this.btn_land.UseVisualStyleBackColor = true;
            this.btn_land.Click += new System.EventHandler(this.btn_land_Click);
            // 
            // pb_product
            // 
            this.pb_product.BackgroundImage = global::Farmulator.Properties.Resources.carrot;
            this.pb_product.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pb_product.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pb_product.Location = new System.Drawing.Point(10, 2);
            this.pb_product.Name = "pb_product";
            this.pb_product.Size = new System.Drawing.Size(150, 85);
            this.pb_product.TabIndex = 2;
            this.pb_product.TabStop = false;
            // 
            // panel_description
            // 
            this.panel_description.Controls.Add(this.btn_subtractconsumable);
            this.panel_description.Controls.Add(this.btn_addconsumable);
            this.panel_description.Controls.Add(this.lb_quantityconsumable);
            this.panel_description.Controls.Add(this.lbox_products);
            this.panel_description.Controls.Add(this.btn_cancel);
            this.panel_description.Controls.Add(this.btn_buy);
            this.panel_description.Controls.Add(this.lb_description);
            this.panel_description.Controls.Add(this.btn_down);
            this.panel_description.Controls.Add(this.btn_up);
            this.panel_description.Controls.Add(this.lb_numberown);
            this.panel_description.Controls.Add(this.lb_own);
            this.panel_description.Controls.Add(this.lb_price);
            this.panel_description.Controls.Add(this.lb_nameproduct);
            this.panel_description.Controls.Add(this.lb_numberprice);
            this.panel_description.Controls.Add(this.pb_product);
            this.panel_description.Location = new System.Drawing.Point(70, 10);
            this.panel_description.Name = "panel_description";
            this.panel_description.Size = new System.Drawing.Size(270, 330);
            this.panel_description.TabIndex = 3;
            // 
            // btn_subtractconsumable
            // 
            this.btn_subtractconsumable.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_subtractconsumable.Location = new System.Drawing.Point(235, 193);
            this.btn_subtractconsumable.Name = "btn_subtractconsumable";
            this.btn_subtractconsumable.Size = new System.Drawing.Size(22, 22);
            this.btn_subtractconsumable.TabIndex = 16;
            this.btn_subtractconsumable.Text = "-";
            this.btn_subtractconsumable.UseVisualStyleBackColor = true;
            this.btn_subtractconsumable.Visible = false;
            this.btn_subtractconsumable.Click += new System.EventHandler(this.btn_subtractconsumable_Click);
            // 
            // btn_addconsumable
            // 
            this.btn_addconsumable.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_addconsumable.Location = new System.Drawing.Point(235, 165);
            this.btn_addconsumable.Name = "btn_addconsumable";
            this.btn_addconsumable.Size = new System.Drawing.Size(22, 22);
            this.btn_addconsumable.TabIndex = 15;
            this.btn_addconsumable.Text = "+";
            this.btn_addconsumable.UseVisualStyleBackColor = true;
            this.btn_addconsumable.Visible = false;
            this.btn_addconsumable.Click += new System.EventHandler(this.btn_addconsumable_Click);
            // 
            // lb_quantityconsumable
            // 
            this.lb_quantityconsumable.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lb_quantityconsumable.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_quantityconsumable.Location = new System.Drawing.Point(180, 165);
            this.lb_quantityconsumable.Name = "lb_quantityconsumable";
            this.lb_quantityconsumable.Size = new System.Drawing.Size(50, 50);
            this.lb_quantityconsumable.TabIndex = 14;
            this.lb_quantityconsumable.Text = "1";
            this.lb_quantityconsumable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_quantityconsumable.Visible = false;
            // 
            // lbox_products
            // 
            this.lbox_products.FormattingEnabled = true;
            this.lbox_products.Location = new System.Drawing.Point(18, 160);
            this.lbox_products.Name = "lbox_products";
            this.lbox_products.Size = new System.Drawing.Size(120, 160);
            this.lbox_products.TabIndex = 13;
            this.lbox_products.Visible = false;
            // 
            // btn_cancel
            // 
            this.btn_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancel.Location = new System.Drawing.Point(170, 270);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(100, 30);
            this.btn_cancel.TabIndex = 12;
            this.btn_cancel.Text = "CANCELAR";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_buy
            // 
            this.btn_buy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_buy.Location = new System.Drawing.Point(170, 230);
            this.btn_buy.Name = "btn_buy";
            this.btn_buy.Size = new System.Drawing.Size(100, 30);
            this.btn_buy.TabIndex = 11;
            this.btn_buy.Text = "COMPRAR";
            this.btn_buy.UseVisualStyleBackColor = true;
            this.btn_buy.Click += new System.EventHandler(this.btn_buy_Click);
            // 
            // lb_description
            // 
            this.lb_description.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lb_description.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_description.Location = new System.Drawing.Point(10, 130);
            this.lb_description.Name = "lb_description";
            this.lb_description.Size = new System.Drawing.Size(150, 200);
            this.lb_description.TabIndex = 10;
            this.lb_description.Text = "Descripcion Producto";
            // 
            // btn_down
            // 
            this.btn_down.Location = new System.Drawing.Point(225, 104);
            this.btn_down.Name = "btn_down";
            this.btn_down.Size = new System.Drawing.Size(40, 40);
            this.btn_down.TabIndex = 9;
            this.btn_down.Text = "▼";
            this.btn_down.UseVisualStyleBackColor = true;
            this.btn_down.Click += new System.EventHandler(this.btn_down_Click);
            // 
            // btn_up
            // 
            this.btn_up.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_up.Location = new System.Drawing.Point(175, 104);
            this.btn_up.Name = "btn_up";
            this.btn_up.Size = new System.Drawing.Size(40, 40);
            this.btn_up.TabIndex = 8;
            this.btn_up.Text = "▲";
            this.btn_up.UseVisualStyleBackColor = true;
            this.btn_up.Click += new System.EventHandler(this.btn_up_Click);
            // 
            // lb_numberown
            // 
            this.lb_numberown.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lb_numberown.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_numberown.Location = new System.Drawing.Point(170, 71);
            this.lb_numberown.Name = "lb_numberown";
            this.lb_numberown.Size = new System.Drawing.Size(100, 23);
            this.lb_numberown.TabIndex = 7;
            this.lb_numberown.Text = "0";
            // 
            // lb_own
            // 
            this.lb_own.AutoSize = true;
            this.lb_own.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_own.Location = new System.Drawing.Point(170, 50);
            this.lb_own.Name = "lb_own";
            this.lb_own.Size = new System.Drawing.Size(63, 16);
            this.lb_own.TabIndex = 6;
            this.lb_own.Text = "TIENES";
            // 
            // lb_price
            // 
            this.lb_price.AutoSize = true;
            this.lb_price.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_price.Location = new System.Drawing.Point(170, 2);
            this.lb_price.Name = "lb_price";
            this.lb_price.Size = new System.Drawing.Size(58, 15);
            this.lb_price.TabIndex = 5;
            this.lb_price.Text = "PRECIO";
            // 
            // lb_nameproduct
            // 
            this.lb_nameproduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_nameproduct.Location = new System.Drawing.Point(10, 92);
            this.lb_nameproduct.Name = "lb_nameproduct";
            this.lb_nameproduct.Size = new System.Drawing.Size(150, 32);
            this.lb_nameproduct.TabIndex = 4;
            this.lb_nameproduct.Text = "Nombre producto";
            // 
            // lb_numberprice
            // 
            this.lb_numberprice.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lb_numberprice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_numberprice.Location = new System.Drawing.Point(170, 22);
            this.lb_numberprice.Name = "lb_numberprice";
            this.lb_numberprice.Size = new System.Drawing.Size(100, 23);
            this.lb_numberprice.TabIndex = 3;
            this.lb_numberprice.Text = "5000";
            // 
            // FormBuy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 350);
            this.Controls.Add(this.panel_description);
            this.Controls.Add(this.panel_categories);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormBuy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormBuy";
            this.Load += new System.EventHandler(this.FormBuy_Load);
            this.panel_categories.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_product)).EndInit();
            this.panel_description.ResumeLayout(false);
            this.panel_description.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_land;
        private System.Windows.Forms.Panel panel_categories;
        private System.Windows.Forms.Button btn_terrain;
        private System.Windows.Forms.Button btn_consumables;
        private System.Windows.Forms.Button btn_storage;
        private System.Windows.Forms.Button btn_ranch;
        private System.Windows.Forms.PictureBox pb_product;
        private System.Windows.Forms.Panel panel_description;
        private System.Windows.Forms.Button btn_up;
        private System.Windows.Forms.Label lb_numberown;
        private System.Windows.Forms.Label lb_own;
        private System.Windows.Forms.Label lb_price;
        private System.Windows.Forms.Label lb_nameproduct;
        private System.Windows.Forms.Label lb_numberprice;
        private System.Windows.Forms.Button btn_down;
        private System.Windows.Forms.ListBox lbox_products;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_buy;
        private System.Windows.Forms.Label lb_description;
        private System.Windows.Forms.Button btn_subtractconsumable;
        private System.Windows.Forms.Button btn_addconsumable;
        private System.Windows.Forms.Label lb_quantityconsumable;
    }
}
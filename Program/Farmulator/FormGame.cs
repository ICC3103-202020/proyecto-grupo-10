using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Farmulator.Classes.nsGame;
using Farmulator.Classes.nsPrinter;

namespace Farmulator
{
    partial class FormGame : Form
    {
        private Game game;
        private Bitmap map;
        public FormGame(Game game)
        {
            InitializeComponent();

            this.game = game;
            lb_numbermoney.Text = this.game.GetMoney().ToString();
            lb_numberturn.Text = this.game.GetTurn().ToString();

        }

        private void FormGame_Load(object sender, EventArgs e)
        {
            this.map = Print.RenderImgMap(this.game);

            Bitmap cropMap = new Bitmap(500, 500);

            Graphics g = Graphics.FromImage(cropMap);

            int x = 0;
            int y = 0;

            for (int i = 0; i < 100; i++)
            {
                if (this.game.GetMap().GetFarm().GetTerrains().Contains(this.game.GetMap().GetTerrains()[i / 10, i % 10]))
                {
                    y = i / 10;
                    x = i % 10;
                    break;
                }
            }

            if (x != 0)
            {
                if(x - 1 > 5)
                {
                    x = 5;
                }
                else
                {
                    x -= 1;
                }
            }

            if (y != 0)
            {
                if (y - 1 > 5)
                {
                    y = 5;
                }
                else
                {
                    y -= 1;
                }
            }

            Rectangle rectangle = new Rectangle(x * 100, y * 100, 500, 500);

            g.DrawImage(this.map, 0, 0, rectangle, GraphicsUnit.Pixel);

            g.Dispose();

            pb_map.Image = cropMap;
            pb_map.SizeMode = PictureBoxSizeMode.StretchImage;

            vsb_map.Maximum = 59;
            vsb_map.Minimum = 0;

            hsb_map.Maximum = 50;
            hsb_map.Minimum = 0;

            vsb_map.Value = y * 10;
            hsb_map.Value = x * 10;

        }

        private void vsb_map_Scroll(object sender, ScrollEventArgs e)
        {
            int x;
            int y;

            x = hsb_map.Value;
            y = e.NewValue;

            Bitmap cropMap = new Bitmap(500, 500);

            Graphics g = Graphics.FromImage(cropMap);

            Rectangle rectangle = new Rectangle(x * 10, y * 10, 500, 500);

            g.DrawImage(this.map, 0, 0, rectangle, GraphicsUnit.Pixel);

            g.Dispose();

            pb_map.Image = cropMap;

        }

        private void hsb_map_Scroll(object sender, ScrollEventArgs e)
        {
            int x;
            int y;

            x = e.NewValue;
            y = vsb_map.Value;

            Bitmap cropMap = new Bitmap(500, 500);

            Graphics g = Graphics.FromImage(cropMap);

            Rectangle rectangle = new Rectangle(x * 10, y * 10, 500, 500);

            g.DrawImage(this.map, 0, 0, rectangle, GraphicsUnit.Pixel);

            g.Dispose();

            pb_map.Image = cropMap;
        }


        //SIGUIENTE TURNO
        private void btn_nexturn_Click(object sender, EventArgs e)
        {
            this.game.NextTurn();

            lb_numberturn.Text = this.game.GetTurn().ToString();
        }

    

        private void btn_market_Click(object sender, EventArgs e)
        {
            FormBuy formBuy = new FormBuy(this.game);

            formBuy.Show();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            FormSave formSave = new FormSave(this.game);

            formSave.Show();
        }
    }
}

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
using Farmulator.Classes.nsGame.nsMap;
using Farmulator.Classes.nsPrinter;

namespace Farmulator
{
    public partial class FormNewGame : Form
    {
        private Game game;
        private Bitmap map;
        public FormNewGame()
        {
            InitializeComponent();
        }

        private void FormNewGame_Load(object sender, EventArgs e)
        {
            game = new Game(pb_temperature.Value, pb_rainfall.Value);

            this.game.GetMap().GenerateMap(0, 0, pb_temperature.Value, pb_rainfall.Value);

            this.map = Print.RenderImgMap(this.game);

            pb_map.Image = this.map;
            pb_map.SizeMode = PictureBoxSizeMode.Zoom;


            //COLOR DE LAS BARRAS
            Color yellow = Color.FromArgb(237,172,0);
            Color blue = Color.FromArgb(46, 101, 165);

            pb_temperature.ForeColor = yellow;
            pb_rainfall.ForeColor = blue;
        }

        private void btn_generateworld_Click(object sender, EventArgs e)
        {
            int lake = 0;
            int river = 0;
            
            if (check_lake.Checked)
            {
                lake = 1;
            }

            if (!check_lake.Checked)
            {
                lake = 0;
            }

            if (check_river.Checked)
            {
                river = 1;
            }
            if (!check_river.Checked)
            {
                river = 0;
            }

            this.game.GetMap().GenerateMap(lake, river, pb_temperature.Value, pb_rainfall.Value);

            this.map = Print.RenderImgMap(this.game);

            pb_map.Image = this.map;
            pb_map.SizeMode = PictureBoxSizeMode.Zoom;

        }

        private void btn_uptemperature_Click(object sender, EventArgs e)
        {
            if (pb_temperature.Value < 100)
            {
                pb_temperature.Value += 20;
            }
        }

        private void btn_downtemperature_Click(object sender, EventArgs e)
        {
            if (pb_temperature.Value > 0)
            {
                pb_temperature.Value -= 20;
            }
        }

        private void btn_uprainfall_Click(object sender, EventArgs e)
        {
            if (pb_rainfall.Value < 100)
            {
                pb_rainfall.Value += 20;
            }
        }

        private void btn_downrainfall_Click(object sender, EventArgs e)
        {
            if (pb_rainfall.Value > 0)
            {
                pb_rainfall.Value -= 20;
            }
        }

        private void btn_play_Click(object sender, EventArgs e)
        {
            FormGame formGame = new FormGame(this.game);

            formGame.Show();

            Close();

        }
    }
}

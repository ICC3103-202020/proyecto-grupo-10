using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Farmulator.Classes.nsPrinter;

namespace Farmulator
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();

        }

        private void btn_newgame_Click(object sender, EventArgs e)
        {
            FormNewGame newGame = new FormNewGame();

            newGame.Show();

            Hide();
        }

        private void btn_loadgame_Click(object sender, EventArgs e)
        {
            FormLoad formLoad = new FormLoad();

            formLoad.Show();

            Hide();
        }
    }
}

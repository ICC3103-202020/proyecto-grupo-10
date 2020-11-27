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
using Farmulator.Classes.nsGame;

namespace Farmulator
{
    partial class FormSave : Form
    {
        private Game game;
        public FormSave(Game game)
        {
            InitializeComponent();
            this.game = game;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if(tb_namesave.Text == "")
            {
                lb_state.ForeColor = Color.Red;
                lb_state.Text = "Ingrese un nombre";
            }
            else
            {
                bool verification = Print.RenderSaveMenu(game,tb_namesave.Text);
                
                if(verification == true)
                {
                    MessageBox.Show("Guardado con exito");
                    Close();
                }
                else
                {
                    lb_state.ForeColor = Color.Red;
                    lb_state.Text = "El nombre ingresado ya existe";
                }
            }
        }
    }
}

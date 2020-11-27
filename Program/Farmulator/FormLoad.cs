using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Authentication;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Farmulator.Classes.nsGame;

namespace Farmulator
{
    partial class FormLoad : Form
    {
        private Game game;
        public FormLoad()
        {
            InitializeComponent();

            DirectoryInfo directoryInfo = new DirectoryInfo("../../Resources/Savegames");
            FileInfo[] fileGamesSaved = directoryInfo.GetFiles();

            for (int a = 0; a < fileGamesSaved.Length; a++)
            {
                lbox_savedgames.Items.Add(fileGamesSaved[a].ToString());
            }


        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            if (lbox_savedgames.Items.Count == 0)
            {
                lb_status.ForeColor = Color.Red;
                lb_status.Text = "No existen partidas para cargar";
            }

            else if (lbox_savedgames.SelectedItem == null)
            {
                lb_status.ForeColor = Color.Red;
                lb_status.Text = "Seleccione una partida";
            }
            else
            {
                bool verification = LoadGame(lbox_savedgames.SelectedItem.ToString());

                if(verification == true)
                {
                    FormGame formGame = new FormGame(this.game);

                    formGame.Show();

                    MessageBox.Show("Cargado con exito");
                    Close();
                }
                else
                {

                }
            }
        }

        private bool LoadGame(string nameFile)
        {
            if (nameFile == null)
            {
                return false;
            }
            else
            {
                IFormatter formatter = new BinaryFormatter();
                string path = "../../Resources/Savegames/" + nameFile;
                Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
                this.game = (Game)formatter.Deserialize(stream);

                stream.Close();

                return true;
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            FormMain formMain = new FormMain();

            formMain.Show();
            Close();
        }
    }
}

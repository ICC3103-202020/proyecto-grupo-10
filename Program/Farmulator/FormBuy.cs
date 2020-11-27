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
using Farmulator.Classes.nsGame.nsMap.nsTerrains.nsBuilds.nsProductions.nsProducts;
using Farmulator.Classes.nsGame.nsMap.nsTerrains.nsBuilds.nsProductions.nsProducts.nsConsumables;
using Farmulator.Classes.nsGame.nsMap.nsTerrains.nsBuilds.nsProductions;
using Farmulator.Classes.nsGame.nsMap.nsTerrains.nsBuilds;
using Farmulator.Classes.nsGame.nsMap.nsTerrains;
using Farmulator.Classes.nsGame.nsMap.nsAssets;
using Farmulator.Classes.nsGame.nsMarket;

namespace Farmulator
{
    partial class FormBuy : Form
    {
        private List<PriceProduct> seeds;
        private List<PriceProduct> animals;
        private List<Ranch> ranchs;
        private List<Land> lands;
        private List<Storage> storages;
        private List<PriceConsumable> consumables;
        private List<PriceTerrain> terrains;
        private Farm farm;
        private Market market;
        private Game game;
        private int typeBuy;
        public FormBuy(Game game)
        {
            InitializeComponent();

            this.game = game;
            this.market = this.game.GetMarket();
            this.farm = this.game.GetMap().GetFarm();
            this.seeds = new List<PriceProduct>();
            this.animals = new List<PriceProduct>();
            this.ranchs = new List<Ranch>();
            this.lands = new List<Land>();
            this.storages = new List<Storage>();
            this.consumables = new List<PriceConsumable>();
            this.terrains = new List<PriceTerrain>();
            this.typeBuy = 1;

        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_buy_Click(object sender, EventArgs e)
        {

        }

        private void FormBuy_Load(object sender, EventArgs e)
        {
            //AGREGAMOS PRODUCTOS

            for (int product = 0; product < market.GetPricesProducts().Count; product++)
            {
                if (market.GetPricesProducts()[product].GetProduct().GetType().Equals(typeof(Seed)))
                {
                    seeds.Add(market.GetPricesProducts()[product]);
                }

                if (market.GetPricesProducts()[product].GetProduct().GetType().Equals(typeof(Animal)))
                {
                    animals.Add(market.GetPricesProducts()[product]);
                }
            }

            //AGREGAMOS CONSTRUCCIONES

            for (int build = 0; build < game.GetBuilds().Count; build++)
            {
                if (game.GetBuilds()[build].GetType().Equals(typeof(Storage)))
                {
                    Storage storage = (Storage)game.GetBuilds()[build];

                    storages.Add(storage);
                }

                if (game.GetBuilds()[build].GetType().Equals(typeof(Land)))
                {
                    Land land = (Land)game.GetBuilds()[build];

                    lands.Add(land);
                }

                if (game.GetBuilds()[build].GetType().Equals(typeof(Ranch)))
                {
                    Ranch ranch = (Ranch)game.GetBuilds()[build];

                    ranchs.Add(ranch);
                }
            }

            //AGREGAMOS CONSUMIBLES

            for(int consumable = 0; consumable < market.GetPricesConsumables().Count; consumable++)
            {
                consumables.Add(market.GetPricesConsumables()[consumable]);
            }

            //AGREGAMOS LOS TERRENOS

            for(int terrain = 0; terrain < market.GetPricesTerrains().Count; terrain++)
            {
                terrains.Add(market.GetPricesTerrains()[terrain]);
            }

            //--------------------------------
            for (int a = 0; a < lands.Count; a++)
            {

                lbox_products.Items.Add(lands[a].GetName());

                if (a == 0)
                {
                    lbox_products.SelectedItem = lands[a].GetName();
                }
            }

            SetProduct(typeBuy);

        }

        private void btn_up_Click(object sender, EventArgs e)
        {
            lb_quantityconsumable.Text = "1";

            if (lbox_products.Items.Count - 1 == lbox_products.SelectedIndex)
            {
                lbox_products.SelectedIndex = 0;

                SetProduct(typeBuy);
            }
            else
            {
                lbox_products.SelectedIndex += 1;
                SetProduct(typeBuy);
            }
        }

        private void SetProduct(int type)
        {

            if (type == 1)
            {
                for (int b = 0; b < lands.Count; b++)
                {
                    if (lands[b].GetName() == lbox_products.SelectedItem.ToString())
                    {
                        lb_nameproduct.Text = lbox_products.SelectedItem.ToString();

                        pb_product.Image = lands[b].GetImg();
                        pb_product.SizeMode = PictureBoxSizeMode.StretchImage;

                        lb_description.Text = "Tiempo maduracion: " + lands[b].GetSeed().GetTimeProduction().ToString() +
                            "\nMin nutrientes: " + lands[b].GetSeed().GetMinNutrients().ToString();

                        for (int c = 0; c < seeds.Count; c++)
                        {
                            Seed seed = (Seed)seeds[c].GetProduct();

                            if (seed.GetName() == lands[b].GetSeed().GetName())
                            {
                                Console.WriteLine("ENTRAR");
                                lb_numberprice.Text = (lands[b].GetBuyPrice() + seeds[c].GetPricesHistory()[seeds[c].GetPricesHistory().Count - 1]).ToString();
                            }
                        }

                        int own = 0;

                        for (int d = 0; d < this.farm.GetTerrains().Count; d++)
                        {
                            if (this.farm.GetTerrains()[d].GetBuild() != null)
                            {
                                if (this.farm.GetTerrains()[d].GetBuild().GetType().Equals(typeof(Land)))
                                {
                                    Land land = (Land)this.farm.GetTerrains()[d].GetBuild();

                                    if (land.GetName() == lands[b].GetName())
                                    {
                                        own += 1;
                                    }
                                }
                            }

                        }

                        lb_numberown.Text = own.ToString();
                    }
                }
            }

            else if (type == 2)
            {
                for (int b = 0; b < ranchs.Count; b++)
                {
                    if (ranchs[b].GetName() == lbox_products.SelectedItem.ToString())
                    {
                        lb_nameproduct.Text = lbox_products.SelectedItem.ToString();

                        pb_product.Image = ranchs[b].GetImg();
                        pb_product.SizeMode = PictureBoxSizeMode.StretchImage;

                        lb_description.Text = "Tiempo maduracion: " + ranchs[b].GetAnimal().GetTimeProduction().ToString() +
                            "\nMin comida: " + ranchs[b].GetAnimal().GetMinFood().ToString();

                        for (int c = 0; c < animals.Count; c++)
                        {
                            Animal animal = (Animal)animals[c].GetProduct();

                            if (animal.GetName() == ranchs[b].GetAnimal().GetName())
                            {
                                Console.WriteLine("ENTRAR");
                                lb_numberprice.Text = (ranchs[b].GetBuyPrice() + animals[c].GetInitialPrice()).ToString();
                            }
                        }

                        int own = 0;

                        for (int d = 0; d < this.farm.GetTerrains().Count; d++)
                        {
                            if (this.farm.GetTerrains()[d].GetBuild() != null)
                            {
                                if (this.farm.GetTerrains()[d].GetBuild().GetType().Equals(typeof(Ranch)))
                                {
                                    Ranch ranch = (Ranch)this.farm.GetTerrains()[d].GetBuild();

                                    if (ranch.GetName() == ranchs[b].GetName())
                                    {
                                        own += 1;
                                    }
                                }
                            }

                        }

                        lb_numberown.Text = own.ToString();
                    }
                }
            }

            else if (type == 3)
            {
                for (int b = 0; b < storages.Count; b++)
                {
                    if (storages[b].GetName() == lbox_products.SelectedItem.ToString())
                    {
                        lb_nameproduct.Text = lbox_products.SelectedItem.ToString();

                        pb_product.Image = storages[b].GetImg();
                        pb_product.SizeMode = PictureBoxSizeMode.StretchImage;

                        lb_description.Text = "Capacidad max: " + storages[b].GetMaxCapacity().ToString();

                        lb_numberprice.Text = storages[b].GetBuyPrice().ToString();

                        int own = 0;

                        for (int d = 0; d < this.farm.GetTerrains().Count; d++)
                        {
                            if (this.farm.GetTerrains()[d].GetBuild() != null)
                            {
                                if (this.farm.GetTerrains()[d].GetBuild().GetType().Equals(typeof(Storage)))
                                {
                                    Storage storage = (Storage)this.farm.GetTerrains()[d].GetBuild();

                                    if (storage.GetName() == storages[b].GetName())
                                    {
                                        own += 1;
                                    }
                                }
                            }

                        }

                        lb_numberown.Text = own.ToString();
                    }
                }
            }

            else if (type == 4)
            {
                string name = "";
                string description = "";
                string value = "";
                Bitmap consumableImg = null;

                for (int b = 0; b < consumables.Count; b++)
                {
                    if (consumables[b].GetConsumable().GetType().Equals(typeof(Pesticide)))
                    {
                        Pesticide pesticide = (Pesticide)consumables[b].GetConsumable();
                        name = pesticide.GetName();
                        consumableImg = pesticide.GetImg();
                        description = pesticide.GetDescription();
                        value = consumables[b].GetPrice().ToString();
                    }

                    if (consumables[b].GetConsumable().GetType().Equals(typeof(Herbicide)))
                    {
                        Herbicide pesticide = (Herbicide)consumables[b].GetConsumable();
                        name = pesticide.GetName();
                        consumableImg = pesticide.GetImg();
                        description = pesticide.GetDescription();
                        value = consumables[b].GetPrice().ToString();
                    }

                    if (consumables[b].GetConsumable().GetType().Equals(typeof(Fungicide)))
                    {
                        Fungicide pesticide = (Fungicide)consumables[b].GetConsumable();
                        name = pesticide.GetName();
                        consumableImg = pesticide.GetImg();
                        description = pesticide.GetDescription();
                        value = consumables[b].GetPrice().ToString();
                    }

                    if (consumables[b].GetConsumable().GetType().Equals(typeof(Fertilizer)))
                    {
                        Fertilizer pesticide = (Fertilizer)consumables[b].GetConsumable();
                        name = pesticide.GetName();
                        consumableImg = pesticide.GetImg();
                        description = pesticide.GetDescription();
                        value = consumables[b].GetPrice().ToString();
                    }

                    if (consumables[b].GetConsumable().GetType().Equals(typeof(Irrigation)))
                    {
                        Irrigation pesticide = (Irrigation)consumables[b].GetConsumable();
                        name = pesticide.GetName();
                        consumableImg = pesticide.GetImg();
                        description = pesticide.GetDescription();
                        value = consumables[b].GetPrice().ToString();
                    }

                    if (consumables[b].GetConsumable().GetType().Equals(typeof(Vaccine)))
                    {
                        Vaccine pesticide = (Vaccine)consumables[b].GetConsumable();
                        name = pesticide.GetName();
                        consumableImg = pesticide.GetImg();
                        description = pesticide.GetDescription();
                        value = consumables[b].GetPrice().ToString();
                    }

                    if (consumables[b].GetConsumable().GetType().Equals(typeof(AnimalFood)))
                    {
                        AnimalFood pesticide = (AnimalFood)consumables[b].GetConsumable();
                        name = pesticide.GetName();
                        consumableImg = pesticide.GetImg();
                        description = pesticide.GetDescription();
                        value = consumables[b].GetPrice().ToString();
                    }

                    if (consumables[b].GetConsumable().GetType().Equals(typeof(AnimalWater)))
                    {
                        AnimalWater pesticide = (AnimalWater)consumables[b].GetConsumable();
                        name = pesticide.GetName();
                        consumableImg = pesticide.GetImg();
                        description = pesticide.GetDescription();
                        value = consumables[b].GetPrice().ToString();
                    }

                    if (name == lbox_products.SelectedItem.ToString())
                    {
                        lb_nameproduct.Text = lbox_products.SelectedItem.ToString();

                        pb_product.Image = consumableImg;
                        pb_product.SizeMode = PictureBoxSizeMode.StretchImage;

                        lb_description.Text = description;

                        lb_numberprice.Text = value;

                        int own = 0;

                        for (int d = 0; d < this.farm.GetConsumables().Count; d++)
                        {
                            if (this.farm.GetConsumables()[d].GetType().Equals(consumables[b].GetType()))
                            {
                                own += 1;
                            }

                        }

                        lb_numberown.Text = own.ToString();
                    }
                }
            }

            else if (type == 5)
            {
                string nameTerrain = "";

                for (int b = 0; b < 100; b++)
                {
                    nameTerrain = "[" + (b / 10).ToString() + "," + (b % 10).ToString() + "]";

                    if (nameTerrain == lbox_products.SelectedItem.ToString())
                    {
                        lb_nameproduct.Text = lbox_products.SelectedItem.ToString();

                        pb_product.Image = new Bitmap("../../Resources/Assets/terrain.gif");
                        pb_product.SizeMode = PictureBoxSizeMode.StretchImage;

                        lb_description.Text = "Perfecto para cultivar";

                        for (int c = 0; c < terrains.Count; c++)
                        {
                            if (game.GetMap().GetTerrains()[b/10,b%10].Equals(terrains[c].GetTerrain()))
                            {
                                Console.WriteLine("ENTRAR");
                                lb_numberprice.Text = terrains[c].GetPrice().ToString();
                            }
                        }

                        int own = 0;

                        lb_numberown.Text = own.ToString();
                    }
                }
            }
        }

        private void btn_ranch_Click(object sender, EventArgs e)
        {
            this.typeBuy = 2;

            lb_quantityconsumable.Visible = false;
            btn_addconsumable.Visible = false;
            btn_subtractconsumable.Visible = false;

            lbox_products.Items.Clear();

            for (int a = 0; a < ranchs.Count; a++)
            {

                lbox_products.Items.Add(ranchs[a].GetName());

                if (a == 0)
                {
                    lbox_products.SelectedItem = ranchs[a].GetName();
                }
            }

            SetProduct(typeBuy);
        }

        private void btn_down_Click(object sender, EventArgs e)
        {
            lb_quantityconsumable.Text = "1";

            if (lbox_products.SelectedIndex == 0)
            {
                lbox_products.SelectedIndex = lbox_products.Items.Count - 1;

                SetProduct(typeBuy);
            }
            else
            {
                lbox_products.SelectedIndex -= 1;
                SetProduct(typeBuy);
            }
        }

        private void btn_land_Click(object sender, EventArgs e)
        {
            this.typeBuy = 1;

            lb_quantityconsumable.Visible = false;
            btn_addconsumable.Visible = false;
            btn_subtractconsumable.Visible = false;

            lbox_products.Items.Clear();

            for (int a = 0; a < lands.Count; a++)
            {

                lbox_products.Items.Add(lands[a].GetName());

                if (a == 0)
                {
                    lbox_products.SelectedItem = lands[a].GetName();
                }
            }

            SetProduct(typeBuy);
        }

        private void btn_storage_Click(object sender, EventArgs e)
        {
            this.typeBuy = 3;

            lb_quantityconsumable.Visible = false;
            btn_addconsumable.Visible = false;
            btn_subtractconsumable.Visible = false;

            lbox_products.Items.Clear();

            for (int a = 0; a < storages.Count; a++)
            {

                lbox_products.Items.Add(storages[a].GetName());

                if (a == 0)
                {
                    lbox_products.SelectedItem = storages[a].GetName();
                }
            }

            SetProduct(typeBuy);
        }

        private void btn_consumables_Click(object sender, EventArgs e)
        {
            this.typeBuy = 4;

            lbox_products.Items.Clear();

            lb_quantityconsumable.Visible = true;
            btn_addconsumable.Visible = true;
            btn_subtractconsumable.Visible = true;

            string name = "";

            for (int a = 0; a < consumables.Count; a++)
            {
                Console.WriteLine("Funciona");

                if (consumables[a].GetConsumable().GetType().Equals(typeof(Pesticide)))
                {
                    Pesticide pesticide = (Pesticide)consumables[a].GetConsumable();
                    name = pesticide.GetName();
                }

                if (consumables[a].GetConsumable().GetType().Equals(typeof(Herbicide)))
                {
                    Herbicide pesticide = (Herbicide)consumables[a].GetConsumable();
                    name = pesticide.GetName();
                }

                if (consumables[a].GetConsumable().GetType().Equals(typeof(Fungicide)))
                {
                    Fungicide pesticide = (Fungicide)consumables[a].GetConsumable();
                    name = pesticide.GetName();
                }

                if (consumables[a].GetConsumable().GetType().Equals(typeof(Fertilizer)))
                {
                    Fertilizer pesticide = (Fertilizer)consumables[a].GetConsumable();
                    name = pesticide.GetName();
                }

                if (consumables[a].GetConsumable().GetType().Equals(typeof(Irrigation)))
                {
                    Irrigation pesticide = (Irrigation)consumables[a].GetConsumable();
                    name = pesticide.GetName();
                }

                if (consumables[a].GetConsumable().GetType().Equals(typeof(Vaccine)))
                {
                    Vaccine pesticide = (Vaccine)consumables[a].GetConsumable();
                    name = pesticide.GetName();
                }

                if (consumables[a].GetConsumable().GetType().Equals(typeof(AnimalFood)))
                {
                    AnimalFood pesticide = (AnimalFood)consumables[a].GetConsumable();
                    name = pesticide.GetName();
                }

                if (consumables[a].GetConsumable().GetType().Equals(typeof(AnimalWater)))
                {
                    AnimalWater pesticide = (AnimalWater)consumables[a].GetConsumable();
                    name = pesticide.GetName();
                }

                lbox_products.Items.Add(name);

                if (a == 0)
                {
                    lbox_products.SelectedItem = name;
                }
            }

            SetProduct(typeBuy);
        }

        private void btn_addconsumable_Click(object sender, EventArgs e)
        {
            int value = Int32.Parse(lb_quantityconsumable.Text);

            if (lb_quantityconsumable.Text == "20")
            {
                return;
            }
            else
            {
                
                lb_quantityconsumable.Text = (value + 1).ToString();

                lb_numberprice.Text = ((Int32.Parse(lb_numberprice.Text) / value) * (value + 1)).ToString();
            }
        }

        private void btn_subtractconsumable_Click(object sender, EventArgs e)
        {
            int value = Int32.Parse(lb_quantityconsumable.Text);

            if (lb_quantityconsumable.Text == "1")
            {
                return;
            }
            else
            {
                lb_quantityconsumable.Text = (value - 1).ToString();

                lb_numberprice.Text = ((Int32.Parse(lb_numberprice.Text) / value) * (value - 1)).ToString();
            }
        }

        private void btn_terrain_Click(object sender, EventArgs e)
        {
            this.typeBuy = 5;

            lb_quantityconsumable.Visible = false;
            btn_addconsumable.Visible = false;
            btn_subtractconsumable.Visible = false;

            lbox_products.Items.Clear();

            for (int a = 0; a < terrains.Count; a++)
            {
                string namePosition = "";

                for(int i = 0; i < 100; i++)
                {
                    namePosition = "[" + (i / 10).ToString() + "," + (i % 10).ToString() + "]";

                    if (farm.GetTerrains().Contains(game.GetMap().GetTerrains()[i / 10, i % 10]))
                    {
                        continue;
                    }
                    else
                    {
                        lbox_products.Items.Add(namePosition);

                        if (a == 0)
                        {
                            lbox_products.SelectedItem = namePosition;
                        }
                    }
                }
                
            }

            SetProduct(typeBuy);
        }
    }
    
}

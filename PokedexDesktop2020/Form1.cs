using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;
using Dominio;

namespace PokedexDesktop2020
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargarGrilla();
        }

        private void cargarGrilla()
        {
            try
            {
                PokemonNegocio negocio = new PokemonNegocio();
                dgvPokemons.DataSource = negocio.listar();
                dgvPokemons.Columns[0].Visible = false;
                dgvPokemons.Columns[3].Visible = false;
                dgvPokemons.Columns[4].Visible = false;
            }
            catch (NoMeGustaException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvPokemons_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                Pokemon poke;
                poke = (Pokemon)dgvPokemons.CurrentRow.DataBoundItem;
                picPoke.Load(poke.ImagenURL);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAltaPokemon alta = new frmAltaPokemon();
            alta.ShowDialog();
            cargarGrilla();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Pokemon modi = (Pokemon)dgvPokemons.CurrentRow.DataBoundItem;
            frmAltaPokemon alta = new frmAltaPokemon(modi);
            alta.ShowDialog();
            cargarGrilla();
        }
    }
}

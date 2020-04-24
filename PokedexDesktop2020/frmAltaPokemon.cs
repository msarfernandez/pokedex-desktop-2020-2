using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;

namespace PokedexDesktop2020
{
    public partial class frmAltaPokemon : Form
    {
        private Pokemon pokemon = null;
        public frmAltaPokemon()
        {
            InitializeComponent();
        }
        public frmAltaPokemon(Pokemon poke)
        {
            InitializeComponent();
            pokemon = poke;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            PokemonNegocio negocio = new PokemonNegocio();
            try
            {
                if (pokemon == null)
                    pokemon = new Pokemon();

                pokemon.Nombre = txtNombre.Text.Trim();
                pokemon.ImagenURL = txtUrlImagen.Text.Trim();
                pokemon.Tipo = (Tipo)cboTipo.SelectedItem;
                // pokemon.Precio = double.Parse(txtPrecio.Text);

                if (pokemon.Id == null)
                    negocio.agregar(pokemon);
                else
                    negocio.modificar(pokemon);

                Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmAltaPokemon_Load(object sender, EventArgs e)
        {
            TipoNegocio tipo = new TipoNegocio();
            try
            {
                cboTipo.DataSource = tipo.listar();
                cboTipo.DisplayMember = "Descripcion";
                cboTipo.ValueMember = "Id";


                if(pokemon != null)
                {
                    txtNombre.Text = pokemon.Nombre;
                    cboTipo.SelectedValue = pokemon.Tipo.Id;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

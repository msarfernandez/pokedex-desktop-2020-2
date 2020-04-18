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
        public frmAltaPokemon()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Pokemon nuevo = new Pokemon();
            PokemonNegocio negocio = new PokemonNegocio();
            try
            {
                nuevo.Nombre = txtNombre.Text.Trim();
                nuevo.ImagenURL = txtUrlImagen.Text.Trim();
                nuevo.Tipo = (Tipo)cboTipo.SelectedItem;

                negocio.agregar(nuevo);

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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

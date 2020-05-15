using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PokemonWeb
{
    public partial class AltaPokemon : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // txtEmail.Text = "pokemon@utn.com";
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {

            Session.Add(Session.SessionID + "nombreBienvenida", txtEmail.Text);
            Response.Redirect("Bienvenida.aspx");
        }
    }
}
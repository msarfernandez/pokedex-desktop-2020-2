<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PokemonIndex.aspx.cs" Inherits="PokemonWeb.PokemonIndex" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:GridView CssClass="table" ID="dgvPokemons" runat="server"></asp:GridView>

</asp:Content>

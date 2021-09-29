<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="BadRequest.aspx.cs" Inherits="PaginaWebClinina.BadRequest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="text-center">
        <h3>No tiene permisos para acceder a la ruta. Habilite los permisos y vuelva a iniciar sesión.</h3>
        <br />
         <asp:Button ID="btnReturn" CssClass="btn btn-primary" runat="server" Text="Regresar" OnClick="btnReturn_Click" />
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>

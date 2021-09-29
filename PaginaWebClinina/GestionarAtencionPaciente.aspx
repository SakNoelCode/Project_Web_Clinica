<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="GestionarAtencionPaciente.aspx.cs" Inherits="PaginaWebClinina.GestionarAtencionPaciente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="content-header">
        <div class="text-center">
            <h1>GESTIONAR ATENCIÓN MÉDICA</h1>
            <asp:Label ID="lblFechaAtencion" runat="server" Font-Bold="true"></asp:Label>
        </div>
        <br />
        <br />
        <div class="row">
            <div class="col-md-1"></div>
            <div class="col-md-10">
                <div class="box box-primary row">
                    <div class="box-header">
                        <h3 class="box-title">Menu de búsqueda:</h3>
                    </div>
                    <div class="box-body">
                        <div class="col-md-3">
                            <div class="form-group">
                                <asp:DropDownList ID="ddlBuscar" runat="server" CssClass="form-control">
                                    <asp:ListItem>DNI</asp:ListItem>
                                    <asp:ListItem>Fecha</asp:ListItem>
                                    <asp:ListItem>Especialidad</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class=" form-group">
                                <asp:TextBox ID="txtBuscar" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" class="btn btn-facebook center-block btnBuscar" OnClick="btnBuscar_Click" />
                            </div>
                        </div>
                    </div>
                    <br />
                    <br />
                </div>
            </div>
            <div class="col-md-1"></div>
        </div>
    </section>
    <section class="content invoice">
        <!-- LISTA DE LAS CITAS MÉDICAS QUE FUERON REGISTRADAS PARA EL DÍA ACTUAL -->
        <asp:DataList ID="dlAtencionMedica" runat="server" CssClass="table table-striped" RepeatColumns="1" OnItemCommand="dlAtencionMedica_ItemCommand">
            <ItemTemplate>
                <table>
                    <tr>
                        <td rowspan="2">
                            <asp:Image ID="imgPaciente" runat="server" Height="200px" Width="200px" ImageUrl="~/img/avatar3.png" />
                        </td>
                        <td>
                            <strong>&nbsp;&nbsp;ID Cita:&nbsp;&nbsp;&nbsp;&nbsp;</strong>
                            <asp:Label ID="lblIdCita" runat="server" Text='<%#Eval("IdCita") %>' Font-Size="Medium"></asp:Label><br />
                            <asp:HiddenField ID="hdIdCita" runat="server" Value='<%#Eval("IdCita") %>' Visible="false" />
                            <strong>&nbsp;&nbsp;Nombres y Apellidos:&nbsp;&nbsp;&nbsp;&nbsp;</strong>
                            <asp:Label ID="lblNombres" runat="server" Text='<%#Eval("Paciente.Nombres")+" "+Eval("Paciente.ApPaterno")+" "+Eval("Paciente.ApMaterno") %>' Font-Size="Medium"></asp:Label><br />
                            <strong>&nbsp;&nbsp;DNI:&nbsp;&nbsp;&nbsp;&nbsp;</strong>
                            <asp:Label ID="lblDNI" runat="server" Text='<%#Eval("Paciente.nroDocumento") %>' Font-Size="Medium"></asp:Label><br />
                            <strong>&nbsp;&nbsp;Fecha:&nbsp;&nbsp;&nbsp;&nbsp;</strong>
                            <asp:Label ID="lblFecha" runat="server" Text='<%#Eval("fechaReserva","{0:dd/MM/yyyy}") %>' Font-Size="Medium"></asp:Label><br />
                            <strong>&nbsp;&nbsp;Hora:&nbsp;&nbsp;&nbsp;&nbsp;</strong>
                            <asp:Label ID="lblHora" runat="server" Text='<%#Eval("Hora") %>' Font-Size="Medium"></asp:Label><br />
                            <strong>&nbsp;&nbsp;Especialidad:&nbsp;&nbsp;&nbsp;&nbsp;</strong>
                            <asp:Label ID="lblEspecialidad" runat="server" Text='<%#Eval("Medico.Especialidad.Descripcion") %>' Font-Size="Medium"></asp:Label><br />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;&nbsp;<asp:Button ID="btnAtencion" runat="server" CssClass="btn btn-primary " Text="Realizar Atención" CommandName="Registrar" />
                        </td>
                        <td>&nbsp;&nbsp;<asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-danger " Text="Cancelar" CommandName="Cancelar" OnClientClick="return confirm('¿Esta seguro que desea cancelar la Cita?')" />
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:DataList>
    </section>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
    
</asp:Content>

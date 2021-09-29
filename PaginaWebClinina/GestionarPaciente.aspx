<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="GestionarPaciente.aspx.cs" Inherits="PaginaWebClinina.GestionarPaciente" ClientIDMode="Static" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/CssPersonalizado/Paciente.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="content-header">
        <h1 style="text-align: center">REGISTRO DE PACIENTES</h1>
    </section>
    <section class="content">
        <div style="width: 100%" class="row">
            <div class="col-md-6">
                <div class="box box-primary">
                    <div class="box-body">
                        <div class="form-group">
                            <label for="txtNroDocumento" class="formulario__label">DOCUMENTO DE IDENTIDAD</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtNroDocumento" runat="server" Text="" MaxLength="8" CssClass="form-control formulario__input"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="evDNI" runat="server" ErrorMessage="El DNI solo debe contener 8 digitos y deben ser números" ControlToValidate="txtNroDocumento" ForeColor="#FF3300" ValidationExpression="[0-9]{8}" ValidationGroup="DatosRequeridos"></asp:RegularExpressionValidator>
                        </div>
                        <div class="form-group">
                            <label for="txtNombres" class="formulario__label">NOMBRES</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtNombres" runat="server" Text="" CssClass="form-control formulario__input"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="evNombres" runat="server" ErrorMessage="El nombre solo contiene letras y espacios" ControlToValidate="txtNombres" ForeColor="#FF3300" ValidationExpression="[a-zA-ZÀ-ÿ\s]{1,40}" ValidationGroup="DatosRequeridos"></asp:RegularExpressionValidator>
                        </div>
                        <div class="form-group">
                            <label for="txtApPaterno" class="formulario__label">APELLIDO PATERNO</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtApPaterno" runat="server" Text="" CssClass="form-control formulario__input"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="evApPaterno" runat="server" ErrorMessage="El apellido solo contiene letras" ControlToValidate="txtApPaterno" ForeColor="#FF3300" ValidationExpression="[a-zA-ZÀ-ÿ]{1,30}" ValidationGroup="DatosRequeridos"></asp:RegularExpressionValidator>
                        </div>
                        <div class="form-group">
                            <label for="txtApMaterno" class="formulario__label">APELLIDO MATERNO</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtApMaterno" runat="server" Text="" CssClass="form-control formulario__input"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="evApMaterno" runat="server" ErrorMessage="El apellido solo contiene letras" ControlToValidate="txtApMaterno" ForeColor="#FF3300" ValidationExpression="[a-zA-ZÀ-ÿ]{1,30}" ValidationGroup="DatosRequeridos"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="box box-primary">
                    <div class="box-body">
                        <div class="form-group">
                            <label for="ddlSexo" class="formulario__label">SEXO</label>
                        </div>
                        <div class="form-group">
                            <asp:DropDownList ID="ddlSexo" runat="server" CssClass="form-control formulario__input">
                                <asp:ListItem>Masculino</asp:ListItem>
                                <asp:ListItem>Femenino</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RegularExpressionValidator ID="evSexo" runat="server" ErrorMessage="Debe ingresar un sexo" ControlToValidate="ddlSexo" ForeColor="#FF3300" ValidationExpression="[a-zA-Z]{1,10}" ValidationGroup="DatosRequeridos"></asp:RegularExpressionValidator>
                        </div>
                        <div class="form-group">
                            <label for="txtEdad" class="formulario__label">EDAD</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtEdad" runat="server" Text="" CssClass="form-control formulario__input"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="evEdad" runat="server" ErrorMessage="Ingrese una edad correcta" ControlToValidate="txtEdad" ForeColor="#FF3300" ValidationExpression="[0-9]{1,2}" ValidationGroup="DatosRequeridos"></asp:RegularExpressionValidator>
                        </div>
                        <div class="form-group">
                            <label for="txtTelefono" class="formulario__label">TELÉFONO</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtTelefono" runat="server" Text="" CssClass="form-control formulario__input"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="evTelefono" runat="server" ErrorMessage="El telefono solo contiene numeros" ControlToValidate="txtTelefono" ForeColor="#FF3300" ValidationExpression="\d{9,14}$" ValidationGroup="DatosRequeridos"></asp:RegularExpressionValidator>
                        </div>
                        <div class="form-group">
                            <label for="txtDireccion" class="formulario__label">DIRECCIÓN</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtDireccion" runat="server" Text="" CssClass="form-control formulario__input"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="evDireccion" runat="server" ErrorMessage="Dirección Incorrecta" ControlToValidate="txtDireccion" ForeColor="#FF3300" ValidationExpression=".{0,40}" ValidationGroup="DatosRequeridos"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div>
                <p class="formulario__mensaje" id="formulario__mensaje">
                    <i class="fas fa-exclamation-triangle"></i>
                    <b>Error:</b> Rellene los campos correctamente
                </p>
            </div>
        </div>

        <div align="center">
            <table>
                <tr>
                    <td>
                        <asp:Button ID="btnRegistrar" runat="server" CssClass="btn btn-primary" Width="200px" Text="Registrar" OnClick="btnRegistrar_Click" ValidationGroup="DatosRequeridos" />
                    </td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td>
                        <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-danger" Width="200px" Text="Cancelar" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <!-- Datatable Part -->

        <div class="row" style="width: 100%">
            <div class="col-xs-12">
                <div class="box box-primary">
                    <div class="box-header">
                        <h3 class="box-title">Lista de Pacientes</h3>
                    </div>
                    <div class="box-body table-responsive">
                        <table id="tbl_pacientes" class="table table-bordered table-hover text-center">
                            <thead>
                                <tr>
                                    <th>Código</th>
                                    <th>Nombres</th>
                                    <th>Apellidos</th>
                                    <th>Nro Documento</th>  
                                    <th>Sexo</th>
                                    <th>Edad</th>
                                    <th>Dirección</th>
                                    <th>Acciones</th>
                                </tr>
                            </thead>
                            <tbody id="tbl_body_table">
                                <!-- DATA POR MEDIO DE AJAX-->
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
        <!-- End Datatable -->
    </section>

    <!--Modal Parte-->
    <div class="modal fade" id="imodal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title" id="myModalLabel">Actualizar registro</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label>NOMBRES Y APELLIDOS</label>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="txtFullName" runat="server" Text="" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>DIRECCIÓN</label>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="txtModalDireccion" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-primary" id="btnactualizar">Actualizar</button>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
    <script src="js/paciente.js" type="text/javascript"></script>
    <script src="https://kit.fontawesome.com/2c36e9b7b1.js"></script>
</asp:Content>



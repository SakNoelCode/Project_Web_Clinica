<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="GestionarUsuario.aspx.cs" Inherits="PaginaWebClinina.GestionarUsuario" ClientIDMode="Static"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <section class="content-header">
     <h1 style="text-align: center">REGISTRO DE USUARIOS</h1>
     </section>
    <section class="content">
    <div class="box-header">
       <h3 style="text-align: center" class="box-title">DATOS DEL EMPLEADO</h3>
      </div>
                    <div class="row">
                    <div class="col-md-9">
                        <div class="box box-primary">
                            <div class="box-body">
                                <div class="form-group">
                                    <label>DOCUMENTO DE IDENTIDAD</label>
                                </div>
                                <div class="input-group">
                                    <asp:TextBox ID="txtDNI" CssClass="form-control" runat="server" MaxLength="8"></asp:TextBox>
                                    <div class="input-group-btn">
                                        <asp:Button ID="btnBuscar" runat="server" CssClass="btn btn-danger" Text="BUSCAR" />
                                    </div>
                                </div>
                                <br />
                                <div class="form-group">
                                    <label>NOMBRES</label>
                                    <asp:TextBox ID="txtNombres" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label>APELLIDOS</label>
                                    <asp:TextBox ID="txtApellidos" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label>TIPO EMPLEADO</label>
                                    <asp:TextBox ID="txtTipoEmpleado" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="box box-primary">
                            <div class="box-body">
                                <div class="form-group">
                                    <img src="img/usuario.jpg"/>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div Style="width:100%" class="row">
            <div class="col-md-4">
                <div class="box box-primary">
                    <div class="box-body">
                       
                        <div class="form-group">
                            <label>USUARIO</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtUsuario" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                        </div>

                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="box box-primary">
                    <div class="box-body">

                        <div class="form-group">
                            <label>CONTRASEÑA</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtContraseña" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                        </div>

                    </div>
                </div>
            </div>
                     <div class="col-md-4">
                <div class="box box-primary">
                    <div class="box-body">
                       
                        <div class="form-group">
                            <label>ROL</label>
                        </div>
                        <div class="form-group">
                             <asp:DropDownList ID="ddlTipoUsuario" runat="server" CssClass="form-control">
                                <asp:ListItem>Administrador</asp:ListItem>
                                <asp:ListItem>Invitado</asp:ListItem>
                            </asp:DropDownList>                          </div>

                    </div>
                </div>
            </div>
        </div>
                <div align="center">
            <table>
                <tr>
                    <td>
                        <asp:Button ID="btnRegistrar" runat="server" CssClass="btn btn-primary" Width="200px" Text="Registrar" OnClick="btnRegistrar_Click" />
                    </td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td>
                        <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-danger" Width="200px" Text="Limpiar" OnClick="btnCancelar_Click"  />
                    </td>
                     <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td>
                        <asp:Button ID="btnActualizar" runat="server" CssClass="btn btn-primary" Width="200px" Text="Actualizar" OnClick="btnActualizar_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <!-- Datatable Part -->

        <div class="row" style="width:100%">
            <div class="col-xs-12">
                <div class="box box-primary">
                    <div class="box-header">
                        <h3 class="box-title">Lista de Usuarios</h3>
                    </div>
                    <div class="box-body table-responsive">
                        <table id="tbl_usuarios" class="table table-bordered table-hover text-center">
                            <thead>
                                <tr>
                                    <th>Código</th>
                                    <th>Nombres</th>
                                    <th>Apellidos</th>
                                    <th>Nro Documento</th>
                                    <th>Usuario</th>
                                    <th>Contraseña</th>
                                    <th>Tipo Usuario</th>
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
         </section>
     <asp:HiddenField ID="idEmpleado" runat="server" />
     <asp:HiddenField ID="idUsuario" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
   <script src="js/usuario.js" type="text/javascript"></script>
</asp:Content>
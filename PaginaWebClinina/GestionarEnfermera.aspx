<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="GestionarEnfermera.aspx.cs" Inherits="PaginaWebClinina.GestionarEnfermera" ClientIDMode="Static" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <section class="content-header">
        <h1 style="text-align: center">REGISTRO DE ENFERMERAS</h1>
    </section>
    <section class="content">
        <div Style="width:100%" class="row">
            <div class="col-md-6">
                <div class="box box-primary">
                    <div class="box-body">
                       
                        <div class="form-group">
                            <label>DOCUMENTO DE IDENTIDAD</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtNroDocumento" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>NOMBRES</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtNombres" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>APELLIDO PATERNO</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtApPaterno" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>APELLIDO MATERNO</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtApMaterno" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                        </div>
                         <div class="form-group">
                          <label>TIPO</label>
                          <asp:DropDownList ID="ddlTipoEnfermera" runat="server" CssClass="form-control">
                                <asp:ListItem>Técnica</asp:ListItem>
                                <asp:ListItem>Licenciada</asp:ListItem>
                            </asp:DropDownList>  
                         </div>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="box box-primary">
                    <div class="box-body">
                        <div class="form-group">
                            <img src="img/médica-700x427.jpg"/>
                        </div>
                        <div class="form-group">
                            <label>Tipo Empleado</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtTipoEnfermera" runat="server" Text="Enfermera" Enabled="false" CssClass="form-control"></asp:TextBox>
                        </div>

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
                       <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-danger" Width="200px" Text="Cancelar" />
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
                        <h3 class="box-title">Lista de Enfermeras</h3>
                    </div>
                    <div class="box-body table-responsive">
                        <table id="tbl_enfermeras" class="table table-bordered table-hover text-center">
                            <thead>
                                <tr>
                                    <th>Código</th>
                                    <th>Nombres</th>
                                    <th>Apellidos</th>
                                    <th>Nro Documento</th>
                                    <th>Tipo</th>
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


         <div class="modal fade" id="imodal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close"  data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title" id="myModalLabel">Actualizar registro</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label>NOMBRES</label>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="txtName" runat="server" Text="" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>APELLIDOS</label>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="txtApellidos" runat="server" Text="" CssClass="form-control" Enabled="false" ></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label>DNI</label>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="txtDNI" runat="server" Text="" CssClass="form-control" ></asp:TextBox>
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
     <script src="js/enfermera.js" type="text/javascript"></script>
</asp:Content>
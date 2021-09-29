<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="GestionarHorariosEnfermeras.aspx.cs" Inherits="PaginaWebClinina.GestionarHorariosEnfermeras" ClientIDMode="Static" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/timepicker/bootstrap-timepicker.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content-header">
        <h1 style="text-align: center">GESTION DE HORARIOS DE ENFERMERAS</h1>
    </section>
    <section class="content">
        <div class="row">
            <div class="col-md-4">
                <div class="box box-primary">
                    <div class="box-header">
                        <h3 class="box-title">Datos de la Enfermera</h3>
                    </div>
                    <div class="box-body">
                        <label>DNI</label>
                        <div class="input-group">
                            <asp:TextBox ID="txtDNI" runat="server" CssClass="form-control" MaxLength="8"></asp:TextBox>
                            <span class="input-group-btn">
                                <asp:Button ID="btnBuscar" Text="Buscar" runat="server" CssClass="btn btn-info btn-flat" />
                            </span>
                        </div>
                    </div>
                    <div class="box-footer">
                        <strong>Nombres: </strong>
                        <asp:Label ID="lblNombres" runat="server" Text=""></asp:Label>
                        <br />
                        <br />
                        <strong>Apellidos: </strong>
                        <asp:Label ID="lblApellidos" runat="server" Text=""></asp:Label>
                        <br />
                        <br />
                        <strong>Tipo:</strong>
                        <asp:Label ID="lblTipo" runat="server" Text=""></asp:Label>
                        <br />
                        <br />
                    </div>
                </div>
            </div>
            <div class="col-md-8">
                <div class="box box-primary">
                    <div class="box-header">
                        <h3 class="box-title">Horario de Trabajo</h3>
                    </div>
                    <div class="box-body">
                        <table id="tbl_horarios" class="table table-bordered table-hover">
                            <thead>
                                <tr>
                                    <th></th>
                                    <th></th>
                                    <!-- contenedor del id -->
                                    <th>FECHA DE ATENCIÓN</th>
                                    <th>TURNO DE ATENCIÓN</th>
                                </tr>
                            </thead>
                            <tbody id="tbl_body_table">
                                <%-- DATA POR AJAX     --%>
                            </tbody>
                        </table>
                    </div>
                    <div class="box-footer" style="text-align: center">
                        <%--<asp:Button ID="btnAgregarHorario" runat="server" CssClass="btn btn-primary" Text="Agregar Horario" />--%>
                        <asp:LinkButton ID="btnAgregarHorario" runat="server" CssClass="btn btn-primary" href="#AgregarHorario" data-toggle="modal">Agregar Horario</asp:LinkButton>
                        <%--<asp:Button ID="btnGuardarHorario" runat="server" CssClass="btn btn-success" Text="Guarda Horario" />--%>
                    </div>
                </div>

            </div>
        </div>
    </section>


    <div class="modal fade" id="AgregarHorario" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">x</button>
                    <h3 class="modal-title"><i class="fa fa-clock-o"></i>Agregar Horario Trabajo</h3>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label>Fecha:</label>
                        <div class="input-group">
                            <div class="input-group-addon">
                                <i class="fa fa-calendar"></i>
                            </div>
                            <asp:TextBox ID="txtFecha" CssClass="form-control" data-inputmask="'alias': 'dd/mm/yyyy'"
                                data-mask="" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label>Turno:</label>
                        <div class="input-group">
                            <label>Diurno (06:00 am - 02:00 pm)</label><br />
                            <label>Vespertino (02:00 pm - 10:00pm)</label>
                        </div>
                        <br />
                        <div class="input-group">
                            <asp:DropDownList ID="ddlTurnoEnfermera" runat="server" CssClass="form-control">
                                <asp:ListItem>Diurno</asp:ListItem>
                                <asp:ListItem>Vespertino</asp:ListItem>
                            </asp:DropDownList>
                            <div class="input-group-addon">
                                 <i class="fa fa-clock-o"></i>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer clearfix">
                    <asp:Button ID="btnAgregar" runat="server" CssClass="btn btn-primary" Text="Agregar" />
                </div>
            </div>
        </div>
    </div>

    <input type="hidden" id="txtEnfermera" />
    <input type="hidden" id="txtIdHorario" />

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">

    <script src="js/plugins/input-mask/jquery.inputmask.js"></script>
    <script src="js/plugins/input-mask/jquery.inputmask.date.extensions.js"></script>
    <script src="js/plugins/input-mask/jquery.inputmask.extensions.js"></script>

    <script src="js/plugins/timepicker/bootstrap-timepicker.min.js"></script>
    <script src="js/plugins/moment/moment.min.js"></script>
    <script src="js/horariosenfermera.js" type="text/javascript"></script>
</asp:Content>

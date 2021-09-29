//date
$("[data-mask]").inputmask();

var tabla,nrofilas=0;

//Inicializar la tabla
function initDataTable() {
    tabla = $("#tbl_horarios").DataTable({
        "oLanguage": {
            "oPaginate": {
                "sNext": "Siguiente",
                "sPrevious": "Anterior"
            },
        },
        "aaSorting": [[0, 'desc']],
        "bSort": true,
        "aoColumns": [
            { "bSortable": false },
            { "bSortable": false },
            null,
            null
        ]
    });

    tabla.fnSetColumnVis(1, false);
}

initDataTable();


//Función para Buscar Enfermeras
$("#btnBuscar").on("click", function (event) {
    event.preventDefault();
    var dni = $("#txtDNI").val();
    var obj = JSON.stringify({ dni: dni });

    if (dni.length > 0) {
        // llamada a ajax
        $.ajax({
            type: "POST",
            url: "GestionarHorariosEnfermeras.aspx/BuscarEnfermera",
            data: obj,
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOptions, thrownError) {
                console.log(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                if (data.d !== null) {
                    llenarDatosEnfermera(data.d);
                    listHorarios(data.d.IdEnfermera);
                } else {
                    llenarDatosDefault(data.d);
                    tabla.fnClearTable();
                }
            }
        });
    } else {
        alert('No ha ingresado un DNI');
        llenarDatosDefault();
        tabla.fnClearTable();
    }
});


//Función para llenar los datos
function llenarDatosEnfermera(obj) {
    $("#lblNombres").text(obj.Nombre);
    $("#lblApellidos").text(obj.ApPaterno.concat(" ".concat(obj.ApMaterno)));
    $("#lblTipo").text(obj.TipoEnfermera);
    $("#txtEnfermera").val(obj.IdEnfermera);
}


//Funcion para Limpiar los datos
function llenarDatosDefault() {
    alert("No existe una enfermera con DNI " + $("#txtDNI").val());
    $("#lblNombres").text("");
    $("#lblApellidos").text("");
    $("#lblTipo").text("");
    $("#txtEnfermera").val("0");
    $("#txtDNI").val("");
}


//LimpiarDatosModal
function LimpiarModal() {
    $("#txtFecha").val("");
    $("[data-mask]").inputmask();
    $("#ddlTurnoEnfermera")[0].selectedIndex = 0;
}

//agregar un horario
$("#btnAgregar").on("click", function (event) {
    event.preventDefault();
    //obtener los valores de los campos
    var fecha, turno, idenfermera;
    fecha = $("#txtFecha").val();
    turno = $("#ddlTurnoEnfermera").val();
    idenfermera = $("#txtEnfermera").val();

    var rpta = Comparar(fecha, turno);

    if (fecha.length <= 0 || turno.length <= 0 || idenfermera.length <= 0) {
            alert("Ingrese los datos requeridos.");
    } else {
        if (rpta == false) {
            var obj = JSON.stringify({ fecha: fecha, turno: turno, id: idenfermera });

            //llamada a ajax
            $.ajax({
                type: "POST",
                url: "GestionarHorariosEnfermeras.aspx/AgregarHorario",
                data: obj,
                contentType: 'application/json; charset=utf-8',
                error: function (xhr, ajaxOptions, thrownError) {
                    console.log(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
                },
                success: function (data) {
                    LimpiarModal();
                    //cerrar ventana modal usando jquery
                    $("#AgregarHorario").modal('toggle');
                    addRow(data.d);
                }
            });

        } else {
        alert("Esta tratando de ingresar horarios repetidos");
        LimpiarModal();
        }
    }
});


//Funcion para agregar filas a la tabla
function addRow(obj) {
    var fecha = moment(obj.Fecha).format("DD/MM/YYYY");
    tabla.fnAddData(
        ['<button type="button" value="Eliminar" title="Eliminar" class="btn btn-danger btn-delete"><i class="fa fa-minus-square-o" aria-hidden="true"></i></button>',
            obj.IdHorarioAtencionEnfermera,
            fecha,
            obj.Turno
        ]
    );
    nrofilas++;
    console.log(nrofilas);
}


//Funcion para listar los horarios
function listHorarios(idEnfermera) {

    var obj = JSON.stringify({ idenfermera: idEnfermera });

    $.ajax({
        type: "POST",
        url: "GestionarHorariosEnfermeras.aspx/ListarHorariosAtencion",
        data: obj,
        contentType: 'application/json; charset=utf-8',
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
        },
        success: function (data) {
            tabla.fnClearTable();
            for (var i = 0; i < data.d.length; i++) {
                addRow(data.d[i]);
            }
        }
    });

}


//Funcion para Comparar Valores
function Comparar(fecha, turno) {
    var rpta = false;
    if (nrofilas == 0) {
        return rpta;
    } else {
        for (var i = 0; i < nrofilas; i++) {
            var dataRow = tabla.fnGetData(i);
            //Para el turno
            var tempturno = dataRow[3];
            //Para la fecha
            var tempfecha = dataRow[2];
            if (fecha == tempfecha && turno == tempturno) {
                rpta = true;
                return rpta;
                break;
            }
        }
        return rpta;
    }
}


//evento click para boton eliminar
$(document).on('click', '.btn-delete', function (e) {
    e.preventDefault();
    var row = $(this).parent().parent()[0];
    var dataRow = tabla.fnGetData(row);

    var response = confirm("¿Está seguro que desea eliminar el horario?");
    if (response == true) {
        nrofilas=0;
        deleteDataAjax(dataRow[1]);
        listHorarios($("#txtEnfermera").val());
    }
});


//funcion DELETE
function deleteDataAjax(data) {
    var obj = JSON.stringify({ id: JSON.stringify(data) });
    $.ajax({
        type: "POST",
        url: "GestionarHorariosEnfermeras.aspx/EliminarHorarioAtencion",
        data: obj,
        dataType: "json",
        contentType: 'application/json; charset=utf-8',
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
        },
        success: function (response) {
            if (response.d) {
                alert("Registro eliminado de manera correcta.");
            } else {
                alert("No se pudo eliminar el registro.");
            }
        }
    });
}
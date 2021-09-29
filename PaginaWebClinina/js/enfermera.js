var tabla, data;

//Función para cargar la tabla
function addRowDT(data) {
    tabla = $("#tbl_enfermeras").DataTable({
        "oLanguage": {
            "oPaginate": {
                "sNext": "Siguiente",
                "sPrevious": "Anterior"
            },
        },
        "aaSorting": [[0, 'desc']],
        "bSort": true,
        "aoColumns": [
            null,
            null,
            null,
            null,
            null,
           { "bSortable": false }
        ],
        bDestroy: true

    });

    tabla.fnClearTable();

    for (var i = 0; i < data.length; i++) {
        tabla.fnAddData([
            data[i].IdEnfermera,
            data[i].Nombre,
            (data[i].ApPaterno) + " " + (data[i].ApMaterno),
            data[i].NroDocumento,
            data[i].TipoEnfermera,
            '<button title="Actualizar" value="Actualizar" class="btn btn-primary btn-edit" data-target="#imodal"  data-toggle="modal"><i class="fa fa-check-square-o" aria-hidden="true"></i></button>&nbsp;' +
            '<button title="Eliminar" value="Eliminar" class="btn btn-danger btn-delete"><i class="fa fa-minus-square-o" aria-hidden="true"></i>&nbsp</button>',

        ]);
    }
 }


//Funcion para Listar
function sendDataAjax() {
    $.ajax({
        type: "POST",
        url: "GestionarEnfermera.aspx/ListarEnfermeras",
        data: {},
        contentType: 'application/json; charset=utf-8',
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
        },
        success: function (data) {
            addRowDT(data.d);
        }
    });
}


//Funcion para actualizar
function updateDataAjax() {
    var obj = JSON.stringify({
        id: JSON.stringify(data[0]),
        documento: $("#txtDNI").val()
    });
    $.ajax({
        type: "POST",
        url: "GestionarEnfermera.aspx/ActualizarDatosEnfermera",
        data: obj,
        dataType: "json",
        contentType: 'application/json; charset=utf-8',
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
        },
        success: function (response) {
            if (response.d) {
                $("#imodal").modal('toggle');
                alert("Registro actualizado de manera correcta.");
            } else {
                alert("No se pudo actualizar el registro.");
            }

        }
    });
}


//Funcion para Eliminar
function deleteDataAjax(data) {
    var obj = JSON.stringify({
        id: JSON.stringify(data)
    });
    $.ajax({
        type: "POST",
        url: "GestionarEnfermera.aspx/EliminarDatosEnfermera",
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


// evento click para boton actualizar
$(document).on('click', '.btn-edit', function (e) {
    e.preventDefault();
    var row = $(this).parent().parent()[0];
    data = tabla.fnGetData(row);
    fillModalData();
    sendDataAjax();
});


// evento click para boton eliminar
$(document).on('click', '.btn-delete', function (e) {
    e.preventDefault();
    var rpta = confirm("¿Seguro que quiere eliminar el registro?");
    if (rpta == true) {
        var row = $(this).parent().parent()[0];
        var dataRow = tabla.fnGetData(row);
        deleteDataAjax(dataRow[0]);
        // paso 2: renderizar el datatable
        sendDataAjax();
    }   
});


//Evento Click Para el boton Cancelar
$("#btnCancelar").click(function (e) {
    e.preventDefault();
    Limpiar();
});


//Limpiar Campos
function Limpiar() {
    $("#txtNroDocumento").val("");
    $("#txtNombres").val("");
    $("#txtApPaterno").val("");
    $("#txtApMaterno").val("");
    $("#ddlTipoEnfermera")[0].selectedIndex = 0;
}


// cargar datos en el modal
function fillModalData() {
    $("#txtName").val(data[1]);
    $("#txtApellidos").val(data[2]);
    $("#txtDNI").val(data[3]);
}


// enviar la informacion al servidor
$("#btnactualizar").click(function (e) {
    e.preventDefault();
    updateDataAjax();
    sendDataAjax();
});

sendDataAjax();
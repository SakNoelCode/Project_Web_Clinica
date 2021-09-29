var tabla, data;

$("#btnBuscar").on('click', function (e) {
    e.preventDefault();
    var dni = $("#txtDNI").val();
   searchUsuarioDni(dni);
});


//Funcion Buscar Paciente
function searchUsuarioDni(dni){

    var data = JSON.stringify({ dni: dni });
    $.ajax({
        type: "POST",
        url: "GestionarUsuario.aspx/BuscarEmpleadoDNI",
        data: data,
        contentType: 'application/json; charset=utf-8',
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
        },
        success: function (data) {
            console.log(data.d.ID);
            if (data.d.ID == 0) {
                alert('El empleado ya esta registrado o no existe');
                limpiarDatosUsuario();
            } else {
                llenarDatosUsuario(data.d);
                console.log(data.d.ID);
                limpiarCampos();
            }

        }
    });
}


function llenarDatosUsuario(obj) {
    $("#idEmpleado").val(obj.ID);
    $("#txtNombres").val(obj.Nombre);
    $("#txtApellidos").val(obj.ApPaterno + " " + obj.ApMaterno);
    $("#txtTipoEmpleado").val(obj.RTipoEmpleado.Descripcion);
}

function limpiarDatosUsuario() {
    $("#txtDNI").val("");
    $("#idEmpleado").val("0");
    $("#txtNombres").val("");
    $("#txtApellidos").val("");
    $("#txtTipoEmpleado").val("");
}

function limpiarCampos(){
    $("#txtUsuario").val("");
    $("#txtContraseña").val("");
    $("#tbtnRegistrar").val("Registrar");
    var btnActualizar = $("#btnActualizar");
    btnActualizar.prop('disabled', true);
    var btnRegistrar = $("#btnRegistrar");
    btnRegistrar.prop('disabled', false);
}

//Funcion para cargar la tabla
function addRowDT(data) {
    tabla = $("#tbl_usuarios").DataTable({
        "aaSorting": [[0, 'desc']],
        "bSort": true,
        "bDestroy": true,
        "aoColumns": [
            null,
            null,
            null,
            null,
            null,
            null,
            null,
            { "bSortable": false }
        ]
    });

    tabla.fnClearTable();

    for (var i = 0; i < data.length; i++) {
        tabla.fnAddData([
            data[i].IdUsuario,
            data[i].Nombre,
            data[i].ApPaterno + " "+  data[i].ApMaterno,
            data[i].NroDocumento,
            data[i].user,
            data[i].password,
            data[i].TipUser,
            '<button type="button" value="Actualizar" title="Actualizar" class="btn btn-primary btn-edit" data-target="#imodal" data-toggle="modal"><i class="fa fa-check-square-o" aria-hidden="true"></i></button>&nbsp;' +
            '<button type="button" value="Eliminar" title="Eliminar" class="btn btn-danger btn-delete"><i class="fa fa-minus-square-o" aria-hidden="true"></i></button>'
        ]);
    }

}



//Funcion para Listar
function sendDataAjax() {
    $.ajax({
        type: "POST",
        url: "GestionarUsuario.aspx/ListarUsuarios",
        data: {},
        contentType: 'application/json; charset=utf-8',
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
        },
        success: function (data) {
            console.log(data);
            addRowDT(data.d);
            limpiarCampos();
        }
    });
}


//Funcion para editar
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
        url: "GestionarUsuario.aspx/EliminarDatosUsuario",
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
   // console.log("Aqui prro")
    var row = $(this).parent().parent()[0];
    data = tabla.fnGetData(row);
    console.log(data);
    fillModalData();
});



// evento click para boton eliminar
$(document).on('click', '.btn-delete', function (e) {

    e.preventDefault();
    var rpta = confirm("¿Seguro que quiere eliminar el regisytro?");
    if (rpta==true) {
        var row = $(this).parent().parent()[0];
        var dataRow = tabla.fnGetData(row);
        deleteDataAjax(dataRow[0]);
        // paso 2: renderizar el datatable
        sendDataAjax();
    }
});

// cargar datos en el modal
function fillModalData() {
    $("#txtUsuario").val(data[4]);
    $("#txtContraseña").val(data[5]);
    $("#txtNombres").val(data[1]);
    $("#txtApellidos").val(data[2]);
    $("#txtDNI").val("");
    $("#txtTipoEmpleado").val("Usuario");
    var temp = data[6];
    $("#ddlTipoUsuario").val(temp);
    var btnActualizar = $("#btnActualizar");
    btnActualizar.prop('disabled', false);
    var btnRegistrar = $("#btnRegistrar");
    btnRegistrar.prop('disabled', true);
    $("#idUsuario").val(data[0]);
    console.log($("#idUsuario").val(data[0]));
}


// enviar la informacion al servidor
//$("#btnActualizar").click(function (e) {
//    e.preventDefault();
//    updateDataAjax();
//});


sendDataAjax();
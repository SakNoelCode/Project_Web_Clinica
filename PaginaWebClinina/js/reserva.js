$("[data-mask]").inputmask();

//Función Click para buscar pacientes
$("#btnBuscar").on('click', function (e) {
    e.preventDefault();
    var dni = $("#txtDNI").val();
    searchPacienteDni(dni);

});


//Funcion Buscar Paciente
function searchPacienteDni(dni) {

    var data = JSON.stringify({ dni: dni });
    $.ajax({
        type: "POST",
        url: "GestionarReservaCitas.aspx/BuscarPacienteDNI",
        data: data,
        contentType: 'application/json; charset=utf-8',
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
        },
        success: function (data) {
            if (data.d == null) {
                alert('No exite el paciente con dni ' + dni);
                limpiarDatosPaciente();
            } else {
                llenarDatosPaciente(data.d);
            }

        }
    });
}


function llenarDatosPaciente(obj) {
    $("#idPaciente").val(obj.IdPaciente);
    $("#txtNombres").val(obj.Nombres);
    $("#txtApellidos").val(obj.ApPaterno + " " + obj.ApMaterno);
    $("#txtTelefono").val(obj.Telefono);
    $("#txtEdad").val(obj.Edad);
    $("#txtSexo").val((obj.Sexo == 'M') ? 'Masculino' : 'Femenino');
}

//Funcion AJAX actualizar
function updateDataAjax() {

    var obj = JSON.stringify({ id: $("#idHorarioAtencion").val() });
    console.log(obj);
    $.ajax({
        type: "POST",
        url: "GestionarReservaCitas.aspx/ActualizarHorarioAtencion",
        data: obj,
        dataType: "json",
        contentType: 'application/json; charset=utf-8',
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
        },
        success: function (response) {
            if (response.d) { }
        }
    });
}

//Evento Click
$(document).on('click', '.btn-registrar', function (e) {
   // e.preventDefault();
    updateDataAjax();
});

function limpiarDatosPaciente() {
    $("#idPaciente").val("0");
    $("#txtDNI").val("");
    $("#txtNombres").val("");
    $("#txtApellidos").val("");
    $("#txtTelefono").val("");
    $("#txtEdad").val("");
    $("#txtSexo").val("");
}
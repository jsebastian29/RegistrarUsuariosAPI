var urlApi = "http://localhost:51145/"
var paisId;
$(document).ready(function () {
    $("#PaisId").append($("<option />").val("").text("--Seleccione un País--"));
    $("#DepartamentoId").prop("disabled", true);
    $("#CiudadId").prop("disabled", true);
    $("#guardarId").click("click", function () {
        guardarUsuario();
    });
    cargarPaises();    
});

function cargarPaises() {
    $.ajax({
        type: 'GET',
        url: urlApi + 'api/Pais',
        dataType: 'json',
        success: function (data) {            
            $.each(data, function (index, val) {
                $("#PaisId").append($("<option />").val(val.Id).text(val.Nombre));
            });
        }
    });
}

function cargaDepartamentos(id) {
    paisId = parseInt(id.value);

    if (paisId > 0) {
        $('#DepartamentoId').empty();
        $("#DepartamentoId").prop("disabled", false);
        $.ajax({
            type: 'GET',
            url: urlApi + 'api/Departamento/GetDepartamentoByPaisId?id=' + paisId,
            dataType: 'json',
            success: function (data) {
                $.each(data, function (index, val) {
                    $("#DepartamentoId").append($("<option />").val(val.Id).text(val.Nombre));
                });
            }
        });
    } else {
        $('#DepartamentoId').empty();
        $("#DepartamentoId").prop("disabled", true);
        $('#CiudadId').empty();
        $("#CiudadId").prop("disabled", true);
    }
}

function cargaCiudades(id) {
    var departamentoId = parseInt(id.value);

    if (departamentoId > 0) {
        $('#CiudadId').empty();
        $("#CiudadId").prop("disabled", false);
        $.ajax({
            type: 'GET',
            url: urlApi + 'api/Ciudad/GetCiudadByDepartamentoId?id=' + departamentoId,
            dataType: 'json',
            success: function (data) {
                $.each(data, function (index, val) {
                    $("#CiudadId").append($("<option />").val(val.Id).text(val.Nombre));
                });
            }
        });
    } else {
        $('#CiudadId').empty();
        $("#CiudadId").prop("disabled", true);
    }
}

function guardarUsuario() {
    var usuario = {};
    if ($("#form").valid()) {
        usuario.Nombre = $("#nombreId").val();
        usuario.Telefono = $("#telefonoId").val();
        usuario.Direccion = $("#direccionId").val();
        usuario.PaisId = parseInt($("#PaisId").val());
        usuario.DepartamentoId = parseInt($("#DepartamentoId").val());
        usuario.CiudadId = parseInt($("#CiudadId").val());

        $.ajax({
            type: 'POST',
            url: urlApi + 'api/Usuario/Insert',
            data: JSON.stringify(usuario),
            contentType: "application/json",
            success: function (data) {
                if (data) {
                    alert("¡Usuario registrado exitosamente!");
                    window.location.replace(urlApi + "Home/Index");
                } else {
                    alert("¡Ocurrió un error!");
                }   
            }
        });
    }
}

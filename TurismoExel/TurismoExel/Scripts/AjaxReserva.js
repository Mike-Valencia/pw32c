$(".cancelar-reserva").click(function () {
    var data = $(this).attr("data-id"); //Obtenemos el id
    $.ajax(
    {
        type: "POST", //Tipo de llamada
        url: "http://localhost:61613//ServicioWebTurismo.asmx/CancelarReserva?ReservaId=" + data, //Dirección del WebMethod
        data: "{ ReservaId:" + data + "}",  
        contentType: "application/json; charset=utf-8", //Tipo de contenido
        dataType: "json",   //Tipo de datos

        success: function (response) {
            console.log(response);
            var resultadoAMostrar = '<p class="alert alert-success">' + response.d + '</p>';
            setTimeout(function () {
                location.reload();
            }, 1500);
            $("#alert-ajax").html(resultadoAMostrar);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log("lalalala", jqXHR);
            var resultadoAMostrar = '<p class="alert alert-danger">ERROR AL CANCELAR LA RESERVA</p>';
            $("#alert-ajax").html(resultadoAMostrar);
        }
    });
});
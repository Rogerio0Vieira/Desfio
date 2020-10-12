function OnclickPesquisarExame() {

    event.preventDefault();
    
    var item = document.getElementById("IdTipoExameConsulta").value;       

    if (item == null)
        item = "";    

    $.get("/Consulta/ConsultarListaExamesJR?idTipoExame=" + item, function (data) {

        $("#IdExame").empty();
        $("#dropdownListarExames").css({ "display": "block" });        

        for (var i = 0; i < data.length; i++){

            $('#IdExame').append('<option value="' + data[i].CodigoExame + '">' + data[i].NomeExame + '</option>');               

        }
    });  
}
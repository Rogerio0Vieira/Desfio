function OnclickPesquisarCpfPaciente() {

    event.preventDefault();
    var item = document.getElementById("CpfPacienteConsulta").value;

    if (item == null)
        item = "";

    $.get("/Consulta/ConsultarPacienteCpfJR?cpfPesquisaPaciente=" + item, function (data) {

        if (data.CpfPaciente != null) {

            $(function () {

                $("#IdPaciente").val(data.CodigoPaciente);
                $("#NomePacienteSelecionado").val(data.NomePaciente);

            });
        } 

    });
}
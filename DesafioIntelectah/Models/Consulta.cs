using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DesafioIntelectah.Models
{
    public class Consulta
    {
        [Key]
        public int CodigoConsulta { get; set; }

        [DisplayName("Paciente")]
        public int IdPaciente { get; set; }

        [DisplayName("Exame")]
        public int IdExame { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Data e Hora da Consulta")]
        public DateTime DataHoraConsulta { get; set; }

        [DisplayName("Horas")]
        [Range(0, 23, ErrorMessage = "Só é permitido entre 0 e 23 horas")]
        public int HorasConsulta { get; set; }

        [DisplayName("Minutos")]
        [Range(0, 59, ErrorMessage = "Só é permitido entre 0 e 59 minutos")]
        public int MinutosConsulta { get; set; }

        [DisplayName("Número de Protocolo")]
        public string ProtocoloConsulta { get; set; }
    }
}
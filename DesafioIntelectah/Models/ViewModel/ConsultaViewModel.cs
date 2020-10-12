using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DesafioIntelectah.Models.ViewModel
{
    public class ConsultaViewModel
    {
        /* Modelo de tela para Consulta */
        [Key]
        public int CodigoConsulta { get; set; }

        [DisplayName("Exame")]
        public int IdExame { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Data da Consulta")]
        public DateTime DataHoraConsulta { get; set; }

        [Range(0, 23, ErrorMessage = "Só é permitido entre 0 e 23 horas")]
        public int HorasConsulta { get; set; }

        [Range(0, 59, ErrorMessage = "Só é permitido entre 0 e 59 minutos")]
        public int MinutosConsulta { get; set; }

        [DisplayName("Número de Protocolo")]
        public string ProtocoloConsulta { get; set; }


        /* Modelo de tela para Regras de Negócio */
        [DisplayName("Consultar por CPF")]
        [StringLength(14, ErrorMessage = "Devem ser incluídos 14 caracteres.")]
        [MaxLength(14, ErrorMessage = "Preenchimento máximo de 14 caracteres.")]
        [MinLength(14, ErrorMessage = "Preenchimento mínimo de 14 caracteres.")]
        [RegularExpression(@"[0-9]{3}\.?[0-9]{3}\.?[0-9]{3}\-?[0-9]{2}", ErrorMessage = "Digite no formato 000.000.000-00")]
        public string CpfPacienteConsulta { get; set; }

        [DisplayName("Código")]
        public int IdPaciente { get; set; }

        [DisplayName("Paciente")]        
        public string NomePacienteSelecionado { get; set; }

        [DisplayName("Tipo de Exame")]
        public int IdTipoExameConsulta { get; set; }

        public List<SelectListItem> ListarTiposExameConsultaViewModel { get; set; }
        public List<SelectListItem> ListarExamesConsultaViewModel { get; set; }        

        public ConsultaViewModel()
        {
            ListarTiposExameConsultaViewModel = new List<SelectListItem>();
            ListarExamesConsultaViewModel = new List<SelectListItem>();            
        }
    }
}
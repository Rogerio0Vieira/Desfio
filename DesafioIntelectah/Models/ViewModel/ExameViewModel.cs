using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DesafioIntelectah.Models.ViewModel
{
    public class ExameViewModel
    {
        /* Modelo de tela para Exame */
        [Key]
        public int CodigoExame { get; set; }

        [Required(ErrorMessage = "O preenchimento é obrigatório", AllowEmptyStrings = false)]
        [DisplayName("Tipo de Exame")]
        public int IdTipoExame { get; set; }

        [Required(ErrorMessage = "O preenchimento é obrigatório", AllowEmptyStrings = false)]
        [DisplayName("Nome do Exame")]
        [StringLength(100, ErrorMessage = "São permitidos até 100 caracteres.")]
        public string NomeExame { get; set; }

        [Required(ErrorMessage = "O preenchimento é obrigatório", AllowEmptyStrings = false)]
        [DisplayName("Observações")]
        [StringLength(1000, ErrorMessage = "São permitidos até 1000 caracteres.")]
        public string ObservacaoExame { get; set; }

        
        /* Modelo de tela para lista dos Tipos de Exame */
        public string StringNomeTipoExame { get; set; }
        public List<SelectListItem> ListarTiposExamesViewModel { get; set; }

        public ExameViewModel()
        {
            ListarTiposExamesViewModel = new List<SelectListItem>();
        }
    }
}
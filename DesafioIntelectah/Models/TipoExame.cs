using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DesafioIntelectah.Models
{
    public class TipoExame
    {
        [Key]
        public int CodigoTipoExame { get; set; }

        [Required(ErrorMessage = "O preenchimento é obrigatório", AllowEmptyStrings = false)]
        [DisplayName("Tipo de Exame")]
        [StringLength(100, ErrorMessage = "São permitidos até 100 caracteres.")]
        public string NomeTipoExame { get; set; }

        [Required(ErrorMessage = "O preenchimento é obrigatório", AllowEmptyStrings = false)]
        [DisplayName("Descrição")]
        [StringLength(256, ErrorMessage = "São permitidos até 250 caracteres.")]
        public string DescricaoTipoExame { get; set; }
    }
}
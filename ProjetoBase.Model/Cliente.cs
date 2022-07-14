using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBase.Model
{
    [Table("CLIENTE")]
    public partial class Cliente
    {
        [Key]
        [Column("ID_CLIENTE")]
        public int? Id { get; set; }

        [Column("NM_CLIENTE")]
        [Required(ErrorMessage ="O campo {0} é obrigatório")]
        [StringLength(100, MinimumLength = 3)]
        public string Nome { get; set; }

        [Column("DS_EMAIL")]
        [EmailAddress]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, MinimumLength = 3)]
        public string Email { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seguranca.Model
{
    [Table("SISTEMA", Schema = "Seguranca")]
    public partial class Sistema
    {
        public Sistema()
        {
            Modulo = new HashSet<Modulo>();
        }

        [Key]
        [Column("ID_SISTEMA")]
        public int? Id { get; set; }

        [Column("NM_SISTEMA")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, MinimumLength = 3)]
        public string Nome { get; set; }

        [Column("CO_SISTEMA")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(3, MinimumLength = 3)]
        public string Codigo { get; set; }

        [Column("DS_SISTEMA")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(400, MinimumLength = 3)]
        public string Descricao { get; set; }

        [Column("FL_ATIVO")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public bool Situacao { get; set; }

        public virtual ICollection<Modulo> Modulo { get; set; }
    }
}

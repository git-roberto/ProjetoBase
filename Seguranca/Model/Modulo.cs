using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seguranca.Model
{
    [Table("MODULO", Schema = "Seguranca")]
    public partial class Modulo
    {
        public Modulo()
        {
            Funcao = new HashSet<Funcao>();
        }

        [Key]
        [Column("ID_MODULO")]
        public int? Id { get; set; }

        [Column("ID_SISTEMA")]
        public int IdSistema { get; set; }

        [Column("NM_MODULO")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, MinimumLength = 3)]
        public string Nome { get; set; }

        [Column("CO_MODULO")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(3, MinimumLength = 3)]
        public string Codigo { get; set; }

        [Column("DS_MODULO")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(400, MinimumLength = 3)]
        public string Descricao { get; set; }

        [Column("FL_ATIVO")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public bool Situacao { get; set; }

        [ForeignKey("IdSistema")]
        public virtual Sistema Sistema { get; set; }

        public virtual ICollection<Funcao> Funcao { get; set; }
    }
}

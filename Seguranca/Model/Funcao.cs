using Seguranca.Config.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seguranca.Model
{
    [Table("FUNCAO", Schema = "Seguranca")]
    public partial class Funcao
    {
        public Funcao()
        {
            Perfil = new HashSet<PerfilFuncao>();
            Filhos = new HashSet<Funcao>();
        }

        [Key]
        [Column("ID_FUNCAO")]
        public int? Id { get; set; }

        [Column("ID_FUNCAO_PAI")]
        public int? IdFuncaoPai { get; set; }

        [Column("ID_MODULO")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int IdModulo { get; set; }

        [Column("NM_FUNCAO")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, MinimumLength = 3)]
        public string Nome { get; set; }

        [Column("CO_FUNCAO")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(3, MinimumLength = 3)]
        public string Codigo { get; set; }

        [Column("DS_FUNCAO")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(400, MinimumLength = 3)]
        public string Descricao { get; set; }

        [Column("DS_ROTA")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(400, MinimumLength = 3)]
        public string Rota { get; set; }

        [Column("TP_VISIBILIDADE")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public TipoVisibilidadeEnum Visibilidade { get; set; }

        [Column("TP_PERMISSAO")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public TipoAutenticacaoEnum Permissao { get; set; }

        [Column("NU_ORDEM")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public short Ordem { get; set; }

        [Column("FL_ATIVO")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public bool Situacao { get; set; }

        [ForeignKey("IdFuncaoPai")]
        public virtual Funcao? FuncaoPai { get; set; }

        [ForeignKey("IdModulo")]
        public virtual Modulo Modulo { get; set; }

        public virtual ICollection<PerfilFuncao> Perfil { get; set; }
        public virtual ICollection<Funcao> Filhos { get; set; }
    }
}

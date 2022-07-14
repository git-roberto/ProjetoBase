using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seguranca.Model
{
    [Table("PERFIL_FUNCAO", Schema = "Seguranca")]
    public partial class PerfilFuncao
    {
        [Key]
        [Column("ID_PERFIL_FUNCAO")]
        public int? Id { get; set; }

        [Column("ID_PERFIL")]
        public int IdPerfil { get; set; }

        [Column("ID_FUNCAO")]
        public int IdFuncao { get; set; }

        [Column("FL_CONSULTAR")]
        public bool Consultar { get; set; }

        [Column("FL_INSERIR")]
        public bool Inserir { get; set; }

        [Column("FL_ALTERAR")]
        public bool Alterar { get; set; }

        [Column("FL_EXCLUIR")]
        public bool Excluir { get; set; }

        [Column("FL_VISUALIZAR")]
        public bool Visualizar { get; set; }

        [ForeignKey("IdFuncao")]
        public virtual Funcao Funcao { get; set; }

        [ForeignKey("IdPerfil")]
        public virtual Perfil Perfil { get; set; }
    }
}

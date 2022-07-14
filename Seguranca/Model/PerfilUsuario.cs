using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seguranca.Model
{
    [Table("PERFIL_USUARIO", Schema = "Seguranca")]
    public partial class PerfilUsuario
    {
        [Key]
        [Column("ID_PERFIL", Order = 1)]
        public int IdPerfil { get; set; }

        [Key]
        [Column("ID_USUARIO", Order = 2)]
        public int IdUsuario { get; set; }

        [ForeignKey("IdPerfil")]
        public virtual Perfil Perfil { get; set; }

        [ForeignKey("IdUsuario")]
        public virtual Usuario Usuario { get; set; }

    }
}

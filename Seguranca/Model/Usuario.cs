using Seguranca.Config.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seguranca.Model
{
    [Table("USUARIO", Schema = "Seguranca")]
    public partial class Usuario
    {
        public Usuario()
        {
            Perfil = new HashSet<PerfilUsuario>();
        }
        
        [Key]
        [Column("ID_USUARIO")]
        public int? Id { get; set; }

        [Column("DS_LOGIN")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Login { get; set; }

        [Column("NM_USUARIO")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, MinimumLength = 3)]
        public string Nome { get; set; }

        [Column("DS_SENHA")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Senha { get; set; }

        [Column("DT_SENHA")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime DataSenha { get; set; }

        [Column("FL_BLOQUEADO")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public bool Bloqueado { get; set; }

        [Column("FL_ATIVO")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public bool Situacao { get; set; }

        public virtual ICollection<PerfilUsuario> Perfil { get; set; }

        public virtual ICollection<PermissaoFuncao> Permissoes
        {
            get
            {
                ICollection<PermissaoFuncao> funcoes = new HashSet<PermissaoFuncao>();
                funcoes = Perfil.SelectMany(x => x.Perfil.Permissoes.Select(z => z.Funcao)).Distinct().Select(x => new PermissaoFuncao() { Funcao = x }).ToList();

                Parallel.ForEach(funcoes, new ParallelOptions { MaxDegreeOfParallelism = 10 }, (x) =>
                {
                    x.Alterar = Perfil.Any(z => z.Perfil.Permissoes.Any(y => y.Funcao.Id == x.Funcao.Id && y.Alterar));
                    x.Consultar = Perfil.Any(z => z.Perfil.Permissoes.Any(y => y.Funcao.Id == x.Funcao.Id && y.Consultar));
                    x.Excluir = Perfil.Any(z => z.Perfil.Permissoes.Any(y => y.Funcao.Id == x.Funcao.Id && y.Excluir));
                    x.Inserir = Perfil.Any(z => z.Perfil.Permissoes.Any(y => y.Funcao.Id == x.Funcao.Id && y.Inserir));
                    x.Visualizar = Perfil.Any(z => z.Perfil.Permissoes.Any(y => y.Funcao.Id == x.Funcao.Id && y.Visualizar));
                });

                return funcoes;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilidades.Models
{
    public class Filtro
    {
        public Paginacao paginacao { get; set; }
        public Sort ordenacao { get; set; }
    }

    public class Paginacao
    {
        public int inicio { get; set; }
        public int qtdPaginas { get; set; }
        public int qtdRegistros { get; set; }
    }

    public class Sort
    {
        public string coluna { get; set; }
        public bool sentido { get; set; }
    }

}

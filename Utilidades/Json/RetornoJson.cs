using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilidades.Json
{
    public class RetornoJson<T>
    {
        public T resultado { get; set; }
        public int qtdRegistros { get; set; }
        public string mensagem { get; set; }
    }

}

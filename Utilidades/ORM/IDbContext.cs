using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilidades.ORM
{
    public interface IDbContext : IDisposable
    {
        DbContext Conexao { get; }
    }
}

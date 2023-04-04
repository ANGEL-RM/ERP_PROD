using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Modelo.ACCESOBD
{
    public interface IApplicationDbContext
    {
        IDbConnection Connection { get; }
        DatabaseFacade Database { get; }
        DbSet<Tbl_Adm_Usuario> Tbl_Adm_Usuario { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}

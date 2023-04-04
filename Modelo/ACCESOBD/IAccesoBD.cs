using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Threading.Tasks;

namespace Modelo.ACCESOBD
{
    public interface IAccesoBD
    {
        IDbConnection Connection { get; }
        DbSet<Tbl_Adm_Usuario> Tbl_Adm_Usuario { get; set; }

        Task<int> SaveChanges();
    }
}
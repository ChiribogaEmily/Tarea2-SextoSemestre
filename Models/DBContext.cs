using Microsoft.EntityFrameworkCore;

namespace TareaSemana2.Models
{
    public class DBContext: DbContext
    {
        public DBContext(DbContextOptions db) : base(db)
        {

        }

        public DbSet<PaisModel> Paises {  get; set; }
        public DbSet<ClienteModel> Clientes { get; set; }
    }
}

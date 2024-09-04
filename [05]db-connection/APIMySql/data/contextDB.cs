using Microsoft.EntityFrameworkCore;
using APIMySQL.Models;

namespace APIMySQL
{
    public class DataBaseContext: DbContext
    {
        public DbSet<Test> Tests { get; set; }
    }

}

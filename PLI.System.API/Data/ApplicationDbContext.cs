using Microsoft.EntityFrameworkCore;
using PLI.System.API.Entities.General;

namespace PLI.System.API.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
    }
}

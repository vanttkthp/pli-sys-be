using Microsoft.EntityFrameworkCore;
using PLI.System.Core.Entities.General;

namespace PLI.System.Infrastructure.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
    }
}

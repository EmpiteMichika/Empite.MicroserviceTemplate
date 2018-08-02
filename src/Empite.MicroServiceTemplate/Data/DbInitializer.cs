using System.Threading.Tasks;
using Empite.Template.Data;
using Empite.Template.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Empite.MicroserviceTemplate.Data
{
    public class DbInitializer: IDbInitializer
    {
        private readonly ApplicationDbContext _appDbContext;

        public DbInitializer(ApplicationDbContext context)
        {
            _appDbContext = context;
        }

        public async Task Initialize()
        {
            _appDbContext.Database.Migrate();
        }
    }
}

using Microsoft.EntityFrameworkCore;

namespace MoviesAPI.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) 
        {

        }

    }
}

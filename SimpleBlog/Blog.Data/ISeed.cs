using System.Threading.Tasks;

namespace Blog.Data
{
    public interface ISeed
    {
        Task MigrateAsync();
        Task SeedAsync();
    }
}

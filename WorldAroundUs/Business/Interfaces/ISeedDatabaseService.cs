using System.Threading.Tasks;

namespace WorldAroundUs.Business.Interfaces
{
    public interface ISeedDatabaseService
    {
        public Task CreateStartAdmin();
        public Task CreateStartRole();
    }
}
using ctrlspec.Models;

namespace ctrlspec.Repository
{
    public interface IClient
    {
        Task<List<Application>> GetAll();
        Task<Application> GetByID(int Id);
        Task<Application> Add(Application application);
        Task<Application> Update(int Id, Application cardetails);
        Task Delete(int Id);
    }
}
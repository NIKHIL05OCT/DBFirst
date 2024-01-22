using GE = GlobalEntity;

namespace DataAccessLayer.repo
{
    public interface ILoginDA
    {
        Task<string> CreateUser(GE::tblEmployeeLogin model);
        Task<string> RemoveUser(int id);
        Task<GE::tblEmployeeLogin> GetUserById(int id);
        Task<List<GE::tblEmployeeLogin>> GetAllUser();
        Task<string> LoginAsync(string emailid, string password);
    }
}

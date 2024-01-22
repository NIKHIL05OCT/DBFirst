using GE = GlobalEntity;

namespace BussinessLayer.repo
{
    public interface ILoginBC
    {
        Task<string> CreateUser(GE::tblEmployeeLogin model);
        Task<string> RemoveUser(int id);
        Task<GE::tblEmployeeLogin> GetUserById(int id);
        Task<List<GE::tblEmployeeLogin>> GetAllUser();
        Task<string> validateuser(string emailid, string password);
    }
}

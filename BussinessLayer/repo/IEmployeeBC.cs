using GE = GlobalEntity;

namespace BussinessLayer.repo
{
    public interface IEmployeeBC
    {
        Task<string> Save(GE::tblEmployee model);
        Task<string> Modify(GE::tblEmployee model);
        Task<string> RemoveEmployee(int id);
        Task<GE::tblEmployee> GetEmployeeById(int id);
        Task<GE::tblEmployee> GetEmployeeByEmailId(string emailid);
        Task<List<GE::tblEmployee>> GetAllEmployee();
    }
}

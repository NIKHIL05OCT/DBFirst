using BussinessLayer.repo;
using DataAccessLayer.repo;
using GE = GlobalEntity;

namespace BussinessLayer
{
    public class EmployeeBC : IEmployeeBC
    {
        private readonly IEmployeeDA employeeDA;
        public EmployeeBC(IEmployeeDA employee)
        {
            this.employeeDA = employee;
        }
        public async Task<string> Save(GE::tblEmployee model)
        {
            return await this.employeeDA.Save(model);
        }
        public async Task<string> Modify(GE::tblEmployee model)
        {
            return await this.employeeDA.Modify(model);
        }
        public async Task<string> RemoveEmployee(int id)
        {
            return await this.employeeDA.RemoveEmployee(id);
        }
        public async Task<GE::tblEmployee> GetEmployeeById(int id)
        {
            return await this.employeeDA.GetEmployeeById(id);
        }
        public async Task<GE::tblEmployee> GetEmployeeByEmailId(string emailid)
        {
            return await this.employeeDA.GetEmployeeByEmail(emailid);
        }
        public async Task<List<GE::tblEmployee>> GetAllEmployee()
        {
            return await this.employeeDA.GetAllEmployee();
        }
    }
}
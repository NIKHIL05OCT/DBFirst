using DataAccessLayer.Models;
using DataAccessLayer.repo;
using Microsoft.EntityFrameworkCore;
using GE = GlobalEntity;

namespace DataAccessLayer
{
    public class EmployeeDA : IEmployeeDA
    {
        private readonly DbfirstContext _dbcontext;
        public EmployeeDA(DbfirstContext dbfirst)
        {
            this._dbcontext = dbfirst;
        }
        public async Task<string> Save(GE::tblEmployee model)
        {
            string res = string.Empty;
            try
            {
                if (model.Id > 0)
                {
                    var _exist = await this._dbcontext.Employees.FirstOrDefaultAsync(itm => itm.Id == model.Id);
                    if (_exist != null)
                    {
                        _exist.FirstName = model.FirstName;
                        _exist.Email = model.Email;
                        _exist.Mobile = model.Mobile;
                    }
                }
                else
                {
                    Employee _employee = new Employee()
                    {
                        FirstName = model.FirstName,
                        Email = model.Email,
                        Mobile = model.Mobile,
                    };
                    await _dbcontext.Employees.AddAsync(_employee);
                }
                await _dbcontext.SaveChangesAsync();
                res = "Saved";
                return res;
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
                return "fail";
            }
        }
        public async Task<string> Modify(GE::tblEmployee model)
        {
            string res = string.Empty;
            try
            {
                var _exist = await this._dbcontext.Employees.FindAsync(model.Id);
                if (_exist != null)
                {
                    _exist.Email = model.Email;
                    _exist.Mobile = model.Mobile;
                }
                 _dbcontext.Update(_exist);

                await _dbcontext.SaveChangesAsync();
                res = "updated";
                return res;
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
                return "fail";
            }
        }
        public async Task<string> RemoveEmployee(int id)
        {
            string res = string.Empty;
            var _data = await this._dbcontext.Employees.FirstOrDefaultAsync(itm => itm.Id == id);

            if (_data != null)
            {
                try
                {
                    this._dbcontext.Employees.Remove(_data);
                    await this._dbcontext.SaveChangesAsync();
                    res = "deleted";
                }
                catch (Exception ex)
                {
                    ex.Data.Clear();
                    res = "fail";
                }
            }
            return res;
        }
        public async Task<List<GE::tblEmployee>> GetAllEmployee()
        {
            var _data = await this._dbcontext.Employees.ToListAsync();
            List<GE::tblEmployee> employees = new List<GE::tblEmployee>();

            if (_data != null && _data.Count > 0)
            {
                _data.ForEach(item =>
                {
                    employees.Add(new GE.tblEmployee()
                    {
                        Id = item.Id,
                        FirstName = item.FirstName,
                        Email = item.Email,
                        Mobile = item.Mobile
                    });
                });
            }
            return employees;
        }
        public async Task<GE::tblEmployee> GetEmployeeById(int id)
        {
            var _data = await this._dbcontext.Employees.FirstOrDefaultAsync(item => item.Id == id);
            GE::tblEmployee employees = new GE.tblEmployee();

            if (_data != null)
            {
                employees = (new GE.tblEmployee()
                {
                    Id = _data.Id,
                    FirstName = _data.FirstName,
                    Email = _data.Email,
                    Mobile = _data.Mobile
                });
            }
            return employees;
        }
        public async Task<GE::tblEmployee> GetEmployeeByEmail(string emailid)
        {
            var _data = await this._dbcontext.Employees.FirstOrDefaultAsync(item => item.Email == emailid);
            GE::tblEmployee employees = new GE.tblEmployee();

            if (_data != null)
            {
                employees = (new GE.tblEmployee()
                {
                    Id = _data.Id,
                    FirstName = _data.FirstName,
                    Email = _data.Email,
                    Mobile = _data.Mobile
                });
            }
            return employees;
        }
    }
}
using SpeedTest.Context.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedTest.Repository.Interfaces
{
    public interface ICompanyRepository
    {
        public Task Insert(Company company);
        public Task Update(Company company);
        public Task Delete(int companyId);
        public Task<Company> GetOne(int companyId);
        public Task<IEnumerable<Company>> All();

    }
}

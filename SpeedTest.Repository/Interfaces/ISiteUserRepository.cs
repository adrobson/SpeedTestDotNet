using SpeedTest.Context.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedTest.Repository.Interfaces
{
    public interface ISiteUserRepository
    {
        public Task Insert(SiteUser siteUser);
        public Task Update(SiteUser siteUser);
        public Task Delete(int siteUserId);
        public Task<SiteUser> GetOne(int id);
        public Task<IEnumerable<SiteUser>> All();

    }
}

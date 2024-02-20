using Microsoft.EntityFrameworkCore;
using SpeedTest.Context.Models;
using SpeedTest.Repository.Interfaces;

namespace SpeedTest.Repository
{
    public class SiteUserRepository : ISiteUserRepository
    {
        private readonly SpeedTestContext context;

        public SiteUserRepository(SpeedTestContext context)
        {
            this.context = context;
        }

        public async Task Insert(SiteUser siteUser)
        {
            //using (var context = new SpeedTestContext())
            //{
                context.SiteUsers.Add(siteUser);
                await context.SaveChangesAsync();
            //}
        }

        public async Task Update(SiteUser siteUser)
        {
            //using (var context = new SpeedTestContext())
            //{
                context.Entry(siteUser).State = EntityState.Modified;
                await context.SaveChangesAsync();
            //}
        }

        public async Task Delete(int siteUserId)
        {
            //using (var context = new SpeedTestContext())
            //{
                var SiteUser = await context.SiteUsers.FindAsync(siteUserId);
                if(SiteUser != null)
                {
                    context.SiteUsers.Remove(SiteUser);
                    await context.SaveChangesAsync();
                }
            //}
        }

        public async Task<SiteUser> GetOne(int id)
        {
            //using (var context = new SpeedTestContext())
            //{
                return await context.SiteUsers.FindAsync(id);
            //}
        }

        public async Task<IEnumerable<SiteUser>> All()
        {
            //using (var context = new SpeedTestContext())
            //{
                return await context.SiteUsers.ToListAsync();
            //    }
        }
    }
}

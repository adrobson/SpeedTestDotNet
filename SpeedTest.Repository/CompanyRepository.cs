using Microsoft.EntityFrameworkCore;
using SpeedTest.Context.Models;
using SpeedTest.Repository.Interfaces;

namespace SpeedTest.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly SpeedTestContext context;
        public CompanyRepository(SpeedTestContext _context)
        {
            context = _context;
        }

        public async Task Insert(Company Company)
        {
            //using (var context = new SpeedTestContext())
            //{
                context.Companies.Add(Company);
                await context.SaveChangesAsync();
            //}
        }

        public async Task Update(Company Company)
        {
            //using (var context = new SpeedTestContext())
            //{
                context.Entry(Company).State = EntityState.Modified;
                await context.SaveChangesAsync();
            //}
        }

        public async Task Delete(int companyId)
        {
            //using (var context = new SpeedTestContext())
            //{
                var Company = await context.Companies.FindAsync(companyId);
                if(Company != null)
                {
                    context.Companies.Remove(Company);
                    await context.SaveChangesAsync();
                }
            //}
        }

        public async Task<Company> GetOne(int companyId)
        {
            //using (var context = new SpeedTestContext())
            //{
                return await context.Companies.FindAsync(companyId);
            //}
        }

        public async Task<IEnumerable<Company>> All()
        {
            //using (var context = new SpeedTestContext())
            //{
                return await context.Companies.ToListAsync();
            //}
        }
    }
}

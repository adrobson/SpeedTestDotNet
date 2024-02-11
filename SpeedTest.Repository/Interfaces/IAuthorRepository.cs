using SpeedTest.Context.Models;
using SpeedTest.Repository.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedTest.Repository.Interfaces
{
    public interface IAuthorRepository
    {
        public Task Insert(Author Author);
        public Task Update(Author Author);
        public Task Delete(int AuthorId);
        public Task<Author> GetOne(int id);
        public IEnumerable<AuthorRating> Top(int numAuthors);
        public Task<IEnumerable<Author>> All();

    }
}

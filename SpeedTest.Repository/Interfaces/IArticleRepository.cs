using SpeedTest.Context.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedTest.Repository.Interfaces
{
    public interface IArticleRepository
    {
        public Task Insert(Article article);
        public Task Update(Article article);
        public Task Delete(int articleId);
        public Task<Article> GetOne(int id);
        public Task<IEnumerable<Article>> Top(int numArticles);

        public Task<IEnumerable<Article>> All();

    }
}

using SpeedTest.Context.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedTest.Repository.Interfaces
{
    public interface IArticleRatingRepository
    {
        public Task Insert(ArticleRating articleRating);
        public Task Update(ArticleRating articleRating);
        public Task Delete(int articleRatingId);
        public Task<ArticleRating> GetOne(int id);
        public Task<IEnumerable<ArticleRating>> Last(int numRatings);
        public Task<IEnumerable<ArticleRating>> All();

    }
}

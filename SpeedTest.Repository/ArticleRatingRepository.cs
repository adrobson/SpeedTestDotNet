using Microsoft.EntityFrameworkCore;
using SpeedTest.Context.Models;
using SpeedTest.Repository.Interfaces;

namespace SpeedTest.Repository
{
    public class ArticleRatingRepository : IArticleRatingRepository
    {
        public async Task Insert(ArticleRating articleRating)
        {
            using (var context = new SpeedTestContext())
            {
                context.ArticleRatings.Add(articleRating);
                await context.SaveChangesAsync();
            }
        }

        public async Task Update(ArticleRating articleRating)
        {
            using (var context = new SpeedTestContext())
            {
                context.Entry(articleRating).State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
        }

        public async Task Delete(int articleRatingId)
        {
            using (var context = new SpeedTestContext())
            {
                var articleRating = await context.ArticleRatings.FindAsync(articleRatingId);
                if(articleRating != null)
                {
                    context.ArticleRatings.Remove(articleRating);
                    await context.SaveChangesAsync();
                }
            }
        }

        public async Task<ArticleRating> GetOne(int id)
        {
            using (var context = new SpeedTestContext())
            {
                return await context.ArticleRatings.FindAsync(id);
            }
        }

        public async Task<IEnumerable<ArticleRating>> Last(int numRatings)
        {
            using (var context = new SpeedTestContext())
            {
                return await context.ArticleRatings
                    .OrderByDescending(x => x.RatingDate)
                    .Take(numRatings)
                    .ToListAsync();
            }
        }

        public async Task<IEnumerable<ArticleRating>> All()
        {
            using (var context = new SpeedTestContext())
            {
                return await context.ArticleRatings.ToListAsync();
            }
        }


        //Test only methods
        public async Task UpdateLast()
        {
            using (var context = new SpeedTestContext())
            {
                ArticleRating articleRating = context.ArticleRatings.OrderByDescending(x => x.ArticleRatingId).Take(1).First();
                articleRating.RatingDate = DateTime.Now;
                context.Entry(articleRating).State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteLast()
        {
            using (var context = new SpeedTestContext())
            {
                var articleRating = context.ArticleRatings.OrderByDescending(x => x.ArticleRatingId).Take(1).First();
                if (articleRating != null)
                {
                    context.ArticleRatings.Remove(articleRating);
                    await context.SaveChangesAsync();
                }
            }
        }


    }
}

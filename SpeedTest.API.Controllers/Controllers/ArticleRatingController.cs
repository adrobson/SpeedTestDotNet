using Microsoft.AspNetCore.Mvc;
using SpeedTest.API.Controllers.DTOs;
using SpeedTest.Context.Models;
using SpeedTest.Repository.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SpeedTest.API.Controllers.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArticleRatingController : ControllerBase
    {
        private readonly ILogger<ArticleRatingController> _logger;
        private readonly IArticleRatingRepository _articleRatingRepository;

        public ArticleRatingController(ILogger<ArticleRatingController> logger,
            IArticleRatingRepository articleRatingRepository
            )
        {
            _logger = logger;
            _articleRatingRepository = articleRatingRepository;
        }

        [HttpPost]
        public async Task<ActionResult<ArticleRating>> AddArticleRating(ArticleRatingDTO newArticleRatingDTO)
        {
            var newArticleRating = new ArticleRating
            {
                ArticleId = newArticleRatingDTO.ArticleId,
                SiteUserId = newArticleRatingDTO.SiteUserId,
                Rating = newArticleRatingDTO.Rating,
                RatingDate = newArticleRatingDTO.RatingDate
            };

            await _articleRatingRepository.Insert(newArticleRating);

            return CreatedAtAction(nameof(GetArticleRating),
                new { id = newArticleRating.ArticleRatingId },
                ItemToDTO(newArticleRating));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ArticleRatingDTO>> UpdateArticleRating(int id, ArticleRatingDTO articleRatingDTO)
        {
            if (id != articleRatingDTO.ArticleRatingId)
            {
                return BadRequest();
            }

            var ArticleRating = await _articleRatingRepository.GetOne(id);
            ArticleRating.ArticleId = articleRatingDTO.ArticleId;
            ArticleRating.SiteUserId = articleRatingDTO.SiteUserId;
            ArticleRating.Rating = articleRatingDTO.Rating;
            ArticleRating.RatingDate = articleRatingDTO.RatingDate;

            await _articleRatingRepository.Update(ArticleRating);

            return ItemToDTO(ArticleRating);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteArticleRating(int id)
        {
            await _articleRatingRepository.Delete(id);

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ArticleRating>> GetArticleRating(int id)
        {
            var ArticleRating = await _articleRatingRepository.GetOne(id);
            if(ArticleRating == null)
            {
                return NotFound();
            }

            return await _articleRatingRepository.GetOne(id);
        }

        [HttpGet("[action]/{numRatings}")]
        public async Task<IEnumerable<ArticleRating>> Last(int numRatings)
        {
            return await _articleRatingRepository.Last(numRatings);
        }

        [HttpGet]
        public async Task<IEnumerable<ArticleRating>> Get()
        {
            return await _articleRatingRepository.All();
        }

        [HttpPut("[action]")]
        public async Task UpdateLast()
        {
            await _articleRatingRepository.UpdateLast();
        }

        [HttpDelete("[action]")]
        public async Task DeleteLast()
        {
            await _articleRatingRepository.DeleteLast();
        }

        private static ArticleRatingDTO ItemToDTO(ArticleRating ArticleRating) =>
            new ArticleRatingDTO
            {
                ArticleRatingId = ArticleRating.ArticleRatingId,
                ArticleId = ArticleRating.ArticleId,
                SiteUserId = ArticleRating.SiteUserId,
                Rating = ArticleRating.Rating,
                RatingDate = ArticleRating.RatingDate
            };
    }
}

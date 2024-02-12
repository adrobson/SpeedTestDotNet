using FastEndpoints;
using SpeedTest.API.FastEndpoints.DTOs.Authors;
using SpeedTest.Repository.Interfaces;
using SpeedTest.Repository.ViewModels;

namespace SpeedTest.API.FastEndpoints.Endpoints.Authors
{

    public class GetTopAuthors : Endpoint<NumAuthorsRequestDTO, IEnumerable<AuthorRating>>
    {
        public IAuthorRepository _authorRepository { get; set; }

        public override void Configure()
        {
            Get("/author/top/{numAuthors}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(NumAuthorsRequestDTO numAuthors, CancellationToken ct)
        {
            var topAuthors = _authorRepository.Top(numAuthors.NumAuthors);

            await SendAsync(topAuthors);
        }
    }
}

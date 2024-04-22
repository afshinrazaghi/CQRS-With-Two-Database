using MediatR;
using Sample.DAL.Read;
using Sample.DAL.ReadRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Core.MovieApplication.Queries.GetMovieByName
{
    public class GetMovieByNameQueryHandler : IRequestHandler<GetMovieByNameQuery, Movie>
    {
        private readonly ReadMovieRepository _readMovieRepository;

        public GetMovieByNameQueryHandler(ReadMovieRepository readMovieRepository)
        {
            _readMovieRepository = readMovieRepository;
        }

        public Task<Movie> Handle(GetMovieByNameQuery request, CancellationToken cancellationToken)
        {
            return _readMovieRepository.GetByNameAsync(request.MovieName, cancellationToken);
        }
    }
}

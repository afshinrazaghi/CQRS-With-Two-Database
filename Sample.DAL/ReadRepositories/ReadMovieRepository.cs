using MongoDB.Driver;
using Sample.DAL.Read;
using Sample.DAL.ReadRepositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.DAL.ReadRepositories
{
    public class ReadMovieRepository : BaseReadRepository<Movie>
    {
        public ReadMovieRepository(IMongoDatabase db) : base(db)
        {
        }

        public Task<Movie> GetByMovieIdAsync(int movieId, CancellationToken cancellationToken = default)
        {
            return base.FirstOrDefaultAsync(movie => movie.MovieId == movieId, cancellationToken);
        }

        public Task<Movie> GetByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            return base.FirstOrDefaultAsync(movie => movie.Name == name, cancellationToken);
        }

        public Task DeleteByMovieIdAsync(int movieId, CancellationToken cancellationToken = default)
        {
            return base.DeleteAsync(m => m.MovieId == movieId, cancellationToken);
        }
    }
}

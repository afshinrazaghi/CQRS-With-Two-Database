using Microsoft.EntityFrameworkCore;
using Sample.DAL.Context;
using Sample.DAL.Write;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable
namespace Sample.DAL.WriteRepositories
{
    public class WriteMovieRepository
    {
        private readonly ApplicationDbContext _db;

        public WriteMovieRepository(ApplicationDbContext db)
        {
            _db = db;
        }


        public async Task AddMovieAsync(Movie movie, CancellationToken cancellationToken = default)
        {
            await _db.Movies.AddAsync(movie, cancellationToken);
        }

        public async Task<Movie> GetMovieByIdAsync(int movieId, CancellationToken cancellationToken = default)
        {
            return await _db.Movies.Include(c => c.Director).FirstOrDefaultAsync(c => c.Id == movieId, cancellationToken);
        }

        public void DeleteMovie(Movie movie)
        {
            _db.Movies.Remove(movie);
        }
    }
}

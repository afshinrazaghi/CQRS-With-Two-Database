using Sample.DAL.Context;
using Sample.DAL.Write;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Sample.DAL.WriteRepositories
{
    public class DirectorRepository
    {
        private readonly ApplicationDbContext _db;

        public DirectorRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Director> GetDirectorAsync(string name, CancellationToken cancellationToken = default)
        {
            return await _db.Directors.FirstOrDefaultAsync(d => d.FullName == name, cancellationToken: cancellationToken);
        }

        public async Task AddDirectorAsync(Director director, CancellationToken cancellationToken = default)
        {
            await _db.Directors.AddAsync(director, cancellationToken);
        }
    }
}

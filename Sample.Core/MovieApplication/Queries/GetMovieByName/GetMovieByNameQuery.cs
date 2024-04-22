using MediatR;
using Sample.DAL.Read;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Core.MovieApplication.Queries.GetMovieByName
{
    public class GetMovieByNameQuery:IRequest<Movie>
    {
        public string MovieName { get; set; }
    }
}

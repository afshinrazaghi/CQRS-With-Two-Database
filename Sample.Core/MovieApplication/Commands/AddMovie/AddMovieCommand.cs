using MediatR;
using Sample.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Core.MovieApplication.Commands.AddMovie
{
    public class AddMovieCommand : IRequest<AddMovieCommandResult>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime PublishYear { get; set; }

        [Required]
        public decimal ImdbRate { get; set; }

        [Required]
        public decimal BoxOffice { get; set; }

        [Required]
        public string Director { get; set; }
    }
}

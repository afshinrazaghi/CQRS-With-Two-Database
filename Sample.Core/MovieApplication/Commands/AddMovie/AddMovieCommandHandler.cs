﻿using MediatR;
using Sample.Core.Common.BaseChannel;
using Sample.Core.Models;
using Sample.Core.MovieApplication.BackgroundWorker.Common.Events;
using Sample.DAL.Context;
using Sample.DAL.Write;
using Sample.DAL.WriteRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Core.MovieApplication.Commands.AddMovie
{
    public class AddMovieCommandHandler : IRequestHandler<AddMovieCommand, AddMovieCommandResult>
    {
        private readonly WriteMovieRepository _movieRepository;
        private readonly DirectorRepository _directorRepository;
        private readonly ApplicationDbContext _db;
        private readonly ChannelQueue<MovieAdded> _channel;

        public AddMovieCommandHandler(WriteMovieRepository movieRepository, ApplicationDbContext db, ChannelQueue<MovieAdded> channel, DirectorRepository directorRepository)
        {
            _movieRepository = movieRepository;
            _db = db;
            _channel = channel;
            _directorRepository = directorRepository;
        }

        public async Task<AddMovieCommandResult> Handle(AddMovieCommand request, CancellationToken cancellationToken)
        {
            var director = await _directorRepository.GetDirectorAsync(request.Director, cancellationToken);

            if (director is null)
            {
                director = new Director { FullName = request.Director };
                await _directorRepository.AddDirectorAsync(director, cancellationToken);
            }

            var movie = new Movie
            {
                PublishYear = request.PublishYear,
                BoxOffice = request.BoxOffice,
                ImdbRate = request.ImdbRate,
                Name = request.Name,
                Director = director
            };

            await _movieRepository.AddMovieAsync(movie, cancellationToken);

            await _db.SaveChangesAsync(cancellationToken);

            await _channel.AddToChannelAsync(new MovieAdded { MovieId = movie.Id }, cancellationToken);

            return new AddMovieCommandResult { MovieId = movie.Id };


        }
    }
}

﻿using Template.Application.Features.Movie.Command;
using Template.Application.Features.Movie.Virtual_Models;
using Template.Domain.Entitys;

namespace Template.Application.Features.Movie.Usecase
{
    public interface IMovieUsecases
    {
        Task<List<MovieModel>> GetAllMovies();
        Task<string> AddMovie(AddMoveCommand addmoviecmd);
    }
}

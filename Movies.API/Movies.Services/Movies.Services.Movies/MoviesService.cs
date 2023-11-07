using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Movies.Database;
using Movies.Shared;
using Movies.Shared.Request;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Services.Movies
{
    public class MoviesService : IMoviesService
    {
        private readonly ILogger<MoviesService> _log;
        private readonly DataContext _dataContext;

        public MoviesService(ILogger<MoviesService> log, IDbContextFactory<DataContext> dataContextFactory)
        {
            _log = log;
            _dataContext = dataContextFactory.CreateDbContext();
        }

        public ApiResponse<IEnumerable<Movie>> GetMovies()
        {

            return new ApiResponse<IEnumerable<Movie>>
            {
                Data = _dataContext.Movies,
                Success = true,
                Message = $"{_dataContext.Movies.Count()} movies were found"
            };
        }

        public ApiResponse<Movie> GetMovieById(int id)
        {
            Movie? movie = _dataContext.Movies.FirstOrDefault(x => x.Id == id);

            if (movie is null)
            {
                return new ApiResponse<Movie>
                {
                    Data = null,
                    Success = false,
                    Message = $"Movie with id {id} was not found"
                };
            }
            else
            {
                return new ApiResponse<Movie>
                {
                    Data = movie,
                    Success = false,
                    Message = $"Movie with id {id} was not found"
                };
            }
        }

        public ApiResponse AddMovie(MoviePostPutRequest request)
        {
            _dataContext.Movies.Add(new Movie
            {
                Title = request.Title,
                Director = request.Director,
                Year = request.Year,
            });
            _dataContext.SaveChanges();

            return new ApiResponse
            {
                Success = true,
                Message = $"Movie was added"
            };
        }

        public ApiResponse DeleteMovie(int id)
        {
            Movie movie = _dataContext.Movies.FirstOrDefault(x => x.Id == id);

            string message = $"Movie with id {id} does not exist";
            if (movie is not null)
            {
                _dataContext.Movies.Remove(movie);

                _dataContext.SaveChanges();

                message = $"Movie with id {id} was deleted";
            }

            return new ApiResponse
            {
                Success = movie is not null,
                Message = message
            };
        }

        public ApiResponse UpdateMovie(int id, MoviePostPutRequest data)
        {
            Movie? movie = _dataContext.Movies.FirstOrDefault(x => x.Id == id);

            string message = $"Movie with id {id} does not exist";
            if (movie is not null)
            {
                movie.Title = data.Title;
                movie.Director = data.Director;
                movie.Year = data.Year;

                _dataContext.SaveChanges();

                message = $"Movie with id {id} was modified";
            }

            return new ApiResponse
            {
                Success = movie is not null,
                Message = message
            };
        }
    }
}

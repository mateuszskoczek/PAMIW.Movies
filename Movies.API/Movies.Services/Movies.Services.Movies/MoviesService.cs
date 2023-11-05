using Microsoft.Extensions.Logging;
using Movies.Shared;
using Movies.Shared.Request;
using System;
using System.Collections.Generic;
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

        private List<Movie> _movies;

        public MoviesService(ILogger<MoviesService> log)
        {
            _log = log;

            _movies = new List<Movie>
            {
                new Movie
                {
                    Id = 1,
                    Title = "Inception",
                    Director = "Christopher Nolan",
                    Year = 2010
                },
                new Movie
                {
                    Id = 2,
                    Title = "Interstellar",
                    Director = "Christopher Nolan",
                    Year = 2014
                },
                new Movie
                {
                    Id = 3,
                    Title = "Fight Club",
                    Director = "David Fincher",
                    Year = 1999
                },
                new Movie
                {
                    Id = 4,
                    Title = "Full Metal Jacket",
                    Director = "Stanley Kubrick",
                    Year = 1987
                },
                new Movie
                {
                    Id = 5,
                    Title = "No Country for Old Men",
                    Director = "Joel Coen, Ethan Coen",
                    Year = 2007
                },
                new Movie
                {
                    Id = 6,
                    Title = "Once Upon a Time ... in Hollywood",
                    Director = "Quentin Tarantino",
                    Year = 2019
                },
                new Movie
                {
                    Id = 7,
                    Title = "Shutter Island",
                    Director = "Martin Scorsese",
                    Year = 2010
                },
                new Movie
                {
                    Id = 8,
                    Title = "The Shawshank Redemption",
                    Director = "Frank Darabont",
                    Year = 1994
                },
            };
        }

        public ApiResponse<IEnumerable<Movie>> GetMovies()
        {
            return new ApiResponse<IEnumerable<Movie>>
            {
                Data = _movies,
                Success = true,
                Message = $"{_movies.Count} movies were found"
            };
        }

        public ApiResponse<Movie> GetMovieById(int id)
        {
            Movie? movie = _movies.FirstOrDefault(x => x.Id == id);

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
            int id = _movies.Select(x => x.Id).Max() + 1;
            _movies.Add(new Movie
            {
                Id = id,
                Title = request.Title,
                Director = request.Director,
                Year = request.Year,
            });

            return new ApiResponse
            {
                Success = true,
                Message = $"Movie was added with id {id}"
            };
        }

        public ApiResponse DeleteMovie(int id)
        {
            int count = _movies.RemoveAll(x => x.Id == id);

            string message = $"Movie with id {id} does not exist";
            if (count > 0)
            {
                message = $"Movie with id {id} was deleted";
            }

            return new ApiResponse
            {
                Success = count > 0,
                Message = message
            };
        }

        public ApiResponse UpdateMovie(int id, MoviePostPutRequest data)
        {
            Movie? movie = _movies.FirstOrDefault(x => x.Id == id);

            string message = $"Movie with id {id} does not exist";
            if (movie is not null)
            {
                movie.Title = data.Title;
                movie.Director = data.Director;
                movie.Year = data.Year;

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

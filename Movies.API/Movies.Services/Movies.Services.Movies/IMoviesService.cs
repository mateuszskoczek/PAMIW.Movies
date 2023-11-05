using Movies.Shared;
using Movies.Shared.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Services.Movies
{
    public interface IMoviesService
    {
        ApiResponse<IEnumerable<Movie>> GetMovies();
        ApiResponse<Movie> GetMovieById(int id);
        ApiResponse AddMovie(MoviePostPutRequest request);
        ApiResponse DeleteMovie(int id);
        ApiResponse UpdateMovie(int id, MoviePostPutRequest data);
    }
}

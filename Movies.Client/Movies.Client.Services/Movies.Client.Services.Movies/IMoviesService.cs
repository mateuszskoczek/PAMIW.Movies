using Movies.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Client.Services.Movies
{
    public interface IMoviesService
    {
        Task<ApiResponse<IEnumerable<Movie>>> GetMovies();
    }
}

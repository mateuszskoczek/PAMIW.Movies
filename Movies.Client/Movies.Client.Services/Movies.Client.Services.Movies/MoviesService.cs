using Movies.Shared;
using Movies.Shared.Request;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Client.Services.Movies
{
    public class MoviesService : IMoviesService
    {
        #region FIELDS

        private MoviesConfiguration _configuration;

        #endregion



        #region CONSTRUCTORS

        public MoviesService(MoviesConfiguration configuration)
        {
            _configuration = configuration;
        }

        #endregion



        #region PUBLIC METHODS

        public async Task<ApiResponse<IEnumerable<Movie>>> GetMovies()
        {
            string request = string.Format(_configuration.GetAllEndpoint, _configuration.BaseUrl);

            return await RequestGet<ApiResponse<IEnumerable<Movie>>>(request);
        }

        #endregion



        #region PRIVATE METHODS

        private static async Task<T> RequestGet<T>(string request)
        {
            using (HttpClient client = new HttpClient())
            {
                string response = await client.GetStringAsync(request);

                return JsonConvert.DeserializeObject<T>(response);
            }
        }

        #endregion
    }
}

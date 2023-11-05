using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Client.Services.Movies
{
    public class MoviesConfiguration
    {
        #region PROPERTIES

        public string BaseUrl { get; private set; }
        public string GetAllEndpoint { get; private set; }
        public string GetByIdEndpoint { get; private set; }
        public string DeleteEndpoint { get; private set; }
        public string UpdateEndpoint { get; private set; }
        public string AddEndpoint { get; private set; }

        #endregion



        #region CONSTRUCTORS

        public MoviesConfiguration(IConfiguration configuration)
        {
            BaseUrl = configuration["api_base_url"];
            GetAllEndpoint = configuration["api_get_all_movies_endpoint"];
            GetByIdEndpoint = configuration["api_get_movie_by_id_endpoint"];
            DeleteEndpoint = configuration["api_delete_movie_endpoint"];
            UpdateEndpoint = configuration["api_update_movie_endpoint"];
            AddEndpoint = configuration["api_add_movie_endpoint"];
        }

        #endregion
    }
}

using CommunityToolkit.Mvvm.ComponentModel;
using Movies.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Client.Windows.ViewModels.Models
{
    public class MovieVM : ObservableObject
    {
        #region FIELDS

        private Movie _movie;

        #endregion



        #region PROPERTIES

        public string Title
        { 
            get => _movie.Title;
            set => SetProperty(_movie.Title, value, _movie, (model, value) => model.Title = value);
        }

        public string Director
        {
            get => _movie.Director;
            set => SetProperty(_movie.Director, value, _movie, (model, value) => model.Director = value);
        }

        public int Year
        {
            get => _movie.Year;
            set => SetProperty(_movie.Year, value, _movie, (model, value) => model.Year = value);
        }

        #endregion



        #region CONSTRUCTORS

        public MovieVM(Movie movie)
        {
            _movie = movie;
        }

        #endregion
    }
}

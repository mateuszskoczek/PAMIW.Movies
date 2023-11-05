using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Movies.Client.Services.Movies;
using Movies.Client.Windows.ViewModels.Models;
using Movies.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Movies.Client.Windows.ViewModels.Views
{
    public partial class MainWindowVM : ObservableObject
    {
        #region FIELDS

        private IMoviesService _moviesService;

        private List<MovieVM> _allMovies;

        [ObservableProperty]
        private bool _limit;

        #endregion



        #region PROPERTIES

        public ObservableCollection<MovieVM> Movies { get; set; }

        #endregion



        #region CONSTRUCTORS

        public MainWindowVM(IMoviesService moviesService) 
        {
            _moviesService = moviesService;

            _allMovies = new List<MovieVM>();

            Movies = new ObservableCollection<MovieVM>();
        }

        #endregion



        #region PUBLIC METHODS

        [RelayCommand]
        public async Task GetData()
        {
            ApiResponse<IEnumerable<Movie>> movies = await _moviesService.GetMovies();

            if (movies.Success)
            {
                Limit = false;
                _allMovies.Clear();
                Movies.Clear();
                foreach (Movie movie in movies.Data) 
                {
                    _allMovies.Add(new MovieVM(movie));
                }

                LoadMore();
            }
            else
            {
                MessageBox.Show(movies.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        [RelayCommand]
        public void LoadMore()
        {
            List<MovieVM> toRemove = new List<MovieVM>();
            for (int i = 0; i < 5 && i < _allMovies.Count; i++)
            {
                Movies.Add(_allMovies[i]);
                toRemove.Add(_allMovies[i]);
            }
            foreach (MovieVM movie in toRemove)
            {
                _allMovies.Remove(movie);
            }
            if (!_allMovies.Any())
            {
                Limit = true;
            }
        }

        #endregion
    }
}

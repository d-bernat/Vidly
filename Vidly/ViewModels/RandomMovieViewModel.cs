using System.Collections.Generic;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class RandomMovieViewModel
    {
        public RandomMovieViewModel()
        {
            Movies = new List<Movie>
            {
                new Movie() {Id = 1, Name = "R.E.D"},
                new Movie() {Id = 2, Name = "The edge of tomorrow"}
            };

            Customers = new List<Customer>
            {
                new Customer() {Id = 1, Name = "Basula Dorow"},
                new Customer() {Id = 2, Name = "Samko Bernat"},
            };
        }

        public List<Movie> Movies { get; set; }
        public List<Customer> Customers { get; set; }
    }
}
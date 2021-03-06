﻿using System;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context = ApplicationDbContext.Create();

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movies
        public ActionResult Index()
        {
            var movies = new MovieViewModel { Movies = _context.Movies.Include(m => m.Genre).ToList() };
            return View(movies);
        }

        public ActionResult Details(int id)
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();
            var movie = movies.FirstOrDefault(c => c.Id == id);
            if (movie != null)
            {
                return View(movie);
            }

            return HttpNotFound();
        }

        public ActionResult New()
        {
            var viewModel = new MovieFormViewModel() { Genres = _context.Genres };

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie) { Genres = _context.Genres.ToList() };
                return View("MovieForm", viewModel);
            }

            if (movie.Id == 0)
            {
                movie.Added = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieEntity = _context.Movies.SingleOrDefault(m => m.Id == movie.Id);
                if (movieEntity != null)
                {
                    movieEntity.Name = movie.Name;
                    movieEntity.ReleaseDate = movie.ReleaseDate;
                    movieEntity.Added = movie.Added;
                    movieEntity.GenreId = movie.GenreId;
                    movieEntity.NumberInStock = movie.NumberInStock;
                }
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            var viewModel = new MovieFormViewModel(movie)
            {
                
                Genres = _context.Genres
            };
            return View("MovieForm", viewModel);
        }
    }
}
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication462.Models;
using WebApplication462.Utils;

namespace WebApplication462Tests
{
    [TestClass]
    public class MovieHelperGerReviewTest
    {
        [TestMethod]
        public void GetMovieSatisfactionBasedOnRating()
        {
            //Arrange
            var rating = 79;
            var movie = new Movie
            {
                Id = 1,
                Rating = rating,
                Title = "Shrek",
                Year = 1972,
            };

            //Act
            var review = movie.GetMovieReview();

            //Assert
            Assert.AreEqual(MovieReviewEnum.Good, review);
        }

        [TestMethod]
        [DynamicData(nameof(GoodMovieRatings))]
        public void GetMovieSatisfactionForGoodMovies(int rating)
        {
            //Arrange
            var movie = new Movie
            {
                Id = 1,
                Rating = rating,
                Title = "Shrek",
                Year = 1972,
            };

            //Act
            var satisfaction = movie.GetMovieReview();

            //Assert
            Assert.AreEqual(MovieReviewEnum.Good, satisfaction);
        }

        public static IEnumerable<object[]> GoodMovieRatings
        {
            get
            {
                return new[]
                {
                    new object[] { 61 },
                    new object[] { 63 },
                    new object[] { 67 },
                    new object[] { 72 },
                    new object[] { 76 },
                    new object[] { 77 },
                    new object[] { 80 },
                };
            }
        }
    }
}

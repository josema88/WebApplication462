using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication462.Models;

namespace WebApplication462Tests
{
    [TestClass]
    public class CreateMovieEntityTest
    {
        [TestMethod]
        public void CreateMovieObject()
        {
            var movie = new Movie
            {
                Id = 1,
                Rating = 89,
                Title = "Shrek",
                Year = 2003,
            };

            Assert.AreEqual(1, movie.Id);
            Assert.AreEqual(89, movie.Rating);
            Assert.IsTrue(movie.Title.Equals("Shrek"));
        }
    }
}

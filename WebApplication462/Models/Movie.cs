using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication462.Utils;

namespace WebApplication462.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public int Rating { get; set; }
        public MovieReviewEnum Review { get; set; }
    }
}
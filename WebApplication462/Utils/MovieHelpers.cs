using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication462.Models;

namespace WebApplication462.Utils
{
    public static class MovieHelpers
    {
        public static MovieReviewEnum GetMovieReview(this Movie movie)
        {
            switch (movie.Rating)
            {
                case int n when (n < 0):
                    return MovieReviewEnum.NA;
                case int n when (n <= 20 && n >= 0):
                    return MovieReviewEnum.Terrible;
                case int n when (n <= 40 && n >= 21):
                    return MovieReviewEnum.Bad;
                case int n when (n <= 60 && n >= 41):
                    return MovieReviewEnum.Normal;
                case int n when (n <= 80 && n >= 61):
                    return MovieReviewEnum.Good;
                case int n when (n <= 100 && n >= 81):
                    return MovieReviewEnum.Excellent;
                default:
                    break;
            }

            return MovieReviewEnum.NA;
        }
    }
}